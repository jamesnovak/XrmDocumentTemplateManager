using DocumentFormat.OpenXml.Packaging;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml;

namespace Futurez.Xrm.Tools.AppCode
{
    internal class WordDocumentToTemplate
    {
        private readonly IOrganizationService service;
        private readonly BackgroundWorker worker;

        public WordDocumentToTemplate(IOrganizationService service, BackgroundWorker worker)
        {
            this.service = service;
            this.worker = worker;
        }

        public void Process(EntityMetadata emd, List<string> relationships, string filePath, string destinationPath)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, true))
            {
                using (wordDoc.SaveAs(destinationPath)) { }
            }

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(destinationPath, true))
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml($"<DocumentTemplate xmlns=\"urn:microsoft-crm/document-template/{emd.LogicalName}/{emd.ObjectTypeCode.Value}/\"/>");

                var tableElt = xmlDoc.CreateElement(emd.LogicalName, "");
                xmlDoc.DocumentElement.AppendChild(tableElt);
                worker.ReportProgress(0, $"Loading table {emd.DisplayName?.UserLocalizedLabel?.Label ?? emd.SchemaName}...");
                AddAttributes(tableElt, GetMetadataForAttributes(emd.LogicalName).Attributes.ToArray());

                foreach (string relationship in relationships)
                {
                    worker.ReportProgress(0, $"Loading relationship {relationship}...");

                    var response = (RetrieveRelationshipResponse)service.Execute(new RetrieveRelationshipRequest
                    {
                        Name = relationship
                    });

                    var relElt = xmlDoc.CreateElement(relationship, tableElt.NamespaceURI);
                    tableElt.AppendChild(relElt);

                    if (response.RelationshipMetadata is OneToManyRelationshipMetadata otm)
                    {
                        var entity = otm.ReferencedEntity == emd.LogicalName ? otm.ReferencingEntity : otm.ReferencedEntity;

                        worker.ReportProgress(0, $"Loading table {entity}...");
                        AddAttributes(relElt, entity, service);
                    }

                    if (response.RelationshipMetadata is ManyToManyRelationshipMetadata mtm)
                    {
                        var entity = mtm.Entity1LogicalName == emd.LogicalName ? mtm.Entity2LogicalName : mtm.Entity1LogicalName;

                        worker.ReportProgress(0, $"Loading table {entity}...");
                        AddAttributes(relElt, entity, service);
                    }
                }

                var part = wordDoc.MainDocumentPart.AddCustomXmlPart(CustomXmlPartType.CustomXml);
                using (StreamWriter ts = new StreamWriter(part.GetStream()))
                {
                    ts.Write(xmlDoc.OuterXml);
                }
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

        private void AddAttributes(XmlNode parentNode, AttributeMetadata[] amds)
        {
            foreach (var amd in amds.OrderBy(a => a.LogicalName))
            {
                var elt = parentNode.OwnerDocument.CreateElement(amd.LogicalName, parentNode.NamespaceURI);
                elt.InnerText = amd.LogicalName;
                parentNode.AppendChild(elt);
            }
        }

        private EntityMetadata GetMetadataForAttributes(string logicalname)
        {
            EntityQueryExpression entityQueryExpression = new EntityQueryExpression()
            {
                // Sans propriétés d'entité
                Properties = new MetadataPropertiesExpression
                {
                    AllProperties = false,
                    PropertyNames = { "Attributes" }
                },
                Criteria = new MetadataFilterExpression
                {
                    Conditions =
                    {
                        new MetadataConditionExpression("LogicalName", MetadataConditionOperator.Equals, logicalname)
                    }
                },
                AttributeQuery = new AttributeQueryExpression
                {
                    Properties = new MetadataPropertiesExpression
                    {
                        AllProperties = false,
                        PropertyNames = { "LogicalName" }
                    }
                }
            };

            RetrieveMetadataChangesRequest retrieveMetadataChangesRequest = new RetrieveMetadataChangesRequest
            {
                Query = entityQueryExpression,
                ClientVersionStamp = null
            };

            var response = (RetrieveMetadataChangesResponse)service.Execute(retrieveMetadataChangesRequest);

            return response.EntityMetadata.First();
        }
    }
}