using System;
using System.Linq;

namespace OrbitalDrydock.Functions
{
    public class Moment
    {
        public static DateTime toDateTime(string dateString)
        {
            return toDateTime(dateString, DateTime.MinValue);
        }
        public static DateTime toDateTime(string dateString, DateTime failsafe)
        {
            //TODO: Add the .NET built-ins such as "d", "D", "f", etc.
            //      https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings
            //NOTE: To build the formats array, there's probably some elegant
            //      way to use linq to do something like a haskell zip.
            var s0 = string.Empty;
            var s1 = " ";
            var s2 = "T";
            var d1 = "yyyy-M-d";
            var d2 = "yyyy/M/d";
            var d3 = "M/d/yyyy";
            var d4 = "M/d/yy";
            var t0 = string.Empty;
            var t1 = "h:mm:ss tt";
            var t2 = "h:mm tt";
            var t3 = "H:mm:ss";
            var t4 = "H:mm";
            var t5 = "h:m tt";
            var dateTimeFormats = new string[] {
                string.Join(s1, d1, t1),
                string.Join(s1, d1, t2),
                string.Join(s1, d1, t3),
                string.Join(s1, d1, t4),
                string.Join(s1, d1, t5),
                string.Join(s1, d2, t1),
                string.Join(s1, d2, t2),
                string.Join(s1, d2, t3),
                string.Join(s1, d2, t4),
                string.Join(s1, d2, t5),
                string.Join(s1, d3, t1),
                string.Join(s1, d3, t2),
                string.Join(s1, d3, t3),
                string.Join(s1, d3, t4),
                string.Join(s1, d3, t5),
                string.Join(s1, d4, t1),
                string.Join(s1, d4, t2),
                string.Join(s1, d4, t3),
                string.Join(s1, d4, t4),
                string.Join(s1, d4, t5),
                string.Join(s2, d1, t1),
                string.Join(s2, d1, t2),
                string.Join(s2, d1, t3),
                string.Join(s2, d1, t4),
                string.Join(s2, d1, t5),
                string.Join(s2, d2, t1),
                string.Join(s2, d2, t2),
                string.Join(s2, d2, t3),
                string.Join(s2, d2, t4),
                string.Join(s2, d2, t5),
                string.Join(s2, d3, t1),
                string.Join(s2, d3, t2),
                string.Join(s2, d3, t3),
                string.Join(s2, d3, t4),
                string.Join(s2, d3, t5),
                //date only
                string.Join(s0, d1, t0),
                string.Join(s0, d2, t0),
                string.Join(s0, d3, t0),
                string.Join(s0, d4, t0)
            };

            var cult = System.Globalization.CultureInfo.InvariantCulture;
            var assm = System.Globalization.DateTimeStyles.AssumeLocal;
            Func<string, string, DateTime, DateTime> tryParseExactFu =
            (val1, val2, val3) =>
            {
                DateTime blar;
                return DateTime.TryParseExact(val1, val2, cult, assm, out blar) ? blar : val3;
            };
            var glux = dateTimeFormats
                .Select(blar => tryParseExactFu(dateString, blar, failsafe))
                .Where(blar => blar != failsafe)
                .ToArray();
            return (glux != null && glux.Length > 0) ? glux[0] : failsafe;
        }
    }
}
