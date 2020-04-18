using System;
using DotMath.Core;
using DotMath.Core.Numbers;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Integer(2);
            var b = new Integer(8);
            var c = MathUtils.GCD(a, b);

            var p = new Fraction(1, 2);
            var q = new Fraction(4, 3);
            Console.WriteLine($"{p} / {q} = {p / q}");
        }
    }
}
