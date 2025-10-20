using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;


namespace Elements.Quantity.Test.Quantities.Basic;

using TimeTestData = (Unit<Time> unit, string shortName, string longNameSingle, string longNamePlural);

[TestClass]
public class TimeTests
{
    internal static TimeTestData[] TimeTestDataTuples
    {
        get => new TimeTestData[]
        {
            new (Time.Millisecond, "{0} ms", "1 millisecond", "{0} milliseconds"),
            new (Time.Second, "{0} s", "1 second", "{0} seconds"),
            new (Time.Minute, "{0} m", "1 minute", "{0} minutes"),
            new (Time.Hour, "{0} h", "1 hour", "{0} hours"),
            new (Time.Day, "{0} d", "1 day", "{0} days")
        };
    }

    internal static IEnumerable<object[]> TimeShortNameArgs
    {
        get => DataProvider.UnitQuantityShortNameNumberValues.SelectMany(numValue =>
            TimeTestDataTuples.Select(timeUnitArgs => new object[] {
                timeUnitArgs.unit, numValue, string.Format(timeUnitArgs.shortName, numValue)
            }).ToArray()
        );
    }

    internal static IEnumerable<object[]> TimeLongNameSingularFormArgs
    {
        get => TimeTestDataTuples.Select(timeUnitArgs => new object[] {
            timeUnitArgs.unit, timeUnitArgs.longNameSingle
        });
    }

    internal static IEnumerable<object[]> TimeLongNamePluralFormArgs
    {
        get => DataProvider.UnitQuantityPluralNumberValues.SelectMany(numValue =>
            TimeTestDataTuples.Select(timeUnitArgs => new object[] {
                timeUnitArgs.unit, numValue, string.Format(timeUnitArgs.longNamePlural, numValue)
            }).ToArray()
        );
    }

