using VRC.SDK3.Data;

namespace Kemocade.Vrc.Data.Extensions
{
    public static partial class DataDictionaryExtensions
    {
        public static DataDictionary[] WhereValuesContain<T>
        (this DataDictionary[] dicts, string key, T target, char split = DOT) =>
            dicts.WhereValuesContainAny(key, new T[] { target }, split);
    }
}