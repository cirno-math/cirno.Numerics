using System;
using System.Numerics;
using cirno.Numerics.Inners;

namespace cirno.Numerics
{
    public class Number : IComparable, IComparable<Number>, IEquatable<Number>
    {
        INumberValue inner;
        public Number()
        {
            inner = new IntegerNumber(0);
        }

        public Number(BigInteger numerator, BigInteger denominator)
        {
            throw new NotImplementedException();
        }

        public Number Add(Number other)
        {
            throw new NotImplementedException();
        }

        public Number Subtract(Number other)
        {
            throw new NotImplementedException();
        }

        public Number Multiply(Number other)
        {
            throw new NotImplementedException();
        }

        public Number Divide(Number other)
        {
            throw new NotImplementedException();
        }

        public Number Remainder(Number other)
        {
            throw new NotImplementedException();
        }

        public Number DivideRemainder(Number other, out Number remainder)
        {
            throw new NotImplementedException();
        }

        public Number Pow(Number exponent)
        {
            throw new NotImplementedException();
        }

        public Number Sqrt()
        {
            throw new NotImplementedException();
        }

        public Number Log10()
        {
            throw new NotImplementedException();
        }

        public Number Log(double baseValue)
        {
            throw new NotImplementedException();
        }

        public Number Abs()
        {
            throw new NotImplementedException();
        }

        public Number Negate()
        {
            throw new NotImplementedException();
        }

        public Number Inverse()
        {
            throw new NotImplementedException();
        }

        public Number Increment()
        {
            throw new NotImplementedException();
        }

        public Number Decrement()
        {
            throw new NotImplementedException();
        }

        public Number Ceil()
        {
            throw new NotImplementedException();
        }

        public Number Floor()
        {
            throw new NotImplementedException();
        }

        public Number Round()
        {
            throw new NotImplementedException();
        }

        public Number Truncate()
        {
            throw new NotImplementedException();
        }

        public Number Decimals()
        {
            throw new NotImplementedException();
        }

        public Number ShiftDecimalLeft(int shift)
        {
            throw new NotImplementedException();
        }

        public Number ShiftDecimalRight(int shift)
        {
            throw new NotImplementedException();
        }

        public static Number Parse(string value)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Number other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Number other)
        {
            throw new NotImplementedException();
        }

        public static Number operator +(Number left, Number right)
        {
            throw new NotImplementedException();
        }

        public static Number operator -(Number left, Number right)
        {
            throw new NotImplementedException();
        }

        public static Number operator *(Number left, Number right)
        {
            throw new NotImplementedException();
        }

        public static Number operator /(Number left, Number right)
        {
            throw new NotImplementedException();
        }

        public static Number operator >>(Number value, int shift)
        {
            throw new NotImplementedException();
        }

        public static Number operator <<(Number value, int shift)
        {
            throw new NotImplementedException();
        }

        public static Number operator ^(Number left, Number right)
        {
            throw new NotImplementedException();
        }

        public static Number operator ~(Number value)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Number left, Number right)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(Number left, Number right)
        {
            throw new NotImplementedException();
        }

        public static bool operator <(Number left, Number right)
        {
            throw new NotImplementedException();
        }

        public static bool operator <=(Number left, Number right)
        {
            throw new NotImplementedException();
        }

        public static bool operator >(Number left, Number right)
        {
            throw new NotImplementedException();
        }

        public static bool operator >=(Number left, Number right)
        {
            throw new NotImplementedException();
        }

        public static explicit operator decimal(Number value)
        {
            throw new NotImplementedException();
        }

        public static explicit operator double(Number value)
        {
            throw new NotImplementedException();
        }

        public static explicit operator float(Number value)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Number(byte value)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Number(sbyte value)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Number(short value)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Number(ushort value)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Number(int value)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Number(long value)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Number(uint value)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Number(ulong value)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Number(float value)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Number(double value)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Number(decimal value)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Number(BigInteger value)
        {
            throw new NotImplementedException();
        }
    }
}
