using NUnit.Framework;
using VRC.SDK3.Data;
using static NUnit.Framework.Assert;

namespace Kemocade.Vrc.Data.Extensions.Tests
{
    public static partial class DataTokenExtensions
    {
        private const bool BOOL = true;
        private const sbyte SBYTE = 1;
        private const byte BYTE = 1;
        private const short SHORT = 1;
        private const ushort USHORT = 1;
        private const int INT = 1;
        private const uint UINT = 1;
        private const long LONG = 1;
        private const ulong ULONG = 1;
        private const float FLOAT = 1;
        private const double DOUBLE = 1;
        private const string STRING = "1";
        private const string STRING_TRUE = "true";
        // This is the only type used with no equivalent TokenType
        private const decimal DECIMAL = 1;
        private static readonly DataList DATA_LIST = new DataList(1);
        private static readonly DataDictionary DATA_DICTIONARY = new DataDictionary(){{1,1}};
        private static readonly object OBJECT = 1;

        private static DataToken BOOL_T => new DataToken(BOOL);
        private static DataToken SBYTE_T => new DataToken(SBYTE);
        private static DataToken BYTE_T => new DataToken(BYTE);
        private static DataToken SHORT_T => new DataToken(SHORT);
        private static DataToken USHORT_T => new DataToken(USHORT);
        private static DataToken INT_T => new DataToken(INT);
        private static DataToken UINT_T => new DataToken(UINT);
        private static DataToken LONG_T => new DataToken(LONG);
        private static DataToken ULONG_T => new DataToken(ULONG);
        private static DataToken FLOAT_T => new DataToken(FLOAT);
        private static DataToken DOUBLE_T => new DataToken(DOUBLE);
        private static DataToken STRING_T => new DataToken(STRING);
        private static DataToken STRING_TRUE_T => new DataToken(STRING_TRUE);
        private static DataToken DATA_LIST_T => new DataToken(DATA_LIST);
        private static DataToken DATA_DICTIONARY_T => new DataToken(DATA_DICTIONARY);
        private static DataToken OBJECT_T => new DataToken(OBJECT);

        private static bool Test<T>(DataToken input, T expected)
        {
            if (!input.TryCast(out T output)) { return false; }
            return output.Equals(expected);
        }

        // Bool
        // Self
        [Test] public static void TryCastBool() => True(Test(BOOL_T, BOOL));
        // String
        [Test] public static void TryCastBoolString() => True(Test(BOOL_T, BOOL.ToString()));
        // Object
        [Test] public static void TryCastBoolObject() => True(Test(BOOL_T, (object)BOOL));

        // SByte
        // Self
        [Test] public static void TryCastSByte() => True(Test(SBYTE_T, SBYTE));
        // Implicit
        [Test] public static void TryCastSByteShort() => True(Test(SBYTE_T, SHORT));
        [Test] public static void TryCastSByteInt() => True(Test(SBYTE_T, INT));
        [Test] public static void TryCastSByteLong() => True(Test(SBYTE_T, LONG));
        [Test] public static void TryCastSByteFloat() => True(Test(SBYTE_T, FLOAT));
        [Test] public static void TryCastSByteDouble() => True(Test(SBYTE_T, DOUBLE));
        [Test] public static void TryCastSByteDecimal() => True(Test(SBYTE_T, DECIMAL));
        // Explicit
        [Test] public static void TryCastSByteByte() => True(Test(SBYTE_T, BYTE));
        [Test] public static void TryCastSByteUShort() => True(Test(SBYTE_T, USHORT));
        [Test] public static void TryCastSByteUInt() => True(Test(SBYTE_T, UINT));
        [Test] public static void TryCastSByteULong() => True(Test(SBYTE_T, ULONG));
        // String
        [Test] public static void TryCastSByteString() => True(Test(SBYTE_T, SBYTE.ToString()));
        // Object
        [Test] public static void TryCastSByteObject() => True(Test(SBYTE_T, (object)SBYTE));

        // Int
        // Self
        [Test] public static void TryCastByte() => True(Test(BYTE_T, BYTE));
        // Implicit
        [Test] public static void TryCastByteShort() => True(Test(BYTE_T, SHORT));
        [Test] public static void TryCastByteUShort() => True(Test(BYTE_T, USHORT));
        [Test] public static void TryCastByteInt() => True(Test(BYTE_T, INT));
        [Test] public static void TryCastByteUInt() => True(Test(BYTE_T, UINT));
        [Test] public static void TryCastByteLong() => True(Test(BYTE_T, LONG));
        [Test] public static void TryCastByteULong() => True(Test(BYTE_T, ULONG));
        [Test] public static void TryCastByteFloat() => True(Test(BYTE_T, FLOAT));
        [Test] public static void TryCastByteDouble() => True(Test(BYTE_T, DOUBLE));
        [Test] public static void TryCastByteDecimal() => True(Test(BYTE_T, DECIMAL));
        // Explicit
        [Test] public static void TryCastByteSByte() => True(Test(BYTE_T, SBYTE));
        // String
        [Test] public static void TryCastByteString() => True(Test(BYTE_T, BYTE.ToString()));
        // Object
        [Test] public static void TryCastByteObject() => True(Test(BYTE_T, (object)BYTE));

