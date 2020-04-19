using DotMath.Core.Polynomials;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotMath.Tests
{

    public class TermsTests
    {
        [Test]
        public void ConstantTermParseTest()
        {
            var term = Term.Parse("2");
            Assert.Pass();
        }
    }
}
