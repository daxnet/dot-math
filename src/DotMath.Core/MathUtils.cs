
using System;
using DotMath.Core.Numbers;

namespace DotMath.Core
{
    public static class MathUtils
    {
        /// <summary>
        /// Calculates the Greatest Common Divisor (G.c.D) of
        /// the two given Integers.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The Greatest Common Divisor of the two.</returns>
        public static Integer GCD(Integer a, Integer b)
        {
            var f = Math.Abs(a);
            var s = Math.Abs(b);
            var c = f % s;
            while (c != 0)
            {
                f = s;
                s = c;
                c = f % s;
            }

            return s;
        }

        public static Integer LCM(Integer a, Integer b)
        {
            return (a * b) / GCD(a, b);
        }
    }
}