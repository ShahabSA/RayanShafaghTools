using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayanShafagh.Windows.Froms
{
    internal sealed partial class CustomMessageBox : Form
    {

        public CustomMessageBox(string title, string message, PersianMessageBoxIcon icon, MessageBoxButtons buttons)
        {
            InitializeComponent();

            this.SuspendLayout();

            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            //this.MaximumSize = new Size(Convert.ToInt32(SystemInformation.VirtualScreen.Width * 0.8), 0);
            Lbl_Message.MaximumSize = new Size(this.Width - 10, 0);

            title = title.Trim();
            message = message.Trim();

            if (title.Length > 50)
            {
                title = title.Substring(0, 50);
            }

            Lbl_Title.Text = title;
            Lbl_Message.Text = message;
            if (!string.IsNullOrEmpty(title))
            {
                this.Text = title;
            }

            switch (icon)
            {
                case PersianMessageBoxIcon.Error:
                    PicBox_Icon.BackgroundImage = Res_Icons.error.ToBitmap();
                    break;
                case PersianMessageBoxIcon.Warning:
                    PicBox_Icon.BackgroundImage = Res_Icons.warning.ToBitmap();
                    break;
                case PersianMessageBoxIcon.Information:
                    PicBox_Icon.BackgroundImage = Res_Icons.information.ToBitmap();
                    break;
                case PersianMessageBoxIcon.Hand:
                    PicBox_Icon.BackgroundImage = Res_Icons.hand.ToBitmap();
                    break;
                case PersianMessageBoxIcon.Ok:
                    PicBox_Icon.BackgroundImage = Res_Icons.ok.ToBitmap();
                    break;
                case PersianMessageBoxIcon.Message:
                    PicBox_Icon.BackgroundImage = Res_Icons.message.ToBitmap();
                    break;
                case PersianMessageBoxIcon.Question:
                    PicBox_Icon.BackgroundImage = Res_Icons.questions.ToBitmap();
                    break;
                default:
                    PicBox_Icon.BackgroundImage = Res_Icons.message.ToBitmap();
                    break;
            }

            NameDialogResultPack[] names;

            switch (buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    names = new NameDialogResultPack[] 
                    { 
                        new NameDialogResultPack( "لغو",DialogResult.Abort), 
                        new NameDialogResultPack( "دوباره سعی کن",DialogResult.Retry),
                        new NameDialogResultPack( "نادیده بگیر",DialogResult.Ignore) 
                    };

                    break;
                case MessageBoxButtons.OK:
                    names = new NameDialogResultPack[] 
                    { 
                        new NameDialogResultPack( "تایید",DialogResult.OK)
                    };
                    break;
                case MessageBoxButtons.OKCancel:
                    names = new NameDialogResultPack[] 
                    { 
                        new NameDialogResultPack( "تایید",DialogResult.OK), 
                        new NameDialogResultPack( "انصراف",DialogResult.Cancel)  
                    };
                    break;
                case MessageBoxButtons.RetryCancel:
                    names = new NameDialogResultPack[] 
                    { 
                        new NameDialogResultPack( "دوباره سعی کن",DialogResult.Retry),
                        new NameDialogResultPack( "انصراف",DialogResult.Cancel) 
                    };
                    break;
                case MessageBoxButtons.YesNo:
                    names = new NameDialogResultPack[] 
                    { 
                        new NameDialogResultPack( "بله",DialogResult.Yes), 
                        new NameDialogResultPack( "خیر",DialogResult.No)
                    };
                    break;
                case MessageBoxButtons.YesNoCancel:
                    names = new NameDialogResultPack[] 
                    { 
                        new NameDialogResultPack( "بله",DialogResult.Yes), 
                        new NameDialogResultPack( "خیر",DialogResult.No),
                        new NameDialogResultPack( "انصراف",DialogResult.Cancel) 
                    };
                    break;
                default:
                    names = new NameDialogResultPack[] 
                    { 
                        new NameDialogResultPack( "تایید",DialogResult.OK)
                    };
                    break;
            }

            AddButtons(names);

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void AddButtons(NameDialogResultPack[] names)
        {
            for (int i = names.Length-1; i >= 0; i--)
            {
                Button btn = new Button();
                btn.Text = names[i].Name;
                btn.AutoSize = true;
                btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                btn.Padding = new Padding(3);
                btn.Margin = new Padding(3);
                btn.DialogResult = names[i].Result;
                Flpnl_Buttons.Controls.Add(btn);
                btn.Click += clickHandler;
            }
        }

        private void clickHandler(object sender, EventArgs e)
        {
            this.DialogResult = ((Button)sender).DialogResult;
            this.Close();
        }

        private void CntMnu_CopyMessage_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Lbl_Message.Text);
        }
    }
}