    internal static IEnumerable<object[]> TimePredefinedCompoundFormatInfoArgs
    {
        get => new object[][]
        {
            [Time.MinuteSecond, 0d, "00:00"],
            [Time.MinuteSecond, 30d, "00:30"],
            [Time.MinuteSecond, 150d, "02:30"],
            [Time.MinuteSecond, 150.4d, "02:30"],
            [Time.HourMinuteSecond, 150d, "0:02:30"],
            [Time.HourMinuteSecond, 3750d, "1:02:30"],
            [Time.HourMinuteSecond, 3750.4d, "1:02:30"],
            [Time.HourMinuteSecond, 360150d, "100:02:30"],
            [Time.HourMinuteSecond_Trimmed, 0d, "00:00"],
            [Time.HourMinuteSecond_Trimmed, 150d, "02:30"],
            [Time.HourMinuteSecond_Trimmed, 3750d, "1:02:30"],
            [Time.DayHourMinuteSecond_Long, 0d, "0 seconds"],
            [Time.DayHourMinuteSecond_Long, 1d, "1 second"],
            [Time.DayHourMinuteSecond_Long, 10d, "10 seconds"],
            [Time.DayHourMinuteSecond_Long, 60d, "1 minute 0 seconds"],
            [Time.DayHourMinuteSecond_Long, 61.2d, "1 minute 1 second"],
            [Time.DayHourMinuteSecond_Long, 122.2d, "2 minutes 2 seconds"],
            [Time.DayHourMinuteSecond_Long, 3661.2d, "1 hour 1 minute 1 second"],
            [Time.DayHourMinuteSecond_Long, 7322.2d, "2 hours 2 minutes 2 seconds"],
            [Time.DayHourMinuteSecond_Long, 90061.4d, "1 day 1 hour 1 minute 1 second"],
            [Time.DayHourMinuteSecond_Long, 180122.4d, "2 days 2 hours 2 minutes 2 seconds"],
            [Time.DayHourMinute_Long, 1d, "0 minutes"],
            [Time.DayHourMinute_Long, 10d, "0 minutes"],
            [Time.DayHourMinute_Long, 60d, "1 minute"],
            [Time.DayHourMinute_Long, 61.2d, "1 minute"],
            [Time.DayHourMinute_Long, 122.2d, "2 minutes"],
            [Time.DayHourMinute_Long, 3661.2d, "1 hour 1 minute"],
            [Time.DayHourMinute_Long, 7322.2d, "2 hours 2 minutes"],
            [Time.DayHourMinute_Long, 90061.4d, "1 day 1 hour 1 minute"],
            [Time.DayHourMinute_Long, 180122.4d, "2 days 2 hours 2 minutes"],
            [Time.DayHourMinuteSecond_Trimmed, 0d, "00:00"],
            [Time.DayHourMinuteSecond_Trimmed, 150d, "02:30"],
            [Time.DayHourMinuteSecond_Trimmed, 3750d, "1:02:30"],
            [Time.DayHourMinuteSecond_Trimmed, 90150.4d, "1day:1:02:30"],
            [Time.DayHourMinuteSecond_Trimmed, 176550.6d, "2day:1:02:30"],
            [Time.HourMinuteSecond_Symbol, 0d, "00 s"],
            [Time.HourMinuteSecond_Symbol, 1d, "01 s"],
            [Time.HourMinuteSecond_Symbol, 120d, "2 m 00 s"],
            [Time.HourMinuteSecond_Symbol, 150d, "2 m 30 s"],
            [Time.HourMinuteSecond_Symbol, 3720d, "1 h 2 m 00 s"],
            [Time.HourMinuteSecond_Symbol, 3750d, "1 h 2 m 30 s"],
            [Time.StopWatch, 0d, "00:00:00"],
            [Time.StopWatch, 0.5d, "00:00:500"],
            [Time.StopWatch, 0.55d, "00:00:550"],
            [Time.StopWatch, 0.555d, "00:00:555"],
            [Time.StopWatch, 1d, "00:01:00"],
            [Time.StopWatch, 1.5d, "00:01:500"],
            [Time.StopWatch, 60d, "01:00:00"],
            [Time.StopWatch, 60.5002d, "01:00:500"],
            [Time.StopWatch, 3600d, "1:00:00:00"],
            [Time.StopWatch, 3600.5002d, "1:00:00:500"]
        };
    }

    [TestMethod]
    [DynamicData(nameof(TimeShortNameArgs))]
    public void TimeUnit_QuantityProvidedFormatAsShortName_FormatsWithDefaultShortName(Unit<Time> timeUnit, double timeValue, string expectedStr)
    {
        var time = new Time(timeValue * timeUnit.Ratio);
        var resultStr = time.FormatAs(timeUnit, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(TimeLongNameSingularFormArgs))]
    public void TimeUnit_QuantitySingleValueFormatAsLongName_FormatsWithDefaultLongNameSingularForm(Unit<Time> timeUnit, string expectedStr)
    {
        var time = new Time(timeUnit.Ratio);
        var resultStr = time.FormatAs(timeUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(TimeLongNamePluralFormArgs))]
    public void TimeUnit_QuantityPluralValueFormatAsLongName_FormatsWithDefaultLongNamePluralForm(Unit<Time> timeUnit, double timeValue, string expectedStr)
    {
        var time = new Time(timeValue * timeUnit.Ratio);
        var resultStr = time.FormatAs(timeUnit, longName: true, formatNum: "0.#");

        Assert.AreEqual(expectedStr, resultStr);
    }

    [TestMethod]
    [DynamicData(nameof(TimePredefinedCompoundFormatInfoArgs))]
    public void TimeUnit_PredefinedQuantityCompoundFormatInfo_FormatsQuantityAsString(CompoundFormatInfo<Time> timeCompoundFormatInfo, double timeValue, string expectedStr)
    {
        var time = new Time(timeValue);
        var resultStr = time.FormatCompound(timeCompoundFormatInfo);

        Assert.AreEqual(expectedStr, resultStr);
    }
}
