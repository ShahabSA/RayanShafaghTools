using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayanShafagh.Windows.Froms
{
    public static class PersianMessageBox
    {
        public static DialogResult Show(string title, string message, PersianMessageBoxIcon icon, MessageBoxButtons buttons)
        {
            CustomMessageBox f = new CustomMessageBox(title, message, icon, buttons);
            return f.ShowDialog();
        }

        public static DialogResult Show(string message, PersianMessageBoxIcon icon, MessageBoxButtons buttons)
        {
            return Show("", message, icon, buttons);
        }

        public static DialogResult Show(string message)
        {
            return Show("", message, PersianMessageBoxIcon.Message, MessageBoxButtons.OK);
        }
    }
}
