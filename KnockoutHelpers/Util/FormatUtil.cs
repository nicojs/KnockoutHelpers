using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace KnockoutHelpers.Util
{
    public static class FormatUtil
    {
        public static string ToFormattedString(this string format, params object[] args)
        {
            return String.Format(CultureInfo.InvariantCulture, format, args);
        }
    }
}