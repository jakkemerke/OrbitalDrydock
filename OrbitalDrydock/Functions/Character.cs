using System.Text;

namespace OrbitalDrydock.Functions
{
    public class Character
    {
        public static string convertStringToAsciiPrintableSafe(string value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            StringBuilder result = new StringBuilder();
            foreach (var current in value)
            {
                byte currentByte = (byte)current;
                if (currentByte < 32 || currentByte > 126)
                {
                    //spaces char 32 are printable
                    //ignore others
                }
                else
                {
                    result.Append(current);
                }
            }
            return result.ToString();
        }
        public static string replaceWhitespace(string value, string replacement)
        {
            if (value == null)
            {
                return string.Empty;
            }

            StringBuilder result = new StringBuilder();
            foreach (var current in value)
            {
                byte currentByte = (byte)current;
                if (currentByte <= 32 || currentByte > 126)
                {
                    result.Append(replacement);
                }
                else
                {
                    result.Append(current);
                }
            }
            return result.ToString();
        }
    }
}
