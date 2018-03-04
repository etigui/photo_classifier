namespace PhotoIdentifier {
    partial class PI {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PI));
            this.SS = new System.Windows.Forms.StatusStrip();
            this.TSSL_infos = new System.Windows.Forms.ToolStripStatusLabel();
            this.ILV_photos = new Manina.Windows.Forms.ImageListView();
            this.TS_action = new System.Windows.Forms.ToolStrip();
            this.TSB_add = new System.Windows.Forms.ToolStripButton();
            this.TSB_remove = new System.Windows.Forms.ToolStripButton();
            this.TSB_clear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
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
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_person = new System.Windows.Forms.ToolStripButton();
            this.TSB_manage_person = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_identify = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_search = new System.Windows.Forms.ToolStripButton();
            this.SS.SuspendLayout();
            this.TS_action.SuspendLayout();
            this.SuspendLayout();
            // 
            // SS
            // 
            this.SS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSSL_infos});
            this.SS.Location = new System.Drawing.Point(0, 281);
            this.SS.Name = "SS";
            this.SS.Size = new System.Drawing.Size(703, 22);
            this.SS.TabIndex = 2;
            // 
            // TSSL_infos
            // 
            this.TSSL_infos.Name = "TSSL_infos";
            this.TSSL_infos.Size = new System.Drawing.Size(63, 17);
            this.TSSL_infos.Text = "No photos";
            // 
            // ILV_photos
            // 
            this.ILV_photos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ILV_photos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ILV_photos.DefaultImage = ((System.Drawing.Image)(resources.GetObject("ILV_photos.DefaultImage")));
            this.ILV_photos.ErrorImage = ((System.Drawing.Image)(resources.GetObject("ILV_photos.ErrorImage")));
            this.ILV_photos.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ILV_photos.Location = new System.Drawing.Point(-1, 34);
            this.ILV_photos.Name = "ILV_photos";
            this.ILV_photos.Size = new System.Drawing.Size(705, 247);
            this.ILV_photos.TabIndex = 5;
            this.ILV_photos.Text = "";
            this.ILV_photos.SelectionChanged += new System.EventHandler(this.ILV_photos_SelectionChanged);
            // 
            // TS_action
            // 
            this.TS_action.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TS_action.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSB_add,
            this.TSB_remove,
            this.TSB_clear,
            this.toolStripSeparator1,
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
            this.TSDDB_size,
            this.toolStripSeparator3,
            this.TSB_person,
            this.TSB_manage_person,
            this.toolStripSeparator6,
            this.TSB_identify,
            this.toolStripSeparator5,
            this.TSB_search});
            this.TS_action.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.TS_action.Location = new System.Drawing.Point(0, 0);
            this.TS_action.Name = "TS_action";
            this.TS_action.Size = new System.Drawing.Size(703, 31);
            this.TS_action.TabIndex = 7;
            this.TS_action.Text = "toolStrip1";
            // 
            // TSB_add
            // 
            this.TSB_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_add.Image = ((System.Drawing.Image)(resources.GetObject("TSB_add.Image")));
            this.TSB_add.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSB_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_add.Name = "TSB_add";
            this.TSB_add.Size = new System.Drawing.Size(28, 28);
            this.TSB_add.Text = "Add photos";
            this.TSB_add.Click += new System.EventHandler(this.TSB_add_Click);
            // 
            // TSB_remove
            // 
            this.TSB_remove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_remove.Enabled = false;
            this.TSB_remove.Image = ((System.Drawing.Image)(resources.GetObject("TSB_remove.Image")));
            this.TSB_remove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSB_remove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_remove.Name = "TSB_remove";
            this.TSB_remove.Size = new System.Drawing.Size(28, 28);
            this.TSB_remove.Text = "Remove selected photos";
            this.TSB_remove.Click += new System.EventHandler(this.TSB_remove_Click);
            // 
            // TSB_clear
            // 
            this.TSB_clear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_clear.Enabled = false;
            this.TSB_clear.Image = ((System.Drawing.Image)(resources.GetObject("TSB_clear.Image")));
            this.TSB_clear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSB_clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_clear.Name = "TSB_clear";
            this.TSB_clear.Size = new System.Drawing.Size(28, 28);
            this.TSB_clear.Text = "Remove all photos";
            this.TSB_clear.Click += new System.EventHandler(this.TSB_clear_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
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
            this.TSB_left.Click += new System.EventHandler(this.TSB_left_Click);
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
            this.TSB_right.Click += new System.EventHandler(this.TSB_right_Click);
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
            // TSB_info
            // 
            this.TSB_info.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_info.Image = ((System.Drawing.Image)(resources.GetObject("TSB_info.Image")));
            this.TSB_info.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSB_info.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_info.Name = "TSB_info";
            this.TSB_info.Size = new System.Drawing.Size(28, 28);
            this.TSB_info.Text = "Columns info";
            this.TSB_info.Click += new System.EventHandler(this.TSB_info_Click);
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
            this.x48ToolStripMenuItem.Click += new System.EventHandler(this.x48ToolStripMenuItem_Click);
            // 
            // x96ToolStripMenuItem
            // 
            this.x96ToolStripMenuItem.Name = "x96ToolStripMenuItem";
            this.x96ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.x96ToolStripMenuItem.Text = "96 x 96";
            this.x96ToolStripMenuItem.Click += new System.EventHandler(this.x96ToolStripMenuItem_Click);
            // 
            // x120ToolStripMenuItem
            // 
            this.x120ToolStripMenuItem.Name = "x120ToolStripMenuItem";
            this.x120ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.x120ToolStripMenuItem.Text = "120 x 120";
            this.x120ToolStripMenuItem.Click += new System.EventHandler(this.x120ToolStripMenuItem_Click);
            // 
            // x150ToolStripMenuItem
            // 
            this.x150ToolStripMenuItem.Name = "x150ToolStripMenuItem";
            this.x150ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.x150ToolStripMenuItem.Text = "150 x 150";
            this.x150ToolStripMenuItem.Click += new System.EventHandler(this.x150ToolStripMenuItem_Click);
            // 
            // x200ToolStripMenuItem
            // 
            this.x200ToolStripMenuItem.Name = "x200ToolStripMenuItem";
            this.x200ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.x200ToolStripMenuItem.Text = "200 x 200";
            this.x200ToolStripMenuItem.Click += new System.EventHandler(this.x200ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // TSB_person
            // 
            this.TSB_person.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_person.Image = ((System.Drawing.Image)(resources.GetObject("TSB_person.Image")));
            this.TSB_person.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSB_person.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_person.Name = "TSB_person";
            this.TSB_person.Size = new System.Drawing.Size(28, 28);
            this.TSB_person.Text = "Add person";
            this.TSB_person.Click += new System.EventHandler(this.TSB_person_Click);
            // 
            // TSB_manage_person
            // 
            this.TSB_manage_person.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_manage_person.Image = ((System.Drawing.Image)(resources.GetObject("TSB_manage_person.Image")));
            this.TSB_manage_person.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSB_manage_person.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_manage_person.Name = "TSB_manage_person";
            this.TSB_manage_person.Size = new System.Drawing.Size(28, 28);
            this.TSB_manage_person.Text = "Manage person";
            this.TSB_manage_person.Click += new System.EventHandler(this.TSB_manage_person_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 31);
            // 
            // TSB_identify
            // 
            this.TSB_identify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_identify.Enabled = false;
            this.TSB_identify.Image = ((System.Drawing.Image)(resources.GetObject("TSB_identify.Image")));
            this.TSB_identify.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSB_identify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_identify.Name = "TSB_identify";
            this.TSB_identify.Size = new System.Drawing.Size(28, 28);
            this.TSB_identify.Text = "Identify photos";
            this.TSB_identify.Click += new System.EventHandler(this.TSB_identify_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 31);
            // 
            // TSB_search
            // 
            this.TSB_search.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_search.Image = ((System.Drawing.Image)(resources.GetObject("TSB_search.Image")));
            this.TSB_search.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSB_search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_search.Name = "TSB_search";
            this.TSB_search.Size = new System.Drawing.Size(28, 28);
            this.TSB_search.Text = "Lunch PhotosFinder";
            this.TSB_search.Click += new System.EventHandler(this.TSB_search_Click);
            // 
            // PI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 303);
            this.Controls.Add(this.TS_action);
            this.Controls.Add(this.ILV_photos);
            this.Controls.Add(this.SS);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PI";
            this.Load += new System.EventHandler(this.PI_Load);
            this.SS.ResumeLayout(false);
            this.SS.PerformLayout();
            this.TS_action.ResumeLayout(false);
            this.TS_action.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip SS;
        private Manina.Windows.Forms.ImageListView ILV_photos;
        private System.Windows.Forms.ToolStrip TS_action;
        private System.Windows.Forms.ToolStripButton TSB_remove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton TSB_clear;
        private System.Windows.Forms.ToolStripButton TSB_thumbnails;
        private System.Windows.Forms.ToolStripButton TSB_gallery;
        private System.Windows.Forms.ToolStripButton TSB_pane;
        private System.Windows.Forms.ToolStripButton TSB_info;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton TSB_person;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton TSB_search;
        private System.Windows.Forms.ToolStripButton TSB_list;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton TSDDB_size;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem x48ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton TSB_add;
        private System.Windows.Forms.ToolStripMenuItem x96ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x120ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x150ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x200ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel TSSL_infos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton TSB_identify;
        private System.Windows.Forms.ToolStripButton TSB_left;
        private System.Windows.Forms.ToolStripButton TSB_right;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton TSB_manage_person;
    }
}

