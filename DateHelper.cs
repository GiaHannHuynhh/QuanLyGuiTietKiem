using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGuiTietKiem
{
    public class DateHelper
    {
        private const string DateFormat = "dd/MM/yyyy";

        public static DateTime ParseDate(string dateString)
        {
            string[] formats = { "dd/MM/yyyy", "MM/dd/yyyy" };
            if (DateTime.TryParseExact(dateString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                return result;
            }
            throw new FormatException($"Invalid date format. Expected formats: {string.Join(", ", formats)}");
        }

        public static string FormatDate(DateTime date)
        {
            return date.ToString(DateFormat);
        }
    }
}
