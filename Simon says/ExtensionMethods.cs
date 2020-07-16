using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

namespace System
{
    public static class ExtensionMethods
    {

        /// <summary>
        /// Tries to get the key value from the dictionary. If unsuccessful, then returns the default value
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary">Dictionary instance holding the TKey and TValue</param>
        /// <param name="key">Key we are looking for</param>
        /// <param name="defaultValue">Default value to return when the TKey is not found in the dictionary</param>
        /// <returns></returns>
        public static TValue GetOrDefault<TKey, TValue>(this System.Collections.Generic.Dictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue))
        {
            
            if(dictionary.TryGetValue(key, out var value))
            {
                return value;
            }
            return defaultValue;
            /*
            if (dictionary != null && dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            return defaultValue;
            */
        }

        public static Drawing.Color HexToColor(this uint argb)
        {
            return Drawing.Color.FromArgb((byte)(argb & (argb & 0xff000000) >> 0x18),
                                  (byte)((argb & 0xff0000) >> 0x10),
                                  (byte)((argb & 0xff00) >> 0x08),
                                  (byte)(argb & 0xff));
        }

        public static String ColorToHex(this Drawing.Color argb)
        {
            return argb.A.ToString("X2") + argb.R.ToString("X2") + argb.G.ToString("X2") + argb.B.ToString("X2");
        }
    }
}
