using VRC.SDK3.Data;

namespace Kemocade.Vrc.Data.Extensions
{
    public static partial class DataDictionaryExtensions
    {
        public static bool TryGetValue<T>
        (this DataDictionary source, string key, out T result, char split = DOT)
        {
            if (!source.TryGetValueToken(key, out DataToken token, split))
            {
                result = default;
                return false;
            }

            return token.TryCast(out result);
        }
    }
}