namespace QueryPal
{
    partial class frmQueryPal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQueryPal));
            this.label1 = new System.Windows.Forms.Label();
            this.cbInstances = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnFileDialog = new System.Windows.Forms.Button();
            this.clbDatabases = new System.Windows.Forms.CheckedListBox();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.chkViewSystemDbs = new System.Windows.Forms.CheckBox();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbExportResults = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.llQuery = new System.Windows.Forms.LinkLabel();
            this.lblLic = new System.Windows.Forms.Label();
            this.gbFilter.SuspendLayout();
            this.tsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Instance:";
            // 
            // cbInstances
            // 
            this.cbInstances.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbInstances.FormattingEnabled = true;
            this.cbInstances.Location = new System.Drawing.Point(165, 46);
            this.cbInstances.Name = "cbInstances";
            this.cbInstances.Size = new System.Drawing.Size(410, 37);
            this.cbInstances.TabIndex = 1;
            this.cbInstances.SelectedIndexChanged += new System.EventHandler(this.cbInstancias_SelectedIndexChanged);
            this.cbInstances.Click += new System.EventHandler(this.cbInstances_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtQuery
            // 
            this.txtQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuery.Location = new System.Drawing.Point(713, 46);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ReadOnly = true;
            this.txtQuery.Size = new System.Drawing.Size(530, 35);
            this.txtQuery.TabIndex = 3;
            // 
            // btnFileDialog
            // 
            this.btnFileDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileDialog.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnFileDialog.Location = new System.Drawing.Point(1256, 47);
            this.btnFileDialog.Name = "btnFileDialog";
            this.btnFileDialog.Size = new System.Drawing.Size(40, 34);
            this.btnFileDialog.TabIndex = 4;
            this.btnFileDialog.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnFileDialog.UseVisualStyleBackColor = true;
            this.btnFileDialog.Click += new System.EventHandler(this.btnFileDialog_Click);
            // 
            // clbDatabases
            // 
            this.clbDatabases.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbDatabases.FormattingEnabled = true;
            this.clbDatabases.Location = new System.Drawing.Point(51, 204);
            this.clbDatabases.Name = "clbDatabases";
            this.clbDatabases.Size = new System.Drawing.Size(524, 388);
            this.clbDatabases.TabIndex = 5;
            // 
            // txtResults
            // 
            this.txtResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResults.Location = new System.Drawing.Point(627, 202);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ReadOnly = true;
            this.txtResults.Size = new System.Drawing.Size(616, 363);
            this.txtResults.TabIndex = 6;
            this.txtResults.Text = "Results will be displayed here.";
            // 
            // btnExecute
            // 
            this.btnExecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.Image = ((System.Drawing.Image)(resources.GetObject("btnExecute.Image")));
            this.btnExecute.Location = new System.Drawing.Point(592, 609);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(191, 56);
            this.btnExecute.TabIndex = 7;
            this.btnExecute.Text = "Execute";
            this.btnExecute.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.chkViewSystemDbs);
            this.gbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(51, 98);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(1191, 87);
            this.gbFilter.TabIndex = 8;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filters";
            // 
            // chkViewSystemDbs
            // 
            this.chkViewSystemDbs.AutoSize = true;
            this.chkViewSystemDbs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkViewSystemDbs.Location = new System.Drawing.Point(38, 34);
            this.chkViewSystemDbs.Name = "chkViewSystemDbs";
            this.chkViewSystemDbs.Size = new System.Drawing.Size(298, 33);
            this.chkViewSystemDbs.TabIndex = 0;
            this.chkViewSystemDbs.Text = "Show system databases";
            this.chkViewSystemDbs.UseVisualStyleBackColor = true;
            // 
            // tsMenu
            // 
            this.tsMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExportResults});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tsMenu.Size = new System.Drawing.Size(1308, 41);
            this.tsMenu.TabIndex = 9;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsbExportResults
            // 
            this.tsbExportResults.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbExportResults.Image = ((System.Drawing.Image)(resources.GetObject("tsbExportResults.Image")));
            this.tsbExportResults.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportResults.Name = "tsbExportResults";
            this.tsbExportResults.Size = new System.Drawing.Size(190, 36);
            this.tsbExportResults.Text = "Export Results";
            this.tsbExportResults.Click += new System.EventHandler(this.tsbExportResults_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1117, 571);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 113);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // llQuery
            // 
            this.llQuery.AutoSize = true;
            this.llQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llQuery.Location = new System.Drawing.Point(621, 50);
            this.llQuery.Name = "llQuery";
            this.llQuery.Size = new System.Drawing.Size(84, 29);
            this.llQuery.TabIndex = 11;
            this.llQuery.TabStop = true;
            this.llQuery.Text = "Query:";
            this.llQuery.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llQuery_LinkClicked);
            // 
            // lblLic
            // 
            this.lblLic.AutoSize = true;
            this.lblLic.Location = new System.Drawing.Point(47, 630);
            this.lblLic.Name = "lblLic";
            this.lblLic.Size = new System.Drawing.Size(120, 20);
            this.lblLic.TabIndex = 12;
            this.lblLic.Text = "Licença: DEMO";
            // 
            // frmQueryPal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1308, 694);
            this.Controls.Add(this.lblLic);
            this.Controls.Add(this.llQuery);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.clbDatabases);
            this.Controls.Add(this.btnFileDialog);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.cbInstances);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmQueryPal";
            this.Text = "QueryPal for SQL Server";
            this.Load += new System.EventHandler(this.frmQueryPal_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbInstances;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnFileDialog;
        private System.Windows.Forms.CheckedListBox clbDatabases;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.CheckBox chkViewSystemDbs;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbExportResults;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel llQuery;
        private System.Windows.Forms.Label lblLic;
    }
}

