using NUnit.Framework;
using DotMath.Core.Numbers;

namespace DotMath.Tests
{
    public class NumbersTests
    {
        [Test]
        public void IntegerAssignTest()
        {
            Integer p = 10;
            Assert.AreEqual(10, p.Value);
        }

        [Test]
        public void IntegerEqualsTest()
        {
            Integer a = 10;
            Integer b = 10;
            Assert.True(a == b);
        }

        [Test]
        public void IntegerNotEqualsTest()
        {
            Integer a = 10;
            Integer b = 9;
            Assert.True(a != b);
        }

        [Test]
        public void IntegerNotEqualsNullTest()
        {
            Integer a = 10;
            Integer b = null;
            Assert.True(a != b);
        }

        [Test]
        public void IntegerGreatherThanTest()
        {
            Integer a = 10;
            Integer b = 9;
            Assert.True(a > b);
        }

        [Test]
        public void IntegerGreaterThanOrEqualsToTest()
        {
            Integer a = 10;
            Integer b = 10;
            Assert.True(a >= b);
        }

        [Test]
        public void IntegerLessThanTest()
        {
            Integer a = 10;
            Integer b = 9;
            Assert.True(b < a);
        }

        [Test]
        public void IntegerLessThanOrEqualsToTest()
        {
            Integer a = 10;
            Integer b = 10;
            Assert.True(a <= b);
        }
    }
}