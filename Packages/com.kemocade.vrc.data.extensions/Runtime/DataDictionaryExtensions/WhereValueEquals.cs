using VRC.SDK3.Data;

namespace Kemocade.Vrc.Data.Extensions
{
    public static partial class DataDictionaryExtensions
    {
        public static DataDictionary[] WhereValueEquals<T>
        (this DataDictionary[] dicts, string key, T target, char split = DOT)
        {
            DataDictionary[] matches = new DataDictionary[dicts.Length];
            int matchesCount = 0;
            foreach (DataDictionary dict in dicts)
            {
                if
                (
                    !dict.TryGetValue(key, out T child, split) ||
                    !child.Equals(target)
                )
                { continue; }
                matches[matchesCount++] = dict;
            }

            return Fit(matches, matchesCount);
        }
    }
}