using System;

namespace DotMath.Core.Numbers
{
    public class Fraction : Number
    {
        public Fraction(Integer numerator, Integer denominator)
        {
            if (denominator == 0)
            {
                throw new DivideByZeroException();
            }

            Numerator = numerator;
            Denominator = denominator;
        }

        public Integer Numerator { get; }
        public Integer Denominator { get; }
        public override float Value => (int)Numerator / (int)Denominator;

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

        public override string ToString() => Denominator == 0 || Denominator == 1 ? Numerator.ToString() : $"{Numerator}/{Denominator}";

        public Fraction Simplify()
        {
            var gcd = MathUtils.GCD(Numerator, Denominator);
            if (gcd == 1)
            {
                return this;
            }

            return new Fraction(Numerator / gcd, Denominator / gcd);
        }

        public static implicit operator Fraction(Integer i) => new Fraction(i, 1);

        public static implicit operator Fraction(int i) => new Fraction(i, 1); 

        public static Fraction operator + (Fraction a, Fraction b)
        {
            var lcm = MathUtils.LCM(a.Denominator, b.Denominator);
            var fa = lcm / a.Denominator;
            var fb = lcm / b.Denominator;
            return new Fraction(a.Numerator * fa + b.Numerator * fb, lcm).Simplify();
        }

        public static Fraction operator - (Fraction a, Fraction b)
        {
            var lcm = MathUtils.LCM(a.Denominator, b.Denominator);
            var fa = lcm / a.Denominator;
            var fb = lcm / b.Denominator;
            return new Fraction(a.Numerator * fa - b.Numerator * fb, lcm).Simplify();
        }

        public static Fraction operator * (Fraction a, Fraction b) => new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator).Simplify();

        public static Fraction operator / (Fraction a, Fraction b) => new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator).Simplify();
    }
}