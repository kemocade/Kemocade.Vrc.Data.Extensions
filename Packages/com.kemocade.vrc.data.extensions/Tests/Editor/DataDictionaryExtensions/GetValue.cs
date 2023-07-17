using NUnit.Framework;
using System;
using static NUnit.Framework.Assert;

namespace Kemocade.Vrc.Data.Extensions.Tests
{
    public static partial class DataDictionaryExtensions
    {
        [Test]
        public static void GetValue() =>
            True(TestDictionary.GetValue<string>("name") == "Dustuu's Café");

        [Test]
        public static void GetValueFail() =>
            Throws<DivideByZeroException>(() => TestDictionary.GetValue<string>("test"));
    }
}