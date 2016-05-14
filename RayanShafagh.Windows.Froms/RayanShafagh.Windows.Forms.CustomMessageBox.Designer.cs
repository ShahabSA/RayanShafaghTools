namespace RayanShafagh.Windows.Forms
{
    partial class CustomMessageBox
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
            this.Lbl_Message = new System.Windows.Forms.Label();
            this.CntMnu_Main = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CntMnu_CopyMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.PicBox_Icon = new System.Windows.Forms.PictureBox();
            this.Flpnl_Buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.CntMnu_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_Message
            // 
            this.Lbl_Message.AutoSize = true;
            this.Lbl_Message.ContextMenuStrip = this.CntMnu_Main;
            this.Lbl_Message.Location = new System.Drawing.Point(22, 15);
            this.Lbl_Message.MaximumSize = new System.Drawing.Size(600, 0);
            this.Lbl_Message.Name = "Lbl_Message";
            this.Lbl_Message.Size = new System.Drawing.Size(18, 21);
            this.Lbl_Message.TabIndex = 0;
            this.Lbl_Message.Text = "x";
            // 
            // CntMnu_Main
            // 
            this.CntMnu_Main.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CntMnu_Main.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.CntMnu_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CntMnu_CopyMessage});
            this.CntMnu_Main.Name = "CntMnu_Main";
            this.CntMnu_Main.Size = new System.Drawing.Size(114, 30);
            // 
            // CntMnu_CopyMessage
            // 
            this.CntMnu_CopyMessage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CntMnu_CopyMessage.Name = "CntMnu_CopyMessage";
            this.CntMnu_CopyMessage.Size = new System.Drawing.Size(113, 26);
            this.CntMnu_CopyMessage.Text = "کپی";
            this.CntMnu_CopyMessage.Click += new System.EventHandler(this.CntMnu_CopyMessage_Click);
            // 
            // PicBox_Icon
            // 
            this.PicBox_Icon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PicBox_Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PicBox_Icon.Location = new System.Drawing.Point(270, 6);
            this.PicBox_Icon.Name = "PicBox_Icon";
            this.PicBox_Icon.Size = new System.Drawing.Size(48, 48);
            this.PicBox_Icon.TabIndex = 1;
            this.PicBox_Icon.TabStop = false;
            // 
            // Flpnl_Buttons
            // 
            this.Flpnl_Buttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Flpnl_Buttons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.Flpnl_Buttons.Location = new System.Drawing.Point(3, 104);
            this.Flpnl_Buttons.Name = "Flpnl_Buttons";
            this.Flpnl_Buttons.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Flpnl_Buttons.Size = new System.Drawing.Size(318, 39);
            this.Flpnl_Buttons.TabIndex = 2;
            // 
            // CustomMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(324, 146);
            this.ControlBox = false;
            this.Controls.Add(this.Flpnl_Buttons);
            this.Controls.Add(this.PicBox_Icon);
            this.Controls.Add(this.Lbl_Message);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomMessageBox";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "توجه";
            this.Load += new System.EventHandler(this.CustomMessageBox_Load);
            this.CntMnu_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Message;
        private System.Windows.Forms.PictureBox PicBox_Icon;
        private System.Windows.Forms.FlowLayoutPanel Flpnl_Buttons;
        private System.Windows.Forms.ContextMenuStrip CntMnu_Main;
        private System.Windows.Forms.ToolStripMenuItem CntMnu_CopyMessage;
    }
}