using NUnit.Framework;
using System;
using VRC.SDK3.Data;
using static NUnit.Framework.Assert;

namespace Kemocade.Vrc.Data.Extensions.Tests
{
    public static partial class DataTokenExtensions
    {
        [Test]
        public static void CastDoubleListTokenAsIntArray()
        {
            DataToken doublesToken = new DataList(1.1, 2.1, 3.1);
            int[] ints = doublesToken.CastArray<int>();
            True(ints.Length == 3);
            True(ints[0] == 1);
            True(ints[1] == 2);
            True(ints[2] == 3);
        }

        [Test]
        public static void CastDoubleListTokenAsBoolArrayFail() =>
            Throws<DivideByZeroException>
            (() => new DataToken(new DataList(1.1, 2.1, 3.1)).Cast<bool>());
    }
}