        // Short
        // Self
        [Test] public static void TryCastShort() => True(Test(SHORT_T, SHORT));
        // Implicit
        [Test] public static void TryCastShortInt() => True(Test(SHORT_T, INT));
        [Test] public static void TryCastShortLong() => True(Test(SHORT_T, LONG));
        [Test] public static void TryCastShortFloat() => True(Test(SHORT_T, FLOAT));
        [Test] public static void TryCastShortDouble() => True(Test(SHORT_T, DOUBLE));
        [Test] public static void TryCastShortDecimal() => True(Test(SHORT_T, DECIMAL));
        // Explicit
        [Test] public static void TryCastShortSByte() => True(Test(SHORT_T, SBYTE));
        [Test] public static void TryCastShortByte() => True(Test(SHORT_T, BYTE));
        [Test] public static void TryCastShortUShort() => True(Test(SHORT_T, USHORT));
        [Test] public static void TryCastShortUInt() => True(Test(SHORT_T, UINT));
        [Test] public static void TryCastShortULong() => True(Test(SHORT_T, ULONG));
        // String
        [Test] public static void TryCastShortString() => True(Test(SHORT_T, SHORT.ToString()));
        // Object
        [Test] public static void TryCastShortObject() => True(Test(SHORT_T, (object)SHORT));

        // UShort
        // Self
        [Test] public static void TryCastUShort() => True(Test(USHORT_T, USHORT));
        // Implicit
        [Test] public static void TryCastUShortInt() => True(Test(USHORT_T, INT));
        [Test] public static void TryCastUShortUInt() => True(Test(USHORT_T, UINT));
        [Test] public static void TryCastUShortLong() => True(Test(USHORT_T, LONG));
        [Test] public static void TryCastUShortULong() => True(Test(USHORT_T, ULONG));
        [Test] public static void TryCastUShortFloat() => True(Test(USHORT_T, FLOAT));
        [Test] public static void TryCastUShortDouble() => True(Test(USHORT_T, DOUBLE));
        [Test] public static void TryCastUShortDecimal() => True(Test(USHORT_T, DECIMAL));
        // Explicit
        [Test] public static void TryCastUShortSByte() => True(Test(USHORT_T, SBYTE));
        [Test] public static void TryCastUShortByte() => True(Test(USHORT_T, BYTE));
        [Test] public static void TryCastUShortShort() => True(Test(USHORT_T, SHORT));
        // String
        [Test] public static void TryCastUShortString() => True(Test(USHORT_T, USHORT.ToString()));
        // Object
        [Test] public static void TryCastUShortObject() => True(Test(USHORT_T, (object)USHORT));

        // Int
        // Self
        [Test] public static void TryCastInt() => True(Test(INT_T, INT));
        // Implicit
        [Test] public static void TryCastIntLong() => True(Test(INT_T, LONG));
        [Test] public static void TryCastIntFloat() => True(Test(INT_T, FLOAT));
        [Test] public static void TryCastIntDouble() => True(Test(INT_T, DOUBLE));
        [Test] public static void TryCastDecimal() => True(Test(INT_T, DECIMAL));
        // Explicit
        [Test] public static void TryCastIntSByte() => True(Test(INT_T, SBYTE));
        [Test] public static void TryCastIntByte() => True(Test(INT_T, BYTE));
        [Test] public static void TryCastIntShort() => True(Test(INT_T, SHORT));
        [Test] public static void TryCastIntUShort() => True(Test(INT_T, USHORT));
        [Test] public static void TryCastIntUInt() => True(Test(INT_T, UINT));
        [Test] public static void TryCastIntULong() => True(Test(INT_T, ULONG));
        // String
        [Test] public static void TryCastIntString() => True(Test(INT_T, INT.ToString()));
        // Object
        [Test] public static void TryCastIntObject() => True(Test(INT_T, (object)INT));

