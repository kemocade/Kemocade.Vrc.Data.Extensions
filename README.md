# Kemocade VRC Data Extensions

[![VPM Package Version](https://img.shields.io/vpm/v/com.kemocade.vrc.data.extensions?repository_url=https%3A%2F%2Fkemocade.github.io%2FKemocade.Vrc.Data.Extensions%2Findex.json)](https://kemocade.github.io/Kemocade.Vrc.Data.Extensions)
[![Code Coverage](https://kemocade.github.io/Kemocade.Vrc.Data.Extensions/coverage/badge_shieldsio_linecoverage_brightgreen.svg)](https://kemocade.github.io/Kemocade.Vrc.Data.Extensions/coverage)

-----
# Introduction
This package provides extension methods for the VRChat data types [DataToken](https://creators.vrchat.com/worlds/udon/data-containers/data-tokens/), [DataList](https://creators.vrchat.com/worlds/udon/data-containers/data-lists/), and [DataDictionary](https://creators.vrchat.com/worlds/udon/data-containers/data-dictionaries) that allow these data structures to be accessed with type-safe [C# Generics](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics) and navigated with [LINQ](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)-like operations.

TL;DR: ["Why should I use this package?"](#why-should-i-use-this-package)

# Installation
Install via the [VCC Package Listing](https://kemocade.github.io/Kemocade.Vrc.Data.Extensions).

Then, add the package `using` declaration at the top of any script that needs to use it:
```
using Kemocade.Vrc.Data.Extensions;
```

# Example
The main objective of this package is to allow `DataDictionary` objects to be used as arbitrary data structures, similar to how non-[Monobehaviour](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html) classes would be used in a standard C# (non-VRChat) Unity project.

For the following examples, consider the following JSON object which represents an arbitrary game's save data structure:
```json
{
    "name": "Dustuu",
    "badges": 8,
    "inventory":
    {
        "money": 1000,
        "items": ["Potion", "Revive", "Elixir"]
    },
    "team":
    [
        {
            "species": "Swampert",
            "level": 100,
            "types": ["Water", "Ground"],
            "item": "Oran Berry"
        },
        {
            "species": "Flygon",
            "level": 100,
            "types": ["Ground", "Dragon"]
        },
        {
            "species": "Walrien",
            "level": 50,
            "types": ["Ice", "Water"],
            "item": "Cheri Berry"
        }
    ]
}
```

A JSON object like this can be parsed into a `DataDictionary` using the [TryDeserializeFromJson](https://creators.vrchat.com/worlds/udon/data-containers/vrcjson/#deserializing-from-json) function from [VRCJson](https://creators.vrchat.com/worlds/udon/data-containers/vrcjson).
In the following example, `jsonString` represents a `string` containing the JSON object above:
```csharp
VRCJson.TryDeserializeFromJson(jsonString, out DataToken token);
DataDictionary game = token.DataDictionary;
```
In all following examples, `game` represents a `DataDictionary` which has been parsed from the JSON object above.

## Getting Values by Property Key
The `TryGetValue` extension takes a property key as input and uses it to find a single non-array value of a generic type.
This generic type is defined implicitly by whichever type is used with the `out` parameter, such as `string` in this example:
```csharp
game.TryGetValue("name", out string name);
```
This gives us an output value of `"Dustuu"`, which is the value that corresponds to the `"name"` property key.
If `TryGetValue` (or any other extension which accesses properties) can not find the property requested, or is unable to cast the property's value to the requested generic type, `false` will be returned and a value of `default` will be assigned to the `out` parameter.

You can also get the values of nested properties like this:
```csharp
game.TryGetValue("inventory.money", out int money);
```
When using nested properties, `.` is considered the `string` [Split](https://learn.microsoft.com/en-us/dotnet/api/system.string.split) delimiter by default.
Therefore, by passing `"inventory.money"` as the key, the extension will first look inside `game` for a `DataDictionary` property named `"inventory"`, and then look inside `"inventory"` for an `int` property named `"money"`.
In this case, this returns a final value of `1000`.

If needed, you can also change this delimiter by using the optional extra `char` parameter named `split`.
If you have JSON property names that contain `.`, use this option to change the delimiter to something else.
These nested property options and delimiter options are also available in all other extensions that involve accessing properties by name.

## Getting Array Values by Property Key
To get an array value, use the `TryGetValues` extension:
```csharp
game.TryGetValues("inventory.items", out string[] items);
```
This results in the value of the `string[]` property named `"items"`:
```json
["Potion", "Revive", "Elixir"]
```

## Filtering DataDictionaries Conditionally
There are a number of conditional operations that can be applied to `DataDictionary[]`.
These conditional operations allow collections of arbitrary data to be navigated easily.
This functionality is the main objective of this package.

For the following examples, we first use `TryGetValues` to extract the the `DataDictionary[]` named `"team"`:
```csharp
game.TryGetValues("team", out DataDictionary[] team);
```
This outputs a `DataDictionary[]`, which is the type that all conditional extensions in this package start from.
Conditional extensions can then be used to filter this array based on given criteria.

In this case, we have a `DataDictionary[]` named `team` where each `DataDictionary` in the array represents a member of our game's team:
```json
[
    { "species": "Swampert", "level": 100, "types": ["Water", "Ground"], "item": "Oran Berry" },
    { "species": "Flygon", "level": 100, "types": ["Ground", "Dragon"] },
    { "species": "Walrien", "level": 50, "types": ["Ice", "Water"] "item": "Cheri Berry" }
]
```

So, we can use conditional operations to filter these team members by their various properties.

### Value Equality Conditions
The `WhereValueEquals` extension can be used to filter our game data's team members by their level:
```csharp
DataDictionary[] isLevel100 = team.WhereValueEquals("level", 100);
```
This results in a `DataDictionary[]` of team members with a level equal to 100:
```json
[
    { "species": "Swampert", "level": 100, "types": ["Water", "Ground"], "item": "Oran Berry" },
    { "species": "Flygon", "level": 100, "types": ["Ground", "Dragon"] }
]
```

This extension can also be used on properties which are not present in all objects.
For example, only two of our three team members have an `"item"` property.
If a `DataDictionary` does not have the property being evaluated, it will always be excluded from the final result.

For example, we can use `WhereValueEquals` on the `"item"` property:
```csharp
DataDictionary[] hasOranBerry = team.WhereValueEquals("item", "Oran Berry");
```
Which results in a `DataDictionary[]` of the only team member to possess an `"Oran Berry"`.
The team member which does not have an `"item"` property is automatically excluded from this result:
```json
[ { "species": "Swampert", "level": 100, "types": ["Water", "Ground"], "item": "Oran Berry" } ]
```
There is also an opposite extension, `WhereValueDoesNotEqual`.

### Array Content Conditions
For array properties, we can use `WhereValuesContain`:
```csharp
DataDictionary[] hasWaterType = team.WhereValuesContain("types", "Water");
```
Which results in a `DataDictionary[]` of team members whose `"types"` property is a `string[]` that contains `"Water"`:
```json
[
    { "species": "Swampert", "level": 100, "types": ["Water", "Ground"], "item": "Oran Berry" },
    { "species": "Walrien", "level": 50, "types": ["Ice", "Water"] "item": "Cheri Berry" }
]
```
There is also an opposite extension, `WhereValuesDoNotContain`.

When dealing with multiple potential values, `WhereValuesContainAny` can be used:
```csharp
DataDictionary[] hasGroundOrIceType = team.WhereValuesContainAny("types", new string[] { "Ground", "Ice" });
```
Which results in a `DataDictionary[]` of team members whose `"types"` property is a `string[]` that contains at least one of `"Ground"` or `"Ice"`.
In this case, all  of our team members meet this condition:
```json
[
    { "species": "Swampert", "level": 100, "types": ["Water", "Ground"], "item": "Oran Berry" },
    { "species": "Flygon", "level": 100, "types": ["Ground", "Dragon"] },
    { "species": "Walrien", "level": 50, "types": ["Ice", "Water"] "item": "Cheri Berry" }
]
```
There are also `WhereValuesContainAll` and `WhereValuesContainNone` variants of this extension. 

## Selecting Values by Property Key
The previous conditional examples all return the entire `DataDictionary` for each matching element.
However, by using `SelectValues`, it is also possible to get just the desired property:
```csharp
string[] species = team.SelectValues<string>("species");
```
This returns only a `string[]` of the `"species"` property from each `DataDictionary`:
```json
[ "Swampert", "Flygon","Walrien" ]
```
Note that the generic type parameter (`<string>` in this example) must be explicitly supplied for this extension.

# Type Conversions
All generic `DataDictionary` and `DataList` extensions in this package are built on top of the `DataToken` extension methods `TryCast` and `TryCastArray`, which are also part of this package.
These extensions allow all other generic extensions to work by automatically converting the types of values extracted from `DataToken` wrappers wherever possible.

The following table shows the full list of available conversions, along with any conversion limitations:
<table>
    <tr>
        <th></th>
        <th colspan="100%">Output Generic Type</th>
    </tr>
    <tr></tr>
    <tr>
        <th rowspan="100%">Input DataToken Type</th><th></th><td>bool</td><td>sbyte</td><td>byte</td><td>short</td><td>ushort</td><td>int</td><td>uint</td><td>long</td><td>ulong</td><td>float</td><td>double</td><td>string</td><td>DataList</td><td>DataDictionary</td><td>object</td><td>decimal</td>
    </tr>
    <tr>
        <td>Boolean</td>
        <td>🟢</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔵</td><td>🔴</td><td>🔴</td><td>🟢</td><td>🔴</td>
    </tr>
    <tr>
        <td>SByte</td>
        <td>🔴</td><td>🟢</td><td>🟡</td><td>🟢</td><td>🟡</td><td>🟢</td><td>🟡</td><td>🟢</td><td>🟡</td><td>🟢</td><td>🟢</td><td>🔵</td><td>🔴</td><td>🔴</td><td>🟢</td><td>🟢</td>
    </tr>
    <tr>
        <td>Byte</td>
        <td>🔴</td><td>🟡</td><td>🟢</td><td>🟢</td><td>🟢</td><td>🟢</td><td>🟢</td><td>🟢</td><td>🟢</td><td>🟢</td><td>🟢</td><td>🔵</td><td>🔴</td><td>🔴</td><td>🟢</td><td>🟢</td>
    </tr>
    <tr>
        <td>Short</td>
        <td>🔴</td><td>🟡</td><td>🟡</td><td>🟢</td><td>🟡</td><td>🟢</td><td>🟡</td><td>🟢</td><td>🟡</td><td>🟢</td><td>🟢</td><td>🔵</td><td>🔴</td><td>🔴</td><td>🟢</td><td>🟢</td>
    </tr>
    <tr>
        <td>UShort</td>
        <td>🔴</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟢</td><td>🟢</td><td>🟢</td><td>🟢</td><td>🟢</td><td>🟢</td><td>🟢</td><td>🔵</td><td>🔴</td><td>🔴</td><td>🟢</td><td>🟢</td>
    </tr>
    <tr>
        <td>Int</td>
        <td>🔴</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟢</td><td>🟡</td><td>🟢</td><td>🟡</td><td>🟢</td><td>🟢</td><td>🔵</td><td>🔴</td><td>🔴</td><td>🟢</td><td>🟢</td>
    </tr>
    <tr>
        <td>UInt</td>
        <td>🔴</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟢</td><td>🟢</td><td>🟢</td><td>🟢</td><td>🟢</td><td>🔵</td><td>🔴</td><td>🔴</td><td>🟢</td><td>🟢</td>
    </tr>
    <tr>
        <td>Long</td>
        <td>🔴</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟢</td><td>🟡</td><td>🟢</td><td>🟢</td><td>🔵</td><td>🔴</td><td>🔴</td><td>🟢</td><td>🟢</td>
    </tr>
    <tr>
        <td>ULong</td>
        <td>🔴</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟢</td><td>🟢</td><td>🟢</td><td>🔵</td><td>🔴</td><td>🔴</td><td>🟢</td><td>🟢</td>
    </tr>
    <tr>
        <td>Float</td>
        <td>🔴</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟢</td><td>🟢</td><td>🔵</td><td>🔴</td><td>🔴</td><td>🟢</td><td>🟡</td>
    </tr>
    <tr>
        <td>Double</td>
        <td>🔴</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟡</td><td>🟢</td><td>🔵</td><td>🔴</td><td>🔴</td><td>🟢</td><td>🟡</td>
    </tr>
    <tr>
        <td>String</td>
        <td>🔵</td><td>🔵</td><td>🔵</td><td>🔵</td><td>🔵</td><td>🔵</td><td>🔵</td><td>🔵</td><td>🔵</td><td>🔵</td><td>🔵</td><td>🟢</td><td>🔴</td><td>🔴</td><td>🟢</td><td>🔵</td>
    </tr>
    <tr>
        <td>DataList</td>
        <td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🟢</td><td>🔴</td><td>🟢</td><td>🔴</td>
    </tr>
    <tr>
        <td>DataDictionary</td>
        <td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🟢</td><td>🟢</td><td>🔴</td>
    </tr>
    <tr>
        <td>Reference</td>
        <td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🔴</td><td>🟢</td><td>🔴</td>
    </tr>
</table>

| **Key** | **Meaning** |
| - | - |
| 🟢 | [Implicit Conversion](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions#implicit-numeric-conversions) (No data loss) |
| 🟡 | [Explicit Conversion](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions#explicit-numeric-conversions) (Data loss possible) |
| 🔴 | Invalid Conversion |
| 🔵 | String Conversion (Input uses [String Parsing](https://learn.microsoft.com/en-us/dotnet/standard/base-types/parsing-strings), Output uses [ToString](https://learn.microsoft.com/en-us/dotnet/api/system.object.tostring)) |

These extensions can also be used directly to manually extract values from a `DataToken` with automatic type conversion.

## Same Type Extraction
The `TryCast` extension allows values to be extracted from a `DataToken` in a type-safe generic way.
For example, this code extracts an `int` value from an `int` `DataToken`:
```csharp
DataToken inputIntFive = new DataToken(5);
inputIntFive.TryCast(out int outputIntFive);
```
The result will be an `int` value of `5`.
If the cast can not be completed, `TryCast` will return `false`, and the `out` parameter will be assigned a value of `default`.

## Implicitly Convertible Type Extraction
`TryCast` can also be used to convert types that have [Implicit Numeric Conversions](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions#implicit-numeric-conversions).
For example, this code extracts a `float` value from an `int` `DataToken`:
```csharp
DataToken inputIntSix = new DataToken(6);
inputIntSix.TryCast(out float outputFloatSix);
```
The result will be a `float` value of `6f`.

## Explicitly Convertible Type Extraction
`TryCast` can also be used to convert types that have [Explicit Numeric Conversions](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions#explicit-numeric-conversions).
For example, this code extracts an `int` value from a `float` `DataToken`:
```csharp
DataToken inputFloatSixPointFive = new DataToken(6.5f);
inputFloatSixPointFive.TryCast(out int outputIntSix);
```
Because explicit numeric conversions such as converting a `float` to an `int` are lossy operations, the original `float` value of `6.5f` will be truncated to an `int` value of `6`.

## String Parsable Type Extraction
`TryCast` can also be used to convert types from `string` inputs via [String Parsing](https://learn.microsoft.com/en-us/dotnet/standard/base-types/parsing-strings).
For example, this code extracts an `int` value from a `string` `DataToken`:
```csharp
DataToken inputStringTen = new DataToken("10");
inputStringTen.TryCast(out int outputIntTen);
```
This results in an `int` value of `10`.
If the input `string` is not able to be parsed into the requested type, `TryCast` will return `false`, and the `out` parameter will be assigned a value of `default`.

## ToString Extraction
`TryCast` can also be used to convert any type into a `string` representation via that type's [ToString](https://learn.microsoft.com/en-us/dotnet/api/system.object.tostring) implementation.
For example, this code extracts an `string` value from an `int` `DataToken`:
```csharp
DataToken inputIntTen = new DataToken(10);
inputIntTen.TryCast(out string outputStringTen);
```
This results in a `string` value of `"10"`.

## Array Type Extraction
If you have a `DataToken` which contains a `DataList`, you can also use the `TryCastArray` extension to convert it into an array of your desired type:
```csharp
DataList intputIntList = new DataList();
intputIntList.Add(1);
intputIntList.Add(2);
intputIntList.Add(3);
DataToken inputIntListToken = intputIntList;
inputIntListToken.TryCastArray(out int[] outputIntArray);
```
This will result in an `int[]` value of `[1, 2, 3]`.
If the `DataToken` does not contain a `DataList`, or not all elements can be cast as the desired type, `TryCastArray` will return `false`, and `output` will be assigned a value of `default`.

If your `DataList` is not wrapped in a `DataToken`, you can also use `TryCastArray` directly on the raw `DataList`.
For example, this code extracts a `string[]` value from a `DataList`:
```csharp
DataList inputStringList = new DataList();
inputStringList.Add("a");
inputStringList.Add("b");
inputStringList.Add("c");
inputStringList.TryCastArray(out string[] outputStringArray);
```
This will assign `output` a value of `["a", "b", "c"]`.

# FAQs

## Why should I use this package?

To answer this question, let's implement some `DataDictionary` conditional filtering logic. Using the `game` example from above, let's try to get a `string[]` of the `"species"` properties from all team members who have `"Water"` as one of their `"types"`.

First, with this package:
```csharp
if (game.TryGetValues("team", out DataDictionary[] members))
{
    string[] waterSpeciesArray = members
        .WhereValuesContain("types", "Water")
        .SelectValues<string>("species");
}
```

Next, without this package:
```csharp
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
}
```
Using this package allows this type of code to be written much more quickly and in a more standard C# style with type-safe generics.

## Won't this package become obsolete when Udon 2 is released?

Yes!
That's exactly the idea.
Right now, VRChat world developers need to write extremely long and verbose code such as the above conditional filtering example.
That sort of code is very non-standard C# code and will all need to be completely re-written when Udon 2 is released.
However, this package is designed with the types of coding styles that Udon 2 will enable in mind.
Code that is written with this package will be able to be easily replaced with LINQ queries, lambda expressions, and standard C# objects.
For example, consider the `DataDictionary[]` conditional filtering logic from earlier:
```csharp
if (game.TryGetValues("team", out DataDictionary[] members))
{
    string[] waterSpeciesArray = members
        .WhereValuesContain("types", "Water")
        .SelectValues<string>("species");
}
```

In Udon 2, the `DataDictionary[]` here will be able to be replaced with an array of standard C# objects.
These objects can hold any type of data, and can have type-safe properties like `Team`, `Members`, etc.
As such, they could be acted upon with LINQ queries like this:
```csharp
string[] waterSpeciesArray = game.Team.Members
    .Where(member => member.Types.Contains("Water"))
    .Select(member => member.Species)
    .ToArray();
```
This more standard C# style of coding that Udon 2 will enable is very similar to our original code, and much more similar than the code written with native VRChat Data functions would be.

## How do I know this package actually works?

This package comes with a [full suite of unit tests](./Packages/com.kemocade.vrc.data.extensions/Tests) that achieve [100% code coverage](https://kemocade.github.io/Kemocade.Vrc.Data.Extensions/coverage).

Even the example code snippets from this README file are [covered in their own tests](Packages/com.kemocade.vrc.data.extensions/Tests/Editor/ReadMeTests.cs).

These tests are run automatically by GitHub Actions and verified before a package update can be published, so they will always be passing.

# API

## DataDictionary Extensions
| **Extension** | **Parameters** | **Returns** |
| - | - | - |
| [TryGetValue](Packages/com.kemocade.vrc.data.extensions/Runtime/DataDictionaryExtensions/TryGetValue.cs)`<T>` | `string key`, `out T result` | `bool` |
| [TryGetValues](Packages/com.kemocade.vrc.data.extensions/Runtime/DataDictionaryExtensions/TryGetValues.cs)`<T>` | `string key`, `out T result` | `bool` |
| [TryGetValueToken](Packages/com.kemocade.vrc.data.extensions/Runtime/DataDictionaryExtensions/TryGetValueToken.cs) | `string key`, `out DataToken result` | `bool` |
| [WhereValueEquals](Packages/com.kemocade.vrc.data.extensions/Runtime/DataDictionaryExtensions/WhereValueEquals.cs)`<T>` | `string key`, `T target`, `char split = '.'` | `DataDictionary[]` |
| [WhereValueDoesNotEqual](Packages/com.kemocade.vrc.data.extensions/Runtime/DataDictionaryExtensions/WhereValueDoesNotEqual.cs)`<T>` | `string key`, `T target`, `char split = '.'` | `DataDictionary[]` |
| [WhereValuesContain](Packages/com.kemocade.vrc.data.extensions/Runtime/DataDictionaryExtensions/WhereValuesContain.cs)`<T>` | `string key`, `T target`, `char split = '.'` | `DataDictionary[]` |
| [WhereValuesDoNotContain](Packages/com.kemocade.vrc.data.extensions/Runtime/DataDictionaryExtensions/WhereValuesDoNotContain.cs)`<T>` | `string key`, `T target`, `char split = '.'` | `DataDictionary[]` |
| [WhereValuesContainAny](Packages/com.kemocade.vrc.data.extensions/Runtime/DataDictionaryExtensions/WhereValuesContainAny.cs)`<T>` | `string key`, `T[] targets`, `char split = '.'` | `DataDictionary[]` |
| [WhereValuesContainAll](Packages/com.kemocade.vrc.data.extensions/Runtime/DataDictionaryExtensions/WhereValuesContainAll.cs)`<T>` | `string key`, `T[] targets`, `char split = '.'` | `DataDictionary[]` |
| [WhereValuesContainNone](Packages/com.kemocade.vrc.data.extensions/Runtime/DataDictionaryExtensions/WhereValuesContainNone.cs)`<T>` | `string key`, `T[] targets`, `char split = '.'` | `DataDictionary[]` |
| [SelectValues](Packages/com.kemocade.vrc.data.extensions/Runtime/DataDictionaryExtensions/SelectValues.cs)`<T>` | `string key`, `char split = '.'` | `T[]` |
| [TrySerializeToJson](Packages/com.kemocade.vrc.data.extensions/Runtime/DataDictionaryExtensions/TrySerializeToJson.cs) | `out string result` | `bool` |

## DataList Extensions
| **Extension** | **Parameters** | **Returns** |
| - | - | - |
| [TryCastArray](Packages/com.kemocade.vrc.data.extensions/Runtime/DataListExtensions/TryCastArray.cs)`<T>` | `out T[] result` | `bool` |

## DataToken Extensions
| **Extension** | **Parameters** | **Returns** |
| - | - | - |
| [TryCast](Packages/com.kemocade.vrc.data.extensions/Runtime/DataTokenExtensions/TryCast.cs)`<T>` | `out T result` | `bool` |
| [TryCastArray](Packages/com.kemocade.vrc.data.extensions/Runtime/DataTokenExtensions/TryCastArray.cs)`<T>` | `string key`, `out T[] result` | `bool` |