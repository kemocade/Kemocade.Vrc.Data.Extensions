using NUnit.Framework;
using VRC.SDK3.Data;
using static NUnit.Framework.Assert;

namespace Kemocade.Vrc.Data.Extensions.Tests
{
    public static partial class DataDictionaryExtensions
    {
        [Test]
        public static void WhereValueEquals()
        {
            True(TestDictionary.TryGetValues("menu", out DataDictionary[] menu));
            True(menu.WhereValueEquals("name", "Matcha Latte").Length == 1);
        }

        [Test]
        public static void WhereValueEqualsNested()
        {
            True(TestDictionary.TryGetValues("menu", out DataDictionary[] menu));
            True(menu.WhereValueEquals("source.name", "Happy Farm").Length == 1);
        }
    }
}