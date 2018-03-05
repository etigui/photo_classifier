namespace PhotosFinder {
    partial class PF {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PF));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_value2 = new System.Windows.Forms.ComboBox();
            this.CB_type2 = new System.Windows.Forms.ComboBox();
            this.CB_value1 = new System.Windows.Forms.ComboBox();
            this.CB_type1 = new System.Windows.Forms.ComboBox();
            this.TS_action = new System.Windows.Forms.ToolStrip();
            this.TSB_left = new System.Windows.Forms.ToolStripButton();
            this.TSB_right = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_thumbnails = new System.Windows.Forms.ToolStripButton();
            this.TSB_gallery = new System.Windows.Forms.ToolStripButton();
            this.TSB_pane = new System.Windows.Forms.ToolStripButton();
            this.TSB_list = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_info = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TSDDB_size = new System.Windows.Forms.ToolStripDropDownButton();
            this.x48ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x96ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x120ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x150ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x200ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BT_reset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.TS_action.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 34);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(800, 567);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BT_reset);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CB_value2);
            this.groupBox1.Controls.Add(this.CB_type2);
            this.groupBox1.Controls.Add(this.CB_value1);
            this.groupBox1.Controls.Add(this.CB_type1);
            this.groupBox1.Location = new System.Drawing.Point(818, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 218);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Value:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Value:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "AND";
            // 
            // CB_value2
            // 
            this.CB_value2.Enabled = false;
            this.CB_value2.FormattingEnabled = true;
            this.CB_value2.Location = new System.Drawing.Point(59, 123);
            this.CB_value2.Name = "CB_value2";
            this.CB_value2.Size = new System.Drawing.Size(104, 21);
            this.CB_value2.Sorted = true;
            this.CB_value2.TabIndex = 3;
            this.CB_value2.Text = "Select a value";
            this.CB_value2.SelectedIndexChanged += new System.EventHandler(this.CB_value2_SelectedIndexChanged);
            this.CB_value2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CB_value2_KeyPress);
            // 
            // CB_type2
            // 
            this.CB_type2.Enabled = false;
            this.CB_type2.FormattingEnabled = true;
            this.CB_type2.Items.AddRange(new object[] {
            "Age",
            "Emotion",
            "Smile",
            "Tag"});
            this.CB_type2.Location = new System.Drawing.Point(59, 96);
            this.CB_type2.Name = "CB_type2";
            this.CB_type2.Size = new System.Drawing.Size(104, 21);
            this.CB_type2.Sorted = true;
            this.CB_type2.TabIndex = 2;
            this.CB_type2.Text = "Select a type";
            this.CB_type2.SelectedIndexChanged += new System.EventHandler(this.CB_type2_SelectedIndexChanged);
            this.CB_type2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CB_type2_KeyPress);
            // 
            // CB_value1
            // 
            this.CB_value1.FormattingEnabled = true;
            this.CB_value1.Location = new System.Drawing.Point(59, 56);
            this.CB_value1.Name = "CB_value1";
            this.CB_value1.Size = new System.Drawing.Size(104, 21);
            this.CB_value1.Sorted = true;
            this.CB_value1.TabIndex = 1;
            this.CB_value1.Text = "Select a value";
            this.CB_value1.SelectedIndexChanged += new System.EventHandler(this.CB_value1_SelectedIndexChanged);
            this.CB_value1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CB_value1_KeyPress);
            // 
            // CB_type1
            // 
            this.CB_type1.FormattingEnabled = true;
            this.CB_type1.Items.AddRange(new object[] {
            "Age",
            "Emotion",
            "Gender",
            "Name",
            "Smile",
            "Tag"});
            this.CB_type1.Location = new System.Drawing.Point(59, 29);
            this.CB_type1.Name = "CB_type1";
            this.CB_type1.Size = new System.Drawing.Size(104, 21);
            this.CB_type1.Sorted = true;
            this.CB_type1.TabIndex = 0;
            this.CB_type1.Text = "Select a type";
            this.CB_type1.SelectedIndexChanged += new System.EventHandler(this.CB_type1_SelectedIndexChanged);
            this.CB_type1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CB_type1_KeyPress);
            // 
            // TS_action
            // 
            this.TS_action.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TS_action.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSB_left,
            this.TSB_right,
            this.toolStripSeparator7,
            this.TSB_thumbnails,
            this.TSB_gallery,
            this.TSB_pane,
            this.TSB_list,
            this.toolStripSeparator4,
            this.TSB_info,
            this.toolStripSeparator2,
            this.TSDDB_size});
            this.TS_action.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.TS_action.Location = new System.Drawing.Point(0, 0);
            this.TS_action.Name = "TS_action";
            this.TS_action.Size = new System.Drawing.Size(1002, 31);
            this.TS_action.TabIndex = 8;
            this.TS_action.Text = "toolStrip1";
            // 
            // TSB_left
            // 
            this.TSB_left.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_left.Image = ((System.Drawing.Image)(resources.GetObject("TSB_left.Image")));
            this.TSB_left.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSB_left.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_left.Name = "TSB_left";
            this.TSB_left.Size = new System.Drawing.Size(28, 28);
            this.TSB_left.Text = "Rotate left (90°)";
            // 
            // TSB_right
            // 
            this.TSB_right.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_right.Image = ((System.Drawing.Image)(resources.GetObject("TSB_right.Image")));
            this.TSB_right.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSB_right.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_right.Name = "TSB_right";
            this.TSB_right.Size = new System.Drawing.Size(28, 28);
            this.TSB_right.Text = "Rotate right  (90°)";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 31);
            // 
            // TSB_thumbnails
            // 
            this.TSB_thumbnails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_thumbnails.Image = ((System.Drawing.Image)(resources.GetObject("TSB_thumbnails.Image")));
            this.TSB_thumbnails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSB_thumbnails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_thumbnails.Name = "TSB_thumbnails";
            this.TSB_thumbnails.Size = new System.Drawing.Size(28, 28);
            this.TSB_thumbnails.Text = "Thumbnails";
            // 
            // TSB_gallery
            // 
            this.TSB_gallery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_gallery.Image = ((System.Drawing.Image)(resources.GetObject("TSB_gallery.Image")));
            this.TSB_gallery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSB_gallery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_gallery.Name = "TSB_gallery";
            this.TSB_gallery.Size = new System.Drawing.Size(28, 28);
            this.TSB_gallery.Text = "Gallery";
            // 
            // TSB_pane
            // 
            this.TSB_pane.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_pane.Image = ((System.Drawing.Image)(resources.GetObject("TSB_pane.Image")));
            this.TSB_pane.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSB_pane.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_pane.Name = "TSB_pane";
            this.TSB_pane.Size = new System.Drawing.Size(28, 28);
            this.TSB_pane.Text = "Pane";
            // 
            // TSB_list
            // 
            this.TSB_list.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_list.Image = ((System.Drawing.Image)(resources.GetObject("TSB_list.Image")));
            this.TSB_list.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSB_list.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_list.Name = "TSB_list";
            this.TSB_list.Size = new System.Drawing.Size(28, 28);
            this.TSB_list.Text = "List";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // TSB_info
            // 
            this.TSB_info.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_info.Image = ((System.Drawing.Image)(resources.GetObject("TSB_info.Image")));
            this.TSB_info.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSB_info.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_info.Name = "TSB_info";
            this.TSB_info.Size = new System.Drawing.Size(28, 28);
            this.TSB_info.Text = "Columns info";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // TSDDB_size
            // 
            this.TSDDB_size.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSDDB_size.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x48ToolStripMenuItem,
            this.x96ToolStripMenuItem,
            this.x120ToolStripMenuItem,
            this.x150ToolStripMenuItem,
            this.x200ToolStripMenuItem});
            this.TSDDB_size.Image = ((System.Drawing.Image)(resources.GetObject("TSDDB_size.Image")));
            this.TSDDB_size.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSDDB_size.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSDDB_size.Name = "TSDDB_size";
            this.TSDDB_size.Size = new System.Drawing.Size(37, 28);
            this.TSDDB_size.Text = "Photos size";
            // 
            // x48ToolStripMenuItem
            // 
            this.x48ToolStripMenuItem.Name = "x48ToolStripMenuItem";
            this.x48ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.x48ToolStripMenuItem.Text = "48 x 48";
            // 
            // x96ToolStripMenuItem
            // 
            this.x96ToolStripMenuItem.Name = "x96ToolStripMenuItem";
            this.x96ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.x96ToolStripMenuItem.Text = "96 x 96";
            // 
            // x120ToolStripMenuItem
            // 
            this.x120ToolStripMenuItem.Name = "x120ToolStripMenuItem";
            this.x120ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.x120ToolStripMenuItem.Text = "120 x 120";
            // 
            // x150ToolStripMenuItem
            // 
            this.x150ToolStripMenuItem.Name = "x150ToolStripMenuItem";
            this.x150ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.x150ToolStripMenuItem.Text = "150 x 150";
            // 
            // x200ToolStripMenuItem
            // 
            this.x200ToolStripMenuItem.Name = "x200ToolStripMenuItem";
            this.x200ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.x200ToolStripMenuItem.Text = "200 x 200";
            // 
            // BT_reset
            // 
            this.BT_reset.Location = new System.Drawing.Point(72, 171);
            this.BT_reset.Name = "BT_reset";
            this.BT_reset.Size = new System.Drawing.Size(75, 23);
            this.BT_reset.TabIndex = 9;
            this.BT_reset.Text = "Reset";
            this.BT_reset.UseVisualStyleBackColor = true;
            this.BT_reset.Click += new System.EventHandler(this.BT_reset_Click);
            // 
            // PF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 613);
            this.Controls.Add(this.TS_action);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PF";
            this.Text = "Photos Finder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TS_action.ResumeLayout(false);
            this.TS_action.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CB_type1;
        private System.Windows.Forms.ToolStrip TS_action;
        private System.Windows.Forms.ToolStripButton TSB_left;
        private System.Windows.Forms.ToolStripButton TSB_right;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton TSB_thumbnails;
        private System.Windows.Forms.ToolStripButton TSB_gallery;
        private System.Windows.Forms.ToolStripButton TSB_pane;
        private System.Windows.Forms.ToolStripButton TSB_list;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton TSB_info;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton TSDDB_size;
        private System.Windows.Forms.ToolStripMenuItem x48ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x96ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x120ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x150ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x200ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_value2;
        private System.Windows.Forms.ComboBox CB_type2;
        private System.Windows.Forms.ComboBox CB_value1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BT_reset;
    }
}

