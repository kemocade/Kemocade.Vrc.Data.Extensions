using NUnit.Framework;
using System;
using VRC.SDK3.Data;
using static NUnit.Framework.Assert;

namespace Kemocade.Vrc.Data.Extensions.Tests
{
    public static partial class DataListExtensions
    {
        [Test]
        public static void CastDoubleListAsIntArray()
        {
            int[] ints = new DataList(1.1, 2.1, 3.1).CastArray<int>();
            True(ints.Length == 3);
            True(ints[0] == 1);
            True(ints[1] == 2);
            True(ints[2] == 3);
        }

        [Test]
        public static void CastDoubleListAsBoolArrayFail() =>
            Throws<DivideByZeroException>
            (() => new DataList(1.1, 2.1, 3.1).CastArray<bool>());
    }
}