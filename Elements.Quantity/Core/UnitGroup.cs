using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elements.Quantity
{
    public class UnitGroup : IEnumerable<IUnit>, ICollection
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

        private object _lock = new object();

        #endregion

        Dictionary<Type, SortedSet<IUnit>> units = new Dictionary<Type, SortedSet<IUnit>>();

        /// <inheritdoc/>
        public int Count => units.Sum(u => u.Value.Count);

        /// <inheritdoc/>
        public bool IsSynchronized => false;

        /// <inheritdoc/>
        public object SyncRoot => _lock;

        /// <inheritdoc/>
        public void CopyTo(Array array, int index)
        {
            ArgumentNullException.ThrowIfNull(array);
            ArgumentOutOfRangeException.ThrowIfLessThan(index, 0);

            // Official .Net documentation states that the given array to copy to must
            // always be single-dimensional. Although unit groups can be 2D arrays, this
            // .Net standard implementation pattern must be followed.
            if (array.Rank != 1)
            {
                throw new ArgumentException("Only single-dimensional arrays are supported.");
            }

            if (array.Length - index < Count)
            {
                throw new ArgumentException("There is not enough space to copy to the destination array.");
            }

            var currentIndex = 0;
            foreach (var unit in this)
            {
                array.SetValue(unit, index + currentIndex);
                currentIndex++;
            }
        }

        public void RegisterUnit(IUnit unit) => GetSetForType(unit.ValueType)!.Add(unit);

        /// <summary>
        /// Removes the given unit from the group and, if applicable, removes the quntity type
        /// from the dictionary if the resulting set is empty after removal.
        /// </summary>
        /// <param name="unit">The unit to remove.</param>
        public void RemoveUnit(IUnit unit)
        {
            var set = GetSetForType(unit.ValueType)!;
            set.Remove(unit);

            if (set.Any())
            {
                return;
            }

            units.Remove(unit.ValueType);
        }

        /// <summary>
        /// Checks if the given unit is part of the group.
        /// </summary>
        /// <param name="unit">The unit to check.</param>
        /// <returns><c>true</c> if the unit is part of the group; otherwise, <c>false</c></returns>.
        public bool HasUnit(IUnit unit)
        {
            var set = GetSetForType(unit.ValueType, false);
            return set != null && set.Contains(unit);
        }

        public bool HasQuantity(Type quantityType) => units.ContainsKey(quantityType);

        internal SortedSet<IUnit>? GetSetForType(Type type, bool createIfNotExists = true)
        {
            // If not creating, return set variable since it will be null if not in dictionary.
            if (units.TryGetValue(type, out SortedSet<IUnit>? set) || !createIfNotExists)
            {
                return set;
            }

            set = [];
            units.Add(type, set);
            return set;
        }

        #region ENUMERATOR

        public struct Enumerator : IEnumerator<IUnit>
        {
            Dictionary<Type, SortedSet<IUnit>>.Enumerator dictEnum;
            SortedSet<IUnit>.Enumerator setEnum;

            public Enumerator(UnitGroup group)
            {
                dictEnum = group.units.GetEnumerator();
                setEnum = default;
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
                if (setEnum.Current != null && setEnum.MoveNext())
                {
                    return true;
                }
                if (!dictEnum.MoveNext())
                {
                    return false;
                }

                setEnum.Dispose();
                setEnum = dictEnum.Current.Value.GetEnumerator();
                return setEnum.MoveNext();
            }

            public void Reset() => throw new NotSupportedException();
        }

        public Enumerator GetEnumerator() => new Enumerator(this);

        IEnumerator<IUnit> IEnumerable<IUnit>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
    }
}
