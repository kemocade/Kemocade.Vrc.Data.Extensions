using NUnit.Framework;
using VRC.SDK3.Data;
using static NUnit.Framework.Assert;

namespace Kemocade.Vrc.Data.Extensions.Tests
{
    public static partial class DataTokenExtensions
    {
        [Test]
        public static void TryCastArray() =>
            True
            (
                new DataToken(new DataList(1, 2, 3)).TryCastArray(out int[] output) &&
                output.Length == 3 &&
                output[0] == 1 &&
                output[1] == 2 &&
                output[2] == 3
            );

        [Test]
        public static void TryCastArrayUnwrapped()
        {
            DataToken input = new DataList(1, 2, 3);
            True
            (
                input.TryCastArray(out int[] output) &&
                output.Length == 3 &&
                output[0] == 1 &&
                output[1] == 2 &&
                output[2] == 3
            );
        }

        [Test]
        public static void TryCastArrayFailNotDataList() =>
            False(new DataToken("string").TryCastArray(out int[] output));

        [Test]
        public static void TryCastArrayFailInvalidCast() =>
            False(new DataToken(new DataList(1, "string")).TryCastArray(out int[] output));
    }
}