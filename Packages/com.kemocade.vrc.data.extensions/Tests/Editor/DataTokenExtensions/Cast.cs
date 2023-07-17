using NUnit.Framework;
using System;
using static NUnit.Framework.Assert;

namespace Kemocade.Vrc.Data.Extensions.Tests
{
    public static partial class DataTokenExtensions
    {
        [Test]
        public static void CastDoubleAsInt() =>
            True(DOUBLE_T.Cast<int>() == INT);

        [Test]
        public static void CastDoubleAsByteFail() =>
            Throws<DivideByZeroException>(() => DOUBLE_T.Cast<bool>());

    }
}