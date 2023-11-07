
namespace Futurez.Xrm.Tools
{
    partial class RelationshipSelectionDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvManyToMany = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvOneToMany = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbManyToMany = new System.Windows.Forms.GroupBox();
            this.gbManyToOne = new System.Windows.Forms.GroupBox();
            this.lvManyToOne = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbOneToMany = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gbManyToMany.SuspendLayout();
            this.gbManyToOne.SuspendLayout();
            this.gbOneToMany.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Table";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            this.columnHeader5.Width = 200;
            // 
            // lvManyToMany
            // 
            this.lvManyToMany.CheckBoxes = true;
            this.lvManyToMany.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lvManyToMany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvManyToMany.HideSelection = false;
            this.lvManyToMany.Location = new System.Drawing.Point(3, 22);
            this.lvManyToMany.Name = "lvManyToMany";
            this.lvManyToMany.Size = new System.Drawing.Size(458, 534);
            this.lvManyToMany.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvManyToMany.TabIndex = 1;
            this.lvManyToMany.UseCompatibleStateImageBehavior = false;
            this.lvManyToMany.View = System.Windows.Forms.View.Details;
            this.lvManyToMany.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvOneToMany_ColumnClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Table";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 200;
            // 
            // lvOneToMany
            // 
            this.lvOneToMany.CheckBoxes = true;
            this.lvOneToMany.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvOneToMany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOneToMany.HideSelection = false;
            this.lvOneToMany.Location = new System.Drawing.Point(3, 22);
            this.lvOneToMany.Name = "lvOneToMany";
            this.lvOneToMany.Size = new System.Drawing.Size(456, 534);
            this.lvOneToMany.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvOneToMany.TabIndex = 1;
            this.lvOneToMany.UseCompatibleStateImageBehavior = false;
            this.lvOneToMany.View = System.Windows.Forms.View.Details;
            this.lvOneToMany.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvOneToMany_ColumnClick);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Table";
            this.columnHeader4.Width = 100;
            // 
            // gbManyToMany
            // 
            this.gbManyToMany.Controls.Add(this.lvManyToMany);
            this.gbManyToMany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbManyToMany.Location = new System.Drawing.Point(954, 3);
            this.gbManyToMany.Name = "gbManyToMany";
            this.gbManyToMany.Size = new System.Drawing.Size(464, 559);
            this.gbManyToMany.TabIndex = 2;
            this.gbManyToMany.TabStop = false;
            this.gbManyToMany.Text = "Many To Many relationships";
            // 
            // gbManyToOne
            // 
            this.gbManyToOne.Controls.Add(this.lvManyToOne);
            this.gbManyToOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbManyToOne.Location = new System.Drawing.Point(471, 3);
            this.gbManyToOne.Name = "gbManyToOne";
            this.gbManyToOne.Size = new System.Drawing.Size(477, 559);
            this.gbManyToOne.TabIndex = 1;
            this.gbManyToOne.TabStop = false;
            this.gbManyToOne.Text = "Many To One relationships";
            // 
            // lvManyToOne
            // 
            this.lvManyToOne.CheckBoxes = true;
            this.lvManyToOne.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lvManyToOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvManyToOne.HideSelection = false;
            this.lvManyToOne.Location = new System.Drawing.Point(3, 22);
            this.lvManyToOne.Name = "lvManyToOne";
            this.lvManyToOne.Size = new System.Drawing.Size(471, 534);
            this.lvManyToOne.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvManyToOne.TabIndex = 2;
            this.lvManyToOne.UseCompatibleStateImageBehavior = false;
            this.lvManyToOne.View = System.Windows.Forms.View.Details;
            this.lvManyToOne.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvOneToMany_ColumnClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 200;
            // 
            // gbOneToMany
            // 
            this.gbOneToMany.Controls.Add(this.lvOneToMany);
            this.gbOneToMany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOneToMany.Location = new System.Drawing.Point(3, 3);
            this.gbOneToMany.Name = "gbOneToMany";
            this.gbOneToMany.Size = new System.Drawing.Size(462, 559);
            this.gbOneToMany.TabIndex = 0;
            this.gbOneToMany.TabStop = false;
            this.gbOneToMany.Text = "One To Many relationships";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.Controls.Add(this.gbManyToMany, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbManyToOne, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbOneToMany, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 135);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1421, 565);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.button1);
            this.pnlBottom.Controls.Add(this.button2);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 700);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1421, 55);
            this.pnlBottom.TabIndex = 4;
            // 
            // pnlTop
            // 
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1421, 135);
            this.pnlTop.TabIndex = 3;
            this.pnlTop.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(1241, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 34);
            this.button1.TabIndex = 11;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(1331, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 34);
            this.button2.TabIndex = 10;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // RelationshipSelectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 755);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "RelationshipSelectionDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Relationship Selection";
            this.gbManyToMany.ResumeLayout(false);
            this.gbManyToOne.ResumeLayout(false);
            this.gbOneToMany.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView lvManyToMany;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lvOneToMany;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox gbManyToMany;
        private System.Windows.Forms.GroupBox gbManyToOne;
        private System.Windows.Forms.ListView lvManyToOne;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox gbOneToMany;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}