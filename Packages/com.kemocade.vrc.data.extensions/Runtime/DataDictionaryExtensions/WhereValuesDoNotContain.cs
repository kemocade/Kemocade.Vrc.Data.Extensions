using VRC.SDK3.Data;

namespace Kemocade.Vrc.Data.Extensions
{
    public static partial class DataDictionaryExtensions
    {
        public static DataDictionary[] WhereValuesDoNotContain<T>
        (this DataDictionary[] dicts, string key, T target, char split = DOT) =>
            dicts.WhereValuesContainNone(key, new T[] { target }, split);
    }
}