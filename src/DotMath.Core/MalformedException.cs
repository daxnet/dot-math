using System;
using System.Collections.Generic;
using System.Text;

namespace DotMath.Core
{
    public class MalformedException : DotMathException
    {
        public MalformedException(string component, Type componentType, string detailedMessage = null)
            : base($"Malformed value '{component}' for type {componentType.Name}. {detailedMessage ?? string.Empty}")
        { }
    }
}
