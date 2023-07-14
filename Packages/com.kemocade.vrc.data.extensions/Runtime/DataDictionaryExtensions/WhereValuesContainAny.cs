using VRC.SDK3.Data;

namespace Kemocade.Vrc.Data.Extensions
{
    public static partial class DataDictionaryExtensions
    {
        public static DataDictionary[] WhereValuesContainAny<T>
        (this DataDictionary[] dicts, string key, T[] targets, char split = DOT)
        {
            DataDictionary[] matches = new DataDictionary[dicts.Length];
            int matchesCount = 0;
            foreach (DataDictionary dict in dicts)
            {
                if (!dict.TryGetValues(key, out T[] children, split)) { continue; }
                if (ContainsAny(children, targets)) { matches[matchesCount++] = dict; }
            }

            return Fit(matches, matchesCount);
        }
    }
}