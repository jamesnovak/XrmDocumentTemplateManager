using Futurez.Xrm.Tools.AppCode;
using Futurez.Xrm.Tools.Helper;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Futurez.Xrm.Tools.Forms
{
    public partial class NewWordTemplateDialog : Form
    {
        private List<string> relationships = new List<string>();
        private IOrganizationService service;

        public NewWordTemplateDialog(IOrganizationService service)
        {
            InitializeComponent();

            this.service = service;

            var lids = ((RetrieveAvailableLanguagesResponse)service.Execute(new RetrieveAvailableLanguagesRequest())).LocaleIds;
            cbbLanguage.Items.AddRange(lids.Select(l => new LanguageItem(l)).ToArray());
        }

        public CultureInfo Culture => ((LanguageItem)cbbLanguage.SelectedItem).Culture;
        public string FilePath => txtFilePath.Text;
        public string LogicalName { get; private set; }
        public string RecordName => txtName.Text;

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
                    if (!WordHelper.TryValidateSourceTable(service, dialog.FileName, out string table, out string tableDisplayName, out string errorMessage))
                    {
                        MessageBox.Show(this, errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    LogicalName = table;
                    txtFilePath.Text = dialog.FileName;
                    var nameParts = dialog.SafeFileName.Split('.');
                    txtName.Text = string.Join(".", nameParts.Take(nameParts.Length - 1));
                    txtTableName.Text = tableDisplayName;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
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

            if (cbbLanguage.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select a language", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}