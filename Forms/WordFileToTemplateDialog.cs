using Futurez.Xrm.Tools.AppCode;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Futurez.Xrm.Tools.Forms
{
    public partial class WordFileToTemplateDialog : Form
    {
        private List<string> relationships = new List<string>();
        private IOrganizationService service;

        public WordFileToTemplateDialog(IOrganizationService service)
        {
            InitializeComponent();

            this.service = service;

            cbbTables.Items.AddRange(GetMetadata().OrderBy(e => e.DisplayName?.UserLocalizedLabel?.Label ?? "N/A").ThenBy(e => e.LogicalName).Select(e => new TableMetadata(e)).ToArray());
        }

        public string FilePath => txtFilePath.Text;
        public List<string> Relationships => relationships;
        public EntityMetadata TableMetadata => ((TableMetadata)cbbTables.SelectedItem).Metadata;

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog
            {
                Title = "Select a Word document",
                Filter = "Word document (*.docx)|*.docx"
            })
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    txtFilePath.Text = dialog.FileName;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSelectRelationships_Click(object sender, EventArgs e)
        {
            using (var dialog = new RelationshipSelectionDialog(service, GetRelationships(((TableMetadata)cbbTables.SelectedItem).Metadata.LogicalName), relationships))
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    relationships = dialog.SelectedRelationships;

                    lblRelCount.Text = "Number of relationships selected : " + relationships.Count;
                }
            }
        }

        private void btnTransform_Click(object sender, EventArgs e)
        {
            if (txtFilePath.Text.Length == 0)
            {
                MessageBox.Show(this, "Please select a Word document", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(txtFilePath.Text))
            {
                MessageBox.Show(this, "Cannot find file: " + txtFilePath.Text, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbbTables.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select a table", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cbbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTables.SelectedItem == null)
            {
                btnSelectRelationships.Enabled = false;
                btnTransform.Enabled = false;
                return;
            }

            btnSelectRelationships.Enabled = true;
            relationships = new List<string>();
        }

        private List<EntityMetadata> GetMetadata()
        {
            EntityQueryExpression entityQueryExpression = new EntityQueryExpression()
            {
                // Sans propriétés d'entité
                Properties = new MetadataPropertiesExpression
                {
                    AllProperties = false,
                    PropertyNames = { "DisplayName", "LogicalName", "SchemaName", "ObjectTypeCode" }
                },
                Criteria = new MetadataFilterExpression
                {
                    Conditions =
                    {
                        new MetadataConditionExpression("IsIntersect", MetadataConditionOperator.Equals, false),
                        new MetadataConditionExpression("IsBPFEntity", MetadataConditionOperator.Equals, false),
                    }
                }
            };

            RetrieveMetadataChangesRequest retrieveMetadataChangesRequest = new RetrieveMetadataChangesRequest
            {
                Query = entityQueryExpression,
                ClientVersionStamp = null
            };

            var response = (RetrieveMetadataChangesResponse)service.Execute(retrieveMetadataChangesRequest);

            return response.EntityMetadata.Where(e => !e.LogicalName.StartsWith("new_system_")).ToList();
        }

        private EntityMetadata GetRelationships(string logicalname)
        {
            EntityQueryExpression entityQueryExpression = new EntityQueryExpression()
            {
                // Sans propriétés d'entité
                Properties = new MetadataPropertiesExpression
                {
                    AllProperties = false,
                    PropertyNames = { "OneToManyRelationships", "ManyToOneRelationships", "ManyToManyRelationships" }
                },
                Criteria = new MetadataFilterExpression
                {
                    Conditions =
                    {
                        new MetadataConditionExpression("LogicalName", MetadataConditionOperator.Equals, logicalname)
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