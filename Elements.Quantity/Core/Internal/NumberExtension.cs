using System;
using System.Runtime.CompilerServices;

namespace Elements.Quantity.Core.Internal
{
    internal static class NumberExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSingular(this double number) => Math.Abs(number - 1) < 1e-8;
    }
}
