using DotMath.Core.Numbers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotMath.Core.Polynomials
{
    public sealed class Polynomial : IEvaluable, IMathElement
    {
        private readonly List<Term> terms = new List<Term>();

        public Polynomial() { }

        public Polynomial(IEnumerable<Term> terms)
        {
            this.terms.AddRange(terms);
        }

        public IEnumerable<Term> Terms => terms;

        public Number Evaluate(IEnumerable<KeyValuePair<char, Number>> variableParameters)
        {
            throw new NotImplementedException();
        }

        public string ToLaTex()
        {
            throw new NotImplementedException();
        }
    }
}
