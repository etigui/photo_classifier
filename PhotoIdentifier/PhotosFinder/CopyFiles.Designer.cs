namespace PhotosFinder {
    partial class CopyFiles {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CopyFiles));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Lb_status_down = new System.Windows.Forms.Label();
            this.LB_status_up = new System.Windows.Forms.Label();
            this.PB_status = new System.Windows.Forms.ProgressBar();
            this.BT_cancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Lb_status_down);
            this.panel1.Controls.Add(this.LB_status_up);
            this.panel1.Controls.Add(this.PB_status);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(581, 139);
            this.panel1.TabIndex = 3;
            // 
            // Lb_status_down
            // 
            this.Lb_status_down.AutoSize = true;
            this.Lb_status_down.Location = new System.Drawing.Point(17, 102);
            this.Lb_status_down.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lb_status_down.Name = "Lb_status_down";
            this.Lb_status_down.Size = new System.Drawing.Size(0, 17);
            this.Lb_status_down.TabIndex = 2;
            // 
            // LB_status_up
            // 
            this.LB_status_up.AutoSize = true;
            this.LB_status_up.Location = new System.Drawing.Point(17, 27);
            this.LB_status_up.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB_status_up.Name = "LB_status_up";
            this.LB_status_up.Size = new System.Drawing.Size(72, 17);
            this.LB_status_up.TabIndex = 1;
            this.LB_status_up.Text = "Start copy";
            // 
            // PB_status
            // 
            this.PB_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_status.Location = new System.Drawing.Point(17, 58);
            this.PB_status.Margin = new System.Windows.Forms.Padding(4);
            this.PB_status.Name = "PB_status";
            this.PB_status.Size = new System.Drawing.Size(548, 28);
            this.PB_status.Step = 1;
            this.PB_status.TabIndex = 0;
            // 
            // BT_cancel
            // 
            this.BT_cancel.Location = new System.Drawing.Point(466, 152);
            this.BT_cancel.Margin = new System.Windows.Forms.Padding(4);
            this.BT_cancel.Name = "BT_cancel";
            this.BT_cancel.Size = new System.Drawing.Size(100, 28);
            this.BT_cancel.TabIndex = 4;
            this.BT_cancel.Text = "Cancel";
            this.BT_cancel.UseVisualStyleBackColor = true;
            this.BT_cancel.Click += new System.EventHandler(this.BT_cancel_Click);
            // 
            // CopyFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 193);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BT_cancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CopyFiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PF - Copy Files";
            this.Load += new System.EventHandler(this.CopyFiles_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Lb_status_down;
        private System.Windows.Forms.Label LB_status_up;
        private System.Windows.Forms.ProgressBar PB_status;
        private System.Windows.Forms.Button BT_cancel;
    }
}