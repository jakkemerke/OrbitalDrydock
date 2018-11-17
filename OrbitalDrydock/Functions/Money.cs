using System.Linq;

namespace OrbitalDrydock.Functions
{
    public class Money
    {
        /// <summary>
        /// Attempts to parse the string to only contain two digits after the decimal point.
        /// faux regex: [0-9]{n}[.]{1}[0-9]{2} 
        /// params: input, faildollars, failcents
        /// returns: result
        /// </summary>
        public static string convertStringToDollarsDotCents(string value, int failsafeDollars, int failsafeCents)
        {
            char dot = '.';
            string[] temp
                = (!string.IsNullOrEmpty(value) && value.Contains(dot) && value.Split(dot).Length == 2)
                ? value.Split(dot)
                : new string[] { failsafeDollars.ToString(), failsafeCents.ToString() };

            int dollars = Integer.convertStringToInt(temp[0], failsafeDollars);

            char[] centsProto1 = temp[1].ToCharArray();
            string centsProto2
                = (centsProto1 != null && centsProto1.Length > 1)
                ? centsProto1[0].ToString() + centsProto1[1].ToString()
                : failsafeCents.ToString();
            int cents = Integer.convertStringToInt(centsProto2, failsafeCents);

            return dollars.ToString() + "." + ((cents < 10 && cents > -1) ? "0" + cents.ToString() : cents.ToString());
        }
    }
}
