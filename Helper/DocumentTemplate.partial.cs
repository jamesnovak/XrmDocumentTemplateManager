using DocumentFormat.OpenXml.Packaging;
using Futurez.Xrm.Tools;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml;

namespace Futurez.Entities
{
    [DefaultProperty("Name")]
    public partial class DocumentTemplateEdit
    {
        public DocumentTemplateEdit(Entity template)
        {
            Id = template.Id;
            Name = template.GetAttribValue<string>("name");
            Description = template.GetAttribValue<string>("description");
            Type = template.GetFormattedAttribValue("documenttype");
            TypeValue = template.GetAttribValue<OptionSetValue>("documenttype").Value;
            AssociatedEntity = template.GetFormattedAttribValue("associatedentitytypecode");
            AssociatedEntityLogicalName = template.GetAttribValue<string>("associatedentitytypecode");

            Status = template.GetFormattedAttribValue("status");

            var entityRef = template.GetAttribValue<EntityReference>("createdby");
            CreatedBy = (entityRef != null) ? entityRef.Name : null;

            var dt = template.GetAttribValue<DateTime?>("createdon");
            if (dt.HasValue)
            {
                CreatedOn = dt.Value.ToLocalTime();
            }

            entityRef = template.GetAttribValue<EntityReference>("modifiedby");
            ModifiedBy = (entityRef != null) ? entityRef.Name : null;

            dt = template.GetAttribValue<DateTime?>("modifiedon");
            if (dt.HasValue)
            {
                ModifiedOn = dt.Value.ToLocalTime();
            }

            EntityLogicalName = template.LogicalName;
            TemplateScope = (template.LogicalName == "documenttemplate") ? "System" : "Personal";

            var content = template.GetAttribValue<string>("content");
            Content = (content == null) ? null : Convert.FromBase64String(content);

            var ext = TypeValue == 1 ? Constants.FILE_EXT_EXCEL : Constants.FILE_EXT_WORD;

            // make sure we have unique names
            FileName = Name + ext;
        }

        #region Attributes

        [DisplayName("Associated Entity Name")]
        [Description("Name of the Entity to which this Document Template is assocaited")]
        [Category("Locked")]
        public string AssociatedEntity { get; private set; }

        [DisplayName("Associated Entity SchemaName")]
        [Description("Entity SchemaName to which this Document Template is assocaited")]
        [Category("Locked")]
        [Browsable(false)]
        public string AssociatedEntityLogicalName { get; private set; }

        [Description("Document Content")]
        [Category("General")]
        [Browsable(false)]
        [DisplayName("Document Content")]
        public byte[] Content { get; private set; }

        [DisplayName("Created By")]
        [Description("System user who created this Document Template")]
        [Category("Locked")]
        public string CreatedBy { get; private set; }

        [DisplayName("Created On")]
        [Description("Date/Time on which this Document Template was created")]
        [Category("Locked")]
        public DateTime? CreatedOn { get; private set; }

        [Description("Description for this Document Template")]
        [Category("General")]
        [EditorAttribute("System.ComponentModel.Design.MultilineStringEditor, System.Design", "System.Drawing.Design.UITypeEditor")]
        public string Description { get; private set; }

        [Description("Entity Logical Name")]
        [Category("General")]
        [Browsable(false)]
        [DisplayName("Entity Logical Name")]
        public string EntityLogicalName { get; private set; }

        [Description("Document Template Filename")]
        [Category("General")]
        public string FileName { get; private set; }

        [Description("Document Template Id")]
        [Category("General")]
        [Browsable(false)]
        public Guid Id { get; private set; }

        [Description("Language setting for this Document Template")]
        [Category("Locked")]
        [Browsable(false)]
        public string Language { get; private set; }

        [DisplayName("Modified By")]
        [Description("System user who last modified this Document Template")]
        [Category("Locked")]
        public string ModifiedBy { get; private set; }

        [DisplayName("Modified On")]
        [Description("Date/Time on which this Document Template was last modified")]
        [Category("Locked")]
        public DateTime? ModifiedOn { get; private set; }

