using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements.Quantity.Core.Internal
{
    internal static class ArrayExtension
    {
        public static string[] TrimStrings(this string[] strings)
        {
            for (var i = 0; i < strings.Length; i++)
            {
                strings[i] = strings[i].Trim();
            }

            return strings;
        }
    }
}
