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
        /// Tries to get the key value from the dictionary
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
    }
}