        [Description("Document Template Name")]
        [Category("General")]
        public string Name { get; private set; }

        [Description("Current Document Template Status")]
        [Category("Locked")]
        public string Status { get; private set; }

        [Description("System or Personal document template")]
        [Category("General")]
        [DisplayName("Template Scope")]
        public string TemplateScope { get; private set; }

        [Description("Document Template Type")]
        [DisplayName("Content Type")]
        [Category("Locked")]
        public string Type { get; private set; }

        [Description("Document Template Type")]
        [DisplayName("Content Type")]
        [Category("Locked")]
        [Browsable(false)]
        public int TypeValue { get; private set; }

        #endregion Attributes

        #region Helper Methods

        /// <summary>
        /// Helper method to retrieve system document templates by Id
        /// </summary>
        /// <param name="service"></param>
        /// <param name="templateIds"></param>
        /// <param name="includeContent"></param>
        /// <returns></returns>
        public static List<DocumentTemplateEdit> GetDocumentTemplates(IOrganizationService service, List<Guid> templateIds = null, bool includeContent = false)
        {
            var templates = new List<DocumentTemplateEdit>();

            var columns = new string[] {
                "name", "documenttemplateid", "status", "associatedentitytypecode", "documenttype", "modifiedby", "modifiedon", "createdby", "createdon", "description"
            };
            var query = new QueryExpression()
            {
                EntityName = "documenttemplate",
                ColumnSet = new ColumnSet(columns),
                Criteria = new FilterExpression(LogicalOperator.And)
            };

            if (includeContent)
            {
                query.ColumnSet.AddColumn("content");
            }

            if (templateIds != null)
            {
                query.Criteria.AddCondition(new ConditionExpression("documenttemplateid", ConditionOperator.In, templateIds));
            }

            var results = service.RetrieveMultiple(query);

            foreach (var entity in results.Entities)
            {
                templates.Add(new DocumentTemplateEdit(entity));
            }
            return templates;
        }

        public List<string> GetRelationships(IOrganizationService service)
        {
            var list = new List<string>();

            if (Content == null)
                Content = Convert.FromBase64String(service.Retrieve("documenttemplate", Id, new ColumnSet("content")).GetAttributeValue<string>("content"));

            using (var stream = new MemoryStream(Content))
            {
                using (WordprocessingDocument doc = WordprocessingDocument.Open(stream, true))
                {
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
                }
            }

            return list;
        }

