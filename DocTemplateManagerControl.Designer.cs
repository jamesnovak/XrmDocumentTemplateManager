using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Futurez.Xrm.Tools
{
    partial class DocTemplateManagerControl : PluginControlBase, IStatusBarMessenger
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Microsoft Word", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Microsoft Excel", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocTemplateManagerControl));
            this.toolTipInstructions = new System.Windows.Forms.ToolTip(this.components);
            this.colHeadModifiedOn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadCreatedOn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewDocumentTemplates = new System.Windows.Forms.ListView();
            this.colHeadEntityName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadLanguage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelSplitter = new System.Windows.Forms.Panel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.pnlSearchSub = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblEntity = new System.Windows.Forms.Label();
            this.cbbEntity = new System.Windows.Forms.ComboBox();
            this.lblFilterLanguage = new System.Windows.Forms.Label();
            this.cbbLanguage = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolButtonCloseTab = new System.Windows.Forms.ToolStripButton();
            this.toolButtonLoadTemplates = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNewWordTemplate = new System.Windows.Forms.ToolStripButton();
            this.toolButtonDownload = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownUpload = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemUploadSingle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUploadMultiple = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownOther = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemEditTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemActivateTemplates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeactivateTemplates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeleteTemplates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshAvailableColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectRelationshipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolButtonUpload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUpdateLocalWordTemplate = new System.Windows.Forms.ToolStripButton();
            this.tsbTransformToTemplate = new System.Windows.Forms.ToolStripButton();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.templateActionsControl1 = new Futurez.Xrm.Tools.UserControls.TemplateActionsControl();
            this.pnlSpacer1 = new System.Windows.Forms.Panel();
            this.pnlSave = new System.Windows.Forms.Panel();
            this.btnSaveTemplate = new System.Windows.Forms.Button();
            this.propertyGridDetails = new System.Windows.Forms.PropertyGrid();
            this.panelSplitter.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlSearchSub.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.pnlSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTipInstructions
            // 
            this.toolTipInstructions.ToolTipTitle = "Instructions";
            // 
            // colHeadModifiedOn
            // 
            this.colHeadModifiedOn.DisplayIndex = 5;
            this.colHeadModifiedOn.Tag = "ModifiedOn";
            this.colHeadModifiedOn.Text = "Modified On";
            this.colHeadModifiedOn.Width = 120;
            // 
            // colHeadCreatedOn
            // 
            this.colHeadCreatedOn.DisplayIndex = 4;
            this.colHeadCreatedOn.Tag = "CreatedOn";
            this.colHeadCreatedOn.Text = "Created On";
            this.colHeadCreatedOn.Width = 120;
            // 
            // colHeadStatus
            // 
            this.colHeadStatus.Tag = "Status";
            this.colHeadStatus.Text = "Status";
            this.colHeadStatus.Width = 150;
            // 
            // colHeadName
            // 
            this.colHeadName.Tag = "Name";
            this.colHeadName.Text = "Name";
            this.colHeadName.Width = 150;
            // 
            // listViewDocumentTemplates
            // 
            this.listViewDocumentTemplates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeadName,
            this.colHeadStatus,
            this.colHeadCreatedOn,
            this.colHeadModifiedOn,
            this.colHeadEntityName,
            this.colHeadLanguage});
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
            this.listViewDocumentTemplates.Location = new System.Drawing.Point(0, 39);
            this.listViewDocumentTemplates.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewDocumentTemplates.Name = "listViewDocumentTemplates";
            this.listViewDocumentTemplates.Size = new System.Drawing.Size(1396, 1013);
            this.listViewDocumentTemplates.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewDocumentTemplates.TabIndex = 4;
            this.listViewDocumentTemplates.Tag = "0";
            this.listViewDocumentTemplates.UseCompatibleStateImageBehavior = false;
            this.listViewDocumentTemplates.View = System.Windows.Forms.View.Details;
            this.listViewDocumentTemplates.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewDocumentTemplates_ColumnClick);
            this.listViewDocumentTemplates.SelectedIndexChanged += new System.EventHandler(this.listViewDocumentTemplates_SelectedIndexChanged);
            this.listViewDocumentTemplates.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewDocumentTemplates_KeyDown);
            // 
            // colHeadEntityName
            // 
            this.colHeadEntityName.DisplayIndex = 2;
            this.colHeadEntityName.Tag = "Associated Entity";
            this.colHeadEntityName.Text = "Associated Entity";
            this.colHeadEntityName.Width = 200;
            // 
            // colHeadLanguage
            // 
            this.colHeadLanguage.DisplayIndex = 3;
            this.colHeadLanguage.Text = "Language";
            this.colHeadLanguage.Width = 200;
            // 
            // panelSplitter
            // 
            this.panelSplitter.Controls.Add(this.listViewDocumentTemplates);
            this.panelSplitter.Controls.Add(this.pnlSearch);
            this.panelSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSplitter.Location = new System.Drawing.Point(0, 0);
            this.panelSplitter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelSplitter.Name = "panelSplitter";
            this.panelSplitter.Size = new System.Drawing.Size(1396, 1052);
            this.panelSplitter.TabIndex = 6;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.pnlSearchSub);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1396, 39);
            this.pnlSearch.TabIndex = 7;
            // 
            // pnlSearchSub
            // 
            this.pnlSearchSub.Controls.Add(this.txtSearch);
            this.pnlSearchSub.Controls.Add(this.lblEntity);
            this.pnlSearchSub.Controls.Add(this.cbbEntity);
            this.pnlSearchSub.Controls.Add(this.lblFilterLanguage);
            this.pnlSearchSub.Controls.Add(this.cbbLanguage);
            this.pnlSearchSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearchSub.Location = new System.Drawing.Point(87, 0);
            this.pnlSearchSub.Name = "pnlSearchSub";
            this.pnlSearchSub.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.pnlSearchSub.Size = new System.Drawing.Size(1309, 39);
            this.pnlSearchSub.TabIndex = 2;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(0, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(686, 26);
            this.txtSearch.TabIndex = 7;
            // 
            // lblEntity
            // 
            this.lblEntity.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblEntity.Location = new System.Drawing.Point(686, 4);
            this.lblEntity.Name = "lblEntity";
            this.lblEntity.Size = new System.Drawing.Size(148, 35);
            this.lblEntity.TabIndex = 6;
            this.lblEntity.Text = "Associated table ";
            this.lblEntity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbEntity
            // 
            this.cbbEntity.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbbEntity.FormattingEnabled = true;
            this.cbbEntity.Location = new System.Drawing.Point(834, 4);
            this.cbbEntity.Name = "cbbEntity";
            this.cbbEntity.Size = new System.Drawing.Size(185, 28);
            this.cbbEntity.TabIndex = 5;
            this.cbbEntity.SelectedIndexChanged += new System.EventHandler(this.cbbEntity_SelectedIndexChanged);
            // 
            // lblFilterLanguage
            // 
            this.lblFilterLanguage.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFilterLanguage.Location = new System.Drawing.Point(1019, 4);
            this.lblFilterLanguage.Name = "lblFilterLanguage";
            this.lblFilterLanguage.Size = new System.Drawing.Size(105, 35);
            this.lblFilterLanguage.TabIndex = 4;
            this.lblFilterLanguage.Text = "Language ";
            this.lblFilterLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbLanguage
            // 
            this.cbbLanguage.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbbLanguage.FormattingEnabled = true;
            this.cbbLanguage.Location = new System.Drawing.Point(1124, 4);
            this.cbbLanguage.Name = "cbbLanguage";
            this.cbbLanguage.Size = new System.Drawing.Size(185, 28);
            this.cbbLanguage.TabIndex = 3;
            this.cbbLanguage.SelectedIndexChanged += new System.EventHandler(this.cbbLanguage_SelectedIndexChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSearch.Location = new System.Drawing.Point(0, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(87, 39);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripMain
            // 
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolButtonCloseTab,
            this.toolButtonLoadTemplates,
            this.toolStripSeparator3,
            this.tsbNewWordTemplate,
            this.toolButtonDownload,
            this.toolStripDropDownUpload,
            this.toolStripDropDownOther,
            this.toolButtonUpload,
            this.toolStripSeparator2,
            this.tsbUpdateLocalWordTemplate,
            this.tsbTransformToTemplate});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStripMain.Size = new System.Drawing.Size(2199, 34);
            this.toolStripMain.TabIndex = 0;
            this.toolStripMain.Text = "Main";
            // 
            // toolButtonCloseTab
            // 
            this.toolButtonCloseTab.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonCloseTab.Image")));
            this.toolButtonCloseTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonCloseTab.Name = "toolButtonCloseTab";
            this.toolButtonCloseTab.Size = new System.Drawing.Size(115, 29);
            this.toolButtonCloseTab.Text = "Close Tab";
            this.toolButtonCloseTab.Visible = false;
            this.toolButtonCloseTab.Click += new System.EventHandler(this.toolButtonCloseTab_Click);
            // 
            // toolButtonLoadTemplates
            // 
            this.toolButtonLoadTemplates.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonLoadTemplates.Image")));
            this.toolButtonLoadTemplates.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonLoadTemplates.Name = "toolButtonLoadTemplates";
            this.toolButtonLoadTemplates.Size = new System.Drawing.Size(163, 29);
            this.toolButtonLoadTemplates.Text = "Load Templates";
            this.toolButtonLoadTemplates.ToolTipText = "Load / Reload Templates from the server";
            this.toolButtonLoadTemplates.Click += new System.EventHandler(this.toolButtonLoadTemplates_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 34);
            // 
            // tsbNewWordTemplate
            // 
            this.tsbNewWordTemplate.Image = global::Futurez.Xrm.Tools.Properties.Resources.NewToInstall;
            this.tsbNewWordTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewWordTemplate.Name = "tsbNewWordTemplate";
            this.tsbNewWordTemplate.Size = new System.Drawing.Size(199, 29);
            this.tsbNewWordTemplate.Text = "New Word template";
            this.tsbNewWordTemplate.Click += new System.EventHandler(this.tsbNewWordTemplate_Click);
            // 
            // toolButtonDownload
            // 
            this.toolButtonDownload.Enabled = false;
            this.toolButtonDownload.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonDownload.Image")));
            this.toolButtonDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonDownload.Name = "toolButtonDownload";
            this.toolButtonDownload.Size = new System.Drawing.Size(216, 29);
            this.toolButtonDownload.Text = "Download Template(s)";
            this.toolButtonDownload.Visible = false;
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
            this.toolStripDropDownUpload.Size = new System.Drawing.Size(100, 29);
            this.toolStripDropDownUpload.Text = "Upload...";
            this.toolStripDropDownUpload.ToolTipText = "Upload one or more documents";
            this.toolStripDropDownUpload.Visible = false;
            // 
            // toolStripMenuItemUploadSingle
            // 
            this.toolStripMenuItemUploadSingle.Enabled = false;
            this.toolStripMenuItemUploadSingle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemUploadSingle.Image")));
            this.toolStripMenuItemUploadSingle.Name = "toolStripMenuItemUploadSingle";
            this.toolStripMenuItemUploadSingle.Size = new System.Drawing.Size(241, 34);
            this.toolStripMenuItemUploadSingle.Text = "Upload Single";
            this.toolStripMenuItemUploadSingle.Click += new System.EventHandler(this.toolStripMenuItemUploadSingle_Click);
            // 
            // toolStripMenuItemUploadMultiple
            // 
            this.toolStripMenuItemUploadMultiple.Enabled = false;
            this.toolStripMenuItemUploadMultiple.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemUploadMultiple.Image")));
            this.toolStripMenuItemUploadMultiple.Name = "toolStripMenuItemUploadMultiple";
            this.toolStripMenuItemUploadMultiple.Size = new System.Drawing.Size(241, 34);
            this.toolStripMenuItemUploadMultiple.Text = "Upload Multiple";
            this.toolStripMenuItemUploadMultiple.Click += new System.EventHandler(this.toolStripMenuItemUploadMultiple_Click);
            // 
            // toolStripDropDownOther
            // 
            this.toolStripDropDownOther.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownOther.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEditTemplate,
            this.toolStripMenuItemActivateTemplates,
            this.toolStripMenuItemDeactivateTemplates,
            this.toolStripMenuItemDeleteTemplates,
            this.toolStripSeparator1,
            this.refreshAvailableColumnsToolStripMenuItem,
            this.selectRelationshipsToolStripMenuItem});
            this.toolStripDropDownOther.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownOther.Image")));
            this.toolStripDropDownOther.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownOther.Name = "toolStripDropDownOther";
            this.toolStripDropDownOther.Size = new System.Drawing.Size(139, 29);
            this.toolStripDropDownOther.Text = "Other Actions";
            this.toolStripDropDownOther.Visible = false;
            // 
            // toolStripMenuItemEditTemplate
            // 
            this.toolStripMenuItemEditTemplate.Enabled = false;
            this.toolStripMenuItemEditTemplate.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemEditTemplate.Image")));
            this.toolStripMenuItemEditTemplate.Name = "toolStripMenuItemEditTemplate";
            this.toolStripMenuItemEditTemplate.Size = new System.Drawing.Size(317, 34);
            this.toolStripMenuItemEditTemplate.Text = "Edit Template";
            this.toolStripMenuItemEditTemplate.Click += new System.EventHandler(this.toolStripMenuItemEditTemplate_Click);
            // 
            // toolStripMenuItemActivateTemplates
            // 
            this.toolStripMenuItemActivateTemplates.Enabled = false;
            this.toolStripMenuItemActivateTemplates.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemActivateTemplates.Image")));
            this.toolStripMenuItemActivateTemplates.Name = "toolStripMenuItemActivateTemplates";
            this.toolStripMenuItemActivateTemplates.Size = new System.Drawing.Size(317, 34);
            this.toolStripMenuItemActivateTemplates.Text = "Activate Template(s)";
            this.toolStripMenuItemActivateTemplates.Click += new System.EventHandler(this.toolStripMenuItemActivateTemplates_Click);
            // 
            // toolStripMenuItemDeactivateTemplates
            // 
            this.toolStripMenuItemDeactivateTemplates.Enabled = false;
            this.toolStripMenuItemDeactivateTemplates.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemDeactivateTemplates.Image")));
            this.toolStripMenuItemDeactivateTemplates.Name = "toolStripMenuItemDeactivateTemplates";
            this.toolStripMenuItemDeactivateTemplates.Size = new System.Drawing.Size(317, 34);
            this.toolStripMenuItemDeactivateTemplates.Text = "Deactivate Template(s)";
            this.toolStripMenuItemDeactivateTemplates.Click += new System.EventHandler(this.toolStripMenuItemDeactivateTemplates_Click);
            // 
            // toolStripMenuItemDeleteTemplates
            // 
            this.toolStripMenuItemDeleteTemplates.Enabled = false;
            this.toolStripMenuItemDeleteTemplates.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemDeleteTemplates.Image")));
            this.toolStripMenuItemDeleteTemplates.Name = "toolStripMenuItemDeleteTemplates";
            this.toolStripMenuItemDeleteTemplates.Size = new System.Drawing.Size(317, 34);
            this.toolStripMenuItemDeleteTemplates.Text = "Delete Template(s)";
            this.toolStripMenuItemDeleteTemplates.Click += new System.EventHandler(this.toolStripMenuItemDeleteTemplates_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(314, 6);
            // 
            // refreshAvailableColumnsToolStripMenuItem
            // 
            this.refreshAvailableColumnsToolStripMenuItem.Enabled = false;
            this.refreshAvailableColumnsToolStripMenuItem.Name = "refreshAvailableColumnsToolStripMenuItem";
            this.refreshAvailableColumnsToolStripMenuItem.Size = new System.Drawing.Size(317, 34);
            this.refreshAvailableColumnsToolStripMenuItem.Text = "Refresh available columns";
            this.refreshAvailableColumnsToolStripMenuItem.Click += new System.EventHandler(this.refreshAvailableColumnsToolStripMenuItem_Click);
            // 
            // selectRelationshipsToolStripMenuItem
            // 
            this.selectRelationshipsToolStripMenuItem.Enabled = false;
            this.selectRelationshipsToolStripMenuItem.Name = "selectRelationshipsToolStripMenuItem";
            this.selectRelationshipsToolStripMenuItem.Size = new System.Drawing.Size(317, 34);
            this.selectRelationshipsToolStripMenuItem.Text = "Select relationships";
            this.selectRelationshipsToolStripMenuItem.Click += new System.EventHandler(this.selectRelationshipsToolStripMenuItem_Click);
            // 
            // toolButtonUpload
            // 
            this.toolButtonUpload.Enabled = false;
            this.toolButtonUpload.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonUpload.Image")));
            this.toolButtonUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonUpload.Name = "toolButtonUpload";
            this.toolButtonUpload.Size = new System.Drawing.Size(192, 29);
            this.toolButtonUpload.Text = "Upload Template(s)";
            this.toolButtonUpload.ToolTipText = "Upload new Template Document and replace existing Template Content";
            this.toolButtonUpload.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 34);
            // 
            // tsbUpdateLocalWordTemplate
            // 
            this.tsbUpdateLocalWordTemplate.Image = global::Futurez.Xrm.Tools.Properties.Resources.Refresh;
            this.tsbUpdateLocalWordTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdateLocalWordTemplate.Name = "tsbUpdateLocalWordTemplate";
            this.tsbUpdateLocalWordTemplate.Size = new System.Drawing.Size(264, 29);
            this.tsbUpdateLocalWordTemplate.Text = "Update local Word Template";
            this.tsbUpdateLocalWordTemplate.ToolTipText = "Update local Word Template to get latest customizations available";
            this.tsbUpdateLocalWordTemplate.Click += new System.EventHandler(this.tsbUpdateLocalWordTemplate_Click);
            // 
            // tsbTransformToTemplate
            // 
            this.tsbTransformToTemplate.Image = global::Futurez.Xrm.Tools.Properties.Resources.data_transformation;
            this.tsbTransformToTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTransformToTemplate.Name = "tsbTransformToTemplate";
            this.tsbTransformToTemplate.Size = new System.Drawing.Size(352, 29);
            this.tsbTransformToTemplate.Text = "Transform Word document to Template";
            this.tsbTransformToTemplate.ToolTipText = "Transform Word document to Template by adding XML metadata to include columns fro" +
    "m Dataverse in your document and make it a template";
            this.tsbTransformToTemplate.Click += new System.EventHandler(this.tsbTransformToTemplate_Click);
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scMain.Location = new System.Drawing.Point(0, 34);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.panelSplitter);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.AutoScroll = true;
            this.scMain.Panel2.Controls.Add(this.templateActionsControl1);
            this.scMain.Panel2.Controls.Add(this.pnlSpacer1);
            this.scMain.Panel2.Controls.Add(this.pnlSave);
            this.scMain.Panel2.Controls.Add(this.propertyGridDetails);
            this.scMain.Size = new System.Drawing.Size(2199, 1052);
            this.scMain.SplitterDistance = 1396;
            this.scMain.TabIndex = 7;
            // 
            // templateActionsControl1
            // 
            this.templateActionsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateActionsControl1.Location = new System.Drawing.Point(0, 414);
            this.templateActionsControl1.Name = "templateActionsControl1";
            this.templateActionsControl1.Size = new System.Drawing.Size(799, 638);
            this.templateActionsControl1.TabIndex = 7;
            this.templateActionsControl1.OnActionRequest += new System.EventHandler<Futurez.Xrm.Tools.AppCode.ActionEventArgs>(this.templateActionsControl1_OnActionRequest);
            // 
            // pnlSpacer1
            // 
            this.pnlSpacer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSpacer1.Location = new System.Drawing.Point(0, 391);
            this.pnlSpacer1.Name = "pnlSpacer1";
            this.pnlSpacer1.Size = new System.Drawing.Size(799, 23);
            this.pnlSpacer1.TabIndex = 9;
            this.pnlSpacer1.Visible = false;
            // 
            // pnlSave
            // 
            this.pnlSave.Controls.Add(this.btnSaveTemplate);
            this.pnlSave.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSave.Location = new System.Drawing.Point(0, 350);
            this.pnlSave.Name = "pnlSave";
            this.pnlSave.Size = new System.Drawing.Size(799, 41);
            this.pnlSave.TabIndex = 8;
            // 
            // btnSaveTemplate
            // 
            this.btnSaveTemplate.AutoSize = true;
            this.btnSaveTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveTemplate.Enabled = false;
            this.btnSaveTemplate.Location = new System.Drawing.Point(0, 0);
            this.btnSaveTemplate.Name = "btnSaveTemplate";
            this.btnSaveTemplate.Size = new System.Drawing.Size(799, 41);
            this.btnSaveTemplate.TabIndex = 9;
            this.btnSaveTemplate.Text = "Save";
            this.btnSaveTemplate.UseVisualStyleBackColor = true;
            this.btnSaveTemplate.Click += new System.EventHandler(this.btnSaveTemplate_Click);
            // 
            // propertyGridDetails
            // 
            this.propertyGridDetails.CommandsBorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.propertyGridDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertyGridDetails.HelpVisible = false;
            this.propertyGridDetails.LineColor = System.Drawing.SystemColors.ControlDark;
            this.propertyGridDetails.Location = new System.Drawing.Point(0, 0);
            this.propertyGridDetails.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.propertyGridDetails.Name = "propertyGridDetails";
            this.propertyGridDetails.Size = new System.Drawing.Size(799, 350);
            this.propertyGridDetails.TabIndex = 6;
            this.propertyGridDetails.ToolbarVisible = false;
            this.propertyGridDetails.ViewBorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            // 
            // DocTemplateManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.toolStripMain);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DocTemplateManagerControl";
            this.Size = new System.Drawing.Size(2199, 1086);
            this.panelSplitter.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearchSub.ResumeLayout(false);
            this.pnlSearchSub.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.pnlSave.ResumeLayout(false);
            this.pnlSave.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolTip toolTipInstructions;
        private ColumnHeader colHeadModifiedOn;
        private ColumnHeader colHeadCreatedOn;
        private ColumnHeader colHeadStatus;
        private ColumnHeader colHeadName;
        private ListView listViewDocumentTemplates;
        private ColumnHeader colHeadEntityName;
        private Panel panelSplitter;
        private ToolStripMenuItem toolStripMenuItemDeleteTemplates;
        private ToolStripMenuItem toolStripMenuItemDeactivateTemplates;
        private ToolStripMenuItem toolStripMenuItemActivateTemplates;
        private ToolStripDropDownButton toolStripDropDownOther;
        private ToolStripMenuItem toolStripMenuItemEditTemplate;
        private ToolStripButton toolButtonUpload;
        private ToolStripMenuItem toolStripMenuItemUploadMultiple;
        private ToolStripMenuItem toolStripMenuItemUploadSingle;
        private ToolStripDropDownButton toolStripDropDownUpload;
        private ToolStripButton toolButtonDownload;
        private ToolStripButton toolButtonLoadTemplates;
        private ToolStripButton toolButtonCloseTab;
        private ToolStrip toolStripMain;
        private ToolStripMenuItem refreshAvailableColumnsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem selectRelationshipsToolStripMenuItem;
        private SplitContainer scMain;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbUpdateLocalWordTemplate;
        private Panel pnlSearch;
        private Panel pnlSearchSub;
        private Label lblSearch;
        private Tools.UserControls.TemplateActionsControl templateActionsControl1;
        private PropertyGrid propertyGridDetails;
        private Panel pnlSave;
        private Button btnSaveTemplate;
        private ColumnHeader colHeadLanguage;
        private TextBox txtSearch;
        private Label lblEntity;
        private ComboBox cbbEntity;
        private Label lblFilterLanguage;
        private ComboBox cbbLanguage;
        private Panel pnlSpacer1;
        private ToolStripButton tsbTransformToTemplate;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton tsbNewWordTemplate;
    }
}
