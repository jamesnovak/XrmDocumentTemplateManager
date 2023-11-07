using Futurez.Xrm.Tools.Helper;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Futurez.Xrm.Tools
{
    public partial class LocalTemplateUpdaterDialog : Form
    {
        private readonly IOrganizationService _service;
        private string _table;

        public LocalTemplateUpdaterDialog(IOrganizationService service)
        {
            InitializeComponent();

            _service = service;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Title = "Select a Word Template document",
                Filter = "Word document (*.docx)|*.docx",
                Multiselect = false
            };
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                txtFilePath.Text = ofd.FileName;

                if (!WordHelper.TryValidateSourceTable(_service, ofd.FileName, out string table, out string _, out string errorMessage))
                {
                    MessageBox.Show(this, errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnRefreshColumns.Enabled = false;
                    btnSelectRelationships.Enabled = false;
                }
                else
                {
                    _table = table;
                    btnRefreshColumns.Enabled = true;
                    btnSelectRelationships.Enabled = true;
                }
            }
        }

        private void btnRefreshColumns_Click(object sender, EventArgs e)
        {
            var bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.DoWork += (worker, evt) =>
            {
                bw.ReportProgress(0, "Refreshing columns...");
                WordHelper.RefreshColumns(evt.Argument.ToString(), _service, (BackgroundWorker)worker);
            };
            bw.RunWorkerCompleted += (worker, evt) =>
            {
                setWorkingStatus(false);
                if (evt.Error != null)
                {
                    MessageBox.Show(this, evt.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show(this, "Template updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            bw.ProgressChanged += (worker, evt) =>
            {
                lblProgress.Text = evt.UserState.ToString();
            };
            bw.RunWorkerAsync(txtFilePath.Text);
            setWorkingStatus(true);
        }

        private void btnSelectRelationships_Click(object sender, EventArgs e)
        {
            var bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.DoWork += (worker, evt) =>
            {
                bw.ReportProgress(0, "Loading current table relationships...");

                var emd = ((RetrieveEntityResponse)_service.Execute(new RetrieveEntityRequest
                {
                    LogicalName = _table,
                    EntityFilters = EntityFilters.Relationships
                })).EntityMetadata;

                evt.Result = emd;
            };
            bw.RunWorkerCompleted += (worker, evt) =>
            {
                setWorkingStatus(false);
                if (evt.Error != null)
                {
                    MessageBox.Show(this, evt.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                RefreshRelationships((EntityMetadata)evt.Result);
            };
            bw.ProgressChanged += (worker, evt) =>
            {
                lblProgress.Text = evt.UserState.ToString();
            };
            bw.RunWorkerAsync(txtFilePath.Text);
            setWorkingStatus(true);
        }

        private void RefreshRelationships(EntityMetadata emd)
        {
            var selectedRelationships = WordHelper.GetRelationships(txtFilePath.Text);

            var rsd = new RelationshipSelectionDialog(_service, emd, selectedRelationships);
            if (rsd.ShowDialog(this) != DialogResult.OK) return;

            var bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.DoWork += (worker, evt) =>
            {
                WordHelper.RefreshRelationships(evt.Argument.ToString(), rsd.SelectedRelationships, _service, (BackgroundWorker)worker);
            };
            bw.RunWorkerCompleted += (worker, evt) =>
            {
                setWorkingStatus(false);
                if (evt.Error != null)
                {
                    MessageBox.Show(this, evt.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show(this, "Template updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            bw.ProgressChanged += (worker, evt) =>
            {
                lblProgress.Text = evt.UserState.ToString();
            };
            bw.RunWorkerAsync(txtFilePath.Text);
            setWorkingStatus(true);
        }

        private void setWorkingStatus(bool working)
        {
            btnRefreshColumns.Enabled = !working;
            btnSelectRelationships.Enabled = !working;
            btnClose.Enabled = !working;
            btnBrowse.Enabled = !working;
            if (!working) lblProgress.Text = "";
        }
    }
}