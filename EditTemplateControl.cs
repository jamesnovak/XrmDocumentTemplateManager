using System;
using System.Windows.Forms;
using Futurez.Entities;
using Microsoft.Xrm.Sdk;

namespace Futurez.Xrm.Tools
{
    public partial class EditTemplateControl : UserControl
    {
        #region Event definition
        public EventArgs e = null;
        public event OnCompleteHandler OnComplete;
        public delegate void OnCompleteHandler(bool userCanceled, EventArgs e);
        #endregion

        #region Properties
        DocumentTemplateEdit _docTemplate = null;
        IOrganizationService _service = null;
        #endregion

        public EditTemplateControl(IOrganizationService service, DocumentTemplateEdit docTemplate)
        {
            _docTemplate = docTemplate;
            _service = service;
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            CloseMe(true);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.Hide();

            var docUpdate = new Entity("documenttemplate", _docTemplate.Id);
            docUpdate["description"] = this.textBoxDescription.Text;
            docUpdate["name"] = this.textBoxName.Text;
            docUpdate.EntityState = EntityState.Changed;
            _service.Update(docUpdate);

            CloseMe(false);
        }

        private void CloseMe(bool userCanceled)
        {
            OnComplete?.Invoke(userCanceled, null);
        }

        private void EditTemplateControl_Load(object sender, EventArgs e)
        {
            // set the edit controls to the current values
            this.textBoxName.Text = _docTemplate.Name;
            this.textBoxDescription.Text = _docTemplate.Description;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            this.buttonSave.Enabled = (textBoxName.Text.Trim().Length > 0);
        }
    }
}
