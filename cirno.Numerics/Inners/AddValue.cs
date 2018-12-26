using System;
using System.Collections.Generic;
using System.Text;

namespace cirno.Numerics.Inners
{
    public class AddValue : INumberValue
    {
        INumberValue left;
        INumberValue right;

        public AddValue(INumberValue left, INumberValue right)
        {
            this.left = left;
            this.right = right;
        }

        public bool CanReduce()
        {
            throw new NotImplementedException();
        }

        public INumberValue Reduced()
        {
            throw new NotImplementedException();
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
