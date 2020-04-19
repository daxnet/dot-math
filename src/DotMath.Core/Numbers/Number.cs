using System;

namespace DotMath.Core.Numbers
{
    /// <summary>
    /// Represents a number.
    /// </summary>
    /// <typeparam name="T">The type of the underlying value.</typeparam>
    public class Number : IMathElement
    {
        public static readonly Number Zero = new Number(0);

        public Number() { }

        public Number(float value) => Value = value;

        /// <summary>
        /// Gets the value of the number.
        /// </summary>
        /// <value>The value of the number.</value>
        public virtual float Value { get; }

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

            return obj is Number num && num.Value == Value;
        }

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value.ToString();

        public virtual string ToLaTex() => Value.ToString();

        public static implicit operator Number(float v) => new Number(v);

        public static implicit operator float(Number n) => n.Value;

        public static Number operator +(Number a, Number b) => a.Value + b.Value;

        public static Number operator -(Number a, Number b) => a.Value - b.Value;

        public static Number operator *(Number a, Number b) => a.Value * b.Value;

        public static Number operator /(Number a, Number b) => a.Value / b.Value;

        public static Number operator ^(Number a, Number b) => (float) Math.Pow(a, b);

        public static bool operator ==(Number a, Number b) => Equals(a, b);

        public static bool operator !=(Number a, Number b) => !Equals(a, b);

        public static bool operator >(Number a, Number b) => a.Value > b.Value;

        public static bool operator <(Number a, Number b) => a.Value < b.Value;

        public static bool operator >=(Number a, Number b) => a.Value >= b.Value;

        public static bool operator <=(Number a, Number b) => a.Value <= b.Value;
    }
}