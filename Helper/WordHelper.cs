using DocumentFormat.OpenXml.Packaging;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml;

namespace Futurez.Xrm.Tools.Helper
{
    internal class WordHelper
    {
        public static List<string> GetRelationships(string filePath)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, false))
            {
                return GetRelationships(doc);
            }
        }

        public static List<string> GetRelationships(Stream stream)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Open(stream, false))
            {
                return GetRelationships(doc);
            }
        }

        public static void RefreshColumns(Stream stream, IOrganizationService service, BackgroundWorker bw)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Open(stream, true))
            {
                RefreshColumns(doc, service, bw);
            }
        }

        public static void RefreshColumns(string filePath, IOrganizationService service, BackgroundWorker bw)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, true))
            {
                RefreshColumns(doc, service, bw);
            }
        }

        public static void RefreshRelationships(string filePath, List<string> relationships, IOrganizationService service, BackgroundWorker bw)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, true))
            {
                RefreshRelationships(doc, relationships, service, bw);
            }
        }

        public static void RefreshRelationships(Stream stream, List<string> relationships, IOrganizationService service, BackgroundWorker bw)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Open(stream, true))
            {
                RefreshRelationships(doc, relationships, service, bw);
            }
        }

        public static bool TryValidateSourceTable(IOrganizationService service, string filePath, out string table, out string errorMessage)
        {
            table = "";
            using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, false))
            {
                foreach (var xmlPart in doc.MainDocumentPart.CustomXmlParts)
                {
                    using (XmlTextReader xReader = new XmlTextReader(xmlPart.GetStream(FileMode.Open, FileAccess.Read)))
                    {
                        xReader.MoveToContent();
                        if (!xReader.NamespaceURI.StartsWith("urn:microsoft-crm/document-template")) continue;

                        string entity = xReader.NamespaceURI.Split('/')[2];

                        try
                        {
                            service.Execute(new RetrieveEntityRequest
                            {
                                EntityFilters = EntityFilters.Entity,
                                LogicalName = entity
                            });
                            table = entity;
                            errorMessage = "";
                            return true;
                        }
                        catch
                        {
                            errorMessage = $"The template is not compatible with the selected environment. The table {entity} is not present in the connecte environment. Please connect to another environment before trying to update this local template";
                            return false;
                        }
                    }
                }

                errorMessage = "This document is not a Word Template";
                return false;
            }
        }

        private static void AddAttributes(XmlNode parentNode, AttributeMetadata[] amds)
        {
            foreach (var amd in amds.OrderBy(a => a.LogicalName))
            {
                var elt = parentNode.OwnerDocument.CreateElement(amd.LogicalName, parentNode.NamespaceURI);
                elt.InnerText = amd.LogicalName;
                parentNode.AppendChild(elt);
            }
        }

        private static void AddAttributes(XmlNode parentNode, string entityName, IOrganizationService service)
        {
            var edmResponse = (RetrieveEntityResponse)service.Execute(new RetrieveEntityRequest
            {
                EntityFilters = EntityFilters.Attributes,
                LogicalName = entityName
            });

            AddAttributes(parentNode, edmResponse.EntityMetadata.Attributes);
        }

        private static XmlNode AddTable(XmlNode parentNode, string logicalName, IOrganizationService service)
        {
            var edmResponse = (RetrieveEntityResponse)service.Execute(new RetrieveEntityRequest
            {
                EntityFilters = EntityFilters.Entity | EntityFilters.Attributes,
                LogicalName = logicalName
            });

            var tableElt = parentNode.OwnerDocument.CreateElement(edmResponse.EntityMetadata.LogicalName, null);
            parentNode.AppendChild(tableElt);

            AddAttributes(tableElt, edmResponse.EntityMetadata.Attributes);

            return tableElt;
        }

        private static void ControlObjectTypeCode(XmlElement rootNode, IOrganizationService service)
        {
            var ns = rootNode.Attributes["xmlns"].Value;
            var parts = ns.Split('/');
            var entityCode = parts.Skip(parts.Length - 2).Take(1).First();
            var entityName = parts.Skip(parts.Length - 3).Take(1).First();

            var emd = ((RetrieveEntityResponse)service.Execute(new RetrieveEntityRequest
            {
                EntityFilters = EntityFilters.Entity,
                LogicalName = entityName
            })).EntityMetadata;

            if (emd.ObjectTypeCode.Value != int.Parse(entityCode))
            {
                rootNode.SetAttribute("xmlns", ns.Replace(entityCode, emd.ObjectTypeCode.Value.ToString()));
            }
        }

        private static List<string> GetRelationships(WordprocessingDocument doc)
        {
            var list = new List<string>();

            foreach (var xmlPart in doc.MainDocumentPart.CustomXmlParts)
            {
                using (XmlTextReader xReader = new XmlTextReader(xmlPart.GetStream(FileMode.Open, FileAccess.Read)))
                {
                    xReader.MoveToContent();
                    if (!xReader.NamespaceURI.StartsWith("urn:microsoft-crm/document-template")) continue;

                    XmlDocument xd = new XmlDocument();
                    xd.Load(xReader);

                    foreach (XmlElement node in xd.DocumentElement.FirstChild.ChildNodes)
                    {
                        if (node.ChildNodes.Cast<XmlNode>().OfType<XmlElement>().Any())
                        {
                            list.Add(node.Name);
                        }
                    }
                }
            }

            return list;
        }

        private static void RefreshColumns(WordprocessingDocument doc, IOrganizationService service, BackgroundWorker bw)
        {
            foreach (var xmlPart in doc.MainDocumentPart.CustomXmlParts)
            {
                using (XmlTextReader xReader = new XmlTextReader(xmlPart.GetStream(FileMode.Open, FileAccess.Read)))
                {
                    xReader.MoveToContent();
                    if (!xReader.NamespaceURI.StartsWith("urn:microsoft-crm/document-template")) continue;

                    XmlDocument xd = new XmlDocument();
                    xd.Load(xReader);

                    XmlDocument newContent = new XmlDocument();
                    var rootNode = newContent.ImportNode(xd.DocumentElement, false);
                    newContent.AppendChild(rootNode);

                    var initialEntity = xd.DocumentElement.FirstChild.Name;

                    ControlObjectTypeCode((XmlElement)rootNode, service);

                    bw.ReportProgress(0, $"Loading table {initialEntity}...");
                    XmlNode tableElt = AddTable(rootNode, initialEntity, service);

                    foreach (XmlElement node in xd.DocumentElement.FirstChild.ChildNodes)
                    {
                        if (node.ChildNodes.Cast<XmlNode>().OfType<XmlElement>().Any())
                        {
                            bw.ReportProgress(0, $"Loading relationship {node.Name}...");

                            var response = (RetrieveRelationshipResponse)service.Execute(new RetrieveRelationshipRequest
                            {
                                Name = node.Name
                            });

                            var relElt = newContent.CreateElement(node.Name, tableElt.NamespaceURI);
                            tableElt.AppendChild(relElt);

                            if (response.RelationshipMetadata is OneToManyRelationshipMetadata otm)
                            {
                                var entity = otm.ReferencedEntity == initialEntity ? otm.ReferencingEntity : otm.ReferencedEntity;

                                bw.ReportProgress(0, $"Loading table {entity}...");
                                AddAttributes(relElt, entity, service);
                            }

                            if (response.RelationshipMetadata is ManyToManyRelationshipMetadata mtm)
                            {
                                var entity = mtm.Entity1LogicalName == initialEntity ? mtm.Entity2LogicalName : mtm.Entity1LogicalName;

                                bw.ReportProgress(0, $"Loading table {entity}...");
                                AddAttributes(relElt, entity, service);
                            }
                        }
                    }

                    using (var xmlMS = new MemoryStream())
                    {
                        newContent.Save(xmlMS);
                        xmlMS.Position = 0;
                        xmlPart.FeedData(xmlMS);
                    }
                }
            }

            doc.Save();
        }

        private static void RefreshRelationships(WordprocessingDocument doc, List<string> relationships, IOrganizationService service, BackgroundWorker bw)
        {
            foreach (var xmlPart in doc.MainDocumentPart.CustomXmlParts)
            {
                using (XmlTextReader xReader = new XmlTextReader(xmlPart.GetStream(FileMode.Open, FileAccess.Read)))
                {
                    xReader.MoveToContent();

                    if (!xReader.NamespaceURI.StartsWith("urn:microsoft-crm/document-template")) continue;

                    XmlDocument xd = new XmlDocument();
                    xd.Load(xReader);

                    XmlDocument newContent = new XmlDocument();
                    var rootNode = newContent.ImportNode(xd.DocumentElement, false);
                    newContent.AppendChild(rootNode);

                    var initialEntity = xd.DocumentElement.FirstChild.Name;

                    ControlObjectTypeCode((XmlElement)rootNode, service);

                    bw.ReportProgress(0, $"Loading table {initialEntity}...");

                    XmlNode tableElt = AddTable(newContent.DocumentElement, initialEntity, service);

                    foreach (string relationship in relationships)
                    {
                        bw.ReportProgress(0, $"Loading relationship {relationship}...");

                        var response = (RetrieveRelationshipResponse)service.Execute(new RetrieveRelationshipRequest
                        {
                            Name = relationship
                        });

                        var relElt = newContent.CreateElement(relationship, tableElt.NamespaceURI);
                        tableElt.AppendChild(relElt);

                        if (response.RelationshipMetadata is OneToManyRelationshipMetadata otm)
                        {
                            var entity = otm.ReferencedEntity == initialEntity ? otm.ReferencingEntity : otm.ReferencedEntity;

                            bw.ReportProgress(0, $"Loading table {entity}...");
                            AddAttributes(relElt, entity, service);
                        }

                        if (response.RelationshipMetadata is ManyToManyRelationshipMetadata mtm)
                        {
                            var entity = mtm.Entity1LogicalName == initialEntity ? mtm.Entity2LogicalName : mtm.Entity1LogicalName;

                            bw.ReportProgress(0, $"Loading table {entity}...");
                            AddAttributes(relElt, entity, service);
                        }
                    }

                    using (var xmlMS = new MemoryStream())
                    {
                        newContent.Save(xmlMS);
                        xmlMS.Position = 0;
                        xmlPart.FeedData(xmlMS);
                    }
                }
            }

            doc.Save();
        }
    }
}