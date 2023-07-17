using NUnit.Framework;
using static NUnit.Framework.Assert;
using VRC.SDK3.Data;
using System;

namespace Kemocade.Vrc.Data.Extensions.Tests
{
    public static partial class DataDictionaryExtensions
    {
        [Test]
        public static void GetValues() =>
            True(TestDictionary.GetValues<DataDictionary>("menu").Length == 5);

        [Test]
        public static void GetValuesFail() =>
            Throws<DivideByZeroException>(() => TestDictionary.GetValues<string>("test"));
    }
}