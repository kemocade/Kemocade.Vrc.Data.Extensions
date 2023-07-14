using NUnit.Framework;
using VRC.SDK3.Data;
using static NUnit.Framework.Assert;

namespace Kemocade.Vrc.Data.Extensions.Tests
{
    public static partial class DataDictionaryExtensions
    {
        [Test]
        public static void TryGetValue()
        {
            True(TestDictionary.TryGetValue("name", out string name));
            True(name == "Dustuu's Café");
        }

        [Test]
        public static void TryGetValueFail()
        {
            False(TestDictionary.TryGetValue("test", out string test));
        }
    }
}