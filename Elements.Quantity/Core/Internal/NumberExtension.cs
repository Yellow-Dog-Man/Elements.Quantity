using System;
using System.Runtime.CompilerServices;

namespace Elements.Quantity.Core.Internal
{
    internal static class NumberExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSingular(this double number) => Math.Abs(number - 1) < 1e-8;

        public static string Format(this double number, string? format)
        {
            try
            {
                return number.ToString(format);
            }
            catch (FormatException)
            {
                // The format can never be null since this exception is thrown with
                // a provided format value.
                return format!;
            }
        }
    }
}
