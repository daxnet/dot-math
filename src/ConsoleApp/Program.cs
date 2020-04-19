using System;
using System.Collections.Generic;
using DotMath.Core;
using DotMath.Core.Numbers;
using DotMath.Core.Polynomials;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = new Fraction(2,3);
            Console.WriteLine(f.ToLaTex());

            var parms = new Dictionary<char, Number> { { 'x', 2.5f }, { 'y', 3 } };
            var term = Term.Parse("1/6(x^3)y^2");
            var s = term.ToString();
            var term2 = Term.Parse("23/56");
            var res = term.Evaluate(parms);
            var res2 = term2.Evaluate(parms);
        }
    }
}