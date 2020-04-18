namespace DotMath.Core.Numbers
{
    public class Integer : Number<int>
    {

        public Integer(int value) => Value = value;

        public override int Value { get; }

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

            return obj is Integer i && i.Value.Equals(Value);
        }

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value.ToString();

        public static implicit operator Integer(int value) => new Integer(value);

        public static implicit operator int(Integer integer) => integer.Value;

        public static Integer operator + (Integer a, Integer b) => a.Value + b.Value;

        public static Integer operator - (Integer a, Integer b) => a.Value - b.Value;

        public static Integer operator * (Integer a, Integer b) => a.Value * b.Value;

        public static Integer operator / (Integer a, Integer b) => a.Value / b.Value;

        public static Integer operator % (Integer a, Integer b) => a.Value % b.Value;

        public static bool operator == (Integer a, Integer b) => Equals(a, b);

        public static bool operator != (Integer a, Integer b) => !Equals(a, b);
    }
}
