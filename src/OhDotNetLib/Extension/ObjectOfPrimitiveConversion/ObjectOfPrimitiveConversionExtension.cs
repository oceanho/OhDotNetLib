using OhDotNetLib.Utils;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace OhDotNetLib.Extension
{
    public static partial class ObjectOfPrimitiveConversionExtension
    {
        public static Int16 ToInt16(this object source)
        {
            return Convert.ToInt16(source);
        }

        public static UInt16 ToUInt16(this object source)
        {
            return Convert.ToUInt16(source);
        }

        public static Int32 ToInt(this object source)
        {
            return Convert.ToInt32(source);
        }

        public static UInt32 ToUInt(this object source)
        {
            return Convert.ToUInt32(source);
        }

        public static Int64 ToInt64(this object source)
        {
            return Convert.ToInt64(source);
        }

        public static UInt64 ToUInt64(this object source)
        {
            return Convert.ToUInt64(source);
        }

        public static Single ToSinglet(this object source)
        {
            return Convert.ToSingle(source);
        }

        public static Double ToDouble(this object source)
        {
            return Convert.ToDouble(source);
        }

        public static Decimal ToDecimal(this object source)
        {
            return Convert.ToDecimal(source);
        }

        public static DateTime ToDateTime(this object source)
        {
            return Convert.ToDateTime(source);
        }

        public static Guid ToGuid(this object source)
        {
            ObjectChecker.CheckNotNull(source);
            return Guid.Parse(source.ToString());
        }

        public static TEnumTyper ToEnum<TEnumTyper>(this object source)
        {
            Reflection.EnumHelper.CheckType(typeof(TEnumTyper));
            return (TEnumTyper)Enum.Parse(typeof(TEnumTyper), source.ToString());
        }

        public static TPrimitive ToPrimitive<TPrimitive>(this object source)
        {
            if (Reflection.EnumHelper.IsEnumType(typeof(TPrimitive)))
            {
                return source.ToEnum<TPrimitive>();
            }
            if (Reflection.ReflectionHelper.IsPrimitiveType(typeof(TPrimitive)))
            {
                return (TPrimitive)Convert.ChangeType(source, typeof(TPrimitive));
            }
            throw new InvalidCastException($"invalid TPrimitive Type: {typeof(TPrimitive)}");
        }
    }
}
