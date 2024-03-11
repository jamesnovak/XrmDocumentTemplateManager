
namespace Futurez.Xrm.Tools.UserControls
{
    partial class TemplateActionsControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHElp = new System.Windows.Forms.Panel();
            this.lblHelp = new System.Windows.Forms.Label();
            this.pbHelp = new System.Windows.Forms.PictureBox();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.gbUpload = new System.Windows.Forms.GroupBox();
            this.lblUpload = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRelationships = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnDisable = new System.Windows.Forms.Button();
            this.btnEnable = new System.Windows.Forms.Button();
            this.pnlSpacer2 = new System.Windows.Forms.Panel();
            this.pnlHElp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.gbUpload.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHElp
            // 
            this.pnlHElp.BackColor = System.Drawing.SystemColors.Info;
            this.pnlHElp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHElp.Controls.Add(this.lblHelp);
            this.pnlHElp.Controls.Add(this.pbHelp);
            this.pnlHElp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHElp.Location = new System.Drawing.Point(0, 536);
            this.pnlHElp.Name = "pnlHElp";
            this.pnlHElp.Size = new System.Drawing.Size(747, 279);
            this.pnlHElp.TabIndex = 0;
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHelp.Location = new System.Drawing.Point(75, 0);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Padding = new System.Windows.Forms.Padding(10);
            this.lblHelp.Size = new System.Drawing.Size(945, 60);
            this.lblHelp.TabIndex = 1;
            this.lblHelp.Text = "Choose one of the above action to act on the selected template or upload document" +
    "s";
            // 
            // pbHelp
            // 
            this.pbHelp.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbHelp.Image = global::Futurez.Xrm.Tools.Properties.Resources.info;
            this.pbHelp.Location = new System.Drawing.Point(0, 0);
            this.pbHelp.Name = "pbHelp";
            this.pbHelp.Size = new System.Drawing.Size(75, 277);
            this.pbHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbHelp.TabIndex = 0;
            this.pbHelp.TabStop = false;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.gbUpload, 0, 3);
            this.tlpMain.Controls.Add(this.btnRefresh, 0, 2);
            this.tlpMain.Controls.Add(this.btnRelationships, 0, 2);
            this.tlpMain.Controls.Add(this.btnDelete, 1, 1);
            this.tlpMain.Controls.Add(this.btnDownload, 0, 1);
            this.tlpMain.Controls.Add(this.btnDisable, 1, 0);
            this.tlpMain.Controls.Add(this.btnEnable, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(747, 513);
            this.tlpMain.TabIndex = 2;
            // 
            // gbUpload
            // 
            this.tlpMain.SetColumnSpan(this.gbUpload, 2);
            this.gbUpload.Controls.Add(this.lblUpload);
            this.gbUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbUpload.Location = new System.Drawing.Point(3, 363);
            this.gbUpload.Name = "gbUpload";
            this.gbUpload.Size = new System.Drawing.Size(741, 147);
            this.gbUpload.TabIndex = 7;
            this.gbUpload.TabStop = false;
            this.gbUpload.Text = "Upload";
            // 
            // lblUpload
            // 
            this.lblUpload.AllowDrop = true;
            this.lblUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpload.Location = new System.Drawing.Point(3, 22);
            this.lblUpload.Name = "lblUpload";
            this.lblUpload.Size = new System.Drawing.Size(735, 122);
            this.lblUpload.TabIndex = 0;
            this.lblUpload.Text = "Drag and drop files here or click here to upload document";
            this.lblUpload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUpload.Click += new System.EventHandler(this.lblUpload_Click);
            this.lblUpload.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblUpload_DragDrop);
            this.lblUpload.DragOver += new System.Windows.Forms.DragEventHandler(this.lblUpload_DragOver);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::Futurez.Xrm.Tools.Properties.Resources.Refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.Location = new System.Drawing.Point(3, 243);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(367, 114);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh columns";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnRelationships
            // 
            this.btnRelationships.BackgroundImage = global::Futurez.Xrm.Tools.Properties.Resources.sitemap;
            this.btnRelationships.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRelationships.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRelationships.Location = new System.Drawing.Point(376, 243);
            this.btnRelationships.Name = "btnRelationships";
            this.btnRelationships.Size = new System.Drawing.Size(368, 114);
            this.btnRelationships.TabIndex = 4;
            this.btnRelationships.Text = "Manage relationships";
            this.btnRelationships.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRelationships.UseVisualStyleBackColor = true;
            this.btnRelationships.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::Futurez.Xrm.Tools.Properties.Resources.Uninstall;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Location = new System.Drawing.Point(376, 123);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(368, 114);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.BackgroundImage = global::Futurez.Xrm.Tools.Properties.Resources.Install32;
            this.btnDownload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDownload.Location = new System.Drawing.Point(3, 123);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(367, 114);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "Download";
            this.btnDownload.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnDisable
            // 
            this.btnDisable.BackgroundImage = global::Futurez.Xrm.Tools.Properties.Resources.No32;
            this.btnDisable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDisable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDisable.Location = new System.Drawing.Point(376, 3);
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Size = new System.Drawing.Size(368, 114);
            this.btnDisable.TabIndex = 1;
            this.btnDisable.Text = "Disable";
            this.btnDisable.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDisable.UseVisualStyleBackColor = true;
            this.btnDisable.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnEnable
            // 
            this.btnEnable.BackgroundImage = global::Futurez.Xrm.Tools.Properties.Resources.Success32;
            this.btnEnable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEnable.Location = new System.Drawing.Point(3, 3);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(367, 114);
            this.btnEnable.TabIndex = 0;
            this.btnEnable.Text = "Enable";
            this.btnEnable.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnable.UseVisualStyleBackColor = true;
            this.btnEnable.Click += new System.EventHandler(this.btn_Click);
            // 
            // pnlSpacer2
            // 
            this.pnlSpacer2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSpacer2.Location = new System.Drawing.Point(0, 513);
            this.pnlSpacer2.Name = "pnlSpacer2";
            this.pnlSpacer2.Size = new System.Drawing.Size(747, 23);
            this.pnlSpacer2.TabIndex = 3;
            // 
            // TemplateActionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.pnlSpacer2);
            this.Controls.Add(this.pnlHElp);
            this.Name = "TemplateActionsControl";
            this.Size = new System.Drawing.Size(747, 815);
            this.Resize += new System.EventHandler(this.TemplateActionsControl_Resize);
            this.pnlHElp.ResumeLayout(false);
            this.pnlHElp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.gbUpload.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHElp;
        private System.Windows.Forms.PictureBox pbHelp;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnDisable;
        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnRelationships;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.GroupBox gbUpload;
        private System.Windows.Forms.Label lblUpload;
        private System.Windows.Forms.Panel pnlSpacer2;
    }
}
