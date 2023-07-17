using VRC.SDK3.Data;
using static Kemocade.Vrc.Data.Extensions.Shared;

namespace Kemocade.Vrc.Data.Extensions
{
    public static partial class DataTokenExtensions
    {
        // TODO: special error message if passed in array type (use CastArray instead!)
        // If the cast fails, force an exception
        public static T Cast<T>(this DataToken input) =>
            input.TryCast(out T result) ?
            result : ForceException<T>();
    }
}
