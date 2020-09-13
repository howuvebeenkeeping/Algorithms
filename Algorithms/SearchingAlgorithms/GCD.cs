using System;

namespace Algorithms.SearchingAlgorithms
{
    public class GCD
    {
        public static dynamic FindGcd(dynamic a, dynamic b)
        {
            if (!IsNumber(a) || !IsNumber(b)) return null;

            while (b != 0)
            {
                (a, b) = (b, a % b);
            }

            return a;
        }

        private static bool IsNumber(object value)
        {
            return value is sbyte
                   || value is byte
                   || value is short
                   || value is ushort
                   || value is int
                   || value is uint
                   || value is long
                   || value is ulong
                   || value is float
                   || value is double
                   || value is decimal;
        }

        public static dynamic FindGcdRecursion(dynamic a, dynamic b)
            => b == 0 ? a : FindGcdRecursion(b, a % b);
    }
}