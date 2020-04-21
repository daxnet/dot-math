using DotMath.Core.Numbers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DotMath.Core.Polynomials
{
    public class VariableComponent : IEvaluable
    {
        public VariableComponent(char symbol)
            : this(symbol, 1)
        { }

        public VariableComponent(char symbol, Integer exponent)
        {
            if (symbol < 'a' || symbol > 'z')
            {
                throw new MalformedException(symbol.ToString(), 
                    typeof(VariableComponent), 
                    "Symbol of a variable component in a polynomial must be 'a' to 'z'.");
            }

            if (exponent < 0)
            {
                throw new MalformedException(exponent.ToString(),
                    typeof(VariableComponent),
                    "Exponent of a variable component in a polynomial must either be zero or a positive integer value.");
            }

            Symbol = symbol;
            Exponent = exponent;
        }

        public char Symbol { get; }

        public Integer Exponent { get; }

        public Number Evaluate(IEnumerable<KeyValuePair<char, Number>> variableParameters)
        {
            if (variableParameters.Any(kvp => kvp.Key == Symbol))
            {
                var kvp = variableParameters.First(item => item.Key == Symbol);
                return kvp.Value ^ Exponent;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj == null)
            {
                return false;
            }

            return obj is VariableComponent vc && Symbol == vc.Symbol && Exponent == vc.Exponent;
        }

        public override int GetHashCode()
        {
            return Symbol.GetHashCode() ^ Exponent.GetHashCode();
        }

        public static bool operator ==(VariableComponent a, VariableComponent b) => Equals(a, b);

        public static bool operator !=(VariableComponent a, VariableComponent b) => !Equals(a, b);

        public override string ToString() => $"{Symbol}^{Exponent}";
    }
}
