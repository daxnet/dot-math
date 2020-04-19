using System;
using DotMath.Core;
using DotMath.Core.Numbers;
using DotMath.Core.Polynomials;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var term = Term.Parse("2x^3");
            var term2 = Term.Parse(term.ToString());
        }
    }
}
