using NUnit.Framework;
using VRC.SDK3.Data;
using static NUnit.Framework.Assert;

namespace Kemocade.Vrc.Data.Extensions.Tests
{
    public static class ReadMeTests
    {
        [Test]
        public static void ReadMeSnippets()
        {
            string jsonString =
            @"{
                ""name"": ""Dustuu"",
                ""badges"": 8,
                ""inventory"":
                {
                    ""money"": 1000,
                    ""items"": [""Potion"", ""Revive"", ""Elixir""]
                },
                ""team"":
                [
                    {
                        ""species"": ""Swampert"",
                        ""level"": 100,
                        ""types"": [""Water"", ""Ground""],
                        ""item"": ""Oran Berry""
                    },
                    {
                        ""species"": ""Flygon"",
                        ""level"": 100,
                        ""types"": [""Ground"", ""Dragon""]
                    },
                    {
                        ""species"": ""Walrien"",
                        ""level"": 50,
                        ""types"": [""Ice"", ""Water""],
                        ""item"": ""Cheri Berry""
                    }
                ]
            }";

            // 1
            VRCJson.TryDeserializeFromJson(jsonString, out DataToken token);
            DataDictionary game = token.DataDictionary;

            // Test
            NotNull(game);

            // 2
            game.TryGetValue("name", out string name);

            // Test
            True(name == "Dustuu");

            // 3
            game.TryGetValue("inventory.money", out int money);

            // Test
            True(money == 1000);

            // 4
            game.TryGetValues("inventory.items", out string[] items);

            // Test
            True(items.Length == 3);
            True(items[0] == "Potion");
            True(items[1] == "Revive");
            True(items[2] == "Elixir");

            // 5
            game.TryGetValues("team", out DataDictionary[] team);

            // Test
            True(team.Length == 3);
            True(team[0].TryGetValue("species", out string swampertSpecies));
            True(swampertSpecies == "Swampert");
            True(team[1].TryGetValue("species", out string flygonSpecies));
            True(flygonSpecies == "Flygon");
            True(team[2].TryGetValue("species", out string walrienSpecies));
            True(walrienSpecies == "Walrien");

            // 6
            DataDictionary[] isLevel100 = team.WhereValueEquals("level", 100);

            // Test
            True(isLevel100.Length == 2);
            True(isLevel100[0].TryGetValue("level", out int swampertLevel));
            True(swampertLevel == 100);
            True(isLevel100[1].TryGetValue("level", out int flygonLevel));
            True(flygonLevel == 100);

            // 7
            DataDictionary[] hasOranBerry = team.WhereValueEquals("item", "Oran Berry");

            // Test
            True(hasOranBerry.Length == 1);
            True(hasOranBerry[0].TryGetValue("item", out string swampertItem));
            True(swampertItem == "Oran Berry");

            // 8
            DataDictionary[] hasWaterType = team.WhereValuesContain("types", "Water");

            // Test
            True(hasWaterType.Length == 2);
            True(hasWaterType[0].TryGetValues("types", out string[] swampertTypes));
            True(swampertTypes.Length == 2);
            True(swampertTypes[0] == "Water");
            True(swampertTypes[1] == "Ground");
            True(hasWaterType[1].TryGetValues("types", out string[] walrienTypes));
            True(walrienTypes.Length == 2);
            True(walrienTypes[0] == "Ice");
            True(walrienTypes[1] == "Water");

            // 9
            DataDictionary[] hasGroundOrIceType = team.WhereValuesContainAny("types", new string[] { "Ground", "Ice" });

            // Test
            True(hasGroundOrIceType.Length == 3);

            // 10
            string[] species = team.SelectValues<string>("species");

            // Test
            True(species.Length == 3);
            True(species[0] == "Swampert");
            True(species[1] == "Flygon");
            True(species[2] == "Walrien");

            // 11
            DataToken inputIntFive = new DataToken(5);
            inputIntFive.TryCast(out int outputIntFive);

            // Test
            True(outputIntFive == 5);

            // 12
            DataToken inputIntSix = new DataToken(6);
            inputIntSix.TryCast(out float outputFloatSix);

            // Test
            True(outputFloatSix == 6f);

            // 13
            DataToken inputFloatSixPointFive = new DataToken(6.5f);
            inputFloatSixPointFive.TryCast(out int outputIntSix);

