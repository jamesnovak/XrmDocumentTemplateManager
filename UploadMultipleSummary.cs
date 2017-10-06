using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk;
using Futurez.Entities;

namespace Futurez.Xrm.Tools
{
    public partial class UploadMultipleSummary : UserControl
    {
        #region Event definition
        public EventArgs e = null;
        public event OnCompleteHandler OnComplete;
        public delegate void OnCompleteHandler(bool userCanceled, List<FileUpload> createTemplate, List<FileUpload> updateTemplate, EventArgs e);
        #endregion

        #region Properties
        List<FileUpload> _createTemplate = null;
        List<FileUpload> _updateTemplate = null;
        List<FileUpload> _ignored = null;
        #endregion

        public UploadMultipleSummary(IOrganizationService service, List<FileUpload> createTemplate, List<FileUpload> updateTemplate, List<FileUpload> ignored)
        {
            this._createTemplate = createTemplate;
            this._updateTemplate = updateTemplate;
            this._ignored = ignored;

            InitializeComponent();
        }

        private void UploadMultipleSummary_Load(object sender, EventArgs e)
        {
            // populate the list for the user to review
            foreach (var file in _createTemplate)
            {
                AddListViewItem(file, "listViewGroupCreate");
            }
            foreach (var file in _updateTemplate)
            {
                AddListViewItem(file, "listViewGroupUpdate");
            }
            foreach (var file in _ignored)
            {
                AddListViewItem(file, "listViewGroupIgnore");
            }
        }

        private ListViewItem AddListViewItem(FileUpload file, string groupName) {
            // grab file
            var lvItem = new ListViewItem()
            {
                Name = "File Name",
                Text = file.FileName,
                Group = this.listViewFileUploadSummary.Groups[groupName],
                Tag = file
            };

            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lvItem, file.TemplateType) { Tag = "Template Type", Name = "Template Type" });
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lvItem, file.TemplateType) { Tag = "Template Name", Name = "Template Name" });
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lvItem, file.Note) { Tag = "Note", Name = "Note" });

            var newItem = this.listViewFileUploadSummary.Items.Add(lvItem);

            return newItem;
        }

        private void CloseMe(bool userCanceled)
        {
            OnComplete?.Invoke(userCanceled, this._createTemplate, this._updateTemplate, null);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            CloseMe(true);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Hide();
            CloseMe(false);
        }
    }
}
