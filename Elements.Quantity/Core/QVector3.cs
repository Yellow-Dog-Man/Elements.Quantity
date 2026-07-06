using System;
using System.Collections.Generic;
using System.Numerics;

namespace Elements.Quantity
{
    public readonly struct QVector3<T> :
        IAdditionOperators<QVector3<T>, QVector3<T>, QVector3<T>>,
        IAdditiveIdentity<QVector3<T>, QVector3<T>>,
        ISubtractionOperators<QVector3<T>, QVector3<T>, QVector3<T>>,
        IMultiplyOperators<QVector3<T>, double, QVector3<T>>,
        IMultiplyOperators<QVector3<T>, Ratio, QVector3<T>>,
        IMultiplyOperators<QVector3<T>, QVector3<Ratio>, QVector3<T>>,
        IDivisionOperators<QVector3<T>, double, QVector3<T>>,
        IDivisionOperators<QVector3<T>, Ratio, QVector3<T>>,
        IDivisionOperators<QVector3<T>, QVector3<T>, QVector3<Ratio>>,
        IMultiplicativeIdentity<QVector3<T>, QVector3<Ratio>>,
        IMultiplicativeIdentity<QVector3<T>, Ratio>
    where T : unmanaged, IQuantity<T>
    {
        public readonly T x, y, z;

        public QVector3(double x, double y, double z)
        {
            this.x = T.Create(x);
            this.y = T.Create(y);
            this.z = T.Create(z);
        }

        public QVector3(T x, T y, T z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public T SqrMagnitude => T.Create(
            x.BaseValue * x.BaseValue +
            y.BaseValue * y.BaseValue +
            z.BaseValue * z.BaseValue);

        public T Magnitude => T.Create(Math.Sqrt(SqrMagnitude.BaseValue));

        public QVector3<T> Normalized => this / Magnitude.BaseValue;

        // indexed access - for use in loops and such
        public T this[int axis]
        {
            get
            {
                switch (axis)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    default:
                        throw new Exception("Wrong QVector3 axis index. Must be between 0 and 2");
                }
            }
        }

        public string FormatAs(Unit<T> unit, string? formatNum = null, bool longName = false)
        {
            return "["
                + x.FormatAs(unit, formatNum, longName) + "; "
                + y.FormatAs(unit, formatNum, longName) + "; "
                + z.FormatAs(unit, formatNum, longName) + "]";
        }

        public string FormatAuto(string? formatNum = null, bool longName = false,
            List<UnitGroup>? unitGroups = null)
        {
            return "["
                + x.FormatAuto(formatNum, longName, unitGroups) + "; "
                + y.FormatAuto(formatNum, longName, unitGroups) + "; "
                + z.FormatAuto(formatNum, longName, unitGroups) + "]";
        }

        public static QVector3<T> Zero => new(0, 0, 0);
        public static QVector3<T> One => new(1, 1, 1);

        public static QVector3<T> AdditiveIdentity
        {
            get
            {
                var ident = T.AdditiveIdentity;
                return new(ident, ident, ident);
            }
        }

        static QVector3<Ratio> IMultiplicativeIdentity<QVector3<T>, QVector3<Ratio>>.MultiplicativeIdentity
        {
            get
            {
                var ident = T.MultiplicativeIdentity;
                return new(ident, ident, ident);
            }
        }

        static Ratio IMultiplicativeIdentity<QVector3<T>, Ratio>.MultiplicativeIdentity => T.MultiplicativeIdentity;

        // Component-wise operations
        public static QVector3<T> operator +(QVector3<T> a, QVector3<T> b) => new(a.x + b.x, a.y + b.y, a.z + b.z);
        public static QVector3<T> operator -(QVector3<T> a, QVector3<T> b) => new(a.x - b.x, a.y - b.y, a.z - b.z);
        public static QVector3<T> operator *(QVector3<T> a, QVector3<Ratio> b) => new(a.x * b.x, a.y * b.y, a.z * b.z);
        public static QVector3<Ratio> operator /(QVector3<T> a, QVector3<T> b) => new(a.x / b.x, a.y / b.y, a.z / b.z);

        // Scalar operations
        public static QVector3<T> operator *(QVector3<T> v, double n) => new(v.x * n, v.y * n, v.z * n);
        public static QVector3<T> operator /(QVector3<T> v, double n) => new(v.x / n, v.y / n, v.z / n);
        public static QVector3<T> operator *(QVector3<T> v, Ratio r) => v * r.BaseValue;
        public static QVector3<T> operator /(QVector3<T> v, Ratio r) => v / r.BaseValue;
    }
}
