using System;
using System.Linq;

namespace DotMath.Core.Numbers
{
    public class Fraction : Number
    {
        #region Public Constructors

        public Fraction(Integer numerator, Integer denominator)
        {
            if (denominator == 0)
            {
                throw new DivideByZeroException();
            }

            Numerator = numerator;
            Denominator = denominator;
        }

        #endregion Public Constructors

        #region Private Constructors

        private Fraction(string src)
        {
            if (src.Count(_ => _ == '/') == 1)
            {
                var splitted = src.Split('/');
                Numerator = int.Parse(splitted[0].Trim());
                Denominator = int.Parse(splitted[1].Trim());
            }
            else
            {
                throw new FormatException($"The format of the input string '{src}' is incorrect.");
            }
        }

        #endregion Private Constructors

        #region Public Properties

        public Integer Denominator { get; }
        public Integer Numerator { get; }
        public override float Value => Numerator.Value / Denominator.Value;

        #endregion Public Properties

        #region Public Methods

        public static implicit operator Fraction(Integer i) => new Fraction(i, 1);

        public static implicit operator Fraction(int i) => new Fraction(i, 1);

        public static implicit operator Fraction(string src) => new Fraction(src);

        public static Fraction operator -(Fraction a, Fraction b)
        {
            var lcm = MathUtils.LCM(a.Denominator, b.Denominator);
            var fa = lcm / a.Denominator;
            var fb = lcm / b.Denominator;
            return new Fraction(a.Numerator * fa - b.Numerator * fb, lcm).Simplify();
        }

        public static Fraction operator *(Fraction a, Fraction b) => new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator).Simplify();

        public static Fraction operator /(Fraction a, Fraction b) => new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator).Simplify();

        public static Fraction operator ^(Fraction a, Integer b) => new Fraction(a.Numerator ^ b, a.Denominator ^ b).Simplify();

        public static Fraction operator +(Fraction a, Fraction b)
        {
            var lcm = MathUtils.LCM(a.Denominator, b.Denominator);
            var fa = lcm / a.Denominator;
            var fb = lcm / b.Denominator;
            return new Fraction(a.Numerator * fa + b.Numerator * fb, lcm).Simplify();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj == null) { return false; }

            return obj is Fraction f && f.Value.Equals(this.Value);
        }

        public override int GetHashCode()
        {
            return this.Numerator.GetHashCode() ^
                this.Denominator.GetHashCode();
        }

        /// <summary>
        /// Transforms the current fraction into its simplest form.
        /// </summary>
        /// <returns>The simplified fraction.</returns>
        public Fraction Simplify()
        {
            var gcd = MathUtils.GCD(Numerator, Denominator);
            if (gcd == 1)
            {
                return this;
            }

            return new Fraction(Numerator / gcd, Denominator / gcd);
        }

        public override string ToLaTex() => Denominator == 0 || Denominator == 1 ? Numerator.ToString() : $"\\frac{{{Numerator}}}{{{Denominator}}}";

        public override string ToString() => Denominator == 0 || Denominator == 1 ? Numerator.ToString() : $"{Numerator}/{Denominator}";

        #endregion Public Methods
    }
}