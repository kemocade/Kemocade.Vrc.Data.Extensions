using NUnit.Framework;
using VRC.SDK3.Data;
using static NUnit.Framework.Assert;

namespace Kemocade.Vrc.Data.Extensions.Tests
{
    public static partial class DataDictionaryExtensions
    {
        [Test]
        public static void WhereValuesContainNone()
        {
            True(TestDictionary.TryGetValues("menu", out DataDictionary[] menu));
            // TODO: Validate other unit tests in this style
            DataDictionary[] whereValuesContainNone = menu
                .WhereValuesContainNone
                (
                    "ingredients",
                    new string[] { "Water", "Milk" }
                );
            True(whereValuesContainNone.Length == 2);
            True(whereValuesContainNone[0]["name"] == "Espresso");
            True(whereValuesContainNone[1]["name"] == "Mango Smoothie");
        }
    }
}