using VRC.SDK3.Data;

namespace Kemocade.Vrc.Data.Extensions
{
    public static partial class DataDictionaryExtensions
    {
        public static bool TryGetValues<T>
        (this DataDictionary root, string key, out T[] result, char split = DOT)
        {
            if (!root.TryGetValueToken(key, out DataToken token, split))
            {
                result = default;
                return false;
            }

            return token.TryCastArray(out result);
        }
    }
}