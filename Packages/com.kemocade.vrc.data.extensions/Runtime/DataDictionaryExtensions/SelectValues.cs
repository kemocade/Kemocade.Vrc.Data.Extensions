using VRC.SDK3.Data;

namespace Kemocade.Vrc.Data.Extensions
{
    public static partial class DataDictionaryExtensions
    {
        public static T[] SelectValues<T>
        (this DataDictionary[] dicts, string key, char split = DOT)
        {
            T[] matches = new T[dicts.Length];
            int matchesCount = 0;
            foreach (DataDictionary dict in dicts)
            {
                if (!dict.TryGetValue(key, out T child, split)) { continue; }
                matches[matchesCount++] = child;
            }

            return Fit(matches, matchesCount);
        }
    }
}