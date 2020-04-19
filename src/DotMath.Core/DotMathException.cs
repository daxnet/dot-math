using System;
using System.Collections.Generic;
using System.Text;

namespace DotMath.Core
{
    public class DotMathException : Exception
    {
        public DotMathException() { }

        public DotMathException(string message)
            : base(message) { }

        public DotMathException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
