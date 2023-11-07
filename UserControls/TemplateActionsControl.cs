using Futurez.Xrm.Tools.AppCode;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Futurez.Xrm.Tools.UserControls
{
    public partial class TemplateActionsControl : UserControl
    {
        private Control lastControl = null;

        public TemplateActionsControl()
        {
            InitializeComponent();

            btnDownload.MouseHover += ctrl_Enter;
            btnDelete.MouseHover += ctrl_Enter;
            btnDisable.MouseHover += ctrl_Enter;
            btnEnable.MouseHover += ctrl_Enter;
            btnRefresh.MouseHover += ctrl_Enter;
            btnRelationships.MouseHover += ctrl_Enter;
            lblUpload.MouseHover += ctrl_Enter;
            MouseLeave += TemplateActionsControl_MouseLeave;
            tlpMain.MouseHover += TemplateActionsControl_MouseHover;
            tlpMain.MouseMove += TemplateActionsControl_MouseHover;
            tlpMain.MouseLeave += TlpMain_MouseLeave;

            lblHelp.MaximumSize = new System.Drawing.Size(pnlHElp.Width - pbHelp.Width, 1000);
            pnlHElp.Height = 40;
        }

        public event EventHandler<ActionEventArgs> OnActionRequest;

        public void SetControlsState(string type, int numberOfSelectedTemplates)
        {
            btnRefresh.Enabled = type == "docx" && numberOfSelectedTemplates > 0;
            btnRelationships.Enabled = type == "docx" && numberOfSelectedTemplates == 1;
            btnEnable.Enabled = numberOfSelectedTemplates > 0;
            btnDisable.Enabled = numberOfSelectedTemplates > 0;
            btnDownload.Enabled = numberOfSelectedTemplates > 0;
            btnDelete.Enabled = numberOfSelectedTemplates > 0;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            OnActionRequest?.Invoke(sender, new ActionEventArgs { Action = ((Control)sender).Name });
        }

        private void ctrl_Enter(object sender, EventArgs e)
        {
            if (lastControl != sender) lastControl = (Control)sender;
            else return;

            if (sender == btnDownload)
            {
                lblHelp.Text = @"If multiple templates are selected, all will be downloaded as a Zip file, otherwise the single template file will be downloaded.

If duplicate templates are selected (same name and template type), the duplicate files will include a suffix to avoid clashes.
For example, ''Word Document.docx' and 'Word Document (1).docx'";
            }
            else if (sender == btnDelete)
            {
                lblHelp.Text = "For one or more selected templates, delete the template record";
            }
            else if (sender == btnDisable)
            {
                lblHelp.Text = "For one or more selected templates, Dectivate the template record";
            }
            else if (sender == btnEnable)
            {
                lblHelp.Text = "For one or more selected templates, Activate the template record";
            }
            else if (sender == btnRefresh)
            {
                lblHelp.Text = "Refresh columns available in the template for selected table and relationships";
            }
            else if (sender == btnRelationships)
            {
                lblHelp.Text = "Add/Remove relationships embedded in the template record";
            }
            else if (sender == lblUpload)
            {
                lblHelp.Text = @"If one file is uploaded, the current selected template will be updated with this file.

If multiple files are provided, then we will attempt match the template based on the file name.

If the file name and extension match a name and template type in Dataverse, the template will be updated.
If the file name and extension do not match, then a new template will be created for the template type.
If your system contains duplicate templates for a file being uploaded, it will be ignored.
For example, we are unable to match two Microsoft Word templates named 'Case Summary' and a selected document named 'Case Summary.docx'.";
            }

            pnlHElp.Height = 40;
            while (lblHelp.Height > pnlHElp.Height)
            {
                pnlHElp.Height += 10;
            }
        }

        private void lblUpload_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog
            {
                Filter = "Word document (*.docx)|*.docx|Excel spreadsheet (*.xlsX)|*.xlsx",
                Title = "Choose document(s) to upload"
            })
            {
                if (DialogResult.OK == dialog.ShowDialog(this))
                {
                    OnActionRequest?.Invoke(sender, new ActionEventArgs { Action = ((Control)sender).Name, Files = dialog.FileNames.ToList() });
                }
            }
        }

        private void lblUpload_DragDrop(object sender, DragEventArgs e)
        {
            lblUpload.Click += lblUpload_Click;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            OnActionRequest?.Invoke(sender, new ActionEventArgs { Action = ((Control)sender).Name, Files = files.ToList() });
        }

        private void lblUpload_DragOver(object sender, DragEventArgs e)
        {
            lblUpload.Click -= lblUpload_Click;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0) e.Effect = DragDropEffects.Move;
            foreach (string file in files)
            {
                if (!(file.ToLower().EndsWith(".docx") || file.ToLower().EndsWith(".xlsm")))
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private void TemplateActionsControl_MouseHover(object sender, EventArgs e)
        {
            foreach (var button in tlpMain.Controls.OfType<Button>())
            {
                if (button.Bounds.Contains(((Control)sender).PointToClient(Cursor.Position)))
                {
                    ctrl_Enter(button, new EventArgs());
                    break;
                }
            }
        }

        private void TemplateActionsControl_MouseLeave(object sender, EventArgs e)
        {
            lblHelp.Text = "Choose one of the above action to act on the selected template or upload documents";
            pnlHElp.Height = 40;
        }

        private void TemplateActionsControl_Resize(object sender, EventArgs e)
        {
            lblHelp.MaximumSize = new System.Drawing.Size(pnlHElp.Width - pbHelp.Width, 1000);
        }

        private void TlpMain_MouseLeave(object sender, EventArgs e)
        {
            TemplateActionsControl_MouseLeave(sender, e);
        }
    }
}