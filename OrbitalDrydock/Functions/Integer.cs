using System;
using System.Linq;

namespace OrbitalDrydock.Functions
{
    public class Integer
    {
        public static int convertLongToInt(long interactionId, int failsafe)
        {
            return (interactionId > Convert.ToInt64(Int32.MaxValue) || interactionId < Convert.ToInt64(Int32.MinValue))
                ? failsafe
                : Convert.ToInt32(interactionId);
        }
        public static int convertStringToInt(string someString, int failsafe)
        {
            int num;
            if (!int.TryParse(someString, out num))
            {
                num = failsafe;
            }
            return num;
        }
        public static int convertObjectToInt(object someObject, int failsafe)
        {
            return convertStringToInt(
                (someObject != null) ? someObject.ToString() : failsafe.ToString()
                , failsafe);
        }

        public static long convertStringToLong(string someString, long failsafe)
        {
            long num;
            if (!long.TryParse(someString, out num))
            {
                num = failsafe;
            }

            return num;
        }
        public static long convertObjectToLong(object someObject, long failsafe)
        {
            return convertStringToLong(
                (someObject != null) ? someObject.ToString() : failsafe.ToString()
                , failsafe);
        }
    }
}
