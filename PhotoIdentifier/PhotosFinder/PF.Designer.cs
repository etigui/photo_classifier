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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PF));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BT_reset = new System.Windows.Forms.Button();
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
            this.TSB_thumbnails = new System.Windows.Forms.ToolStripButton();
            this.TSB_gallery = new System.Windows.Forms.ToolStripButton();
            this.TSB_pane = new System.Windows.Forms.ToolStripButton();
            this.TSB_list = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.TSDDB_size = new System.Windows.Forms.ToolStripDropDownButton();
            this.x48ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x96ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x120ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x150ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x200ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ILV_photos = new Manina.Windows.Forms.ImageListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TSSL_infos = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BT_save_all = new System.Windows.Forms.Button();
            this.CMS_action = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ssToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_export = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.TS_action.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.CMS_action.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBox1.Location = new System.Drawing.Point(933, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(235, 242);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // BT_reset
            // 
            this.BT_reset.Location = new System.Drawing.Point(68, 199);
            this.BT_reset.Margin = new System.Windows.Forms.Padding(4);
            this.BT_reset.Name = "BT_reset";
            this.BT_reset.Size = new System.Drawing.Size(100, 28);
            this.BT_reset.TabIndex = 9;
            this.BT_reset.Text = "Reset";
            this.BT_reset.UseVisualStyleBackColor = true;
            this.BT_reset.Click += new System.EventHandler(this.BT_reset_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 155);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Value:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Value:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 122);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "AND";
            // 
            // CB_value2
            // 
            this.CB_value2.Enabled = false;
            this.CB_value2.FormattingEnabled = true;
            this.CB_value2.Location = new System.Drawing.Point(77, 151);
            this.CB_value2.Margin = new System.Windows.Forms.Padding(4);
            this.CB_value2.Name = "CB_value2";
            this.CB_value2.Size = new System.Drawing.Size(137, 24);
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
            "Smile"});
            this.CB_type2.Location = new System.Drawing.Point(77, 118);
            this.CB_type2.Margin = new System.Windows.Forms.Padding(4);
            this.CB_type2.Name = "CB_type2";
            this.CB_type2.Size = new System.Drawing.Size(137, 24);
            this.CB_type2.Sorted = true;
            this.CB_type2.TabIndex = 2;
            this.CB_type2.Text = "Select a type";
            this.CB_type2.SelectedIndexChanged += new System.EventHandler(this.CB_type2_SelectedIndexChanged);
            this.CB_type2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CB_type2_KeyPress);
            // 
            // CB_value1
            // 
            this.CB_value1.FormattingEnabled = true;
            this.CB_value1.Location = new System.Drawing.Point(77, 69);
            this.CB_value1.Margin = new System.Windows.Forms.Padding(4);
            this.CB_value1.Name = "CB_value1";
            this.CB_value1.Size = new System.Drawing.Size(137, 24);
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
            this.CB_type1.Location = new System.Drawing.Point(77, 36);
            this.CB_type1.Margin = new System.Windows.Forms.Padding(4);
            this.CB_type1.Name = "CB_type1";
            this.CB_type1.Size = new System.Drawing.Size(137, 24);
            this.CB_type1.Sorted = true;
            this.CB_type1.TabIndex = 0;
            this.CB_type1.Text = "Select a type";
            this.CB_type1.SelectedIndexChanged += new System.EventHandler(this.CB_type1_SelectedIndexChanged);
            this.CB_type1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CB_type1_KeyPress);
            // 
            // TS_action
            // 
            this.TS_action.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TS_action.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TS_action.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSB_thumbnails,
            this.TSB_gallery,
            this.TSB_pane,
            this.TSB_list,
            this.toolStripSeparator4,
            this.TSDDB_size,
            this.toolStripSeparator1,
            this.TSB_export});
            this.TS_action.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.TS_action.Location = new System.Drawing.Point(0, 0);
            this.TS_action.Name = "TS_action";
            this.TS_action.Size = new System.Drawing.Size(1179, 31);
            this.TS_action.TabIndex = 8;
            this.TS_action.Text = "toolStrip1";
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
            this.TSB_thumbnails.Click += new System.EventHandler(this.TSB_thumbnails_Click);
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
            this.TSB_gallery.Click += new System.EventHandler(this.TSB_gallery_Click);
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
            this.TSB_pane.Click += new System.EventHandler(this.TSB_pane_Click);
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
            this.TSB_list.Click += new System.EventHandler(this.TSB_list_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
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
            this.TSDDB_size.Size = new System.Drawing.Size(38, 28);
            this.TSDDB_size.Text = "Photos size";
            // 
            // x48ToolStripMenuItem
            // 
            this.x48ToolStripMenuItem.Name = "x48ToolStripMenuItem";
            this.x48ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.x48ToolStripMenuItem.Text = "48 x 48";
            this.x48ToolStripMenuItem.Click += new System.EventHandler(this.x48ToolStripMenuItem_Click);
            // 
            // x96ToolStripMenuItem
            // 
            this.x96ToolStripMenuItem.Name = "x96ToolStripMenuItem";
            this.x96ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.x96ToolStripMenuItem.Text = "96 x 96";
            this.x96ToolStripMenuItem.Click += new System.EventHandler(this.x96ToolStripMenuItem_Click);
            // 
            // x120ToolStripMenuItem
            // 
            this.x120ToolStripMenuItem.Name = "x120ToolStripMenuItem";
            this.x120ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.x120ToolStripMenuItem.Text = "120 x 120";
            this.x120ToolStripMenuItem.Click += new System.EventHandler(this.x120ToolStripMenuItem_Click);
            // 
            // x150ToolStripMenuItem
            // 
            this.x150ToolStripMenuItem.Name = "x150ToolStripMenuItem";
            this.x150ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.x150ToolStripMenuItem.Text = "150 x 150";
            this.x150ToolStripMenuItem.Click += new System.EventHandler(this.x150ToolStripMenuItem_Click);
            // 
            // x200ToolStripMenuItem
            // 
            this.x200ToolStripMenuItem.Name = "x200ToolStripMenuItem";
            this.x200ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.x200ToolStripMenuItem.Text = "200 x 200";
            this.x200ToolStripMenuItem.Click += new System.EventHandler(this.x200ToolStripMenuItem_Click);
            // 
            // ILV_photos
            // 
            this.ILV_photos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ILV_photos.DefaultImage = ((System.Drawing.Image)(resources.GetObject("ILV_photos.DefaultImage")));
            this.ILV_photos.ErrorImage = ((System.Drawing.Image)(resources.GetObject("ILV_photos.ErrorImage")));
            this.ILV_photos.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ILV_photos.Location = new System.Drawing.Point(0, 42);
            this.ILV_photos.Margin = new System.Windows.Forms.Padding(4);
            this.ILV_photos.Name = "ILV_photos";
            this.ILV_photos.Size = new System.Drawing.Size(923, 566);
            this.ILV_photos.TabIndex = 9;
            this.ILV_photos.Text = "";
            this.ILV_photos.ItemClick += new Manina.Windows.Forms.ItemClickEventHandler(this.ILV_photos_ItemClick);
            this.ILV_photos.SelectionChanged += new System.EventHandler(this.ILV_photos_SelectionChanged);
            this.ILV_photos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ILV_photos_MouseClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSSL_infos});
            this.statusStrip1.Location = new System.Drawing.Point(0, 611);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1179, 25);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TSSL_infos
            // 
            this.TSSL_infos.Name = "TSSL_infos";
            this.TSSL_infos.Size = new System.Drawing.Size(79, 20);
            this.TSSL_infos.Text = "No photos";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.BT_save_all);
            this.groupBox2.Location = new System.Drawing.Point(933, 292);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(235, 92);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // BT_save_all
            // 
            this.BT_save_all.Location = new System.Drawing.Point(68, 38);
            this.BT_save_all.Margin = new System.Windows.Forms.Padding(4);
            this.BT_save_all.Name = "BT_save_all";
            this.BT_save_all.Size = new System.Drawing.Size(100, 28);
            this.BT_save_all.TabIndex = 10;
            this.BT_save_all.Text = "Save all";
            this.BT_save_all.UseVisualStyleBackColor = true;
            this.BT_save_all.Click += new System.EventHandler(this.BT_save_all_Click);
            // 
            // CMS_action
            // 
            this.CMS_action.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CMS_action.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssToolStripMenuItem});
            this.CMS_action.Name = "CMS_action";
            this.CMS_action.Size = new System.Drawing.Size(91, 28);
            // 
            // ssToolStripMenuItem
            // 
            this.ssToolStripMenuItem.Name = "ssToolStripMenuItem";
            this.ssToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.ssToolStripMenuItem.Text = "ss";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // TSB_export
            // 
            this.TSB_export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_export.Image = ((System.Drawing.Image)(resources.GetObject("TSB_export.Image")));
            this.TSB_export.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSB_export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_export.Name = "TSB_export";
            this.TSB_export.Size = new System.Drawing.Size(28, 28);
            this.TSB_export.Text = "Export";
            this.TSB_export.Click += new System.EventHandler(this.TSB_export_Click);
            // 
            // PF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 636);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ILV_photos);
            this.Controls.Add(this.TS_action);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1194, 672);
            this.Name = "PF";
            this.Text = "Photos Finder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TS_action.ResumeLayout(false);
            this.TS_action.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.CMS_action.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CB_type1;
        private System.Windows.Forms.ToolStrip TS_action;
        private System.Windows.Forms.ToolStripButton TSB_thumbnails;
        private System.Windows.Forms.ToolStripButton TSB_gallery;
        private System.Windows.Forms.ToolStripButton TSB_pane;
        private System.Windows.Forms.ToolStripButton TSB_list;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
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
        private Manina.Windows.Forms.ImageListView ILV_photos;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel TSSL_infos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ContextMenuStrip CMS_action;
        private System.Windows.Forms.ToolStripMenuItem ssToolStripMenuItem;
        private System.Windows.Forms.Button BT_save_all;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton TSB_export;
    }
}

