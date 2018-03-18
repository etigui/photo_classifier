namespace PhotosFinder {
    partial class ImportExport {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportExport));
            this.TC_switch = new System.Windows.Forms.TabControl();
            this.TP_import = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_photo_import = new System.Windows.Forms.TextBox();
            this.BT_database_import = new System.Windows.Forms.Button();
            this.TB_database_import = new System.Windows.Forms.TextBox();
            this.BT_photo_import = new System.Windows.Forms.Button();
            this.BT_import = new System.Windows.Forms.Button();
            this.TP_export = new System.Windows.Forms.TabPage();
            this.TB_dest = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BT_dest = new System.Windows.Forms.Button();
            this.CB_zip = new System.Windows.Forms.CheckBox();
            this.TB_photo_export = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BT_photo_export = new System.Windows.Forms.Button();
            this.BT_export = new System.Windows.Forms.Button();
            this.TC_switch.SuspendLayout();
            this.TP_import.SuspendLayout();
            this.TP_export.SuspendLayout();
            this.SuspendLayout();
            // 
            // TC_switch
            // 
            this.TC_switch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TC_switch.Controls.Add(this.TP_import);
            this.TC_switch.Controls.Add(this.TP_export);
            this.TC_switch.Location = new System.Drawing.Point(-4, 2);
            this.TC_switch.Name = "TC_switch";
            this.TC_switch.SelectedIndex = 0;
            this.TC_switch.Size = new System.Drawing.Size(473, 221);
            this.TC_switch.TabIndex = 2;
            this.TC_switch.SelectedIndexChanged += new System.EventHandler(this.TC_switch_SelectedIndexChanged);
            // 
            // TP_import
            // 
            this.TP_import.Controls.Add(this.label4);
            this.TP_import.Controls.Add(this.label1);
            this.TP_import.Controls.Add(this.TB_photo_import);
            this.TP_import.Controls.Add(this.BT_database_import);
            this.TP_import.Controls.Add(this.TB_database_import);
            this.TP_import.Controls.Add(this.BT_photo_import);
            this.TP_import.Controls.Add(this.BT_import);
            this.TP_import.Location = new System.Drawing.Point(4, 25);
            this.TP_import.Name = "TP_import";
            this.TP_import.Padding = new System.Windows.Forms.Padding(3);
            this.TP_import.Size = new System.Drawing.Size(465, 192);
            this.TP_import.TabIndex = 0;
            this.TP_import.Text = "Import";
            this.TP_import.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "Select photo directory:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Select database:";
            // 
            // TB_photo_import
            // 
            this.TB_photo_import.Location = new System.Drawing.Point(34, 103);
            this.TB_photo_import.Name = "TB_photo_import";
            this.TB_photo_import.Size = new System.Drawing.Size(292, 22);
            this.TB_photo_import.TabIndex = 22;
            this.TB_photo_import.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_photo_import_KeyPress);
            // 
            // BT_database_import
            // 
            this.BT_database_import.Location = new System.Drawing.Point(333, 37);
            this.BT_database_import.Margin = new System.Windows.Forms.Padding(4);
            this.BT_database_import.Name = "BT_database_import";
            this.BT_database_import.Size = new System.Drawing.Size(100, 28);
            this.BT_database_import.TabIndex = 20;
            this.BT_database_import.Text = "Open";
            this.BT_database_import.UseVisualStyleBackColor = true;
            this.BT_database_import.Click += new System.EventHandler(this.BT_database_import_Click);
            // 
            // TB_database_import
            // 
            this.TB_database_import.Location = new System.Drawing.Point(34, 40);
            this.TB_database_import.Name = "TB_database_import";
            this.TB_database_import.Size = new System.Drawing.Size(292, 22);
            this.TB_database_import.TabIndex = 13;
            this.TB_database_import.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_database_import_KeyPress);
            // 
            // BT_photo_import
            // 
            this.BT_photo_import.Location = new System.Drawing.Point(333, 100);
            this.BT_photo_import.Margin = new System.Windows.Forms.Padding(4);
            this.BT_photo_import.Name = "BT_photo_import";
            this.BT_photo_import.Size = new System.Drawing.Size(100, 28);
            this.BT_photo_import.TabIndex = 11;
            this.BT_photo_import.Text = "Open";
            this.BT_photo_import.UseVisualStyleBackColor = true;
            this.BT_photo_import.Click += new System.EventHandler(this.BT_photo_import_Click);
            // 
            // BT_import
            // 
            this.BT_import.Location = new System.Drawing.Point(183, 146);
            this.BT_import.Margin = new System.Windows.Forms.Padding(4);
            this.BT_import.Name = "BT_import";
            this.BT_import.Size = new System.Drawing.Size(100, 28);
            this.BT_import.TabIndex = 10;
            this.BT_import.Text = "Import";
            this.BT_import.UseVisualStyleBackColor = true;
            this.BT_import.Click += new System.EventHandler(this.BT_import_Click);
            // 
            // TP_export
            // 
            this.TP_export.Controls.Add(this.TB_dest);
            this.TP_export.Controls.Add(this.label5);
            this.TP_export.Controls.Add(this.BT_dest);
            this.TP_export.Controls.Add(this.CB_zip);
            this.TP_export.Controls.Add(this.TB_photo_export);
            this.TP_export.Controls.Add(this.label3);
            this.TP_export.Controls.Add(this.BT_photo_export);
            this.TP_export.Controls.Add(this.BT_export);
            this.TP_export.Location = new System.Drawing.Point(4, 25);
            this.TP_export.Name = "TP_export";
            this.TP_export.Padding = new System.Windows.Forms.Padding(3);
            this.TP_export.Size = new System.Drawing.Size(465, 192);
            this.TP_export.TabIndex = 1;
            this.TP_export.Text = "Export";
            this.TP_export.UseVisualStyleBackColor = true;
            // 
            // TB_dest
            // 
            this.TB_dest.Location = new System.Drawing.Point(34, 103);
            this.TB_dest.Name = "TB_dest";
            this.TB_dest.Size = new System.Drawing.Size(292, 22);
            this.TB_dest.TabIndex = 23;
            this.TB_dest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_dest_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "Select destination:";
            // 
            // BT_dest
            // 
            this.BT_dest.Location = new System.Drawing.Point(333, 100);
            this.BT_dest.Margin = new System.Windows.Forms.Padding(4);
            this.BT_dest.Name = "BT_dest";
            this.BT_dest.Size = new System.Drawing.Size(100, 28);
            this.BT_dest.TabIndex = 21;
            this.BT_dest.Text = "Open";
            this.BT_dest.UseVisualStyleBackColor = true;
            this.BT_dest.Click += new System.EventHandler(this.BT_dest_Click);
            // 
            // CB_zip
            // 
            this.CB_zip.AutoSize = true;
            this.CB_zip.Location = new System.Drawing.Point(255, 151);
            this.CB_zip.Name = "CB_zip";
            this.CB_zip.Size = new System.Drawing.Size(71, 21);
            this.CB_zip.TabIndex = 20;
            this.CB_zip.Text = "As ZIP";
            this.CB_zip.UseVisualStyleBackColor = true;
            // 
            // TB_photo_export
            // 
            this.TB_photo_export.Location = new System.Drawing.Point(34, 40);
            this.TB_photo_export.Name = "TB_photo_export";
            this.TB_photo_export.Size = new System.Drawing.Size(292, 22);
            this.TB_photo_export.TabIndex = 19;
            this.TB_photo_export.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_photo_export_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Select photo directory:";
            // 
            // BT_photo_export
            // 
            this.BT_photo_export.Location = new System.Drawing.Point(333, 37);
            this.BT_photo_export.Margin = new System.Windows.Forms.Padding(4);
            this.BT_photo_export.Name = "BT_photo_export";
            this.BT_photo_export.Size = new System.Drawing.Size(100, 28);
            this.BT_photo_export.TabIndex = 17;
            this.BT_photo_export.Text = "Open";
            this.BT_photo_export.UseVisualStyleBackColor = true;
            this.BT_photo_export.Click += new System.EventHandler(this.BT_photo_export_Click);
            // 
            // BT_export
            // 
            this.BT_export.Location = new System.Drawing.Point(148, 146);
            this.BT_export.Margin = new System.Windows.Forms.Padding(4);
            this.BT_export.Name = "BT_export";
            this.BT_export.Size = new System.Drawing.Size(100, 28);
            this.BT_export.TabIndex = 11;
            this.BT_export.Text = "Export";
            this.BT_export.UseVisualStyleBackColor = true;
            this.BT_export.Click += new System.EventHandler(this.BT_export_Click);
            // 
            // ImportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 219);
            this.Controls.Add(this.TC_switch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PF - Import/Export";
            this.TC_switch.ResumeLayout(false);
            this.TP_import.ResumeLayout(false);
            this.TP_import.PerformLayout();
            this.TP_export.ResumeLayout(false);
            this.TP_export.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TC_switch;
        private System.Windows.Forms.TabPage TP_import;
        private System.Windows.Forms.TabPage TP_export;
        private System.Windows.Forms.Button BT_import;
        private System.Windows.Forms.Button BT_export;
        private System.Windows.Forms.TextBox TB_database_import;
        private System.Windows.Forms.Button BT_photo_import;
        private System.Windows.Forms.TextBox TB_photo_export;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BT_photo_export;
        private System.Windows.Forms.CheckBox CB_zip;
        private System.Windows.Forms.TextBox TB_photo_import;
        private System.Windows.Forms.Button BT_database_import;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_dest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BT_dest;
    }
}