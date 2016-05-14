using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayanShafagh.Extensions
{
    public static class Extensions
    {

        #region String Convesion Methods

        public static byte? ToByte(this string s)
        {
            try
            {
                return Convert.ToByte(s);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static short? ToInt16(this string s)
        {
            try
            {
                return Convert.ToInt16(s);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static int? ToInt32(this string s)
        {
            try
            {
                return Convert.ToInt32(s);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static long? ToInt64(this string s)
        {
            try
            {
                return Convert.ToInt64(s);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool? ToBoolean(this string s)
        {
            try
            {
                return Convert.ToBoolean(s);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DateTime? ToDateTime(this string s)
        {
            try
            {
                return Convert.ToDateTime(s);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DateTime? ToDateTimeFromPersianDate(this string s)
        {
            try
            {
                var parts = s.Split('/');
                return RayanShafagh.Utility.DateTime.PersianToGregorian(
                    Convert.ToInt32(parts[0]),
                    Convert.ToInt32(parts[1]),
                    Convert.ToInt32(parts[2])
                                                                        );
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string ReversePersianDate(this string s)
        {
            try
            {
                var parts = s.Split('/').ToArray();
                return string.Format("{0}/{1}/{2}", parts[2], parts[1], parts[0]);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string ReversePersianDate(this string s, char delimiter)
        {
            try
            {
                var parts = s.Split(delimiter).ToArray();
                return string.Format("{0}{3}{1}{3}{2}", parts[2], parts[1], parts[0], delimiter);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static double? ToDouble(this string s)
        {
            try
            {
                return Convert.ToDouble(s);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static float? ToSingle(this string s)
        {
            try
            {
                return Convert.ToSingle(s);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string EmailToUsername(this string s)
        {
            try
            {
                return s.Split('@')[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string EmailToDomainName(this string s)
        {
            try
            {
                return s.Split('@')[1];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string ToPersianGenderPrefix(this string s)
        {
            switch (s.ToLower().Trim())
            {
                case "m":
                    return "آقای";

                case "f":
                    return "خانم";

                default:
                    return "";
            }
        }

        public static string ToPersianGender(this string s)
        {
            switch (s.ToLower().Trim())
            {
                case "m":
                    return "مرد";

                case "f":
                    return "زن";

                default:
                    return "";
            }
        }

        public static T ToEnum<T>(this string value)
        {
            if (!typeof(T).IsEnum)
            {
                throw new Exception("Generic Type \"T\" should be Enum.");
            }
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static T ToEnum<T>(this string value, T defaultValue) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new Exception("Generic Type \"T\" should be Enum.");
            }

            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            T result;
            return Enum.TryParse<T>(value, true, out result) ? result : defaultValue;
        }

        #endregion

        #region String Checking Methods


        public static bool IsName(this string s)
        {
            try
            {
                var query = s.ToArray().Where(a => char.IsLetter(a) == false && a != ' ');
                return query.ToArray().Count() == 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool IsDigit(this string s)
        {
            return s.ToDouble().HasValue;
        }

        public static bool IsInt16(this string s)
        {
            return s.ToInt16().HasValue;
        }

        public static bool IsInt32(this string s)
        {
            return s.ToInt32().HasValue;
        }

        public static bool IsInt64(this string s)
        {
            return s.ToInt64().HasValue;
        }

        public static bool IsByte(this string s)
        {
            return s.ToByte().HasValue;
        }

        public static bool IsPhoneNumber(this string s)
        {
            try
            {
                bool isPhone = Regex.IsMatch(s, @"^(\A09\d{9})$", RegexOptions.IgnoreCase);
                return isPhone;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool IsEmail(this string s)
        {
            try
            {
                bool isEmail = Regex.IsMatch(s, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                return isEmail;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool IsTime(this string s)
        {
            try
            {
                bool isTime = Regex.IsMatch(s, @"^(?:(?:0?[0-9]|1[0-2]):[0-5][0-9] [ap]m|(?:[01][0-9]|2[0-3]):[0-5][0-9])$", RegexOptions.IgnoreCase);
                return isTime;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool IsDate(this string s)
        {
            try
            {
                bool isTime = Regex.IsMatch(s, @"^(?:(?:0?[0-9]|1[0-2]):[0-5][0-9] [ap]m|(?:[01][0-9]|2[0-3]):[0-5][0-9])$", RegexOptions.IgnoreCase);
                return isTime;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool IsDateTime(this string s)
        {
            try
            {
                bool isTime = Regex.IsMatch(s, @"^(?:(?:(?:(?:(?:0[13578]|1[02])\/(?:0[1-9]|[1-2][0-9]|3[01]))|(?:(?:0[469]|11)\/(?:0[1-9]|[1-2][0-9]|30))|(?:02\/(?:0[1-9]|1[0-9]|2[0-8]))))\/\d{4}|02\/29\/(?:(?:\d{2}(?:04|08|[2468][048]|[13579][26]))|(?:(?:[02468][048])|[13579][26])00))(?:\s(?:0[1-9]|1[0-2])\:[0-5][0-9]\:[0-5][0-9]\s(?:AM|PM|am|pm))?$", RegexOptions.IgnoreCase);
                return isTime;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool IsDatePersian(this string s)
        {
            try
            {
                bool isTime = Regex.IsMatch(s, @"(?:1[23]\d{2})\/(?:0?[1-9]|1[0-2])\/(?:0?[1-9]|[12][0-9]|3[01])$", RegexOptions.IgnoreCase);
                return isTime;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool IsURL(this string s)
        {
            try
            {
                return Uri.IsWellFormedUriString(s, UriKind.RelativeOrAbsolute);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool IsNationalIDNumber(this string s)
        {
            return s.IsDigit() && s.Trim().Length == 10 && s.Contains(".") == false && s.Contains("-") == false && s.Contains("+") == false;
        }

        #endregion

        #region Array Methods

        public static bool IsEqual(this byte[] array, byte[] arrayToCompare)
        {
            try
            {
                return Enumerable.SequenceEqual(array, arrayToCompare);
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Can not compare inpyt arrays");
            }

        }

        public static T[] Merge<T>(this IEnumerable<T[]> arrays)
        {
            var query = from a in arrays
                        select a.Length;
            T[] result = new T[query.Sum()];
            int offset = 0;
            foreach (T[] array in arrays)
            {
                array.CopyTo(result, offset);
                offset += array.Length;
            }

            return result;
        }

        #endregion

        #region WinForm Control Methods

        public static FieldInfo GetField(this Control control, Form currentForm)
        {
            var field = currentForm.GetType().GetFields().Where(a => control.Name == a.Name && a.FieldType == control.GetType()).FirstOrDefault();
            return field;
        }

        #endregion

        #region DateTime Conversion Methods
        public static int[] ToPersianDateInt(this DateTime date)
        {
            return RayanShafagh.Utility.DateTime.GregorianToPersianInt(date);
        }

        public static int ToPersianYear(this DateTime date)
        {
            return RayanShafagh.Utility.DateTime.GregorianToPersianInt(date)[0];
        }

        public static int ToPersianMonth(this DateTime date)
        {
            return RayanShafagh.Utility.DateTime.GregorianToPersianInt(date)[1];
        }

        public static int ToPersianDay(this DateTime date)
        {
            return RayanShafagh.Utility.DateTime.GregorianToPersianInt(date)[2];
        }

        public static RayanShafagh.Utility.PersianDate ToPersianDate(this DateTime date)
        {
            return new Utility.PersianDate(RayanShafagh.Utility.DateTime.GregorianToPersianInt(date));
        }

        public static List<DateTime> GetSpecialDates(this DateTime startDate,
                                                     DateTime endDate,
                                                     Utility.SpecialDateType specialDateType)
        {
            List<DateTime> specialDates = new List<DateTime>();
            while (startDate < endDate)
            {
                var persianDate = startDate.ToPersianDate();
                switch (specialDateType)
                {
                    case Utility.SpecialDateType.First:
                        if (persianDate.Day == 1)
                        {
                            specialDates.Add(startDate);
                        }
                        break;
                    case Utility.SpecialDateType.Last:
                        if (persianDate.Day == persianDate.LastDayOfMonth)
                        {
                            specialDates.Add(startDate);
                        }
                        break;
                    case Utility.SpecialDateType.Middle:
                        if (persianDate.Day == 15)
                        {
                            specialDates.Add(startDate);
                        }
                        break;
                }
                startDate = startDate.AddDays(1);
            }

            return specialDates;
        }



        #endregion

        #region PersianDate Conversion Methods

        public static DateTime? ToEnDate(this Utility.PersianDate pdate)
        {
            return pdate.ToString().ToDateTimeFromPersianDate();
        }

        #endregion

        #region String Validation Checks

        public static void ErrorIfNotName(this string s)
        {
            if (!s.IsName())
            {
                throw new Exception();
            }
        }

        public static void ErrorIfNotDigit(this string s)
        {
            if (!s.IsDigit())
            {
                throw new Exception();
            }
        }

        public static void ErrorIfNotInt16(this string s)
        {
            if (!s.IsInt16())
            {
                throw new Exception();
            }
        }

        public static void ErrorIfNotInt32(this string s)
        {
            if (!s.IsInt32())
            {
                throw new Exception();
            }
        }

        public static void ErrorIfNotInt64(this string s)
        {
            if (!s.IsInt64())
            {
                throw new Exception();
            }
        }

        public static void ErrorIfNotByte(this string s)
        {
            if (!s.IsByte())
            {
                throw new Exception();
            }
        }

        public static void ErrorIfNotPhoneNumber(this string s)
        {
            if (!s.IsPhoneNumber())
            {
                throw new Exception();
            }
        }

        public static void ErrorIfNotEmail(this string s)
        {
            if (!s.IsEmail())
            {
                throw new Exception();
            }
        }

        public static void ErrorIfNotTime(this string s)
        {
            if (!s.IsTime())
            {
                throw new Exception();
            }
        }

        public static void ErrorIfNotDate(this string s)
        {
            if (!s.IsDate())
            {
                throw new Exception();
            }
        }

        public static void ErrorIfNotDateTime(this string s)
        {
            if (!s.IsDateTime())
            {
                throw new Exception();
            }
        }

        public static void ErrorIfNotDatePersian(this string s)
        {
            if (!s.IsDatePersian())
            {
                throw new Exception();
            }
        }

        public static void ErrorIfNotURL(this string s)
        {
            if (!s.IsURL())
            {
                throw new Exception();
            }
        }

        public static void ErrorIfNotNationalIDNumber(this string s)
        {
            if (!s.IsNationalIDNumber())
            {
                throw new Exception();
            }
        }

        #endregion
    }
}
