﻿using DotMath.Core.Numbers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotMath.Core.Polynomials
{
    public class Term : IEvaluable
    {
        #region Private Fields

        private readonly List<VariableComponent> variableComponents = new List<VariableComponent>();

        #endregion Private Fields

        #region Public Constructors

        public Term(Number coefficient)
            : this(coefficient, null)
        { }

        public Term(IEnumerable<VariableComponent> variableComponents)
            : this((Integer)1, variableComponents)
        { }

        public Term(Number coefficient, IEnumerable<VariableComponent> variableComponents)
        {
            Coefficient = coefficient;
            if (variableComponents != null)
            {
                this.variableComponents.AddRange(variableComponents);
            }
        }

        #endregion Public Constructors

        #region Public Properties

        public Number Coefficient { get; }

        public IEnumerable<VariableComponent> VariableComponents => variableComponents;

        #endregion Public Properties

        #region Public Methods

        public static Term Parse(string src)
        {
            var pos = 0;
            var token = new StringBuilder();
            var tokenType = "coefficient";
            var coefficient = Number.Zero;
            var variableComponents = new List<VariableComponent>();
            do
            {
                var ch = pos == src.Length ? '\0' : src[pos];
                if (ch == '\0' || ch == '(' || (ch >= 'a' && ch <= 'z'))
                {
                    switch (tokenType)
                    {
                        case "coefficient":
                            coefficient = float.Parse(token.ToString());
                            token.Clear();
                            tokenType = "variableComponent";
                            break;

                        case "variableComponent":
                            var variableComponentStr = token.ToString().Trim('(', ')');
                            if (variableComponentStr.Length == 1)
                            {
                                var symbol = variableComponentStr[0];
                                if (symbol >= 'a' && symbol <= 'z')
                                {
                                    variableComponents.Add(new VariableComponent(symbol));
                                }
                                else
                                {
                                    throw new FormatException("The format of the variable component is invalid.");
                                }
                            }
                            else
                            {
                                var symbolAndExponent = variableComponentStr.Split('^');
                                if (symbolAndExponent.Length != 2)
                                {
                                    throw new FormatException("The format of the variable component is invalid.");
                                }

                                var symbolStr = symbolAndExponent[0].Trim();
                                if (symbolStr.Length != 1 || symbolStr[0] < 'a' || symbolStr[0] > 'z')
                                {
                                    throw new FormatException("The format of the variable component is invalid.");
                                }
                                var exponentStr = symbolAndExponent[1].Trim();
                                var exponent = int.Parse(exponentStr);
                                variableComponents.Add(new VariableComponent(symbolStr[0], exponent));
                            }
                            token.Clear();
                            tokenType = "variableComponent";
                            break;
                    }
                }

                token.Append(ch);
                pos++;
            } while (pos <= src.Length);

            return new Term(coefficient, variableComponents);
        }

        public Number Evaluate(IEnumerable<KeyValuePair<char, Number>> variableParameters)
        {
            var result = Coefficient;
            if (variableComponents?.Count > 0)
            {
                variableComponents.ForEach(vc => result *= vc.Evaluate(variableParameters));
            }

            return result;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Coefficient);
            var m = variableComponents?.Count > 0;
            foreach (var vc in variableComponents)
            {
                sb.Append(m ? $"({vc.Symbol}^{vc.Exponent})" : $"{vc.Symbol}:{vc.Exponent}");
            }
            return sb.ToString();
        }

        #endregion Public Methods
    }
}