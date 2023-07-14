using NUnit.Framework;
using VRC.SDK3.Data;
using static NUnit.Framework.Assert;

namespace Kemocade.Vrc.Data.Extensions.Tests
{
    public static partial class DataDictionaryExtensions
    {
        [Test]
        public static void TryGetValueToken()
        {
            TestDictionary.TryGetValueToken("name", out DataToken name);
            True(name.TokenType == TokenType.String && name.String == "Dustuu's Café");
        }
    }
}