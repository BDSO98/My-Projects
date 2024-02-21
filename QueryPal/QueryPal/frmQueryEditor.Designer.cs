namespace QueryPal
{
    partial class frmQueryEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQueryEditor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnConfirmar = new System.Windows.Forms.ToolStripButton();
            this.txtQueryEditor = new FastColoredTextBoxNS.FastColoredTextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQueryEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConfirmar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1179, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmar.Image")));
            this.btnConfirmar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(144, 29);
            this.btnConfirmar.Text = "Save and Exit";
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtQueryEditor
            // 
            this.txtQueryEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQueryEditor.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtQueryEditor.AutoScrollMinSize = new System.Drawing.Size(35, 22);
            this.txtQueryEditor.BackBrush = null;
            this.txtQueryEditor.CharHeight = 22;
            this.txtQueryEditor.CharWidth = 12;
            this.txtQueryEditor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtQueryEditor.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtQueryEditor.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.txtQueryEditor.IsReplaceMode = false;
            this.txtQueryEditor.Location = new System.Drawing.Point(12, 41);
            this.txtQueryEditor.Name = "txtQueryEditor";
            this.txtQueryEditor.Paddings = new System.Windows.Forms.Padding(0);
            this.txtQueryEditor.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtQueryEditor.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtQueryEditor.ServiceColors")));
            this.txtQueryEditor.Size = new System.Drawing.Size(1167, 632);
            this.txtQueryEditor.TabIndex = 2;
            this.txtQueryEditor.Zoom = 100;
            this.txtQueryEditor.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.txtQueryEditor_TextChanged);
            // 
            // frmQueryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 667);
            this.Controls.Add(this.txtQueryEditor);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmQueryEditor";
            this.Text = "Query Editor";
            this.Load += new System.EventHandler(this.frmQueryEditor_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQueryEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnConfirmar;
        private FastColoredTextBoxNS.FastColoredTextBox txtQueryEditor;
    }
}