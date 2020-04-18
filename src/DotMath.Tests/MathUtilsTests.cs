using NUnit.Framework;
using DotMath.Core;
using DotMath.Core.Numbers;

namespace DotMath.Tests
{
    public class MathUtilsTests
    {
        [Test]
        public void GCDTest1()
        {
            var gcd = MathUtils.GCD(5,6);
            Assert.AreEqual(1, (int)gcd);
        }

        [Test]
        public void GCDTest2()
        {
            var gcd = MathUtils.GCD(1,19);
            Assert.AreEqual(1, (int)gcd);
        }

        [Test]
        public void GCDTest3()
        {
            var gcd = MathUtils.GCD(18,24);
            Assert.AreEqual(6, (int)gcd);
        }
    }
}