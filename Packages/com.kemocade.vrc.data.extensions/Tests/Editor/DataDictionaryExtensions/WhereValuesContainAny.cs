using NUnit.Framework;
using VRC.SDK3.Data;
using static NUnit.Framework.Assert;

namespace Kemocade.Vrc.Data.Extensions.Tests
{
    public static partial class DataDictionaryExtensions
    {
        [Test]
        public static void WhereValuesContainAny()
        {
            True(TestDictionary.TryGetValues("menu", out DataDictionary[] menu));
            True
            (
                menu.WhereValuesContainAny
                (
                    "ingredients",
                    new string[] { "Water", "Milk" }
                )
                .Length == 3
            );
        }
    }
}