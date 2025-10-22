using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements.Quantity.Test;

using FormatArgData = (string formatNum, string expectedValue);

public static class SharedArgsProvider
{
    internal static string CurrentCurrencySymbol => NumberFormatInfo.CurrentInfo.CurrencySymbol;

    internal static string CurrentNumberDecimalSeparator => NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;

    internal static IEnumerable<FormatArgData> ValidFormatArgs =>
        DataProvider.ValidStringFormatsWithEscapedInvalidFormats.Select(format => (format, $"{1.0d.ToString(format)} u"));

    internal static IEnumerable<FormatArgData> InvalidFormatArgs =>
        DataProvider.InvalidStringFormats.Select(format => (format, $"{format} u"));
}
