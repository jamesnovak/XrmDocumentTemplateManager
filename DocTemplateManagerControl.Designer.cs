﻿using System.Windows.Forms;
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
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Microsoft Word", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Microsoft Excel", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocTemplateManagerControl));
            this.toolTipInstructions = new System.Windows.Forms.ToolTip(this.components);
            this.colHeadModifiedOn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadCreatedOn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitterMain = new System.Windows.Forms.Splitter();
            this.propertyGridDetails = new System.Windows.Forms.PropertyGrid();
            this.listViewDocumentTemplates = new System.Windows.Forms.ListView();
            this.colHeadEntityName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelSplitter = new System.Windows.Forms.Panel();
            this.toolStripMenuItemDeleteTemplates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeactivateTemplates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemActivateTemplates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownOther = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemEditTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshAvailableColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectRelationshipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolButtonUpload = new System.Windows.Forms.ToolStripButton();
            this.toolStripMenuItemUploadMultiple = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUploadSingle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownUpload = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolButtonDownload = new System.Windows.Forms.ToolStripButton();
            this.toolButtonLoadTemplates = new System.Windows.Forms.ToolStripButton();
            this.toolButtonCloseTab = new System.Windows.Forms.ToolStripButton();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.labelInstructions = new System.Windows.Forms.Label();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUpdateLocalWordTemplate = new System.Windows.Forms.ToolStripButton();
            this.panelSplitter.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTipInstructions
            // 
            this.toolTipInstructions.ToolTipTitle = "Instructions";
            // 
            // colHeadModifiedOn
            // 
            this.colHeadModifiedOn.Tag = "ModifiedOn";
            this.colHeadModifiedOn.Text = "Modified On";
            this.colHeadModifiedOn.Width = 120;
            // 
            // colHeadCreatedOn
            // 
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
            // splitterMain
            // 
            this.splitterMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterMain.Location = new System.Drawing.Point(1036, 0);
            this.splitterMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitterMain.Name = "splitterMain";
            this.splitterMain.Size = new System.Drawing.Size(21, 754);
            this.splitterMain.TabIndex = 6;
            this.splitterMain.TabStop = false;
            // 
            // propertyGridDetails
            // 
            this.propertyGridDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.propertyGridDetails.LineColor = System.Drawing.SystemColors.ControlDark;
            this.propertyGridDetails.Location = new System.Drawing.Point(1057, 0);
            this.propertyGridDetails.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.propertyGridDetails.Name = "propertyGridDetails";
            this.propertyGridDetails.Size = new System.Drawing.Size(824, 754);
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
            listViewGroup3.Header = "Microsoft Word";
            listViewGroup3.Name = "Microsoft Word";
            listViewGroup3.Tag = "Microsoft Word";
            listViewGroup4.Header = "Microsoft Excel";
            listViewGroup4.Name = "Microsoft Excel";
            listViewGroup4.Tag = "Microsoft Excel";
            this.listViewDocumentTemplates.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3,
            listViewGroup4});
            this.listViewDocumentTemplates.HideSelection = false;
            this.listViewDocumentTemplates.Location = new System.Drawing.Point(0, 0);
            this.listViewDocumentTemplates.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewDocumentTemplates.Name = "listViewDocumentTemplates";
            this.listViewDocumentTemplates.Size = new System.Drawing.Size(1881, 754);
            this.listViewDocumentTemplates.TabIndex = 4;
            this.listViewDocumentTemplates.Tag = "0";
            this.listViewDocumentTemplates.UseCompatibleStateImageBehavior = false;
            this.listViewDocumentTemplates.View = System.Windows.Forms.View.Details;
            this.listViewDocumentTemplates.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewDocumentTemplates_ColumnClick);
            this.listViewDocumentTemplates.SelectedIndexChanged += new System.EventHandler(this.listViewDocumentTemplates_SelectedIndexChanged);
            this.listViewDocumentTemplates.DoubleClick += new System.EventHandler(this.listViewDocumentTemplates_DoubleClick);
            this.listViewDocumentTemplates.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewDocumentTemplates_KeyDown);
            // 
            // colHeadEntityName
            // 
            this.colHeadEntityName.Tag = "Associated Entity";
            this.colHeadEntityName.Text = "Associated Entity";
            this.colHeadEntityName.Width = 200;
            // 
            // panelSplitter
            // 
            this.panelSplitter.Controls.Add(this.splitterMain);
            this.panelSplitter.Controls.Add(this.propertyGridDetails);
            this.panelSplitter.Controls.Add(this.listViewDocumentTemplates);
            this.panelSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSplitter.Location = new System.Drawing.Point(0, 0);
            this.panelSplitter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelSplitter.Name = "panelSplitter";
            this.panelSplitter.Size = new System.Drawing.Size(1881, 754);
            this.panelSplitter.TabIndex = 6;
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
            // toolStripMenuItemDeactivateTemplates
            // 
            this.toolStripMenuItemDeactivateTemplates.Enabled = false;
            this.toolStripMenuItemDeactivateTemplates.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemDeactivateTemplates.Image")));
            this.toolStripMenuItemDeactivateTemplates.Name = "toolStripMenuItemDeactivateTemplates";
            this.toolStripMenuItemDeactivateTemplates.Size = new System.Drawing.Size(317, 34);
            this.toolStripMenuItemDeactivateTemplates.Text = "Deactivate Template(s)";
            this.toolStripMenuItemDeactivateTemplates.Click += new System.EventHandler(this.toolStripMenuItemDeactivateTemplates_Click);
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
            this.toolButtonUpload.Size = new System.Drawing.Size(184, 29);
            this.toolButtonUpload.Text = "Upload Template(s)";
            this.toolButtonUpload.ToolTipText = "Upload new Template Document and replace existing Template Content";
            this.toolButtonUpload.Visible = false;
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
            // toolStripMenuItemUploadSingle
            // 
            this.toolStripMenuItemUploadSingle.Enabled = false;
            this.toolStripMenuItemUploadSingle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemUploadSingle.Image")));
            this.toolStripMenuItemUploadSingle.Name = "toolStripMenuItemUploadSingle";
            this.toolStripMenuItemUploadSingle.Size = new System.Drawing.Size(241, 34);
            this.toolStripMenuItemUploadSingle.Text = "Upload Single";
            this.toolStripMenuItemUploadSingle.Click += new System.EventHandler(this.toolStripMenuItemUploadSingle_Click);
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
            // 
            // toolButtonDownload
            // 
            this.toolButtonDownload.Enabled = false;
            this.toolButtonDownload.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonDownload.Image")));
            this.toolButtonDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonDownload.Name = "toolButtonDownload";
            this.toolButtonDownload.Size = new System.Drawing.Size(208, 29);
            this.toolButtonDownload.Text = "Download Template(s)";
            this.toolButtonDownload.Click += new System.EventHandler(this.toolButtonDownload_Click);
            // 
            // toolButtonLoadTemplates
            // 
            this.toolButtonLoadTemplates.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonLoadTemplates.Image")));
            this.toolButtonLoadTemplates.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonLoadTemplates.Name = "toolButtonLoadTemplates";
            this.toolButtonLoadTemplates.Size = new System.Drawing.Size(155, 29);
            this.toolButtonLoadTemplates.Text = "Load Templates";
            this.toolButtonLoadTemplates.ToolTipText = "Load / Reload Templates from the server";
            this.toolButtonLoadTemplates.Click += new System.EventHandler(this.toolButtonLoadTemplates_Click);
            // 
            // toolButtonCloseTab
            // 
            this.toolButtonCloseTab.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonCloseTab.Image")));
            this.toolButtonCloseTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonCloseTab.Name = "toolButtonCloseTab";
            this.toolButtonCloseTab.Size = new System.Drawing.Size(107, 29);
            this.toolButtonCloseTab.Text = "Close Tab";
            this.toolButtonCloseTab.Click += new System.EventHandler(this.toolButtonCloseTab_Click);
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolButtonCloseTab,
            this.toolButtonLoadTemplates,
            this.toolButtonDownload,
            this.toolStripDropDownUpload,
            this.toolStripDropDownOther,
            this.toolButtonUpload,
            this.toolStripSeparator2,
            this.tsbUpdateLocalWordTemplate});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStripMain.Size = new System.Drawing.Size(1881, 34);
            this.toolStripMain.TabIndex = 0;
            this.toolStripMain.Text = "Main";
            // 
            // labelInstructions
            // 
            this.labelInstructions.BackColor = System.Drawing.SystemColors.Info;
            this.labelInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInstructions.Location = new System.Drawing.Point(0, 0);
            this.labelInstructions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInstructions.Name = "labelInstructions";
            this.labelInstructions.Size = new System.Drawing.Size(1881, 261);
            this.labelInstructions.TabIndex = 5;
            this.labelInstructions.Text = resources.GetString("labelInstructions.Text");
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 34);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.panelSplitter);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.labelInstructions);
            this.scMain.Size = new System.Drawing.Size(1881, 1019);
            this.scMain.SplitterDistance = 754;
            this.scMain.TabIndex = 7;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 34);
            // 
            // tsbUpdateLocalWordTemplate
            // 
            this.tsbUpdateLocalWordTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbUpdateLocalWordTemplate.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpdateLocalWordTemplate.Image")));
            this.tsbUpdateLocalWordTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdateLocalWordTemplate.Name = "tsbUpdateLocalWordTemplate";
            this.tsbUpdateLocalWordTemplate.Size = new System.Drawing.Size(240, 29);
            this.tsbUpdateLocalWordTemplate.Text = "Update local Word Template";
            this.tsbUpdateLocalWordTemplate.Click += new System.EventHandler(this.tsbUpdateLocalWordTemplate_Click);
            // 
            // DocTemplateManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.toolStripMain);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DocTemplateManagerControl";
            this.Size = new System.Drawing.Size(1881, 1053);
            this.panelSplitter.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolTip toolTipInstructions;
        private ColumnHeader colHeadModifiedOn;
        private ColumnHeader colHeadCreatedOn;
        private ColumnHeader colHeadStatus;
        private ColumnHeader colHeadName;
        private Splitter splitterMain;
        private PropertyGrid propertyGridDetails;
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
        private Label labelInstructions;
        private SplitContainer scMain;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbUpdateLocalWordTemplate;
    }
}
