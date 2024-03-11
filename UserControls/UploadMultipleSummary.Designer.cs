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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Create Template", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Update Template", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Ignore File", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadMultipleSummary));
            this.listViewFileUploadSummary = new System.Windows.Forms.ListView();
            this.columnHeaderFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTemplateType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTemplateName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNote = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelInstructions = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBotom = new System.Windows.Forms.Panel();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTop.SuspendLayout();
            this.pnlBotom.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlMain.SuspendLayout();
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
            listViewGroup1.Header = "Create Template";
            listViewGroup1.Name = "listViewGroupCreate";
            listViewGroup2.Header = "Update Template";
            listViewGroup2.Name = "listViewGroupUpdate";
            listViewGroup3.Header = "Ignore File";
            listViewGroup3.Name = "listViewGroupIgnore";
            this.listViewFileUploadSummary.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.listViewFileUploadSummary.HideSelection = false;
            this.listViewFileUploadSummary.Location = new System.Drawing.Point(10, 10);
            this.listViewFileUploadSummary.Margin = new System.Windows.Forms.Padding(14, 15, 14, 15);
            this.listViewFileUploadSummary.Name = "listViewFileUploadSummary";
            this.listViewFileUploadSummary.Size = new System.Drawing.Size(1043, 541);
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
            this.labelInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInstructions.Location = new System.Drawing.Point(10, 10);
            this.labelInstructions.Margin = new System.Windows.Forms.Padding(14, 15, 14, 15);
            this.labelInstructions.Name = "labelInstructions";
            this.labelInstructions.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelInstructions.Size = new System.Drawing.Size(1043, 86);
            this.labelInstructions.TabIndex = 1;
            this.labelInstructions.Text = resources.GetString("labelInstructions.Text");
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCancel.Location = new System.Drawing.Point(676, 10);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(189, 42);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonOk.Location = new System.Drawing.Point(865, 10);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(188, 42);
            this.buttonOk.TabIndex = 8;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTop.Size = new System.Drawing.Size(1063, 73);
            this.pnlTop.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Text", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Multiple Upload  Summary";
            // 
            // pnlBotom
            // 
            this.pnlBotom.Controls.Add(this.buttonCancel);
            this.pnlBotom.Controls.Add(this.buttonOk);
            this.pnlBotom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotom.Location = new System.Drawing.Point(0, 740);
            this.pnlBotom.Name = "pnlBotom";
            this.pnlBotom.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBotom.Size = new System.Drawing.Size(1063, 62);
            this.pnlBotom.TabIndex = 12;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.labelInstructions);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 73);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Padding = new System.Windows.Forms.Padding(10);
            this.pnlInfo.Size = new System.Drawing.Size(1063, 106);
            this.pnlInfo.TabIndex = 13;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.listViewFileUploadSummary);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 179);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(1063, 561);
            this.pnlMain.TabIndex = 14;
            // 
            // UploadMultipleSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlBotom);
            this.Controls.Add(this.pnlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UploadMultipleSummary";
            this.Size = new System.Drawing.Size(1063, 802);
            this.Load += new System.EventHandler(this.UploadMultipleSummary_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBotom.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
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
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlBotom;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Panel pnlMain;
    }
}
