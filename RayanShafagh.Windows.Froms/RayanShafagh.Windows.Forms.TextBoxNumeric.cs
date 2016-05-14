using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayanShafagh.Windows.Forms
{
    public partial class TextBoxNumeric : TextBox
    {
        public TextBoxNumeric()
        {
            InitializeComponent();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space) || e.KeyChar == '-')
            {
                base.OnKeyPress(e);
                return;
            }
            else
                e.Handled = true;
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            if (this.Text.Trim().Length < 3)
            {
                e.Cancel = true;
                this.SelectAll();
                this.BackColor = Color.LightPink;
                this.ForeColor = Color.Crimson;
            }
            base.OnValidating(e);
        }

        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
            this.BackColor = Color.LightGreen;
            this.ForeColor = Color.DarkGreen;
        }
    }
}
