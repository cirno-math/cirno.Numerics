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
            inner = new ImperiodicValue(0);
        }

        public Number(BigInteger numerator, BigInteger denominator)
        {
            inner = new ImperiodicValue(new ImperiodicNumber(numerator, denominator));
        }

        private Number(INumberValue inner)
            => this.inner = inner;

        public string ToExactExpressionString()
        {
            throw new NotImplementedException();
        }

        public static Number Add(Number left, Number right)
        {
            return new Number(new AddValue(left.inner, right.inner));
        }

        public static Number Subtract(Number left, Number right)
        {
            throw new NotImplementedException();
        }

        public static Number Multiply(Number left, Number right)
        {
            throw new NotImplementedException();
        }

        public static Number Divide(Number left, Number right)
        {
            throw new NotImplementedException();
        }

        public static Number Remainder(Number left, Number right)
        {
            throw new NotImplementedException();
        }

        public static Number DivideRemainder(Number left, Number right, out Number remainder)
        {
            throw new NotImplementedException();
        }

        public static Number Pow(Number left, Number right)
        {
            throw new NotImplementedException();
        }

        public static Number Sqrt(Number value)
        {
            throw new NotImplementedException();
        }

        public static Number Parse(string value)
        {
            throw new NotImplementedException();
        }

        public Number Pow(Number other)
        {
            throw new NotImplementedException();
        }

        public Number Sqrt()
        {
            throw new NotImplementedException();
        }

        public Number Sqrt3()
        {
            // 이거는 어떻게 될 지 ㅗㅁ르겟다 구현은 다음의 내가 하겠지^^
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
