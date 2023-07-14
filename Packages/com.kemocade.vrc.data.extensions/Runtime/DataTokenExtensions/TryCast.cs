using System;
using VRC.SDK3.Data;

namespace Kemocade.Vrc.Data.Extensions
{
    public static partial class DataTokenExtensions
    {
        // TODO: special error message if passed in array type (use TryCastArray instead!)
        public static bool TryCast<T>(this DataToken input, out T result)
        {
            object data = null;
            Type type = typeof(T);

            TokenType tokenType = input.TokenType;

            if (tokenType == TokenType.Boolean)
            {
                // Self
                if (type == typeof(bool) || type == typeof(object)) { data = input.Boolean; }
                // String
                else if (type == typeof(string)) { data = input.Boolean.ToString(); }
            }
            else if (tokenType == TokenType.SByte)
            {
                // Self
                if (type == typeof(sbyte) || type == typeof(object)) { data = input.SByte; }
                // Implicit
                else if (type == typeof(short)) { data = (short)input.SByte; }
                else if (type == typeof(int)) { data = (int)input.SByte; }
                else if (type == typeof(long)) { data = (long)input.SByte; }
                else if (type == typeof(float)) { data = (float)input.SByte; }
                else if (type == typeof(double)) { data = (double)input.SByte; }
                else if (type == typeof(decimal)) { data = (decimal)input.SByte; }
                // Explicit
                else if (type == typeof(byte)) { data = (byte)input.SByte; }
                else if (type == typeof(ushort)) { data = (ushort)input.SByte; }
                else if (type == typeof(uint)) { data = (uint)input.SByte; }
                else if (type == typeof(ulong)) { data = (ulong)input.SByte; }
                // String
                else if (type == typeof(string)) { data = input.SByte.ToString(); }
            }
            else if (tokenType == TokenType.Byte)
            {
                // Self
                if (type == typeof(byte) || type == typeof(object)) { data = input.Byte; }
                // Implicit
                else if (type == typeof(short)) { data = (short)input.Byte; }
                else if (type == typeof(ushort)) { data = (ushort)input.Byte; }
                else if (type == typeof(int)) { data = (int)input.Byte; }
                else if (type == typeof(uint)) { data = (uint)input.Byte; }
                else if (type == typeof(long)) { data = (long)input.Byte; }
                else if (type == typeof(ulong)) { data = (ulong)input.Byte; }
                else if (type == typeof(float)) { data = (float)input.Byte; }
                else if (type == typeof(double)) { data = (double)input.Byte; }
                else if (type == typeof(decimal)) { data = (decimal)input.Byte; }
                // Explicit
                else if (type == typeof(sbyte)) { data = (sbyte)input.Byte; }
                // String
                else if (type == typeof(string)) { data = input.Byte.ToString(); }
            }
            else if (tokenType == TokenType.Short)
            {
                // Self
                if (type == typeof(short) || type == typeof(object)) { data = input.Short; }
                // Implicit
                else if (type == typeof(int)) { data = (int)input.Short; }
                else if (type == typeof(long)) { data = (long)input.Short; }
                else if (type == typeof(float)) { data = (float)input.Short; }
                else if (type == typeof(double)) { data = (double)input.Short; }
                else if (type == typeof(decimal)) { data = (decimal)input.Short; }
                // Explicit
                else if (type == typeof(sbyte)) { data = (sbyte)input.Short; }
                else if (type == typeof(byte)) { data = (byte)input.Short; }
                else if (type == typeof(ushort)) { data = (ushort)input.Short; }
                else if (type == typeof(uint)) { data = (uint)input.Short; }
                else if (type == typeof(ulong)) { data = (ulong)input.Short; }
                // String
                else if (type == typeof(string)) { data = input.Short.ToString(); }
            }
            else if (tokenType == TokenType.UShort)
            {
                // Self
                if (type == typeof(ushort) || type == typeof(object)) { data = input.UShort; }
                // Implicit
                else if (type == typeof(int)) { data = (int)input.UShort; }
                else if (type == typeof(uint)) { data = (uint)input.UShort; }
                else if (type == typeof(long)) { data = (long)input.UShort; }
                else if (type == typeof(ulong)) { data = (ulong)input.UShort; }
                else if (type == typeof(float)) { data = (float)input.UShort; }
                else if (type == typeof(double)) { data = (double)input.UShort; }
                else if (type == typeof(decimal)) { data = (decimal)input.UShort; }
                // Explicit
                else if (type == typeof(sbyte)) { data = (sbyte)input.UShort; }
                else if (type == typeof(byte)) { data = (byte)input.UShort; }
                else if (type == typeof(short)) { data = (short)input.UShort; }
                // String
                else if (type == typeof(string)) { data = input.UShort.ToString(); }
            }
            else if (tokenType == TokenType.Int)
            {
                // Self
                if (type == typeof(int) || type == typeof(object)) { data = input.Int; }
                // Implicit
                else if (type == typeof(long)) { data = (long)input.Int; }
                else if (type == typeof(float)) { data = (float)input.Int; }
                else if (type == typeof(double)) { data = (double)input.Int; }
                else if (type == typeof(decimal)) { data = (decimal)input.Int; }
                // Explicit
                else if (type == typeof(sbyte)) { data = (sbyte)input.Int; }
                else if (type == typeof(byte)) { data = (byte)input.Int; }
                else if (type == typeof(short)) { data = (short)input.Int; }
                else if (type == typeof(ushort)) { data = (ushort)input.Int; }
                else if (type == typeof(uint)) { data = (uint)input.Int; }
                else if (type == typeof(ulong)) { data = (ulong)input.Int; }
                // String
                else if (type == typeof(string)) { data = input.Int.ToString(); }
            }
            else if (tokenType == TokenType.UInt)
            {
                // Self
                if (type == typeof(uint) || type == typeof(object)) { data = input.UInt; }
                // Implicit
                else if (type == typeof(long)) { data = (long)input.UInt; }
                else if (type == typeof(ulong)) { data = (ulong)input.UInt; }
                else if (type == typeof(float)) { data = (float)input.UInt; }
                else if (type == typeof(double)) { data = (double)input.UInt; }
                else if (type == typeof(decimal)) { data = (decimal)input.UInt; }
                // Explicit
                else if (type == typeof(sbyte)) { data = (sbyte)input.UInt; }
                else if (type == typeof(byte)) { data = (byte)input.UInt; }
                else if (type == typeof(short)) { data = (short)input.UInt; }
                else if (type == typeof(ushort)) { data = (ushort)input.UInt; }
                else if (type == typeof(int)) { data = (int)input.UInt; }
                // String
                else if (type == typeof(string)) { data = input.UInt.ToString(); }
            }
            else if (tokenType == TokenType.Long)
            {
                // Self
                if (type == typeof(long) || type == typeof(object)) { data = input.Long; }
                // Implicit
                else if (type == typeof(float)) { data = (float)input.Long; }
                else if (type == typeof(double)) { data = (double)input.Long; }
                else if (type == typeof(decimal)) { data = (decimal)input.Long; }
                // Explicit
                else if (type == typeof(sbyte)) { data = (sbyte)input.Long; }
                else if (type == typeof(byte)) { data = (byte)input.Long; }
                else if (type == typeof(short)) { data = (short)input.Long; }
                else if (type == typeof(ushort)) { data = (ushort)input.Long; }
                else if (type == typeof(int)) { data = (int)input.Long; }
                else if (type == typeof(uint)) { data = (uint)input.Long; }
                else if (type == typeof(ulong)) { data = (ulong)input.Long; }
                // String
                else if (type == typeof(string)) { data = input.Long.ToString(); }
            }
            else if (tokenType == TokenType.ULong)
            {
                // Self
                if (type == typeof(ulong) || type == typeof(object)) { data = input.ULong; }
                // Implicit
                else if (type == typeof(float)) { data = (float)input.ULong; }
                else if (type == typeof(double)) { data = (double)input.ULong; }
                else if (type == typeof(decimal)) { data = (decimal)input.ULong; }
                // Explicit
                else if (type == typeof(sbyte)) { data = (sbyte)input.ULong; }
                else if (type == typeof(byte)) { data = (byte)input.ULong; }
                else if (type == typeof(short)) { data = (short)input.ULong; }
                else if (type == typeof(ushort)) { data = (ushort)input.ULong; }
                else if (type == typeof(int)) { data = (int)input.ULong; }
                else if (type == typeof(uint)) { data = (uint)input.ULong; }
                else if (type == typeof(long)) { data = (long)input.ULong; }
                // String
                else if (type == typeof(string)) { data = input.ULong.ToString(); }
            }
            else if (tokenType == TokenType.Float)
            {
                // Self
                if (type == typeof(float) || type == typeof(object)) { data = input.Float; }
                // Implicit
                else if (type == typeof(double)) { data = input.Double; }
                // Explicit
                else if (type == typeof(sbyte)) { data = (sbyte)input.Float; }
                else if (type == typeof(byte)) { data = (byte)input.Float; }
                else if (type == typeof(short)) { data = (short)input.Float; }
                else if (type == typeof(ushort)) { data = (ushort)input.Float; }
                else if (type == typeof(int)) { data = (int)input.Float; }
                else if (type == typeof(uint)) { data = (uint)input.Float; }
                else if (type == typeof(long)) { data = (long)input.Float; }
                else if (type == typeof(ulong)) { data = (ulong)input.Float; }
                else if (type == typeof(decimal)) { data = (decimal)input.Float; }
                // String
                else if (type == typeof(string)) { data = input.Float.ToString(); }
            }
            else if (tokenType == TokenType.Double)
            {
                // Self
                if (type == typeof(double) || type == typeof(object)) { data = input.Double; }
                // Explicit
                else if (type == typeof(sbyte)) { data = (sbyte)input.Double; }
                else if (type == typeof(byte)) { data = (byte)input.Double; }
                else if (type == typeof(short)) { data = (short)input.Double; }
                else if (type == typeof(ushort)) { data = (ushort)input.Double; }
                else if (type == typeof(int)) { data = (int)input.Double; }
                else if (type == typeof(uint)) { data = (uint)input.Double; }
                else if (type == typeof(long)) { data = (long)input.Double; }
                else if (type == typeof(ulong)) { data = (ulong)input.Double; }
                else if (type == typeof(float)) { data = (float)input.Double; }
                else if (type == typeof(decimal)) { data = (decimal)input.Double; }
                // String
                else if (type == typeof(string)) { data = input.Double.ToString(); }
            }
            else if (tokenType == TokenType.String)
            {
                string raw = input.String;
                // Self
                if (type == typeof(string) || type == typeof(object)) { data = raw; }
                // Parsed
                else if (type == typeof(bool) && bool.TryParse(raw, out bool boolP)) { data = boolP; }
                else if (type == typeof(sbyte) && sbyte.TryParse(raw, out sbyte sbyteP)) { data = sbyteP; }
                else if (type == typeof(byte) && byte.TryParse(raw, out byte byteP)) { data = byteP; }
                else if (type == typeof(short) && short.TryParse(raw, out short shortP)) { data = shortP; }
                else if (type == typeof(ushort) && ushort.TryParse(raw, out ushort parsed)) { data = parsed; }
                else if (type == typeof(int) && int.TryParse(raw, out int intP)) { data = intP; }
                else if (type == typeof(uint) && uint.TryParse(raw, out uint uintP)) { data = uintP; }
                else if (type == typeof(long) && long.TryParse(raw, out long longP)) { data = longP; }
                else if (type == typeof(ulong) && ulong.TryParse(raw, out ulong ulongP)) { data = ulongP; }
                else if (type == typeof(float) && float.TryParse(raw, out float floatP)) { data = floatP; }
                else if (type == typeof(double) && double.TryParse(raw, out double doubleP)) { data = doubleP; }
                else if (type == typeof(decimal) && decimal.TryParse(raw, out decimal decimalP)) { data = decimalP; }
            }
            else if (tokenType == TokenType.DataList)
            {
                // Self
                if (type == typeof(DataList) || type == typeof(object)) { data = input.DataList; }
            }
            else if (tokenType == TokenType.DataDictionary)
            {
                // Self
                if (type == typeof(DataDictionary) || type == typeof(object)) { data = input.DataDictionary; }
            }
            else if (tokenType == TokenType.Reference)
            {
                // Self
                if (type == typeof(object)) { data = input.Reference; }
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
