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
            Term term1 = Term.Parse("2x^2y^4");
            Term term2 = Term.Parse("2(x^2)(y^4)");
            Console.WriteLine(term1.Equals(term2));


            // var parms = new Dictionary<char, Number> { { 'x', 2.5f }, { 'y', 3 } };
            // var term = Term.Parse("1/6(x^3)y^2");
            // var s = term.ToString();
            // var term2 = Term.Parse("23/56");
            // var res = term.Evaluate(parms);
            // var res2 = term2.Evaluate(parms);
        }
    }
}