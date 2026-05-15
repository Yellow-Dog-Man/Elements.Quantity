using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Elements.Quantity
{
    public class UnitGroup : IEnumerable<IUnit>
    {
        #region UNIT_GROUPS

        static UnitGroup()
        {
            DefaultUnitGroups.Add(Common);
        }

        public static List<UnitGroup> DefaultUnitGroups = new List<UnitGroup>();

        public static readonly UnitGroup Common = new UnitGroup();
        public static readonly UnitGroup Metric = new UnitGroup();
        public static readonly UnitGroup MetricThousands = new UnitGroup();
        public static readonly UnitGroup CommonMetric = new UnitGroup();

        public static readonly UnitGroup Scientific = new UnitGroup();

        public static readonly UnitGroup Astronomical = new UnitGroup();
        public static readonly UnitGroup Molecular = new UnitGroup();
        public static readonly UnitGroup Meteorological = new UnitGroup();
        public static readonly UnitGroup Aviation = new UnitGroup();
        public static readonly UnitGroup Maritime = new UnitGroup();

        public static readonly UnitGroup Imperial = new UnitGroup();

        #endregion

        Dictionary<Type, SortedSet<IUnit>> units = new Dictionary<Type, SortedSet<IUnit>>();

        public void RegisterUnit(IUnit unit) => GetSetForType(unit.ValueType)!.Add(unit);
        public void RemoveUnit(IUnit unit) => GetSetForType(unit.ValueType)!.Remove(unit);
        public bool HasUnit(IUnit unit) => GetSetForType(unit.ValueType)!.Contains(unit);

        internal SortedSet<IUnit>? GetSetForType(Type type, bool createIfNotExists = true)
        {
            if (units.TryGetValue(type, out SortedSet<IUnit>? set))
                return set;

            if (createIfNotExists)
            {
                set = new SortedSet<IUnit>();
                units.Add(type, set);
                return set;
            }

            return null;
        }

        #region ENUMERATOR

        public struct Enumerator : IEnumerator<IUnit>
        {
            bool firstDone;
            Dictionary<Type, SortedSet<IUnit>>.Enumerator dictEnum;
            SortedSet<IUnit>.Enumerator setEnum;

            public Enumerator(UnitGroup group)
            {
                dictEnum = group.units.GetEnumerator();
                setEnum = default;
                firstDone = false;
            }

            public IUnit Current => setEnum.Current;
            object IEnumerator.Current => Current;

            public void Dispose()
            {
                dictEnum.Dispose();
                setEnum.Dispose();
            }

            public bool MoveNext()
            {
                if (!firstDone || !setEnum.MoveNext())
                {
                    if (dictEnum.MoveNext())
                    {
                        setEnum = dictEnum.Current.Value.GetEnumerator();
                        return setEnum.MoveNext();
                    }
                    else
                        return false;
                }
                else
                    return true;
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }
        }

        public Enumerator GetEnumerator() => new Enumerator(this);

        IEnumerator<IUnit> IEnumerable<IUnit>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
    }
}
