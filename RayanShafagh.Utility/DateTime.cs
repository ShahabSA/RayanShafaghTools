using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayanShafagh.Utility
{
    /// <summary>
    /// Provides methods for date time operations...
    /// </summary>
    public static class DateTime
    {

        /// <summary>
        /// Computes equeivalent Gregorian date for given persian date
        /// </summary>
        /// <param name="year">A System.Int32 which indicates persian year value</param>
        /// <param name="month">A System.Int32 which indicates persian month value</param>
        /// <param name="day">A System.Int32 which indicates persian day value</param>
        /// <returns>A System.DateTime which indicates gergurian date</returns>
        public static System.DateTime PersianToGregorian(int year, int month, int day)
        {
            if (year <= 0)
            {
                throw new Exception("wrong year value");
            }

            if (month > 12 || month <= 0)
            {
                throw new Exception("wrong month value");
            }

            if (day <= 0 || day > 31)
            {
                throw new Exception("wrong day value");
            }

            if (month > 6 && month < 12)
            {
                if (day > 30)
                {
                    throw new Exception("wrong day value");
                }
            }

            if (month == 12)
            {
                if (day == 31)
                {
                    throw new Exception("wrong day value");
                }
            }

            System.DateTime result;

            int ElapsedDays, x, z, i;

            i = 0;

            x = (year - 1276) / 33;
            z = (year - (x * 33 + 1276)) / 4;
            if (((year - (x * 33 + 1276)) % 4) != 0)
            {
                z = z + 1;
            }
            ElapsedDays = (year - 1276) * 365 + x * 8 + z;
            while (i <= month - 2)
            {
                if (i <= 5)
                {
                    ElapsedDays = ElapsedDays + 31;
                }
                else
                {
                    if (i <= 10)
                    {
                        ElapsedDays = ElapsedDays + 30;
                    }
                    else
                    {
                        ElapsedDays = ElapsedDays + 29;
                    }
                }
                i = i + 1;
            }
            ElapsedDays = ElapsedDays + day - 1;
            result = new System.DateTime(1897, 3, 20);
            return result.AddDays(ElapsedDays);
        }

        /// <summary>
        /// Computes equeivalent persian date for given Gregorian date
        /// </summary>
        /// <param name="input">A System.DateTime which indicates  value to be converted</param>
        /// <returns>A System.String which indicates converted value of input date to persian date in yyyy/mm/dd format</returns>
        public static string GregorianToPersianString(System.DateTime input)
        {
            var pr = new System.Globalization.PersianCalendar();
            return string.Format("{2}/{1:00}/{0:00}", pr.GetDayOfMonth(input), pr.GetMonth(input), pr.GetYear(input));
        }

        /// <summary>
        /// Converts Gergurian date to persian date in array format
        /// </summary>
        /// <param name="input">A System.DateTime which indicates Gergurian date to ve converted</param>
        /// <returns>A System.Array of System.Int32 with 3 elements which indicates persian values for year, month and day extracted from input parameter</returns>
        public static int[] GregorianToPersianInt(System.DateTime input)
        {
            var pr = new System.Globalization.PersianCalendar();
            return new int[] { pr.GetYear(input), pr.GetMonth(input), pr.GetDayOfMonth(input) };
        }

        /// <summary>
        /// Indicates wheater the given year is a leap year or not.
        /// </summary>
        /// <param name="PersianYear">A System.Int32 which indicates persian year to be checked.</param>
        /// <returns>A System.Boolean which indicates if the input year was a leap year or not.</returns>
        public static bool IsLeapYear(int PersianYear)
        {
            return new System.Globalization.PersianCalendar().IsLeapYear(PersianYear);
        }

        /// <summary>
        /// Indicates weather the given Gergorian year is a leap year or not.
        /// </summary>
        /// <param name="GregorianDate">A System.Int32 which indicates Gergurian year to be checked.</param>
        /// <returns>A System.Boolean which indicates if the input year was a leap year or not.</returns>
        public static bool IsLeapYear(System.DateTime GregorianDate)
        {
            var pr = new System.Globalization.PersianCalendar();
            return pr.IsLeapYear(pr.GetYear(GregorianDate));
        }

        /// <summary>
        /// Returns persian name for day of week value.
        /// </summary>
        /// <param name="Number">A System.Int32 which indicates day of week value and should be between 0 to 6. 0 indicates Sunday...</param>
        /// <returns>A System.String which indicates persian name for day of week</returns>
        public static string GetDayName(int Number)
        {
            string res = "";
            switch (Number)
            {
                case 6:
                    res = "شنبه";
                    break;
                case 0:
                    res = "یکشنبه";
                    break;
                case 1:
                    res = "دوشنبه";
                    break;
                case 2:
                    res = "سه شنبه";
                    break;
                case 3:
                    res = "چهار شنبه";
                    break;
                case 4:
                    res = "پنج شنبه";
                    break;
                case 5:
                    res = "جمعه";
                    break;
                default:
                    throw new InvalidOperationException("input day of week value is invalid, value should be between 0 to 6.");
            }
            return res;
        }

        /// <summary>
        /// Returns day of week number for given persian day of week name.
        /// </summary>
        /// <param name="Name">A System.Int32 which indicates day of week number which is a value between 0 to 6. 0 is Sunday</param>
        /// <returns></returns>
        public static int GetDayIndex(string Name)
        {
            int res = -1;
            switch (Name.Trim())
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
                default:
                    throw new InvalidOperationException("input string is not a correct persian day of week name.");
            }
            return res;
        }

        /// <summary>
        /// Returns all persian week day names.
        /// </summary>
        /// <returns>A System.Array of A System.String which contains week day names. starting cell is 'یکشنبه'</returns>
        public static string[] GetDayAllNames()
        {
            return new string[] { "یکشنبه", "دوشنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه", "شنبه" };
        }

        /// <summary>
        /// Returns a datetime which consists of current date value and input time value.
        /// </summary>
        /// <param name="hourMin">A System.String which indicates desired time to be converted to System.DateTime. input should be in 'hh:mm:ss' format.</param>
        /// <returns>A Nullable<System.DateTime> which contains current Date value + input Time value.</returns>
        public static System.DateTime? HourMinStringToDate(string hourMin)
        {
            System.DateTime d;
            try
            {
                d = Convert.ToDateTime(System.DateTime.Now.Date.ToShortDateString() + " " + hourMin.Trim() + ":00");

            }
            catch (Exception)
            {
                return null;
            }
            return d;
        }

        /// <summary>
        /// Computes difference of two time in minutes.
        /// </summary>
        /// <param name="startTime">A System.DateTime which indicates start time (Date part of input is not important).</param>
        /// <param name="endTime">A System.DateTime which indicates end time (Date part of input is not important).</param>
        /// <returns>A Nullable<System.Int64> which indicates time difference of two inputs.</returns>
        public static long? TimeOnlyDifInMinutes(System.DateTime startTime, System.DateTime endTime)
        {
            long? d;

            try
            {
                startTime = Convert.ToDateTime(System.DateTime.Now.Date.ToShortDateString() + " " + startTime.TimeOfDay.ToString());
                endTime = Convert.ToDateTime(System.DateTime.Now.Date.ToShortDateString() + " " + endTime.TimeOfDay.ToString());
                d = Convert.ToInt64(startTime.Subtract(endTime).TotalMinutes);
                d = Math.Abs(d.Value);
            }
            catch (Exception)
            {
                d = null;
            }
            return d;

        }

        public static string GetMonthName(byte monthNumber)
        {
            switch (monthNumber)
            {
                case 1:
                    return "فروردین";
                case 2:
                    return "اردیبهشت";
                case 3:
                    return "خرداد";
                case 4:
                    return "تیر";
                case 5:
                    return "مرداد";
                case 6:
                    return "شهریور";
                case 7:
                    return "مهر";
                case 8:
                    return "آبان";
                case 9:
                    return "آذر";
                case 10:
                    return "دی";
                case 11:
                    return "بهمن";
                case 12:
                    return "اسفند";
                default:
                    return null;
            }
        }
    }
}
