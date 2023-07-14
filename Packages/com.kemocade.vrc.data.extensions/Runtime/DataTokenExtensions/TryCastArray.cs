using VRC.SDK3.Data;

namespace Kemocade.Vrc.Data.Extensions
{
    public static partial class DataTokenExtensions
    {
        public static bool TryCastArray<T>(this DataToken token, out T[] result)
        {
            if
            (
                token.TokenType != TokenType.DataList ||
                !token.DataList.TryCastArray(out result)
            )
            {
                result = default;
                return false;
            }

            return true;
        }
    }
}
