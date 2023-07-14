using VRC.SDK3.Data;

namespace Kemocade.Vrc.Data.Extensions
{
    public static partial class DataDictionaryExtensions
    {
        public static bool TryGetValueToken
        (this DataDictionary root, string key, out DataToken result, char split = DOT)
        {
            string[] keys = key.Split(split);

            // Process multiple keys if present
            if ( keys.Length > 1)
            {
                // If more than one key is provided, move down sub-dictionaries
                for (int i = 0; i < keys.Length - 1; i++)
                {
                    if (!root.TryGetValue(keys[i], TokenType.DataDictionary, out DataToken next))
                    {
                        result = default;
                        return false;
                    }
                    root = next.DataDictionary;
                }

                // Get the final key
                key = keys[keys.Length - 1];
            }

            // Get the final value
            return root.TryGetValue(key, out result);
        }
    }
}