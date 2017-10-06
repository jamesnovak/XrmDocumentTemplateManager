namespace Futurez.Xrm.Tools
{
    partial class UploadMultipleSummary
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
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Create Template", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Update Template", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Ignore File", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadMultipleSummary));
            this.listViewFileUploadSummary = new System.Windows.Forms.ListView();
            this.columnHeaderFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTemplateType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTemplateName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNote = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelInstructions = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelActionButtons = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelActionButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewFileUploadSummary
            // 
            this.listViewFileUploadSummary.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFileName,
            this.columnHeaderTemplateType,
            this.columnHeaderTemplateName,
            this.columnHeaderNote});
            this.listViewFileUploadSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFileUploadSummary.FullRowSelect = true;
            listViewGroup4.Header = "Create Template";
            listViewGroup4.Name = "listViewGroupCreate";
            listViewGroup5.Header = "Update Template";
            listViewGroup5.Name = "listViewGroupUpdate";
            listViewGroup6.Header = "Ignore File";
            listViewGroup6.Name = "listViewGroupIgnore";
            this.listViewFileUploadSummary.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup4,
            listViewGroup5,
            listViewGroup6});
            this.listViewFileUploadSummary.HideSelection = false;
            this.listViewFileUploadSummary.Location = new System.Drawing.Point(12, 97);
            this.listViewFileUploadSummary.Margin = new System.Windows.Forms.Padding(12);
            this.listViewFileUploadSummary.Name = "listViewFileUploadSummary";
            this.listViewFileUploadSummary.Size = new System.Drawing.Size(873, 428);
            this.listViewFileUploadSummary.TabIndex = 0;
            this.listViewFileUploadSummary.UseCompatibleStateImageBehavior = false;
            this.listViewFileUploadSummary.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderFileName
            // 
            this.columnHeaderFileName.Text = "File Name";
            this.columnHeaderFileName.Width = 225;
            // 
            // columnHeaderTemplateType
            // 
            this.columnHeaderTemplateType.Text = "Template Type";
            this.columnHeaderTemplateType.Width = 150;
            // 
            // columnHeaderTemplateName
            // 
            this.columnHeaderTemplateName.Text = "Template Name";
            this.columnHeaderTemplateName.Width = 225;
            // 
            // columnHeaderNote
            // 
            this.columnHeaderNote.Text = "Note";
            this.columnHeaderNote.Width = 250;
            // 
            // labelInstructions
            // 
            this.labelInstructions.BackColor = System.Drawing.SystemColors.Info;
            this.labelInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInstructions.Location = new System.Drawing.Point(12, 12);
            this.labelInstructions.Margin = new System.Windows.Forms.Padding(12);
            this.labelInstructions.Name = "labelInstructions";
            this.labelInstructions.Padding = new System.Windows.Forms.Padding(3);
            this.labelInstructions.Size = new System.Drawing.Size(873, 61);
            this.labelInstructions.TabIndex = 1;
            this.labelInstructions.Text = resources.GetString("labelInstructions.Text");
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(6, 0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 27);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(90, 0);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(74, 27);
            this.buttonOk.TabIndex = 8;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.panelActionButtons, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.listViewFileUploadSummary, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelInstructions, 0, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(25);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(897, 588);
            this.tableLayoutPanelMain.TabIndex = 10;
            // 
            // panelActionButtons
            // 
            this.panelActionButtons.Controls.Add(this.buttonOk);
            this.panelActionButtons.Controls.Add(this.buttonCancel);
            this.panelActionButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelActionButtons.Location = new System.Drawing.Point(721, 549);
            this.panelActionButtons.Margin = new System.Windows.Forms.Padding(12);
            this.panelActionButtons.Name = "panelActionButtons";
            this.panelActionButtons.Size = new System.Drawing.Size(164, 27);
            this.panelActionButtons.TabIndex = 11;
            // 
            // UploadMultipleSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "UploadMultipleSummary";
            this.Size = new System.Drawing.Size(897, 588);
            this.Load += new System.EventHandler(this.UploadMultipleSummary_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panelActionButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewFileUploadSummary;
        private System.Windows.Forms.Label labelInstructions;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ColumnHeader columnHeaderFileName;
        private System.Windows.Forms.ColumnHeader columnHeaderTemplateType;
        private System.Windows.Forms.ColumnHeader columnHeaderTemplateName;
        private System.Windows.Forms.ColumnHeader columnHeaderNote;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Panel panelActionButtons;
    }
}