            // Test
            True(outputIntSix == 6);

            // 14
            DataToken inputStringTen = new DataToken("10");
            inputStringTen.TryCast(out int outputIntTen);

            // Test
            True(outputIntTen == 10);

            // 15
            DataToken inputIntTen = new DataToken(10);
            inputIntTen.TryCast(out string outputStringTen);

            // Test
            True(outputStringTen == "10");

            // 16
            DataList intputIntList = new DataList();
            intputIntList.Add(1);
            intputIntList.Add(2);
            intputIntList.Add(3);
            DataToken inputIntListToken = intputIntList;
            inputIntListToken.TryCastArray(out int[] outputIntArray);

            // Test
            True(outputIntArray.Length == 3);
            True(outputIntArray[0] == 1);
            True(outputIntArray[1] == 2);
            True(outputIntArray[2] == 3);

            // 17
            DataList inputStringList = new DataList();
            inputStringList.Add("a");
            inputStringList.Add("b");
            inputStringList.Add("c");
            inputStringList.TryCastArray(out string[] outputStringArray);

            // Test
            True(outputStringArray.Length == 3);
            True(outputStringArray[0] == "a");
            True(outputStringArray[1] == "b");
            True(outputStringArray[2] == "c");

            // 18
            // This line is not in the original readme snippet
            string[] waterSpeciesPackage = new string[0];

            if (game.TryGetValues("team", out DataDictionary[] members))
            {
                string[] waterSpeciesArray = members
                    .WhereValuesContain("types", "Water")
                    .SelectValues<string>("species");

                // This line is not in the original readme snippet
                waterSpeciesPackage = waterSpeciesArray;
            }

            // Test
            True(waterSpeciesPackage.Length == 2);
            True(waterSpeciesPackage[0] == "Swampert");
            True(waterSpeciesPackage[1] == "Walrien");

            // 19
            // This line is not in the original readme snippet
            string[] waterSpeciesNoPackage = new string[0];

            if (game.TryGetValue("team", TokenType.DataList, out DataToken membersToken))
            {
                // Unwrap the team members DataList from its DataToken
                DataList membersList = membersToken.DataList;

                // Create a DataList to track which team members have a "water" type
                DataList waterSpeciesList = new DataList();

                // Loop over all team members
                for (int i = 0; i < membersList.Count; i++)
                {
                    // Get the DataToken of each team member
                    if (membersList.TryGetValue(i, TokenType.DataDictionary, out DataToken memberToken))
                    {
                        // Unwrap the team member DataDictionary from its DataToken
                        DataDictionary member = memberToken.DataDictionary;

                        // Get the "types" DataToken
                        if (member.TryGetValue("types", TokenType.DataList, out DataToken typesToken))
                        {
                            // Unwrap the types DataList from its DataToken
                            DataList types = typesToken.DataList;

                            // Check if this member has a "Water" type
                            if (types.Contains("Water"))
                            {
                                // Get the team member's "species" DataToken
                                if (member.TryGetValue("species", TokenType.String, out DataToken waterSpeciesToken))
                                {
                                    // Unwrap the species string from its DataToken
                                    string waterSpecies = waterSpeciesToken.String;

                                    // Add the species to our water species tracking list
                                    waterSpeciesList.Add(waterSpecies);
                                }
                            }
                        }
                    }
                }

                // Create a final string[] to copy the DataList contents into
                string[] waterSpeciesCopy = new string[waterSpeciesList.Count];

                // Copy each water species to the final string[]
                for (int i = 0; i < waterSpeciesList.Count; i++)
                {
                    // Get the "species" DataToken of each member from the DataList
                    if (waterSpeciesList.TryGetValue(i, TokenType.String, out DataToken waterSpeciesToken))
                    {
                        // Unwrap the species string from its DataToken
                        string waterSpecies = waterSpeciesToken.String;

                        // Insert the species string into the final string[]
                        waterSpeciesCopy[i] = waterSpecies;
                    }
                }

                // This line is not in the original readme snippet
                waterSpeciesNoPackage = waterSpeciesCopy;
            }

            // Test
            True(waterSpeciesNoPackage.Length == 2);
            True(waterSpeciesNoPackage[0] == "Swampert");
            True(waterSpeciesNoPackage[1] == "Walrien");
        }
    }
}