        public void RefreshXmlMappingContent(IOrganizationService service, BackgroundWorker worker)
        {
            if (Content == null)
            {
                worker.ReportProgress(0, "Retrieve content from server...");
                Content = Convert.FromBase64String(service.Retrieve("documenttemplate", Id, new ColumnSet("content")).GetAttributeValue<string>("content"));
            }
            using (var stream = new MemoryStream(Content))
            {
                using (WordprocessingDocument doc = WordprocessingDocument.Open(stream, true))
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

                            worker.ReportProgress(0, $"Loading table {initialEntity}...");
                            XmlNode tableElt = AddTable(rootNode, initialEntity, service);

                            foreach (XmlElement node in xd.DocumentElement.FirstChild.ChildNodes)
                            {
                                if (node.ChildNodes.Cast<XmlNode>().OfType<XmlElement>().Any())
                                {
                                    worker.ReportProgress(0, $"Loading relationship {node.Name}...");

                                    var response = (RetrieveRelationshipResponse)service.Execute(new RetrieveRelationshipRequest
                                    {
                                        Name = node.Name
                                    });

                                    var relElt = newContent.CreateElement(node.Name, newContent.DocumentElement.NamespaceURI);
                                    tableElt.AppendChild(relElt);

                                    if (response.RelationshipMetadata is OneToManyRelationshipMetadata otm)
                                    {
                                        var entity = otm.ReferencedEntity == initialEntity ? otm.ReferencingEntity : otm.ReferencedEntity;

                                        worker.ReportProgress(0, $"Loading table {entity}...");
                                        AddAttributes(relElt, entity, service);
                                    }

                                    if (response.RelationshipMetadata is ManyToManyRelationshipMetadata mtm)
                                    {
                                        var entity = mtm.Entity1LogicalName == initialEntity ? mtm.Entity2LogicalName : mtm.Entity1LogicalName;

                                        worker.ReportProgress(0, $"Loading table {entity}...");
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

                Content = stream.ToArray();

                service.Update(new Entity("documenttemplate")
                {
                    Id = Id,
                    Attributes =
                    {
                        {"content", Convert.ToBase64String(Content) }
                    }
                });
            }
        }

        public void RefreshXmlMappingContent(List<string> relationships, IOrganizationService service, BackgroundWorker worker)
        {
            if (Content == null)
            {
                worker.ReportProgress(0, "Retrieve content from server...");
                Content = Convert.FromBase64String(service.Retrieve("documenttemplate", Id, new ColumnSet("content")).GetAttributeValue<string>("content"));
            }
            using (var stream = new MemoryStream(Content))
            {
                var newMS = new MemoryStream();
                stream.CopyTo(newMS);

                using (WordprocessingDocument doc = WordprocessingDocument.Open(newMS, true))
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

                            worker.ReportProgress(0, $"Loading table {initialEntity}...");

                            XmlNode tableElt = AddTable(newContent.DocumentElement, initialEntity, service);

                            foreach (string relationship in relationships)
                            {
                                worker.ReportProgress(0, $"Loading relationship {relationship}...");

                                var response = (RetrieveRelationshipResponse)service.Execute(new RetrieveRelationshipRequest
                                {
                                    Name = relationship
                                });

                                var relElt = newContent.CreateElement(relationship, newContent.DocumentElement.NamespaceURI);
                                tableElt.AppendChild(relElt);

                                if (response.RelationshipMetadata is OneToManyRelationshipMetadata otm)
                                {
                                    var entity = otm.ReferencedEntity == initialEntity ? otm.ReferencingEntity : otm.ReferencedEntity;

                                    worker.ReportProgress(0, $"Loading table {entity}...");
                                    AddAttributes(relElt, entity, service);
                                }

                                if (response.RelationshipMetadata is ManyToManyRelationshipMetadata mtm)
                                {
                                    var entity = mtm.Entity1LogicalName == initialEntity ? mtm.Entity2LogicalName : mtm.Entity1LogicalName;

                                    worker.ReportProgress(0, $"Loading table {entity}...");
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

                Content = newMS.ToArray();

                service.Update(new Entity("documenttemplate")
                {
                    Id = Id,
                    Attributes =
                    {
                        {"content", Convert.ToBase64String(Content) }
                    }
                });
            }
        }

        private void AddAttributes(XmlNode parentNode, AttributeMetadata[] amds)
        {
            foreach (var amd in amds.OrderBy(a => a.LogicalName))
            {
                var elt = parentNode.OwnerDocument.CreateElement(amd.LogicalName, parentNode.OwnerDocument.DocumentElement.NamespaceURI);
                elt.InnerText = amd.LogicalName;
                parentNode.AppendChild(elt);
            }
        }

        private void AddAttributes(XmlNode parentNode, string entityName, IOrganizationService service)
        {
            var edmResponse = (RetrieveEntityResponse)service.Execute(new RetrieveEntityRequest
            {
                EntityFilters = EntityFilters.Attributes,
                LogicalName = entityName
            });

            AddAttributes(parentNode, edmResponse.EntityMetadata.Attributes);
        }

        private XmlNode AddTable(XmlNode parentNode, string logicalName, IOrganizationService service)
        {
            var edmResponse = (RetrieveEntityResponse)service.Execute(new RetrieveEntityRequest
            {
                EntityFilters = EntityFilters.Attributes,
                LogicalName = logicalName
            });

            var tableElt = parentNode.OwnerDocument.CreateElement(edmResponse.EntityMetadata.LogicalName, parentNode.OwnerDocument.DocumentElement.NamespaceURI);
            parentNode.AppendChild(tableElt);

            AddAttributes(tableElt, edmResponse.EntityMetadata.Attributes);

            return tableElt;
        }

        #endregion Helper Methods
    }
}