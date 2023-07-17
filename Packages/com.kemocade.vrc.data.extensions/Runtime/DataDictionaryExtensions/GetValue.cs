using VRC.SDK3.Data;
using static Kemocade.Vrc.Data.Extensions.Shared;

namespace Kemocade.Vrc.Data.Extensions
{
    public static partial class DataDictionaryExtensions
    {
        public static T GetValue<T>
        (this DataDictionary source, string key, char split = DOT) =>
            source.TryGetValue(key, out T result, split) ?
            result : ForceException<T>();
    }
}