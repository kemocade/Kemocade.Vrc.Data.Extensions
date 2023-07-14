using NUnit.Framework;
using VRC.SDK3.Data;
using static NUnit.Framework.Assert;

namespace Kemocade.Vrc.Data.Extensions.Tests
{
    public static partial class DataDictionaryExtensions
    {
        [Test]
        public static void WhereValuesDoNotContain()
        {
            True(TestDictionary.TryGetValues("menu", out DataDictionary[] menu));
            // TODO: Validate other unit tests in this style
            DataDictionary[] filtered = menu
                .WhereValuesDoNotContain("ingredients", "Coffee");

            True(filtered.Length == 2);
            True(filtered[0]["name"] == "Matcha Latte");
            True(filtered[1]["name"] == "Mango Smoothie");
        }
    }
}