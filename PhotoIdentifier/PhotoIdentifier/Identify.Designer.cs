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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Identify));
            this.PB_status = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Lb_status_down = new System.Windows.Forms.Label();
            this.LB_status_up = new System.Windows.Forms.Label();
            this.BT_cancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PB_status
            // 
            this.PB_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_status.Location = new System.Drawing.Point(13, 47);
            this.PB_status.Name = "PB_status";
            this.PB_status.Size = new System.Drawing.Size(411, 23);
            this.PB_status.Step = 1;
            this.PB_status.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Lb_status_down);
            this.panel1.Controls.Add(this.LB_status_up);
            this.panel1.Controls.Add(this.PB_status);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(436, 113);
            this.panel1.TabIndex = 1;
            // 
            // Lb_status_down
            // 
            this.Lb_status_down.AutoSize = true;
            this.Lb_status_down.Location = new System.Drawing.Point(13, 83);
            this.Lb_status_down.Name = "Lb_status_down";
            this.Lb_status_down.Size = new System.Drawing.Size(165, 13);
            this.Lb_status_down.TabIndex = 2;
            this.Lb_status_down.Text = "Identify photos: C:\\Image\\test.jpg";
            // 
            // LB_status_up
            // 
            this.LB_status_up.AutoSize = true;
            this.LB_status_up.Location = new System.Drawing.Point(13, 22);
            this.LB_status_up.Name = "LB_status_up";
            this.LB_status_up.Size = new System.Drawing.Size(65, 13);
            this.LB_status_up.TabIndex = 1;
            this.LB_status_up.Text = "Start identify";
            // 
            // BT_cancel
            // 
            this.BT_cancel.Location = new System.Drawing.Point(350, 122);
            this.BT_cancel.Name = "BT_cancel";
            this.BT_cancel.Size = new System.Drawing.Size(75, 23);
            this.BT_cancel.TabIndex = 2;
            this.BT_cancel.Text = "Cancel";
            this.BT_cancel.UseVisualStyleBackColor = true;
            this.BT_cancel.Click += new System.EventHandler(this.BT_cancel_Click);
            // 
            // Identify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 157);
            this.Controls.Add(this.BT_cancel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(450, 130);
            this.Name = "Identify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PI - Identify";
            this.Load += new System.EventHandler(this.Identify_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar PB_status;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Lb_status_down;
        private System.Windows.Forms.Label LB_status_up;
        private System.Windows.Forms.Button BT_cancel;
    }
}