        // UInt
        // Self
        [Test] public static void TryCastUInt() => True(Test(UINT_T, UINT));
        // Implicit
        [Test] public static void TryCastUIntLong() => True(Test(UINT_T, LONG));
        [Test] public static void TryCastUIntULong() => True(Test(UINT_T, ULONG));
        [Test] public static void TryCastUIntFloat() => True(Test(UINT_T, FLOAT));
        [Test] public static void TryCastUIntDouble() => True(Test(UINT_T, DOUBLE));
        [Test] public static void TryCastUIntDecimal() => True(Test(UINT_T, DECIMAL));
        // Explicit
        [Test] public static void TryCastUIntSByte() => True(Test(UINT_T, SBYTE));
        [Test] public static void TryCastUIntByte() => True(Test(UINT_T, BYTE));
        [Test] public static void TryCastUIntShort() => True(Test(UINT_T, SHORT));
        [Test] public static void TryCastUIntUShort() => True(Test(UINT_T, USHORT));
        [Test] public static void TryCastUIntInt() => True(Test(UINT_T, INT));
        // String
        [Test] public static void TryCastUIntString() => True(Test(UINT_T, UINT.ToString()));
        // Object
        [Test] public static void TryCastUIntObject() => True(Test(UINT_T, (object)UINT));

        // Long
        // Self
        [Test] public static void TryCastLong() => True(Test(LONG_T, LONG));
        // Implicit
        [Test] public static void TryCastLongFloat() => True(Test(LONG_T, FLOAT));
        [Test] public static void TryCastLongDouble() => True(Test(LONG_T, DOUBLE));
        [Test] public static void TryCastLongDecimal() => True(Test(LONG_T, DECIMAL));
        // Explicit
        [Test] public static void TryCastLongSByte() => True(Test(LONG_T, SBYTE));
        [Test] public static void TryCastLongByte() => True(Test(LONG_T, BYTE));
        [Test] public static void TryCastLongShort() => True(Test(LONG_T, SHORT));
        [Test] public static void TryCastLongUShort() => True(Test(LONG_T, USHORT));
        [Test] public static void TryCastLongInt() => True(Test(LONG_T, INT));
        [Test] public static void TryCastLongUInt() => True(Test(LONG_T, UINT));
        [Test] public static void TryCastLongULong() => True(Test(LONG_T, ULONG));
        // String
        [Test] public static void TryCastLongString() => True(Test(LONG_T, LONG.ToString()));
        // Object
        [Test] public static void TryCastLongObject() => True(Test(LONG_T, (object)LONG));

        // ULong
        // Self
        [Test] public static void TryCastULong() => True(Test(ULONG_T, ULONG));
        // Implicit
        [Test] public static void TryCastULongFloat() => True(Test(ULONG_T, FLOAT));
        [Test] public static void TryCastULongDouble() => True(Test(ULONG_T, DOUBLE));
        [Test] public static void TryCastULongDecimal() => True(Test(ULONG_T, DECIMAL));
        // Explicit
        [Test] public static void TryCastULongSByte() => True(Test(ULONG_T, SBYTE));
        [Test] public static void TryCastULongByte() => True(Test(ULONG_T, BYTE));
        [Test] public static void TryCastULongShort() => True(Test(ULONG_T, SHORT));
        [Test] public static void TryCastULongUShort() => True(Test(ULONG_T, USHORT));
        [Test] public static void TryCastULongInt() => True(Test(ULONG_T, INT));
        [Test] public static void TryCastULongUInt() => True(Test(ULONG_T, UINT));
        [Test] public static void TryCastULongLong() => True(Test(ULONG_T, LONG));
        // String
        [Test] public static void TryCastULongString() => True(Test(ULONG_T, ULONG.ToString()));
        // Object
        [Test] public static void TryCastULongObject() => True(Test(ULONG_T, (object)ULONG));

        // Float
        // Self
        [Test] public static void TryCastFloat() => True(Test(FLOAT_T, FLOAT));
        // Implicit
        [Test] public static void TryCastFloatDouble() => True(Test(FLOAT_T, DOUBLE));
        // Explicit
        [Test] public static void TryCastFloatSByte() => True(Test(FLOAT_T, SBYTE));
        [Test] public static void TryCastFloatByte() => True(Test(FLOAT_T, BYTE));
        [Test] public static void TryCastFloatShort() => True(Test(FLOAT_T, SHORT));
        [Test] public static void TryCastFloatUShort() => True(Test(FLOAT_T, USHORT));
        [Test] public static void TryCastFloatInt() => True(Test(FLOAT_T, INT));
        [Test] public static void TryCastFloatUInt() => True(Test(FLOAT_T, UINT));
        [Test] public static void TryCastFloatLong() => True(Test(FLOAT_T, LONG));
        [Test] public static void TryCastFloatULong() => True(Test(FLOAT_T, ULONG));
        [Test] public static void TryCastFloatDecimal() => True(Test(FLOAT_T, DECIMAL));
        // String
        [Test] public static void TryCastFloatString() => True(Test(FLOAT_T, FLOAT.ToString()));
        // Object
        [Test] public static void TryCastFloatObject() => True(Test(FLOAT_T, (object)FLOAT));

