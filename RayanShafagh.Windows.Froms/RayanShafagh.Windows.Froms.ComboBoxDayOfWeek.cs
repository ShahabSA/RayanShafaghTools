using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayanShafagh.Windows.Froms
{
    public partial class ComboBoxDayOfWeek : UserControl
    {
        public ComboBoxDayOfWeek()
        {
            InitializeComponent();

           
            Cmb_Days.Items.Clear();
            Cmb_Days.Items.Add("شنبه");
            Cmb_Days.Items.Add("یکشنبه");
            Cmb_Days.Items.Add("دوشنبه");
            Cmb_Days.Items.Add("سه شنبه");
            Cmb_Days.Items.Add("چهار شنبه");
            Cmb_Days.Items.Add("پنج شنبه");
            Cmb_Days.Items.Add("جمعه");
      
        }

        public int DayValue
        {
            get
            {
                int res = -1;
                switch (Cmb_Days.SelectedItem.ToString())
                {
                    case "شنبه":
                        res = 6;
                        break;
                    case "یکشنبه":
                        res = 0;
                        break;
                    case "دوشنبه":
                        res = 1;
                        break;
                    case "سه شنبه":
                        res = 2;
                        break;
                    case "چهار شنبه":
                        res = 3;
                        break;
                    case "پنج شنبه":
                        res = 4;
                        break;
                    case "جمعه":
                        res = 5;
                        break;
                }
                return res;
            }
            set
            {
                int index = -1;
                switch (value)
                {
                    case 6:
                        index = 0;
                        break;
                    case 0:
                        index = 1;
                        break;
                    case 1:
                        index = 2;
                        break;
                    case 2:
                        index = 3;
                        break;
                    case 3:
                        index = 4;
                        break;
                    case 4:
                        index = 5;
                        break;
                    case 5:
                        index = 6;
                        break;
                }
                Cmb_Days.SelectedIndex = index;
            }
        }

        public string DayName
        {
            get
            {
                return Cmb_Days.SelectedItem == null ? "" : Cmb_Days.SelectedItem.ToString();
            }
        }
    }
}
