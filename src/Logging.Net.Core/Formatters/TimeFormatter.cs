using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Net.Core.Formatters
{
    public static class DateTimeFormatter
    {
        const string DefaultFormatValuesSeparator = ":";

        public static string AddUtcDate(this string message)
        {
            return $"{DateTime.UtcNow.ToString("d")}{DefaultFormatValuesSeparator}{message}";
        }

        public static string AddUtcTime(this string message)
        { 
            return $"{DateTime.UtcNow.ToString("T")}{DefaultFormatValuesSeparator}{message}";
        }

        public static string AddDate(this string message, FormatType format)
        {
            if(IsFormatEnabled(format, FormatType.Date))
            {
                return message.AddUtcDate();
            }

            return message;
        }

        public static string AddTime(this string message, FormatType format)
        {
            if (IsFormatEnabled(format, FormatType.Date))
            {
                return message.AddUtcTime();
            }

            return message;
        }

        public static string AddDateTime(this string message, FormatType format)
        {
            return message.AddTime(format).AddDate(format);
        }

        private static bool IsFormatEnabled(FormatType sourceFormats, FormatType singleFormatValue)
        {
            // Checks that singleFormatValue contains in sourceFormats when passes value like `SingleFormat.Date | SingleFormat.Time`
            return (sourceFormats & singleFormatValue) == singleFormatValue;
        }
    }
}
