/*
 * Originally from:
 * https://stackoverflow.com/questions/26554003/c-sharp-creating-a-non-nullable-string-is-it-possible-somehow
 */

namespace OrbitalDrydock.Functions
{
    public struct nString
    {
        public nString(string val) : this()
        {
            value = val ?? "N/A";
        }
        public nString(string val, string fail) : this()
        {
            failsafe = fail ?? string.Empty;
            value = val ?? failsafe;
        }

        public string failsafe
        {
            get;
            private set;
        }
        public string value
        {
            get;
            private set;
        }

        public static implicit operator nString(string val)
        {
            return new nString(val);
        }

        public static implicit operator string(nString val)
        {
            return val.value;
        }
    }
}
