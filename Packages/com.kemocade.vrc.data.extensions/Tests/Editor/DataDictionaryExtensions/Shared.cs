using VRC.SDK3.Data;
using static VRC.SDK3.Data.VRCJson;

namespace Kemocade.Vrc.Data.Extensions.Tests
{
    public static partial class DataDictionaryExtensions
    {
        const string JSON =
        @"{
            ""name"": ""Dustuu's Café"",
            ""menu"":
            [
                {
                    ""name"": ""Espresso"",
                    ""price"": 90,
                    ""ingredients"": [""Coffee""],
                    ""source"":
                    {
                        ""name"": ""Happy Farm"",
                        ""location"": ""Kuala Lumpur""
                    }
                },
                {
                    ""name"": ""Americano"",
                    ""price"": 80,
                    ""ingredients"": [""Coffee"", ""Water""]
                },
                {
                    ""name"": ""Latte"", 
                    ""price"": 100,
                    ""ingredients"": [""Coffee"", ""Milk""]
                },
                {
                    ""name"": ""Matcha Latte"",
                    ""price"": 120,
                    ""ingredients"": [""Matcha"", ""Milk""]
                },
                {
                    ""name"": ""Mango Smoothie"",
                    ""price"": 100,
                    ""ingredients"": [""Mango"", ""Ice""]
                }
            ]
        }";

        // Throws an exception if the JSON is invalid
        private static DataDictionary TestDictionary
        {
            get
            {
                TryDeserializeFromJson(JSON, out DataToken token);
                return token.DataDictionary;
            }
        }
    }
}