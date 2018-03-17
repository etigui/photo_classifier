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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BT_import = new System.Windows.Forms.Button();
            this.BT_export = new System.Windows.Forms.Button();
            this.BT_location_import = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BT_database_export = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BT_photo_export = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-4, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(473, 220);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.BT_location_import);
            this.tabPage1.Controls.Add(this.BT_import);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(465, 191);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Import";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.BT_photo_export);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.BT_database_export);
            this.tabPage2.Controls.Add(this.BT_export);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(465, 191);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Export";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BT_import
            // 
            this.BT_import.Location = new System.Drawing.Point(182, 118);
            this.BT_import.Margin = new System.Windows.Forms.Padding(4);
            this.BT_import.Name = "BT_import";
            this.BT_import.Size = new System.Drawing.Size(100, 28);
            this.BT_import.TabIndex = 10;
            this.BT_import.Text = "Import";
            this.BT_import.UseVisualStyleBackColor = true;
            // 
            // BT_export
            // 
            this.BT_export.Location = new System.Drawing.Point(182, 147);
            this.BT_export.Margin = new System.Windows.Forms.Padding(4);
            this.BT_export.Name = "BT_export";
            this.BT_export.Size = new System.Drawing.Size(100, 28);
            this.BT_export.TabIndex = 11;
            this.BT_export.Text = "Export";
            this.BT_export.UseVisualStyleBackColor = true;
            // 
            // BT_location_import
            // 
            this.BT_location_import.Location = new System.Drawing.Point(333, 61);
            this.BT_location_import.Margin = new System.Windows.Forms.Padding(4);
            this.BT_location_import.Name = "BT_location_import";
            this.BT_location_import.Size = new System.Drawing.Size(100, 28);
            this.BT_location_import.TabIndex = 11;
            this.BT_location_import.Text = "Open";
            this.BT_location_import.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Select Photo Finder location:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(34, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(292, 22);
            this.textBox1.TabIndex = 13;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(34, 35);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(292, 22);
            this.textBox2.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Select database:";
            // 
            // BT_database_export
            // 
            this.BT_database_export.Location = new System.Drawing.Point(333, 32);
            this.BT_database_export.Margin = new System.Windows.Forms.Padding(4);
            this.BT_database_export.Name = "BT_database_export";
            this.BT_database_export.Size = new System.Drawing.Size(100, 28);
            this.BT_database_export.TabIndex = 14;
            this.BT_database_export.Text = "Open";
            this.BT_database_export.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(34, 99);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(292, 22);
            this.textBox3.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Select photo directory:";
            // 
            // BT_photo_export
            // 
            this.BT_photo_export.Location = new System.Drawing.Point(333, 96);
            this.BT_photo_export.Margin = new System.Windows.Forms.Padding(4);
            this.BT_photo_export.Name = "BT_photo_export";
            this.BT_photo_export.Size = new System.Drawing.Size(100, 28);
            this.BT_photo_export.TabIndex = 17;
            this.BT_photo_export.Text = "Open";
            this.BT_photo_export.UseVisualStyleBackColor = true;
            // 
            // ImportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 218);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PF - Import/Export";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button BT_import;
        private System.Windows.Forms.Button BT_export;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_location_import;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BT_photo_export;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BT_database_export;
    }
}