using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeClassified.Core.Extentions
{
    public static class StringExtention
    {
        public static int ToInt(this string value)
        {
            if (value is null)
                return 0;
            var tmpVal = value.ToString();
            if (string.IsNullOrEmpty(tmpVal) || string.IsNullOrWhiteSpace(tmpVal))
                return 0;

            int.TryParse(tmpVal, out var val);

            return val;
        }
        public static float ToFloat(this string value)
        {
            if (value is null)
                return 0;
            var tmpVal = value.ToString();
            if (string.IsNullOrEmpty(tmpVal) || string.IsNullOrWhiteSpace(tmpVal))
                return 0;

            float.TryParse(tmpVal, out var val);

            return val;
        }
        public static double ToDouble(this string value)
        {
            if (value is null)
                return 0;
            var tmpVal = value.ToString();
            if (string.IsNullOrEmpty(tmpVal) || string.IsNullOrWhiteSpace(tmpVal))
                return 0;

            double.TryParse(tmpVal, out var val);

            return val;
        }
        public static DateTimeOffset? ToDateTimeOffset(this string value)
        {
            var result = DateTimeOffset.TryParse(value.ToString(), out var dto);
            if (!result)
                return null;
            return dto;
        }
        public static DateTime? ToDate(this string value)
        {
            if (string.IsNullOrEmpty(value.ToString()))
                return null;//new DateTime(); //new DateTime(1919, 01, 09);

            var result = DateTime.TryParse(value.ToString(), out var val);
            if (!result)
                return null;//new DateTime();

            return val;
        }
        public static TimeSpan ToTimeSpan(this string value)
        {
            if (value is null)
                return TimeSpan.Zero; //new DateTime(1919, 01, 09);

            TimeSpan.TryParse(value.ToString(), out var val);

            return val;
        }
        public static bool ToBoolean(this string value)
        {
            if (value is null)
                return false;
            var tmpVal = value.ToString();
            if (string.IsNullOrEmpty(tmpVal) || string.IsNullOrWhiteSpace(tmpVal))
                return false;
            bool.TryParse(tmpVal, out var val);

            return val;
        }
    }
}
