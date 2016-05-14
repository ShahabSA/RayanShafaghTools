namespace RayanShafagh.Windows.Forms
{
    partial class PersianCalendar
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Cmb_Day = new System.Windows.Forms.ComboBox();
            this.Cmb_Month = new System.Windows.Forms.ComboBox();
            this.Cmb_Year = new System.Windows.Forms.ComboBox();
            this.Tltp_Main = new System.Windows.Forms.ToolTip(this.components);
            this.Grp_Container = new System.Windows.Forms.GroupBox();
            this.Grp_Container.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cmb_Day
            // 
            this.Cmb_Day.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmb_Day.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Day.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Day.ForeColor = System.Drawing.Color.Navy;
            this.Cmb_Day.FormattingEnabled = true;
            this.Cmb_Day.Location = new System.Drawing.Point(176, 19);
            this.Cmb_Day.Name = "Cmb_Day";
            this.Cmb_Day.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Cmb_Day.Size = new System.Drawing.Size(40, 21);
            this.Cmb_Day.TabIndex = 0;
            // 
            // Cmb_Month
            // 
            this.Cmb_Month.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmb_Month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Month.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Month.ForeColor = System.Drawing.Color.Navy;
            this.Cmb_Month.FormattingEnabled = true;
            this.Cmb_Month.Location = new System.Drawing.Point(64, 19);
            this.Cmb_Month.Name = "Cmb_Month";
            this.Cmb_Month.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Cmb_Month.Size = new System.Drawing.Size(106, 21);
            this.Cmb_Month.TabIndex = 1;
            this.Cmb_Month.SelectedIndexChanged += new System.EventHandler(this.Cmb_Month_Year_SelectedIndexChanged);
            // 
            // Cmb_Year
            // 
            this.Cmb_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Year.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Year.ForeColor = System.Drawing.Color.Navy;
            this.Cmb_Year.FormattingEnabled = true;
            this.Cmb_Year.Location = new System.Drawing.Point(7, 19);
            this.Cmb_Year.Name = "Cmb_Year";
            this.Cmb_Year.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Cmb_Year.Size = new System.Drawing.Size(51, 21);
            this.Cmb_Year.TabIndex = 2;
            this.Cmb_Year.SelectedIndexChanged += new System.EventHandler(this.Cmb_Month_Year_SelectedIndexChanged);
            // 
            // Grp_Container
            // 
            this.Grp_Container.Controls.Add(this.Cmb_Month);
            this.Grp_Container.Controls.Add(this.Cmb_Year);
            this.Grp_Container.Controls.Add(this.Cmb_Day);
            this.Grp_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grp_Container.Location = new System.Drawing.Point(0, 0);
            this.Grp_Container.Name = "Grp_Container";
            this.Grp_Container.Size = new System.Drawing.Size(225, 50);
            this.Grp_Container.TabIndex = 3;
            this.Grp_Container.TabStop = false;
            // 
            // PersianCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.Grp_Container);
            this.MaximumSize = new System.Drawing.Size(0, 50);
            this.MinimumSize = new System.Drawing.Size(225, 50);
            this.Name = "PersianCalendar";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(225, 50);
            this.Grp_Container.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox Cmb_Day;
        private System.Windows.Forms.ComboBox Cmb_Month;
        private System.Windows.Forms.ComboBox Cmb_Year;
        private System.Windows.Forms.ToolTip Tltp_Main;
        private System.Windows.Forms.GroupBox Grp_Container;
    }
}
