namespace RayanShafagh.Windows.Froms
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
            this.Lbl_Title = new System.Windows.Forms.Label();
            this.PicBox_Icon = new System.Windows.Forms.PictureBox();
            this.Flpnl_Buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.CntMnu_Main = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CntMnu_CopyMessage = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Icon)).BeginInit();
            this.CntMnu_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_Message
            // 
            this.Lbl_Message.AutoSize = true;
            this.Lbl_Message.ContextMenuStrip = this.CntMnu_Main;
            this.Lbl_Message.Location = new System.Drawing.Point(6, 55);
            this.Lbl_Message.MaximumSize = new System.Drawing.Size(600, 0);
            this.Lbl_Message.Name = "Lbl_Message";
            this.Lbl_Message.Size = new System.Drawing.Size(0, 13);
            this.Lbl_Message.TabIndex = 0;
            // 
            // Lbl_Title
            // 
            this.Lbl_Title.Location = new System.Drawing.Point(6, 13);
            this.Lbl_Title.Name = "Lbl_Title";
            this.Lbl_Title.Size = new System.Drawing.Size(362, 30);
            this.Lbl_Title.TabIndex = 0;
            // 
            // PicBox_Icon
            // 
            this.PicBox_Icon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PicBox_Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PicBox_Icon.Location = new System.Drawing.Point(429, 6);
            this.PicBox_Icon.Name = "PicBox_Icon";
            this.PicBox_Icon.Size = new System.Drawing.Size(48, 48);
            this.PicBox_Icon.TabIndex = 1;
            this.PicBox_Icon.TabStop = false;
            // 
            // Flpnl_Buttons
            // 
            this.Flpnl_Buttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Flpnl_Buttons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.Flpnl_Buttons.Location = new System.Drawing.Point(3, 110);
            this.Flpnl_Buttons.Name = "Flpnl_Buttons";
            this.Flpnl_Buttons.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Flpnl_Buttons.Size = new System.Drawing.Size(478, 49);
            this.Flpnl_Buttons.TabIndex = 2;
            // 
            // CntMnu_Main
            // 
            this.CntMnu_Main.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CntMnu_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CntMnu_CopyMessage});
            this.CntMnu_Main.Name = "CntMnu_Main";
            this.CntMnu_Main.Size = new System.Drawing.Size(97, 26);
            // 
            // CntMnu_CopyMessage
            // 
            this.CntMnu_CopyMessage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CntMnu_CopyMessage.Name = "CntMnu_CopyMessage";
            this.CntMnu_CopyMessage.Size = new System.Drawing.Size(152, 22);
            this.CntMnu_CopyMessage.Text = "کپی";
            this.CntMnu_CopyMessage.Click += new System.EventHandler(this.CntMnu_CopyMessage_Click);
            // 
            // CustomMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(484, 162);
            this.ControlBox = false;
            this.Controls.Add(this.Flpnl_Buttons);
            this.Controls.Add(this.PicBox_Icon);
            this.Controls.Add(this.Lbl_Title);
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
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Icon)).EndInit();
            this.CntMnu_Main.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Message;
        private System.Windows.Forms.Label Lbl_Title;
        private System.Windows.Forms.PictureBox PicBox_Icon;
        private System.Windows.Forms.FlowLayoutPanel Flpnl_Buttons;
        private System.Windows.Forms.ContextMenuStrip CntMnu_Main;
        private System.Windows.Forms.ToolStripMenuItem CntMnu_CopyMessage;
    }
}