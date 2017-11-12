namespace PhotoIdentifier {
    partial class ColumnsInfos {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColumnsInfos));
            this.CLB_infos = new System.Windows.Forms.CheckedListBox();
            this.BT_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CLB_infos
            // 
            this.CLB_infos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CLB_infos.CheckOnClick = true;
            this.CLB_infos.FormattingEnabled = true;
            this.CLB_infos.Location = new System.Drawing.Point(12, 12);
            this.CLB_infos.Name = "CLB_infos";
            this.CLB_infos.Size = new System.Drawing.Size(260, 214);
            this.CLB_infos.TabIndex = 0;
            this.CLB_infos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CLB_infos_ItemCheck);
            // 
            // BT_close
            // 
            this.BT_close.Location = new System.Drawing.Point(197, 232);
            this.BT_close.Name = "BT_close";
            this.BT_close.Size = new System.Drawing.Size(75, 23);
            this.BT_close.TabIndex = 1;
            this.BT_close.Text = "Close";
            this.BT_close.UseVisualStyleBackColor = true;
            this.BT_close.Click += new System.EventHandler(this.BT_close_Click);
            // 
            // ColumnsInfos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.BT_close);
            this.Controls.Add(this.CLB_infos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ColumnsInfos";
            this.Text = "Columns Infos";
            this.Load += new System.EventHandler(this.ColumnsInfos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox CLB_infos;
        private System.Windows.Forms.Button BT_close;
    }
}