        // Double
        // Self
        [Test] public static void TryCastDouble() => True(Test(DOUBLE_T, DOUBLE));
        // Explicit
        [Test] public static void TryCastDoubleSByte() => True(Test(DOUBLE_T, SBYTE));
        [Test] public static void TryCastDoubleByte() => True(Test(DOUBLE_T, BYTE));
        [Test] public static void TryCastDoubleShort() => True(Test(DOUBLE_T, SHORT));
        [Test] public static void TryCastDoubleUShort() => True(Test(DOUBLE_T, USHORT));
        [Test] public static void TryCastDoubleInt() => True(Test(DOUBLE_T, INT));
        [Test] public static void TryCastDoubleUInt() => True(Test(DOUBLE_T, UINT));
        [Test] public static void TryCastDoubleLong() => True(Test(DOUBLE_T, LONG));
        [Test] public static void TryCastDoubleULong() => True(Test(DOUBLE_T, ULONG));
        [Test] public static void TryCastDoubleFloat() => True(Test(DOUBLE_T, FLOAT));
        [Test] public static void TryCastDoubleDecimal() => True(Test(DOUBLE_T, DECIMAL));
        // String
        [Test] public static void TryCastDoubleString() => True(Test(DOUBLE_T, DOUBLE.ToString()));
        // Object
        [Test] public static void TryCastDoubleObject() => True(Test(DOUBLE_T, (object)DOUBLE));

        // String
        // Self
        [Test] public static void TryCastString() => True(Test(STRING_T, STRING));
        // Parsed
        [Test] public static void TryCastStringBool() => True(Test(STRING_TRUE_T, BOOL));
        [Test] public static void TryCastStringSByte() => True(Test(STRING_T, SBYTE));
        [Test] public static void TryCastStringByte() => True(Test(STRING_T, BYTE));
        [Test] public static void TryCastStringShort() => True(Test(STRING_T, SHORT));
        [Test] public static void TryCastStringUShort() => True(Test(STRING_T, USHORT));
        [Test] public static void TryCastStringIntUInt() => True(Test(STRING_T, UINT));
        [Test] public static void TryCastStringLong() => True(Test(STRING_T, LONG));
        [Test] public static void TryCastStringULong() => True(Test(STRING_T, ULONG));
        [Test] public static void TryCastStringFloat() => True(Test(STRING_T, FLOAT));
        [Test] public static void TryCastStringDouble() => True(Test(STRING_T, DOUBLE));
        [Test] public static void TryCastStringDecimal() => True(Test(STRING_T, DECIMAL));
        // Object
        [Test] public static void TryCastStringObject() => True(Test(STRING_T, (object)STRING));

        // DataList
        // Self
        [Test] public static void TryCastDataList() => True(Test(DATA_LIST_T, DATA_LIST));
        // Object
        [Test] public static void TryCastDataListObject() => True(Test(DATA_LIST_T, (object)DATA_LIST));

        // DataDictionary
        // Self
        [Test] public static void TryCastDataDictionary() => True(Test(DATA_DICTIONARY_T, DATA_DICTIONARY));
        // Object
        [Test] public static void TryCastDataDictionaryObject() => True(Test(DATA_DICTIONARY_T, (object)DATA_DICTIONARY));

        // Object
        // Self
        [Test] public static void TryCastObject() => True(Test(OBJECT_T, OBJECT));

        // Fail
        [Test] public static void TryCastBooleanFail() => False(Test(BOOL_T, 0));
        [Test] public static void TryCastSByteFail() => False(Test(SBYTE_T, 0));
        [Test] public static void TryCastByteFail() => False(Test(BYTE_T, 0));
        [Test] public static void TryCastShortFail() => False(Test(SHORT_T, 0));
        [Test] public static void TryCastUShortFail() => False(Test(USHORT_T, 0));
        [Test] public static void TryCastIntFail() => False(Test(INT_T, 0));
        [Test] public static void TryCastUIntFail() => False(Test(UINT_T, 0));
        [Test] public static void TryCastLongFail() => False(Test(LONG_T, 0));
        [Test] public static void TryCastULongFail() => False(Test(ULONG_T, 0));
        [Test] public static void TryCastFloatFail() => False(Test(FLOAT_T, 0));
        [Test] public static void TryCastDoubleFail() => False(Test(DOUBLE_T, 0));
        [Test] public static void TryCastStringFail() => False(Test(STRING_T, 0));
        [Test] public static void TryCastDataListFail() => False(Test(DATA_LIST_T, 0));
        [Test] public static void TryCastDataDictionaryFail() => False(Test(DATA_DICTIONARY_T, 0));
        [Test] public static void TryCastObjectFail() => False(Test(OBJECT_T, 0));
    }
}