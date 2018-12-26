using System;
using System.Numerics;

namespace cirno.Numerics
{
    /// <summary>
    /// ImperiodicNumber is Rational Number without Recurring Decimal.
    /// It MUST assert given number is imperiodic by check factors of denominator is only 2 and 5.
    /// If not, it throws exception in constructor.
    /// </summary>
    public struct ImperiodicNumber : IComparable, IComparable<ImperiodicNumber>, IEquatable<ImperiodicNumber>
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
                    parsed = new ImperiodicNumber(numerator);
                    return true;
                }
            }
            else
            {
                if (BigInteger.TryParse(value, out var numerator))
                {
                    var denominator = BigInteger.Pow(10, value.Length - pos);
                    parsed = new ImperiodicNumber(numerator, denominator);
                    return true;
                }
            }

            return false;
        }

        private void Factor()
        {
            var factor = BigInteger.GreatestCommonDivisor(numerator, denominator);
            this.numerator = numerator / factor;
            this.denominator = denominator / factor;
        }

        private static bool IsValidDenominator(BigInteger denominator)
        {
            while (denominator % 2 == 0)
                denominator /= 2;
            while (denominator % 5 == 0)
                denominator /= 5;

            return denominator == 1;
        }

        public void AssertValid()
        {
            if (!IsValidDenominator(denominator))
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

            // `this` MUST be asserted but if...
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

        public static ImperiodicNumber Add(ImperiodicNumber a, ImperiodicNumber b)
        {
            var numerator = a.numerator * b.denominator + b.numerator * a.denominator;
            var denominator = a.denominator * b.denominator;
            return new ImperiodicNumber(numerator, denominator);
        }

        public static ImperiodicNumber Subtract(ImperiodicNumber a, ImperiodicNumber b)
        {
            var numerator = a.numerator * b.denominator - b.numerator * a.denominator;
            var denominator = a.denominator * b.denominator;
            return new ImperiodicNumber(numerator, denominator);
        }

        public static ImperiodicNumber Multiply(ImperiodicNumber a, ImperiodicNumber b)
        {
            var numerator = a.numerator * b.numerator;
            var denominator = a.denominator * b.denominator;
            return new ImperiodicNumber(numerator, denominator);
        }

        public static bool TryDivide(ImperiodicNumber a, ImperiodicNumber b, out ImperiodicNumber result)
        {
            if (b == 0)
                return false;

            var numerator = a.numerator * b.denominator;
            var denominator = b.numerator * a.denominator;

            try
            {
                result = new ImperiodicNumber(numerator, denominator);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static ImperiodicNumber Pow(ImperiodicNumber a, int exponent)
        {
            if (a.numerator.IsZero)
            {
                return a;
            }
            else if (exponent < 0)
            {
                var numerator = BigInteger.Pow(a.denominator, -exponent);
                var denominator = BigInteger.Pow(a.numerator, -exponent);
                return new ImperiodicNumber(numerator, denominator);
            }
            else
            {
                var numerator = BigInteger.Pow(a.numerator, exponent);
                var denominator = BigInteger.Pow(a.denominator, exponent);
                return new ImperiodicNumber(numerator, denominator);
            }
        }

        public static int Compare(ImperiodicNumber a, ImperiodicNumber b)
        {
            return a.CompareTo(b);
        }

        public int CompareTo(object o)
        {
            // TODO: If o is not ImperiodicNumber, it should check convertable
            // But.. 굳이..?
            if (o == null || !(o is ImperiodicNumber))
                throw new ArgumentException("Given parameter is not ImperiodicNumber");

            return CompareTo((ImperiodicNumber)o);
        }

        public int CompareTo(ImperiodicNumber value)
        {
            var left = numerator * value.denominator;
            var right = value.numerator * denominator;

            return left.CompareTo(right);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ImperiodicNumber))
                return false;
            return Equals((ImperiodicNumber)obj);
        }

        public bool Equals(ImperiodicNumber value)
        {
            return CompareTo(value) == 0;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
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

        public static bool operator ==(ImperiodicNumber left, ImperiodicNumber right)
            => Compare(left, right) == 0;
        public static bool operator !=(ImperiodicNumber left, ImperiodicNumber right)
            => !(left == right);
        public static bool operator <(ImperiodicNumber left, ImperiodicNumber right)
            => Compare(left, right) < 0;
        public static bool operator <=(ImperiodicNumber left, ImperiodicNumber right)
            => Compare(left, right) <= 0;
        public static bool operator >(ImperiodicNumber left, ImperiodicNumber right)
            => Compare(left, right) > 0;
        public static bool operator >=(ImperiodicNumber left, ImperiodicNumber right)
            => Compare(left, right) >= 0;
        public static bool operator true(ImperiodicNumber value)
            => value != 0;
        public static bool operator false(ImperiodicNumber value)
            => value == 0;
    }
}
