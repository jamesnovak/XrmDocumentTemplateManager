using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Futurez.Xrm.Tools
{
    partial class DocTemplateManagerControl : PluginControlBase, IStatusBarMessenger // : PluginControlBase UserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocTemplateManagerControl));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Microsoft Word", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Microsoft Excel", System.Windows.Forms.HorizontalAlignment.Left);
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolButtonCloseTab = new System.Windows.Forms.ToolStripButton();
            this.toolButtonLoadTemplates = new System.Windows.Forms.ToolStripButton();
            this.toolButtonDownload = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownUpload = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemUploadSingle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUploadMultiple = new System.Windows.Forms.ToolStripMenuItem();
            this.toolButtonUpload = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownOther = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemEditTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemActivateTemplates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeactivateTemplates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeleteTemplates = new System.Windows.Forms.ToolStripMenuItem();
            this.labelInstructions = new System.Windows.Forms.Label();
            this.panelSplitter = new System.Windows.Forms.Panel();
            this.splitterMain = new System.Windows.Forms.Splitter();
            this.propertyGridDetails = new System.Windows.Forms.PropertyGrid();
            this.listViewDocumentTemplates = new System.Windows.Forms.ListView();
            this.colHeadName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadCreatedOn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadModifiedOn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadEntityName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolTipInstructions = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanelMain.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.panelSplitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.toolStripMain, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelInstructions, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.panelSplitter, 0, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.741573F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.25843F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(682, 400);
            this.tableLayoutPanelMain.TabIndex = 4;
            // 
            // toolStripMain
            // 
            this.tableLayoutPanelMain.SetColumnSpan(this.toolStripMain, 2);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolButtonCloseTab,
            this.toolButtonLoadTemplates,
            this.toolButtonDownload,
            this.toolStripDropDownUpload,
            this.toolButtonUpload,
            this.toolStripDropDownOther});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(682, 21);
            this.toolStripMain.TabIndex = 0;
            this.toolStripMain.Text = "Main";
            // 
            // toolButtonCloseTab
            // 
            this.toolButtonCloseTab.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonCloseTab.Image")));
            this.toolButtonCloseTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonCloseTab.Name = "toolButtonCloseTab";
            this.toolButtonCloseTab.Size = new System.Drawing.Size(78, 18);
            this.toolButtonCloseTab.Text = "Close Tab";
            this.toolButtonCloseTab.Click += new System.EventHandler(this.toolButtonCloseTab_Click);
            // 
            // toolButtonLoadTemplates
            // 
            this.toolButtonLoadTemplates.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonLoadTemplates.Image")));
            this.toolButtonLoadTemplates.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonLoadTemplates.Name = "toolButtonLoadTemplates";
            this.toolButtonLoadTemplates.Size = new System.Drawing.Size(110, 18);
            this.toolButtonLoadTemplates.Text = "Load Templates";
            this.toolButtonLoadTemplates.ToolTipText = "Load / Reload Templates from the server";
            this.toolButtonLoadTemplates.Click += new System.EventHandler(this.toolButtonLoadTemplates_Click);
            // 
            // toolButtonDownload
            // 
            this.toolButtonDownload.Enabled = false;
            this.toolButtonDownload.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonDownload.Image")));
            this.toolButtonDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonDownload.Name = "toolButtonDownload";
            this.toolButtonDownload.Size = new System.Drawing.Size(146, 18);
            this.toolButtonDownload.Text = "Download Template(s)";
            this.toolButtonDownload.Click += new System.EventHandler(this.toolButtonDownload_Click);
            // 
            // toolStripDropDownUpload
            // 
            this.toolStripDropDownUpload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownUpload.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemUploadSingle,
            this.toolStripMenuItemUploadMultiple});
            this.toolStripDropDownUpload.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownUpload.Image")));
            this.toolStripDropDownUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownUpload.Name = "toolStripDropDownUpload";
            this.toolStripDropDownUpload.Size = new System.Drawing.Size(67, 18);
            this.toolStripDropDownUpload.Text = "Upload...";
            this.toolStripDropDownUpload.ToolTipText = "Upload one or more documents";
            // 
            // toolStripMenuItemUploadSingle
            // 
            this.toolStripMenuItemUploadSingle.Enabled = false;
            this.toolStripMenuItemUploadSingle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemUploadSingle.Image")));
            this.toolStripMenuItemUploadSingle.Name = "toolStripMenuItemUploadSingle";
            this.toolStripMenuItemUploadSingle.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItemUploadSingle.Text = "Upload Single";
            this.toolStripMenuItemUploadSingle.Click += new System.EventHandler(this.toolStripMenuItemUploadSingle_Click);
            // 
            // toolStripMenuItemUploadMultiple
            // 
            this.toolStripMenuItemUploadMultiple.Enabled = false;
            this.toolStripMenuItemUploadMultiple.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemUploadMultiple.Image")));
            this.toolStripMenuItemUploadMultiple.Name = "toolStripMenuItemUploadMultiple";
            this.toolStripMenuItemUploadMultiple.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItemUploadMultiple.Text = "Upload Multiple";
            this.toolStripMenuItemUploadMultiple.Click += new System.EventHandler(this.toolStripMenuItemUploadMultiple_Click);
            // 
            // toolButtonUpload
            // 
            this.toolButtonUpload.Enabled = false;
            this.toolButtonUpload.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonUpload.Image")));
            this.toolButtonUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonUpload.Name = "toolButtonUpload";
            this.toolButtonUpload.Size = new System.Drawing.Size(130, 18);
            this.toolButtonUpload.Text = "Upload Template(s)";
            this.toolButtonUpload.ToolTipText = "Upload new Template Document and replace existing Template Content";
            this.toolButtonUpload.Visible = false;
            this.toolButtonUpload.Click += new System.EventHandler(this.toolButtonUpload_Click);
            // 
            // toolStripDropDownOther
            // 
            this.toolStripDropDownOther.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownOther.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEditTemplate,
            this.toolStripMenuItemActivateTemplates,
            this.toolStripMenuItemDeactivateTemplates,
            this.toolStripMenuItemDeleteTemplates});
            this.toolStripDropDownOther.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownOther.Image")));
            this.toolStripDropDownOther.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownOther.Name = "toolStripDropDownOther";
            this.toolStripDropDownOther.Size = new System.Drawing.Size(93, 18);
            this.toolStripDropDownOther.Text = "Other Actions";
            // 
            // toolStripMenuItemEditTemplate
            // 
            this.toolStripMenuItemEditTemplate.Enabled = false;
            this.toolStripMenuItemEditTemplate.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemEditTemplate.Image")));
            this.toolStripMenuItemEditTemplate.Name = "toolStripMenuItemEditTemplate";
            this.toolStripMenuItemEditTemplate.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItemEditTemplate.Text = "Edit Template";
            this.toolStripMenuItemEditTemplate.Click += new System.EventHandler(this.toolStripMenuItemEditTemplate_Click);
            // 
            // toolStripMenuItemActivateTemplates
            // 
            this.toolStripMenuItemActivateTemplates.Enabled = false;
            this.toolStripMenuItemActivateTemplates.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemActivateTemplates.Image")));
            this.toolStripMenuItemActivateTemplates.Name = "toolStripMenuItemActivateTemplates";
            this.toolStripMenuItemActivateTemplates.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItemActivateTemplates.Text = "Activate Template(s)";
            this.toolStripMenuItemActivateTemplates.Click += new System.EventHandler(this.toolStripMenuItemActivateTemplates_Click);
            // 
            // toolStripMenuItemDeactivateTemplates
            // 
            this.toolStripMenuItemDeactivateTemplates.Enabled = false;
            this.toolStripMenuItemDeactivateTemplates.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemDeactivateTemplates.Image")));
            this.toolStripMenuItemDeactivateTemplates.Name = "toolStripMenuItemDeactivateTemplates";
            this.toolStripMenuItemDeactivateTemplates.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItemDeactivateTemplates.Text = "Deactivate Template(s)";
            this.toolStripMenuItemDeactivateTemplates.Click += new System.EventHandler(this.toolStripMenuItemDeactivateTemplates_Click);
            // 
            // toolStripMenuItemDeleteTemplates
            // 
            this.toolStripMenuItemDeleteTemplates.Enabled = false;
            this.toolStripMenuItemDeleteTemplates.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemDeleteTemplates.Image")));
            this.toolStripMenuItemDeleteTemplates.Name = "toolStripMenuItemDeleteTemplates";
            this.toolStripMenuItemDeleteTemplates.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItemDeleteTemplates.Text = "Delete Template(s)";
            this.toolStripMenuItemDeleteTemplates.Click += new System.EventHandler(this.toolStripMenuItemDeleteTemplates_Click);
            // 
            // labelInstructions
            // 
            this.labelInstructions.BackColor = System.Drawing.SystemColors.Info;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelInstructions, 2);
            this.labelInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInstructions.Location = new System.Drawing.Point(3, 318);
            this.labelInstructions.Name = "labelInstructions";
            this.labelInstructions.Size = new System.Drawing.Size(676, 82);
            this.labelInstructions.TabIndex = 5;
            this.labelInstructions.Text = resources.GetString("labelInstructions.Text");
            this.labelInstructions.DoubleClick += new System.EventHandler(this.labelInstructions_DoubleClick);
            this.labelInstructions.MouseHover += new System.EventHandler(this.labelInstructions_MouseHover);
            // 
            // panelSplitter
            // 
            this.panelSplitter.Controls.Add(this.splitterMain);
            this.panelSplitter.Controls.Add(this.propertyGridDetails);
            this.panelSplitter.Controls.Add(this.listViewDocumentTemplates);
            this.panelSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSplitter.Location = new System.Drawing.Point(3, 24);
            this.panelSplitter.Name = "panelSplitter";
            this.panelSplitter.Size = new System.Drawing.Size(676, 291);
            this.panelSplitter.TabIndex = 6;
            // 
            // splitterMain
            // 
            this.splitterMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterMain.Location = new System.Drawing.Point(426, 0);
            this.splitterMain.Name = "splitterMain";
            this.splitterMain.Size = new System.Drawing.Size(6, 291);
            this.splitterMain.TabIndex = 6;
            this.splitterMain.TabStop = false;
            // 
            // propertyGridDetails
            // 
            this.propertyGridDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.propertyGridDetails.LineColor = System.Drawing.SystemColors.ControlDark;
            this.propertyGridDetails.Location = new System.Drawing.Point(432, 0);
            this.propertyGridDetails.Name = "propertyGridDetails";
            this.propertyGridDetails.Size = new System.Drawing.Size(244, 291);
            this.propertyGridDetails.TabIndex = 5;
            this.propertyGridDetails.ToolbarVisible = false;
            // 
            // listViewDocumentTemplates
            // 
            this.listViewDocumentTemplates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeadName,
            this.colHeadStatus,
            this.colHeadCreatedOn,
            this.colHeadModifiedOn,
            this.colHeadEntityName});
            this.listViewDocumentTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewDocumentTemplates.FullRowSelect = true;
            listViewGroup1.Header = "Microsoft Word";
            listViewGroup1.Name = "Microsoft Word";
            listViewGroup1.Tag = "Microsoft Word";
            listViewGroup2.Header = "Microsoft Excel";
            listViewGroup2.Name = "Microsoft Excel";
            listViewGroup2.Tag = "Microsoft Excel";
            this.listViewDocumentTemplates.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.listViewDocumentTemplates.HideSelection = false;
            this.listViewDocumentTemplates.Location = new System.Drawing.Point(0, 0);
            this.listViewDocumentTemplates.Name = "listViewDocumentTemplates";
            this.listViewDocumentTemplates.Size = new System.Drawing.Size(676, 291);
            this.listViewDocumentTemplates.TabIndex = 4;
            this.listViewDocumentTemplates.Tag = "0";
            this.listViewDocumentTemplates.UseCompatibleStateImageBehavior = false;
            this.listViewDocumentTemplates.View = System.Windows.Forms.View.Details;
            this.listViewDocumentTemplates.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewDocumentTemplates_ColumnClick);
            this.listViewDocumentTemplates.SelectedIndexChanged += new System.EventHandler(this.listViewDocumentTemplates_SelectedIndexChanged);
            this.listViewDocumentTemplates.DoubleClick += new System.EventHandler(this.listViewDocumentTemplates_DoubleClick);
            this.listViewDocumentTemplates.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewDocumentTemplates_KeyDown);
            // 
            // colHeadName
            // 
            this.colHeadName.Tag = "Name";
            this.colHeadName.Text = "Name";
            this.colHeadName.Width = 150;
            // 
            // colHeadStatus
            // 
            this.colHeadStatus.Tag = "Status";
            this.colHeadStatus.Text = "Status";
            this.colHeadStatus.Width = 150;
            // 
            // colHeadCreatedOn
            // 
            this.colHeadCreatedOn.Tag = "CreatedOn";
            this.colHeadCreatedOn.Text = "Created On";
            this.colHeadCreatedOn.Width = 120;
            // 
            // colHeadModifiedOn
            // 
            this.colHeadModifiedOn.Tag = "ModifiedOn";
            this.colHeadModifiedOn.Text = "Modified On";
            this.colHeadModifiedOn.Width = 120;
            // 
            // colHeadEntityName
            // 
            this.colHeadEntityName.Tag = "Associated Entity";
            this.colHeadEntityName.Text = "Associated Entity";
            this.colHeadEntityName.Width = 200;
            // 
            // toolTipInstructions
            // 
            this.toolTipInstructions.ToolTipTitle = "Instructions";
            // 
            // DocTemplateManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "DocTemplateManagerControl";
            this.Size = new System.Drawing.Size(682, 400);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.panelSplitter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tableLayoutPanelMain;
        private ToolStrip toolStripMain;
        private ToolStripButton toolButtonCloseTab;
        private ToolStripButton toolButtonLoadTemplates;
        private ToolStripButton toolButtonDownload;
        private ToolStripButton toolButtonUpload;
        private Label labelInstructions;
        private Panel panelSplitter;
        private Splitter splitterMain;
        private PropertyGrid propertyGridDetails;
        private ListView listViewDocumentTemplates;
        private ColumnHeader colHeadName;
        private ColumnHeader colHeadStatus;
        private ColumnHeader colHeadCreatedOn;
        private ColumnHeader colHeadModifiedOn;
        private ColumnHeader colHeadEntityName;
        private ToolStripDropDownButton toolStripDropDownOther;
        private ToolStripMenuItem toolStripMenuItemDeleteTemplates;
        private ToolStripMenuItem toolStripMenuItemEditTemplate;
        private ToolStripMenuItem toolStripMenuItemDeactivateTemplates;
        private ToolStripMenuItem toolStripMenuItemActivateTemplates;
        private ToolStripDropDownButton toolStripDropDownUpload;
        private ToolStripMenuItem toolStripMenuItemUploadSingle;
        private ToolStripMenuItem toolStripMenuItemUploadMultiple;
        private ToolTip toolTipInstructions;
    }
}
