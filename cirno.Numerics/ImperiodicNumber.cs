using System;
using System.Numerics;

namespace cirno.Numerics
{
    /// <summary>
    /// ImperiodicNumber is Rational Number without Recurring Decimal.
    /// It MUST assert given number is imperiodic by check factors of denominator is only 2 and 5.
    /// If not, it throws exception in constructor.
    /// </summary>
    public struct ImperiodicNumber
    {
        BigInteger numerator, denominator;

        public ImperiodicNumber(BigInteger numerator) : this(numerator, 1)
        {

        }

        public ImperiodicNumber(BigInteger numerator, BigInteger denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;

            Factor();
            AssertValid();
        }

        public ImperiodicNumber(string value)
        {
            if (TryParse(value, out var parsed))
            {
                numerator = parsed.numerator;
                denominator = parsed.denominator;
            }
            else throw new ArgumentException($"failed parsing value: {value}");

            AssertValid();
        }

        public ImperiodicNumber(long value)
        {
            numerator = value;
            denominator = BigInteger.One;
        }

        public ImperiodicNumber(int value)
        {
            numerator = value;
            denominator = BigInteger.One;
        }

        public ImperiodicNumber(ulong value)
        {
            numerator = value;
            denominator = BigInteger.One;
        }

        public ImperiodicNumber(uint value)
        {
            numerator = value;
            denominator = BigInteger.One;
        }

        public ImperiodicNumber(float value) : this(value.ToString("N99"))
        {

        }

        public ImperiodicNumber(double value) : this(value.ToString("N99"))
        {

        }

        public ImperiodicNumber(decimal value) : this(value.ToString("N99"))
        {

        }

        public static bool TryParse(string value, out ImperiodicNumber parsed)
        {
            parsed = 0;
            if (value == null)
                return false;

            value.Trim();
            value = value.Replace(",", "");
            int pos = value.IndexOf('.');
            value = value.Replace(".", "");

            if (pos < 0)
            {
                if (BigInteger.TryParse(value, out var numerator))
                {
                    parsed = new ImperiodicNumber(numerator).Factored();
                    return true;
                }
            }
            else
            {
                if (BigInteger.TryParse(value, out var numerator))
                {
                    var denominator = BigInteger.Pow(10, value.Length - pos);
                    parsed = new ImperiodicNumber(numerator, denominator).Factored();
                    return true;
                }
            }

            return false;
        }

        public ImperiodicNumber Factored()
        {
            if (denominator == 1)
                return this;

            var factor = BigInteger.GreatestCommonDivisor(numerator, denominator);

            return new ImperiodicNumber(numerator / factor, denominator / factor);
        }

        public void Factor()
        {
            var factored = Factored();
            this.numerator = factored.numerator;
            this.denominator = factored.denominator;
        }

        public void AssertValid()
        {
            while (denominator % 2 == 0)
                denominator /= 2;
            while (denominator % 5 == 0)
                denominator /= 5;

            if (denominator != 1)
                throw new ArgumentException("given value is not imperiodic number");
        }

        public bool TryAsInteger(out BigInteger integer)
        {
            integer = 0;
            Factor();

            if (denominator == 1)
            {
                integer = numerator;
                return true;
            }

            return false;
        }

        public void AsDecimal(out BigInteger fraction, out BigInteger @decimal)
        {
            var _denominator = denominator;
            int factorsOf2 = 0, factorsOf5 = 0;

            while (_denominator % 2 == 0)
            {
                _denominator /= 2;
                factorsOf2 += 1;
            }
            while (_denominator % 2 == 0)
            {
                _denominator /= 5;
                factorsOf5 += 1;
            }

            if (_denominator != 1)
                throw new Exception("number is not imperiodic number but you tried convert to decimal. HOW??");

            var _numerator = numerator;
            var factorsOf10 = 0;

            while (factorsOf2 > factorsOf5)
            {
                _numerator *= 5;
                factorsOf5++;
            }
            while (factorsOf2 < factorsOf5)
            {
                _numerator *= 2;
                factorsOf2++;
            }
            factorsOf10 = factorsOf2;

            var denominator10 = BigInteger.Pow(10, factorsOf10);

            fraction = _numerator / denominator10;
            @decimal = _numerator % denominator10;
        }

        public static implicit operator ImperiodicNumber(sbyte value)
            => new ImperiodicNumber(value);
        public static implicit operator ImperiodicNumber(short value)
            => new ImperiodicNumber(value);
        public static implicit operator ImperiodicNumber(int value)
            => new ImperiodicNumber(value);
        public static implicit operator ImperiodicNumber(long value)
            => new ImperiodicNumber(value);
        public static implicit operator ImperiodicNumber(byte value)
            => new ImperiodicNumber(value);
        public static implicit operator ImperiodicNumber(ushort value)
            => new ImperiodicNumber(value);
        public static implicit operator ImperiodicNumber(uint value)
            => new ImperiodicNumber(value);
        public static implicit operator ImperiodicNumber(ulong value)
            => new ImperiodicNumber(value);
        public static implicit operator ImperiodicNumber(decimal value)
            => new ImperiodicNumber(value);
        public static implicit operator ImperiodicNumber(double value)
            => new ImperiodicNumber(value);
    }
}
