using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayanShafagh.Utility
{
    public struct PersianDate
    {

        private byte day ;

        public byte Day
        {
            get { return day; }
        }

        private byte month;

        public byte Month
        {
            get { return month; }
        }

        private int year ;

        public int Year
        {
            get { return year; }
        }


        //public byte Day { get; private set; }
        //public byte Month { get; private set; }
        //public int Year { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}/{1:00}/{2:00}", Year, Month, Day);
        }

        public PersianDate(int year, byte month, byte day)
        {
            if (month > 12 || month == 0 || (month <= 6 && day > 31) || (month <= 12 && month > 6 && day > 30))
            {
                throw new InvalidOperationException("Persian day or month number is invalid...");
            }
            this.year = year;
            this.month = month;
            this.day = day;
        }

        public PersianDate(int[] persianDate)
            : this(persianDate[0],
                 Convert.ToByte(persianDate[1]),
                 Convert.ToByte(persianDate[2]))
        {
        }

        public byte LastDayOfMonth
        {
            get
            {
                if (Month <= 6)
                {
                    return 31;
                }
                else if (Month <=11)
                {
                    return 30;
                }
                else
                {
                    return 29;
                }
            }
        }

    }
}
