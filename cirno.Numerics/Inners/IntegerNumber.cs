using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace cirno.Numerics.Inners
{
    internal class IntegerNumber : INumberValue
    {
        BigInteger value;
        public IntegerNumber(BigInteger value)
        {
            this.value = value;
        }
    }
}
