using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Elements.Quantity.Core.Internal
{
    internal static class StringExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToPascalCase(this string str) =>
            !string.IsNullOrEmpty(str) && !char.IsUpper(str[0])
                ? $"{char.ToUpper(str[0])}{str.Substring(1)}"
                : str;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Join(this IEnumerable<string> strings, string separator = "") => string.Join(separator, strings);
    }
}
