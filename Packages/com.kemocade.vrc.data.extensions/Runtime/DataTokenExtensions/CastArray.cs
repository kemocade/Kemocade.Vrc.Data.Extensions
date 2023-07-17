using VRC.SDK3.Data;
using static Kemocade.Vrc.Data.Extensions.Shared;

namespace Kemocade.Vrc.Data.Extensions
{
    public static partial class DataTokenExtensions
    {
        // TODO: special error message if passed in non-array type (use Cast instead!)
        // If the cast fails, force an exception
        public static T[] CastArray<T>(this DataToken input) =>
            input.TryCastArray(out T[] result) ?
            result : ForceException<T[]>();
    }
}
