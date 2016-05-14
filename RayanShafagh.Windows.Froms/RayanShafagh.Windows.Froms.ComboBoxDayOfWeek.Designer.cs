namespace RayanShafagh.Windows.Froms
{
    partial class ComboBoxDayOfWeek
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
            this.Cmb_Days = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Cmb_Days
            // 
            this.Cmb_Days.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmb_Days.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Days.FormattingEnabled = true;
            this.Cmb_Days.Location = new System.Drawing.Point(0, 0);
            this.Cmb_Days.Name = "Cmb_Days";
            this.Cmb_Days.Size = new System.Drawing.Size(121, 21);
            this.Cmb_Days.TabIndex = 0;
            // 
            // ComboBoxDayOfWeek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Cmb_Days);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(0, 23);
            this.MinimumSize = new System.Drawing.Size(123, 23);
            this.Name = "ComboBoxDayOfWeek";
            this.Size = new System.Drawing.Size(123, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox Cmb_Days;
    }
}
