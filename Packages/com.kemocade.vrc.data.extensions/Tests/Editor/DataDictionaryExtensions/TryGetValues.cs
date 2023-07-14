using NUnit.Framework;
using VRC.SDK3.Data;
using static NUnit.Framework.Assert;

namespace Kemocade.Vrc.Data.Extensions.Tests
{
    public static partial class DataDictionaryExtensions
    {
        [Test]
        public static void TryGetValues()
        {
            TestDictionary.TryGetValues("menu", out DataDictionary[] menu);
            True(menu.Length == 5);
        }

        [Test]
        public static void TryGetValuesFail()
        {
            False(TestDictionary.TryGetValues("test", out string[] test));
        }
    }
}