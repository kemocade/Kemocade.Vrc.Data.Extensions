using VRC.SDK3.Data;
using static Kemocade.Vrc.Data.Extensions.Shared;

namespace Kemocade.Vrc.Data.Extensions
{
    public static partial class DataListExtensions
    {
        // TODO: special error message if passed in non-array type (use Cast instead!)
        // If the cast fails, force an exception
        public static T[] CastArray<T>(this DataList input) =>
            input.TryCastArray(out T[] result) ?
            result : ForceException<T[]>();
    }
}
