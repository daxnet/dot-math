using DotMath.Core.Numbers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotMath.Core.Polynomials
{
    public interface IEvaluable
    {
        Number Evaluate(IEnumerable<KeyValuePair<char, Number>> variableParameters);
    }
}
