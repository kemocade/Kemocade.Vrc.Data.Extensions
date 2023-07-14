using NUnit.Framework;
using VRC.SDK3.Data;
using static NUnit.Framework.Assert;
using static VRC.SDK3.Data.VRCJson;

namespace Kemocade.Vrc.Data.Extensions.Tests
{
    public static partial class DataDictionaryExtensions
    {
        [Test]
        public static void TrySerializeToJson()
        {
            True(TestDictionary.TryGetValues("menu", out DataDictionary[] menu));
            True(menu.TrySerializeToJson(out string menuJson));
            True(TryDeserializeFromJson(menuJson, out DataToken menuToken));
            True(menuToken.TokenType == TokenType.DataList);
            True(menuToken.DataList.Count == 5);
        }

        [Test]
        public static void TrySerializeToJsonFail()
        {
            DataToken referenceToken = new DataToken(typeof(DataDictionary));
            DataDictionary referenceDictionary = new DataDictionary() { { 0, referenceToken } };
            DataDictionary[] unserializable = new DataDictionary[] { referenceDictionary };
            False(unserializable.TrySerializeToJson(out string fail));
        }
    }
}