namespace PhotoIdentifier {
    partial class Identify {
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
            this.PB_status = new System.Windows.Forms.ProgressBar();
            this.LB_log = new System.Windows.Forms.ListBox();
            this.BT_show = new System.Windows.Forms.Button();
            this.SS_status = new System.Windows.Forms.StatusStrip();
            this.TSSL_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.SS_status.SuspendLayout();
            this.SuspendLayout();
            // 
            // PB_status
            // 
            this.PB_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_status.Location = new System.Drawing.Point(12, 12);
            this.PB_status.Name = "PB_status";
            this.PB_status.Size = new System.Drawing.Size(413, 23);
            this.PB_status.TabIndex = 0;
            // 
            // LB_log
            // 
            this.LB_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_log.FormattingEnabled = true;
            this.LB_log.Location = new System.Drawing.Point(12, 36);
            this.LB_log.Name = "LB_log";
            this.LB_log.Size = new System.Drawing.Size(413, 4);
            this.LB_log.TabIndex = 1;
            this.LB_log.Visible = false;
            // 
            // BT_show
            // 
            this.BT_show.Location = new System.Drawing.Point(199, 41);
            this.BT_show.Name = "BT_show";
            this.BT_show.Size = new System.Drawing.Size(37, 23);
            this.BT_show.TabIndex = 2;
            this.BT_show.Text = "˅";
            this.BT_show.UseVisualStyleBackColor = true;
            this.BT_show.Click += new System.EventHandler(this.BT_show_Click);
            // 
            // SS_status
            // 
            this.SS_status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSSL_status});
            this.SS_status.Location = new System.Drawing.Point(0, 71);
            this.SS_status.Name = "SS_status";
            this.SS_status.Size = new System.Drawing.Size(434, 22);
            this.SS_status.TabIndex = 3;
            // 
            // TSSL_status
            // 
            this.TSSL_status.Name = "TSSL_status";
            this.TSSL_status.Size = new System.Drawing.Size(0, 17);
            // 
            // Identify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 93);
            this.Controls.Add(this.SS_status);
            this.Controls.Add(this.BT_show);
            this.Controls.Add(this.LB_log);
            this.Controls.Add(this.PB_status);
            this.MinimumSize = new System.Drawing.Size(450, 130);
            this.Name = "Identify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PI - Identify";
            this.Load += new System.EventHandler(this.Identify_Load);
            this.SS_status.ResumeLayout(false);
            this.SS_status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar PB_status;
        private System.Windows.Forms.ListBox LB_log;
        private System.Windows.Forms.Button BT_show;
        private System.Windows.Forms.StatusStrip SS_status;
        private System.Windows.Forms.ToolStripStatusLabel TSSL_status;
    }
}