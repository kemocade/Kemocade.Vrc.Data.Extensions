using NUnit.Framework;
using VRC.SDK3.Data;
using static NUnit.Framework.Assert;

namespace Kemocade.Vrc.Data.Extensions.Tests
{
    public static partial class DataDictionaryExtensions
    {
        [Test]
        public static void WhereValueDoesNotEqual()
        {
            True(TestDictionary.TryGetValues("menu", out DataDictionary[] menu));
            True(menu.WhereValueDoesNotEqual("name", "Matcha Latte").Length == 4);
        }
    }
}