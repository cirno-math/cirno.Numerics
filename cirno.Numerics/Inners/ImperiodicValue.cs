using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace cirno.Numerics.Inners
{
    internal class ImperiodicValue : INumberValue
    {
        ImperiodicNumber value;
        public ImperiodicValue(ImperiodicNumber value)
        {
            this.value = value;
        }

        public bool CanReduce()
            => false;

        public INumberValue Reduced()
        {
            return this;
        }

        public bool TryAsImperiodic(out ImperiodicNumber value)
        {
            throw new NotImplementedException();
        }

        public string ToExpression()
        {
            throw new NotImplementedException();
        }
    }
}
