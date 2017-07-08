using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OhDotNetLib.Linq
{
    public static class PredicateBuilder
    {
        private const string paraExprPrefix = "OhLq_";

        public static Func<T1, bool> True<T1>() => (T1 t1) => true;
        public static Func<T1, T2, bool> True<T1, T2>() => (T1 t1, T2 t2) => true;

        public static Func<T1, T2, T3, bool> True<T1, T2, T3>() => (T1 t1, T2 t2, T3 t3) => true;

        public static Func<T1, T2, T3, T4, bool> True<T1, T2, T3, T4>() => (T1 t1, T2 t2, T3 t3, T4 t4) => true;

        public static Func<T1, T2, T3, T4, T5, bool> True<T1, T2, T3, T4, T5>() => (T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => true;

        public static Func<T1, T2, T3, T4, T5, T6, bool> True<T1, T2, T3, T4, T5, T6>() => (T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => true;

        public static Func<T1, T2, T3, T4, T5, T6, T7, bool> True<T1, T2, T3, T4, T5, T6, T7>() => (T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => true;

        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, bool> True<T1, T2, T3, T4, T5, T6, T7, T8>() => (T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8) => true;

        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool> True<T1, T2, T3, T4, T5, T6, T7, T8, T9>() => (T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9) => true;

        public static ParameterExpression Paramter<T1>()
        {
            return Paramter<T1>($"{paraExprPrefix}P1");
        }
        public static ParameterExpression Paramter<T1>(string paramName)
        {
            return Paramter(typeof(T1), paramName);
        }

        public static List<ParameterExpression> Paramters<T1, T2>()
        {
            return Paramters(typeof(T1), typeof(T2));
        }

        public static List<ParameterExpression> Paramters<T1, T2, T3>()
        {
            return Paramters(typeof(T1), typeof(T2), typeof(T3));
        }

        public static List<ParameterExpression> Paramters<T1, T2, T3, T4>()
        {
            return Paramters(typeof(T1), typeof(T2), typeof(T3), typeof(T4));
        }

        public static List<ParameterExpression> Paramters<T1, T2, T3, T4, T5>()
        {
            return Paramters(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5));
        }

        public static List<ParameterExpression> Paramters<T1, T2, T3, T4, T5, T6>()
        {
            return Paramters(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6));
        }

        public static List<ParameterExpression> Paramters<T1, T2, T3, T4, T5, T6, T7>()
        {
            return Paramters(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7));
        }

        public static List<ParameterExpression> Paramters<T1, T2, T3, T4, T5, T6, T7, T8>()
        {
            return Paramters(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8));
        }

        public static List<ParameterExpression> Paramters<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
        {
            return Paramters(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9));
        }

        public static ParameterExpression Paramter(Type type)
        {
            return Paramter(type, $"{paraExprPrefix}P1");
        }
        public static ParameterExpression Paramter(Type type, string paramName)
        {
            return Expression.Parameter(type, paramName);
        }

        public static List<ParameterExpression> Paramters(Type type1, Type type2)
        {
            var paramterExprs = new List<ParameterExpression>();
            paramterExprs.Add(Paramter(type1));
            paramterExprs.Add(Paramter(type2, $"{paraExprPrefix}P2"));
            return paramterExprs;
        }

        public static List<ParameterExpression> Paramters(Type type1, Type type2, Type type3)
        {
            var paramterExprs = new List<ParameterExpression>();
            paramterExprs.AddRange(Paramters(type1, type2));
            paramterExprs.Add(Paramter(type3, $"{paraExprPrefix}P3"));
            return paramterExprs;
        }

        public static List<ParameterExpression> Paramters(Type type1, Type type2, Type type3, Type type4)
        {
            var paramterExprs = new List<ParameterExpression>();
            paramterExprs.AddRange(Paramters(type1, type2, type3));
            paramterExprs.Add(Paramter(type4, $"{paraExprPrefix}P4"));
            return paramterExprs;
        }
        public static List<ParameterExpression> Paramters(Type type1, Type type2, Type type3, Type type4, Type type5)
        {
            var paramterExprs = new List<ParameterExpression>();
            paramterExprs.AddRange(Paramters(type1, type2, type3, type4));
            paramterExprs.Add(Paramter(type5, $"{paraExprPrefix}P5"));
            return paramterExprs;
        }
        public static List<ParameterExpression> Paramters(Type type1, Type type2, Type type3, Type type4, Type type5, Type type6)
        {
            var paramterExprs = new List<ParameterExpression>();
            paramterExprs.AddRange(Paramters(type1, type2, type3, type4, type5));
            paramterExprs.Add(Paramter(type6, $"{paraExprPrefix}P6"));
            return paramterExprs;
        }

        public static List<ParameterExpression> Paramters(Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7)
        {
            var paramterExprs = new List<ParameterExpression>();
            paramterExprs.AddRange(Paramters(type1, type2, type3, type4, type5, type6));
            paramterExprs.Add(Paramter(type7, $"{paraExprPrefix}P7"));
            return paramterExprs;
        }

        public static List<ParameterExpression> Paramters(Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Type type8)
        {
            var paramterExprs = new List<ParameterExpression>();
            paramterExprs.AddRange(Paramters(type1, type2, type3, type4, type5, type6, type7));
            paramterExprs.Add(Paramter(type8, $"{paraExprPrefix}P8"));
            return paramterExprs;
        }
        public static List<ParameterExpression> Paramters(Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Type type8, Type type9)
        {
            var paramterExprs = new List<ParameterExpression>();
            paramterExprs.AddRange(Paramters(type1, type2, type3, type4, type5, type6, type7, type8));
            paramterExprs.Add(Paramter(type9, $"{paraExprPrefix}P9"));
            return paramterExprs;
        }
    }
}
