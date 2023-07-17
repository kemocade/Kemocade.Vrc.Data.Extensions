using System;
using VRC.SDK3.Data;

namespace Kemocade.Vrc.Data.Extensions
{
    public static partial class DataTokenExtensions
    {
        private const string BOOL = "System.Boolean";
        private const string SBYTE = "System.SByte";
        private const string BYTE = "System.Byte";
        private const string SHORT = "System.Int16";
        private const string USHORT = "System.UInt16";
        private const string INT = "System.Int32";
        private const string UINT = "System.UInt32";
        private const string LONG = "System.Int64";
        private const string ULONG = "System.UInt64";
        private const string FLOAT = "System.Single";
        private const string DOUBLE = "System.Double";
        private const string STRING = "System.String";
        private const string DATA_LIST = "VRC.SDK3.Data.DataList";
        private const string DATA_DICTIONARY = "VRC.SDK3.Data.DataDictionary";
        private const string OBJECT = "System.Object";
        private const string DECIMAL = "System.Decimal";

        // TODO: special error message if passed in array type (use TryCastArray instead!)
        public static bool TryCast<T>(this DataToken input, out T result)
        {
            object data = null;
            Type type = typeof(T);

            switch (input.TokenType)
            {
                case TokenType.Boolean:
                    switch (typeof(T).FullName)
                    {
                        // Self
                        case BOOL:
                        case OBJECT: data = input.Boolean; break;
                        // String
                        case STRING: data = input.Boolean.ToString(); break;
                    }
                    break;
                case TokenType.SByte:
                    switch (typeof(T).FullName)
                    {
                        // Self
                        case SBYTE:
                        case OBJECT: data = input.SByte; break;
                        // Implicit
                        case SHORT: data = (short)input.SByte; break;
                        case INT: data = (int)input.SByte; break;
                        case LONG: data = (long)input.SByte; break;
                        case FLOAT: data = (float)input.SByte; break;
                        case DOUBLE: data = (double)input.SByte; break;
                        case DECIMAL: data = (decimal)input.SByte; break;
                        // Explicit
                        case BYTE: data = (byte)input.SByte; break;
                        case USHORT: data = (ushort)input.SByte; break;
                        case UINT: data = (uint)input.SByte; break;
                        case ULONG: data = (ulong)input.SByte; break;
                        // String
                        case STRING: data = input.SByte.ToString(); break;
                    }
                    break;
                case TokenType.Byte:
                    switch (typeof(T).FullName)
                    {
                        // Self
                        case BYTE:
                        case OBJECT: data = input.Byte; break;
                        // Implicit
                        case SHORT: data = (short)input.Byte; break;
                        case USHORT: data = (ushort)input.Byte; break;
                        case INT: data = (int)input.Byte; break;
                        case UINT: data = (uint)input.Byte; break;
                        case LONG: data = (long)input.Byte; break;
                        case ULONG: data = (ulong)input.Byte; break;
                        case FLOAT: data = (float)input.Byte; break;
                        case DOUBLE: data = (double)input.Byte; break;
                        case DECIMAL: data = (decimal)input.Byte; break;
                        // Explicit
                        case SBYTE: data = (sbyte)input.Byte; break;
                        // String
                        case STRING: data = input.Byte.ToString(); break;
                    }
                    break;
                case TokenType.Short:
                    switch (typeof(T).FullName)
                    {
                        // Self
                        case SHORT:
                        case OBJECT: data = input.Short; break;
                        // Implicit
                        case INT: data = (int)input.Short; break;
                        case LONG: data = (long)input.Short; break;
                        case FLOAT: data = (float)input.Short; break;
                        case DOUBLE: data = (double)input.Short; break;
                        case DECIMAL: data = (decimal)input.Short; break;
                        // Explicit
                        case SBYTE: data = (sbyte)input.Short; break;
                        case BYTE: data = (byte)input.Short; break;
                        case USHORT: data = (ushort)input.Short; break;
                        case UINT: data = (uint)input.Short; break;
                        case ULONG: data = (ulong)input.Short; break;
                        // String
                        case STRING: data = input.Short.ToString(); break;
                    }
                    break;
                case TokenType.UShort:
                    switch (typeof(T).FullName)
                    {
                        // Self
                        case USHORT:
                        case OBJECT: data = input.UShort; break;
                        // Implicit
                        case INT: data = (int)input.UShort; break;
                        case UINT: data = (uint)input.UShort; break;
                        case LONG: data = (long)input.UShort; break;
                        case ULONG: data = (ulong)input.UShort; break;
                        case FLOAT: data = (float)input.UShort; break;
                        case DOUBLE: data = (double)input.UShort; break;
                        case DECIMAL: data = (decimal)input.UShort; break;
                        // Explicit
                        case SBYTE: data = (sbyte)input.UShort; break;
                        case BYTE: data = (byte)input.UShort; break;
                        case SHORT: data = (short)input.UShort; break;
                        // String
                        case STRING: data = input.UShort.ToString(); break;
                    }
                    break;
                case TokenType.Int:
                    switch (typeof(T).FullName)
                    {
                        // Self
                        case INT:
                        case OBJECT: data = input.Int; break;
                        // Implicit
                        case LONG: data = (long)input.Int; break;
                        case FLOAT: data = (float)input.Int; break;
                        case DOUBLE: data = (double)input.Int; break;
                        case DECIMAL: data = (decimal)input.Int; break;
                        // Explicit
                        case SBYTE: data = (sbyte)input.Int; break;
                        case BYTE: data = (byte)input.Int; break;
                        case SHORT: data = (short)input.Int; break;
                        case USHORT: data = (ushort)input.Int; break;
                        case UINT: data = (uint)input.Int; break;
                        case ULONG: data = (ulong)input.Int; break;
                        // String
                        case STRING: data = input.Int.ToString(); break;
                    }
                    break;
                case TokenType.UInt:
                    switch (typeof(T).FullName)
                    {
                        // Self
                        case UINT:
                        case OBJECT: data = input.UInt; break;
                        // Implicit
                        case LONG: data = (long)input.UInt; break;
                        case ULONG: data = (ulong)input.UInt; break;
                        case FLOAT: data = (float)input.UInt; break;
                        case DOUBLE: data = (double)input.UInt; break;
                        case DECIMAL: data = (decimal)input.UInt; break;
                        // Explicit
                        case SBYTE: data = (sbyte)input.UInt; break;
                        case BYTE: data = (byte)input.UInt; break;
                        case SHORT: data = (short)input.UInt; break;
                        case USHORT: data = (ushort)input.UInt; break;
                        case INT: data = (int)input.UInt; break;
                        // String
                        case STRING: data = input.UInt.ToString(); break;
                    }
                    break;
                case TokenType.Long:
                    switch (typeof(T).FullName)
                    {
                        // Self
                        case LONG:
                        case OBJECT: data = input.Long; break;
                        // Implicit
                        case FLOAT: data = (float)input.Long; break;
                        case DOUBLE: data = (double)input.Long; break;
                        case DECIMAL: data = (decimal)input.Long; break;
                        // Explicit
                        case SBYTE: data = (sbyte)input.Long; break;
                        case BYTE: data = (byte)input.Long; break;
                        case SHORT: data = (short)input.Long; break;
                        case USHORT: data = (ushort)input.Long; break;
                        case INT: data = (int)input.Long; break;
                        case UINT: data = (uint)input.Long; break;
                        case ULONG: data = (ulong)input.Long; break;
                        // String
                        case STRING: data = input.Long.ToString(); break;
                    }
                    break;
                case TokenType.ULong:
                    switch (typeof(T).FullName)
                    {
                        // Self
                        case ULONG:
                        case OBJECT: data = input.ULong; break;
                        // Implicit
                        case FLOAT: data = (float)input.ULong; break;
                        case DOUBLE: data = (double)input.ULong; break;
                        case DECIMAL: data = (decimal)input.ULong; break;
                        // Explicit
                        case SBYTE: data = (sbyte)input.ULong; break;
                        case BYTE: data = (byte)input.ULong; break;
                        case SHORT: data = (short)input.ULong; break;
                        case USHORT: data = (ushort)input.ULong; break;
                        case INT: data = (int)input.ULong; break;
                        case UINT: data = (uint)input.ULong; break;
                        case LONG: data = (long)input.ULong; break;
                        // String
                        case STRING: data = input.ULong.ToString(); break;
                    }
                    break;
                case TokenType.Float:
                    switch (typeof(T).FullName)
                    {
                        // Self
                        case FLOAT:
                        case OBJECT: data = input.Float; break;
                        // Implicit
                        case DOUBLE: data = (double)input.Float; break;
                        // Explicit
                        case SBYTE: data = (sbyte)input.Float; break;
                        case BYTE: data = (byte)input.Float; break;
                        case SHORT: data = (short)input.Float; break;
                        case USHORT: data = (ushort)input.Float; break;
                        case INT: data = (int)input.Float; break;
                        case UINT: data = (uint)input.Float; break;
                        case LONG: data = (long)input.Float; break;
                        case ULONG: data = (ulong)input.Float; break;
                        case DECIMAL: data = (decimal)input.Float; break;
                        // String
                        case STRING: data = input.Float.ToString(); break;
                    }
                    break;
                case TokenType.Double:
                    switch (typeof(T).FullName)
                    {
                        // Self
                        case DOUBLE:
                        case OBJECT: data = input.Double; break;
                        // Explicit
                        case SBYTE: data = (sbyte)input.Double; break;
                        case BYTE: data = (byte)input.Double; break;
                        case SHORT: data = (short)input.Double; break;
                        case USHORT: data = (ushort)input.Double; break;
                        case INT: data = (int)input.Double; break;
                        case UINT: data = (uint)input.Double; break;
                        case LONG: data = (long)input.Double; break;
                        case ULONG: data = (ulong)input.Double; break;
                        case FLOAT: data = (float)input.Double; break;
                        case DECIMAL: data = (decimal)input.Double; break;
                        // String
                        case STRING: data = input.Double.ToString(); break;
                    }
                    break;
                case TokenType.String:
                    switch (typeof(T).FullName)
                    {
                        // Self
                        case STRING:
                        case OBJECT: data = input.String; break;
                        // Parsed
                        case BOOL: if (bool.TryParse(input.String, out bool boolP)) { data = boolP; } break;
                        case SBYTE: if (sbyte.TryParse(input.String, out sbyte sbyteP)) { data = sbyteP; } break;
                        case BYTE: if (byte.TryParse(input.String, out byte byteP)) { data = byteP; } break;
                        case SHORT: if (short.TryParse(input.String, out short shortP)) { data = shortP; } break;
                        case USHORT: if (ushort.TryParse(input.String, out ushort ushortP)) { data = ushortP; } break;
                        case INT: if (int.TryParse(input.String, out int intP)) { data = intP; } break;
                        case UINT: if (uint.TryParse(input.String, out uint uintP)) { data = uintP; } break;
                        case LONG: if (long.TryParse(input.String, out long longP)) { data = longP; } break;
                        case ULONG: if (ulong.TryParse(input.String, out ulong ulongP)) { data = ulongP; } break;
                        case FLOAT: if (float.TryParse(input.String, out float floatP)) { data = floatP; } break;
                        case DOUBLE: if (double.TryParse(input.String, out double doubleP)) { data = doubleP; } break;
                        case DECIMAL: if (decimal.TryParse(input.String, out decimal decimalP)) { data = decimalP; } break;
                    }
                    break;
                case TokenType.DataList:
                    switch (typeof(T).FullName)
                    {
                        // Self
                        case DATA_LIST:
                        case OBJECT: data = input.DataList; break;
                    }
                    break;
                case TokenType.DataDictionary:
                    switch (typeof(T).FullName)
                    {
                        // Self
                        case DATA_DICTIONARY:
                        case OBJECT: data = input.DataDictionary; break;
                    }
                    break;
                case TokenType.Reference:
                    // Self
                    switch (typeof(T).FullName)
                    {
                        // Self
                        case OBJECT: data = input.Reference; break;
                    }
                    break;
            }

            if (data == null)
            {
                result = default;
                return false;
            }

            result = (T)data;
            return true;
        }
    }
}
