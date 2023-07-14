using NUnit.Framework;
using VRC.SDK3.Data;
using static NUnit.Framework.Assert;

namespace Kemocade.Vrc.Data.Extensions.Tests
{
    public static partial class DataDictionaryExtensions
    {
        [Test]
        public static void SelectValues()
        {
            TestDictionary.TryGetValues("menu", out DataDictionary[] menu);
            string[] names = menu.SelectValues<string>("name");
            True(names.Length == 5 && names[1] == "Americano");
        }
    }
}