using DocumentFormat.OpenXml.Packaging;
using Futurez.Xrm.Tools;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Futurez.Entities
{
    public class FileUpload
    {
        public FileUpload(string fileNameAndPath, IOrganizationService service)
        {
            // assume this is a good file
            IsIgnored = false;
            FullLocalPath = fileNameAndPath;
            FileName = Path.GetFileName(fileNameAndPath);
            FileContents = File.ReadAllBytes(fileNameAndPath);

            // evaluate the extension, see if we can set the template type
            var ext = Path.GetExtension(fileNameAndPath);
            switch (ext)
            {
                case Constants.FILE_EXT_WORD:
                    TemplateType = Constants.TEMPL_TYPE_WORD;
                    TemplateTypeValue = Constants.TEMPL_TYPE_VAL_WORD;

                    // load the file and grab the Entity Type Code from the file
                    GetETNAndOTCFromDocument();

                    // if we don't have any ETC in the file, then we can't upload it
                    if (EntityTypeName == null)
                    {
                        IsIgnored = true;
                        Note = "Unable to find Entity Type Name within the file contents. This does not appear to be a valid Word Template.";
                    }
                    else
                    {
                        // get the OTC from the document and the target system
                        TargetOTC = GetTypeCode(EntityTypeName, service, out string errorMessage);
                        if (TargetOTC == -1)
                        {
                            IsIgnored = true;
                            Note = errorMessage;
                        }
                        else
                        {
                            UpdateOTCCodes();
                        }
                    }
                    break;

                case Constants.FILE_EXT_EXCEL:
                    TemplateType = Constants.TEMPL_TYPE_EXCEL;
                    TemplateTypeValue = Constants.TEMPL_TYPE_VAL_EXCEL;
                    break;

                default:
                    // no idea here, ignore it
                    IsIgnored = true;
                    Note = "Unknown file extension";
                    break;
            }

            if (!IsIgnored)
            {
                // use filename only to set template name
                TemplateName = Path.GetFileNameWithoutExtension(fileNameAndPath);
            }
        }

        public string EntityTypeName { get; private set; }
        public byte[] FileContents { get; set; }
        public string FileName { get; private set; }
        public string FullLocalPath { get; private set; }
        public bool IsIgnored { get; set; }
        public string Note { get; set; }
        public int ObjectTypeCode { get; private set; }
        public int TargetOTC { get; private set; }
        public Guid TemplateId { get; set; }
        public string TemplateName { get; private set; }
        public string TemplateType { get; private set; }
        public int TemplateTypeValue { get; private set; }
        private static Dictionary<string, int> _objectTypeCodes { get; set; }

        /// <summary>
        /// retrieves the entity type code for the specified entity name
        /// </summary>
        /// <param name="entityName">name of the entity</param>
        /// <param name="service">target organization service</param>
        /// <returns>entity type code</returns>
        private static int GetTypeCode(string entityName, IOrganizationService service, out string errorMessage)
        {
            errorMessage = null;

            // save as static collection to avoid round trips
            if (_objectTypeCodes == null)
            {
                _objectTypeCodes = new Dictionary<string, int>();
            }

            if (!_objectTypeCodes.ContainsKey(entityName))
            {
                RetrieveEntityRequest request = new RetrieveEntityRequest();
                request.EntityFilters = Microsoft.Xrm.Sdk.Metadata.EntityFilters.Entity;
                request.LogicalName = entityName;

                // Retrieve the MetaData, OTC for the entity name
                // cheesy... catch the exception if the ETN is not found
                try
                {
                    RetrieveEntityResponse response = (RetrieveEntityResponse)service.Execute(request);
                    _objectTypeCodes.Add(entityName, response.EntityMetadata.ObjectTypeCode.Value);
                }
                catch
                {
                    errorMessage = $"Error occurred locating Entity Type {entityName} on the current instance";
                    return -1;
                }
            }
            return _objectTypeCodes[entityName];
        }

        /// <summary>
        /// From the Xml schema and other data, grab the ETN and OTC from the document
        /// </summary>
        /// <returns></returns>
        private void GetETNAndOTCFromDocument()
        {
            const string rootPath = @"urn:microsoft-crm/document-template/";

            string xmlBody = null;
            try
            {
                // open the file and read the contents
                using (var ms = new MemoryStream(this.FileContents))
                {
                    // create a word doc from stream
                    WordprocessingDocument wordDoc = WordprocessingDocument.Open(ms, true);
                    OpenXmlPart mainDocPart = wordDoc.MainDocumentPart;

                    var custParts = wordDoc
                        .MainDocumentPart
                        .Parts
                        .Where(p => p.OpenXmlPart is CustomXmlPart)
                        .Select(c => (c.OpenXmlPart as CustomXmlPart).CustomXmlPropertiesPart);

                    foreach (var part in custParts)
                    {
                        if (part.RootElement.InnerXml.Contains(rootPath))
                        {
                            xmlBody = part.RootElement.InnerXml;
                            break;
                        }
                    }
                }

                if (xmlBody != null)
                {
                    // get the ETC from the first instance we can find of the ds:uri attribute.
                    var ns = @"{http://schemas.openxmlformats.org/officeDocument/2006/customXml}";
                    using (var textStream = new StringReader(xmlBody))
                    {
                        XDocument doc = XDocument.Load(textStream);
                        XAttribute attrib = doc
                            .Descendants($"{ns}schemaRef")
                            .Attributes($"{ns}uri")
                            .Where<XAttribute>(a => a.Value.StartsWith(rootPath))
                            .FirstOrDefault();

                        var etn_otc = attrib.Value.Substring(rootPath.Length).Split('/');

                        EntityTypeName = etn_otc[0];
                        ObjectTypeCode = int.Parse(etn_otc[1]);
                    }
                }
            }
            catch (NullReferenceException)
            {
                IsIgnored = true;
                Note = "This does not appear to be a valid Word Document Template";
            }
        }

        /// <summary>
        /// swaps out bad entity type codes for good ones in the given Word Doc part
        /// </summary>
        /// <param name="part">the Open Xml Part needing to be changed</param>
        /// <param name="sourceOTC">source type code needing to be changed</param>
        /// <param name="targetOTC">destination type code</param>
        private void UpdateDocumentPart(OpenXmlPart part, string sourceETC, int sourceOTC, int targetOTC)
        {
            string docText;
            using (StreamReader sr = new StreamReader(part.GetStream()))
            {
                docText = sr.ReadToEnd();
            }

            docText = docText.Replace($"{sourceETC}/{sourceOTC}/", $"{sourceETC}/{targetOTC}/");

            using (StreamWriter sw = new StreamWriter(part.GetStream()))
            {
                sw.Write(docText);
                sw.Flush();
            }
        }

        /// <summary>
        /// changes all bad entity type codes OpenXmlParts in pair to good code
        /// </summary>
        /// <param name="pair">container of desired parts</param>
        /// <param name="sourceOTC">source type code needing to be changed</param>
        /// <param name="goodTC">destination type code</param>
        private void UpdateDocumentParts(IEnumerable<OpenXmlPart> pair, string sourceETC, int sourceOTC, int targetOTC)
        {
            foreach (OpenXmlPart part in pair)
            {
                UpdateDocumentPart(part, sourceETC, sourceOTC, targetOTC);
            }
        }

        /// <summary>
        /// Update the OTC codes for the current entity type name
        /// </summary>
        /// <param name="documentContent"></param>
        /// <param name="sourceETN"></param>
        /// <param name="sourceOTC"></param>
        /// <param name="targetOTC"></param>
        /// <returns></returns>
        private void UpdateOTCCodes()
        {
            using (var ms = new MemoryStream(this.FileContents))
            {
                // create a word doc from stream
                WordprocessingDocument wordDoc = WordprocessingDocument.Open(ms, true);

                // instantiate the parts of the word doc
                OpenXmlPart mainDocPart = wordDoc.MainDocumentPart;
                IEnumerable<OpenXmlPart> docHeaderParts = mainDocPart.Parts.Where(p => p.OpenXmlPart is HeaderPart).Select(p => p.OpenXmlPart);
                IEnumerable<OpenXmlPart> docFooterParts = mainDocPart.Parts.Where(p => p.OpenXmlPart is FooterPart).Select(p => p.OpenXmlPart);
                IEnumerable<OpenXmlPart> customParts = mainDocPart.Parts.Where(p => p.OpenXmlPart is CustomXmlPart).Select(p => p.OpenXmlPart);

                IEnumerable<OpenXmlPart> customPropParts =
                    from parent in customParts
                    from child in parent.Parts
                    where child.OpenXmlPart is CustomXmlPropertiesPart
                    select child.OpenXmlPart;

                // change type codes in each part
                UpdateDocumentPart(mainDocPart, EntityTypeName, ObjectTypeCode, TargetOTC);

                UpdateDocumentParts(docHeaderParts, EntityTypeName, ObjectTypeCode, TargetOTC);
                UpdateDocumentParts(docFooterParts, EntityTypeName, ObjectTypeCode, TargetOTC);
                UpdateDocumentParts(customParts, EntityTypeName, ObjectTypeCode, TargetOTC);
                UpdateDocumentParts(customPropParts, EntityTypeName, ObjectTypeCode, TargetOTC);

                // get wordDoc back into format required for CRM
                wordDoc.Close();

                this.FileContents = ms.ToArray();
            };
        }
    }
}