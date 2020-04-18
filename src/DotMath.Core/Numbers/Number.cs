namespace DotMath.Core.Numbers
{
    /// <summary>
    /// Represents a number.
    /// </summary>
    /// <typeparam name="T">The type of the underlying value.</typeparam>
    public abstract class Number<T>
        where T : struct
    {
        /// <summary>
        /// Gets the value of the number.
        /// </summary>
        /// <value>The value of the number.</value>
        public abstract T Value { get; }
    }
}