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

        public static ParameterExpression Paramters<T1>()
        {
            return Paramters<T1>($"{paraExprPrefix}P1");
        }

        public static ParameterExpression Paramters<T1>(string paramName)
        {
            return Expression.Parameter(typeof(T1), paramName);
        }

        public static List<ParameterExpression> Paramters<T1, T2>()
        {
            var paramterExprs = new List<ParameterExpression>();
            paramterExprs.Add(Paramters<T1>());
            paramterExprs.Add(Paramters<T2>($"{paraExprPrefix}P2"));
            return paramterExprs;
        }

        public static List<ParameterExpression> Paramters<T1, T2, T3>()
        {
            var paramterExprs = new List<ParameterExpression>();
            paramterExprs.AddRange(Paramters<T1, T2>());
            paramterExprs.Add(Paramters<T3>($"{paraExprPrefix}P3"));
            return paramterExprs;
        }

        public static List<ParameterExpression> Paramters<T1, T2, T3, T4>()
        {
            var paramterExprs = new List<ParameterExpression>();
            paramterExprs.AddRange(Paramters<T1, T2, T3>());
            paramterExprs.Add(Paramters<T4>($"{paraExprPrefix}P4"));
            return paramterExprs;
        }

        public static List<ParameterExpression> Paramters<T1, T2, T3, T4, T5>()
        {
            var paramterExprs = new List<ParameterExpression>();
            paramterExprs.AddRange(Paramters<T1, T2, T3, T4>());
            paramterExprs.Add(Paramters<T5>($"{paraExprPrefix}P5"));
            return paramterExprs;
        }

        public static List<ParameterExpression> Paramters<T1, T2, T3, T4, T5, T6>()
        {
            var paramterExprs = new List<ParameterExpression>();
            paramterExprs.AddRange(Paramters<T1, T2, T3, T4, T5>());
            paramterExprs.Add(Paramters<T6>($"{paraExprPrefix}P6"));
            return paramterExprs;
        }

        public static List<ParameterExpression> Paramters<T1, T2, T3, T4, T5, T6, T7>()
        {
            var paramterExprs = new List<ParameterExpression>();
            paramterExprs.AddRange(Paramters<T1, T2, T3, T4, T5, T6>());
            paramterExprs.Add(Paramters<T7>($"{paraExprPrefix}P7"));
            return paramterExprs;
        }

        public static List<ParameterExpression> Paramters<T1, T2, T3, T4, T5, T6, T7, T8>()
        {
            var paramterExprs = new List<ParameterExpression>();
            paramterExprs.AddRange(Paramters<T1, T2, T3, T4, T5, T6, T7>());
            paramterExprs.Add(Paramters<T8>($"{paraExprPrefix}P8"));
            return paramterExprs;
        }

        public static List<ParameterExpression> Paramters<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
        {
            var paramterExprs = new List<ParameterExpression>();
            paramterExprs.AddRange(Paramters<T1, T2, T3, T4, T5, T6, T7, T8>());
            paramterExprs.Add(Paramters<T9>($"{paraExprPrefix}P9"));
            return paramterExprs;
        }
    }
}
