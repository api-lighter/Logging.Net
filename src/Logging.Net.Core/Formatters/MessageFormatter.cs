using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Net.Core.Formatters
{
    public static class MessageFormatter
    {
        public static string FormatMessage(this string message, FormatType format)
        {
            return message.AddDateTime(format);
        }
    }
}
