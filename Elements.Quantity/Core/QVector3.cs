using System;
using System.Collections.Generic;

using System.Text;

namespace Elements.Quantity
{
    public readonly struct QVector3<T> where T : unmanaged, IQuantity<T>
    {
        public readonly T x, y, z;

        public QVector3(double x, double y, double z)
        {
            var t = default(T);

            this.x = t.New(x);
            this.y = t.New(y);
            this.z = t.New(z);
        }

        public QVector3(T x, T y, T z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public T SqrMagnitude
        {
            get
            {
                return default(T).New(x.BaseValue * x.BaseValue +
                    y.BaseValue * y.BaseValue +
                    z.BaseValue * z.BaseValue);
            }
        }

        public T Magnitude
        {
            get
            {
                return default(T).New(Math.Sqrt(SqrMagnitude.BaseValue));
            }
        }

        public QVector3<T> Normalized
        {
            get
            {
                return this / Magnitude.BaseValue;
            }
        }

        // indexed access - for use in loops and such
        public T this[int axis]
        {
            get
            {
                switch(axis)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    default:
                        throw new Exception("Wrong QVector3 axis index. Must be between 0 and 2");
                }
            }
        }

        public string FormatAs(Unit<T> unit, string formatNum = null, bool longName = false)
        {
            return "["
                + x.FormatAs(unit, formatNum, longName) + "; "
                + y.FormatAs(unit, formatNum, longName) + "; "
                + z.FormatAs(unit, formatNum, longName) + "]";
        }

        public string FormatAuto(string formatNum = null, bool longName = false,
            List<UnitGroup> unitGroups = null)
        {
            return "["
                + x.FormatAuto(formatNum, longName, unitGroups) + "; "
                + y.FormatAuto(formatNum, longName, unitGroups) + "; "
                + z.FormatAuto(formatNum, longName, unitGroups) + "]";
        }

        public static QVector3<T> Zero { get { return new QVector3<T>(0, 0, 0); } }
        public static QVector3<T> One { get  { return new QVector3<T>(1, 1, 1); } }

        public static QVector3<T> operator+(QVector3<T> a, QVector3<T> b)
        {
            return new QVector3<T>(a.x.Add(b.x), a.y.Add(b.y), a.z.Add(b.z));
        }

        public static QVector3<T> operator -(QVector3<T> a, QVector3<T> b)
        {
            return new QVector3<T>(a.x.Subtract(b.x), a.y.Subtract(b.y), a.z.Subtract(b.z));
        }

        public static QVector3<T> operator*(QVector3<T> v, double n)
        {
            return new QVector3<T>(v.x.Multiply(n), v.y.Multiply(n), v.z.Multiply(n));
        }

        public static QVector3<T> operator /(QVector3<T> v, double n)
        {
            return new QVector3<T>(v.x.Divide(n), v.y.Divide(n), v.z.Divide(n));
        }
    }
}
