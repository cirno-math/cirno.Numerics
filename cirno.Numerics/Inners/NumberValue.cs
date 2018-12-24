using System;
using System.Collections.Generic;
using System.Text;

namespace cirno.Numerics.Inners
{
    public interface INumberValue
    {
        decimal EvalAsDecimal();

        INumberValue Reduced();

        bool TryAsImperiodic(out ImperiodicNumber value);
    }
}
