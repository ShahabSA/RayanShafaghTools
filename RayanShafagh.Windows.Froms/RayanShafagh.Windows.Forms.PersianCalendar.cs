using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayanShafagh.Windows.Forms
{
    public partial class PersianCalendar : UserControl
    {

        #region Properties
        public string PersianDate
        {
            get
            {
                if (Cmb_Day.SelectedItem != null && Cmb_Month.SelectedItem != null && Cmb_Year.SelectedItem != null)
                {
                    return string.Format("{0:0000}/{1:00}/{2:00}", Cmb_Year.SelectedItem, Cmb_Month.SelectedIndex + 1, Cmb_Day.SelectedItem);
                }
                else
                {
                    return null;
                }
            }
        }

        public DateTime? EnglishDate
        {
            get
            {
                if (Cmb_Day.SelectedItem == null || Cmb_Month.SelectedItem == null || Cmb_Year.SelectedItem == null)
                {
                    return null;
                }
                System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
                int y, m, d;
                d = Convert.ToInt32(Cmb_Day.SelectedItem);
                m = Convert.ToInt32(Cmb_Month.SelectedIndex) + 1;
                y = Convert.ToInt32(Cmb_Year.SelectedItem);
                DateTime dt = DateTime.Now;

                while (y - p.GetYear(dt) != 0)
                {

                    dt = dt.AddYears(y - p.GetYear(dt));

                }

                while (m - p.GetMonth(dt) != 0)
                {

                    dt = dt.AddMonths(m - p.GetMonth(dt));

                }

                while (d - p.GetDayOfMonth(dt) != 0)
                {

                    dt = dt.AddDays(d - p.GetDayOfMonth(dt));

                }

                return new DateTime(dt.Date.Year, dt.Date.Month, dt.Date.Day);

            }
            set
            {
                if (!value.HasValue)
                {
                    return;
                }
                System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
                Cmb_Year.SelectedItem = p.GetYear(value.Value);
                Cmb_Month.SelectedIndex = p.GetMonth(value.Value) - 1;
                Cmb_Day.SelectedItem = p.GetDayOfMonth(value.Value);
            }
        }


        public int MinimumYear { get; set; }

        public int MaximumYear { get; set; } 
        #endregion

        #region Combo Loading Methods
        private void LoadDayCombo(int start, int end)
        {
            Cmb_Day.Items.Clear();
            Cmb_Day.Items.AddRange(Enumerable.Range(start, end).Cast<IEnumerable<object>>().ToArray());
            Cmb_Day.SelectedIndex = -1;
        }

        private void LoadYearCombo()
        {
            Cmb_Year.Items.Clear();
            Cmb_Year.Items.AddRange(Enumerable.Range(MinimumYear, MaximumYear).Cast<IEnumerable<object>>().ToArray());
            Cmb_Day.SelectedIndex = -1;

        }

        private void LoadMonthCombo()
        {
            Cmb_Month.Items.Clear();
            string[] month = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
            Cmb_Month.Items.AddRange(month);
            Cmb_Day.SelectedIndex = -1;
        }

        private void ControlDays()
        {
            System.Globalization.PersianCalendar pr = new System.Globalization.PersianCalendar();

            if (Cmb_Month.SelectedIndex > 5)
            {
                LoadDayCombo(1, 30);
            }
            else if (Cmb_Month.SelectedIndex == 11)
            {
                if (Cmb_Year.SelectedIndex == -1)
                {
                    Cmb_Day.SelectedIndex = -1;
                    LoadDayCombo(1, 29);
                    return;
                }
                else
                {
                    if (pr.IsLeapYear(Convert.ToInt32(Cmb_Year.SelectedItem)))
                    {
                        LoadDayCombo(1, 29);
                    }
                    else
                    {
                        LoadDayCombo(1, 29);
                    }
                }
            }
            else
            {
                LoadDayCombo(1, 30);
            }




        }

        #endregion

        public PersianCalendar()
        {
            InitializeComponent();

            System.Globalization.PersianCalendar pr = new System.Globalization.PersianCalendar();

            MaximumYear = pr.GetYear(DateTime.Now) + 10;
            MinimumYear = pr.GetYear(DateTime.Now) - 70;

            #region Loading Combo

            LoadDayCombo(1,31);

            LoadYearCombo();

            LoadMonthCombo();

            #endregion

            #region Set ToolTip

            Tltp_Main.SetToolTip(Cmb_Day, "روز");
            Tltp_Main.SetToolTip(Cmb_Month, "ماه");
            Tltp_Main.SetToolTip(Cmb_Year, "سال");


            #endregion

        }

        public void ResetControls()
        {
            Cmb_Day.SelectedIndex = -1;
            Cmb_Month.SelectedIndex = -1;
            Cmb_Year.SelectedIndex = -1;
        }
        private void Cmb_Month_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControlDays();
        }

    }
}
