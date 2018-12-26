using System;
using System.Collections.Generic;
using System.Text;

namespace cirno.Numerics.Inners
{
    public interface INumberValue
    {
        bool CanReduce();
        INumberValue Reduced();

        bool TryAsImperiodic(out ImperiodicNumber value);

        string ToExpression();
    }
}
