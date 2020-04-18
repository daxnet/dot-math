using NUnit.Framework;
using DotMath.Core.Numbers;

namespace DotMath.Tests
{
    public class NumbersTests
    {
        [Test]
        public void IntegerAssign()
        {
            Integer p = 10;
            Assert.AreEqual(10, p.Value);
        }
    }
}