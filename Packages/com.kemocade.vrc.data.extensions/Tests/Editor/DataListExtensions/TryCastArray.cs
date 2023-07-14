using NUnit.Framework;
using VRC.SDK3.Data;
using static NUnit.Framework.Assert;

namespace Kemocade.Vrc.Data.Extensions.Tests
{
    public static partial class DataListExtensions
    {
        [Test]
        public static void TryCastAll() =>
            True
            (
                new DataList(1, 2, 3).TryCastArray(out int[] output) &&
                output.Length == 3 &&
                output[0] == 1 &&
                output[1] == 2 &&
                output[2] == 3
            );
    }
}