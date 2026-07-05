using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace Elements.Quantity.Test.Quantities.Basic;

[TestClass]
[ExcludeFromCodeCoverage]
public class TimeTests : BaseQuantityTests<TimeTests, Time>, IQuantityTestData<Time>
{
    /// <inheritdoc/>
    public static QuantityTestData<Time>[] TestDataTuples =>
    [
        new(Time.Millisecond, "{0} ms", "1 millisecond", "{0} milliseconds", "Quantity.Unit.Time.Milliseconds"),
        new(Time.Second, "{0} s", "1 second", "{0} seconds", "Quantity.Unit.Time.Seconds"),
        new(Time.Minute, "{0} m", "1 minute", "{0} minutes", "Quantity.Unit.Time.Minutes"),
        new(Time.Hour, "{0} h", "1 hour", "{0} hours", "Quantity.Unit.Time.Hours"),
        new(Time.Day, "{0} d", "1 day", "{0} days", "Quantity.Unit.Time.Days")
    ];

    /// <inheritdoc/>
    public static IEnumerable<QuantityFormatTestData<Time>>? CompoundFormatInfoDataTuples => [
        new(Time.MinuteSecond, 0d, "00:00"),
        new(Time.MinuteSecond, 30d, "00:30"),
        new(Time.MinuteSecond, 150d, "02:30"),
        new(Time.MinuteSecond, 150.4d, "02:30"),
        new(Time.HourMinuteSecond, 150d, "0:02:30"),
        new(Time.HourMinuteSecond, 3750d, "1:02:30"),
        new(Time.HourMinuteSecond, 3750.4d, "1:02:30"),
        new(Time.HourMinuteSecond, 360150d, "100:02:30"),
        new(Time.HourMinuteSecond_Trimmed, 0d, "00:00"),
        new(Time.HourMinuteSecond_Trimmed, 150d, "02:30"),
        new(Time.HourMinuteSecond_Trimmed, 3750d, "1:02:30"),
        new(Time.DayHourMinuteSecond_Long, 0d, "0 seconds"),
        new(Time.DayHourMinuteSecond_Long, 1d, "1 second"),
        new(Time.DayHourMinuteSecond_Long, 10d, "10 seconds"),
        new(Time.DayHourMinuteSecond_Long, 60d, "1 minute 0 seconds"),
        new(Time.DayHourMinuteSecond_Long, 61.2d, "1 minute 1 second"),
        new(Time.DayHourMinuteSecond_Long, 122.2d, "2 minutes 2 seconds"),
        new(Time.DayHourMinuteSecond_Long, 3661.2d, "1 hour 1 minute 1 second"),
        new(Time.DayHourMinuteSecond_Long, 7322.2d, "2 hours 2 minutes 2 seconds"),
        new(Time.DayHourMinuteSecond_Long, 90061.4d, "1 day 1 hour 1 minute 1 second"),
        new(Time.DayHourMinuteSecond_Long, 180122.4d, "2 days 2 hours 2 minutes 2 seconds"),
        new(Time.DayHourMinute_Long, 1d, "0 minutes"),
        new(Time.DayHourMinute_Long, 10d, "0 minutes"),
        new(Time.DayHourMinute_Long, 60d, "1 minute"),
        new(Time.DayHourMinute_Long, 61.2d, "1 minute"),
        new(Time.DayHourMinute_Long, 122.2d, "2 minutes"),
        new(Time.DayHourMinute_Long, 3661.2d, "1 hour 1 minute"),
        new(Time.DayHourMinute_Long, 7322.2d, "2 hours 2 minutes"),
        new(Time.DayHourMinute_Long, 90061.4d, "1 day 1 hour 1 minute"),
        new(Time.DayHourMinute_Long, 180122.4d, "2 days 2 hours 2 minutes"),
        new(Time.DayHourMinuteSecond_Trimmed, 0d, "00:00"),
        new(Time.DayHourMinuteSecond_Trimmed, 150d, "02:30"),
        new(Time.DayHourMinuteSecond_Trimmed, 3750d, "1:02:30"),
        new(Time.DayHourMinuteSecond_Trimmed, 90150.4d, "1day:1:02:30"),
        new(Time.DayHourMinuteSecond_Trimmed, 176550.6d, "2day:1:02:30"),
        new(Time.HourMinuteSecond_Symbol, 0d, "00 s"),
        new(Time.HourMinuteSecond_Symbol, 1d, "01 s"),
        new(Time.HourMinuteSecond_Symbol, 120d, "2 m 00 s"),
        new(Time.HourMinuteSecond_Symbol, 150d, "2 m 30 s"),
        new(Time.HourMinuteSecond_Symbol, 3720d, "1 h 2 m 00 s"),
        new(Time.HourMinuteSecond_Symbol, 3750d, "1 h 2 m 30 s"),
        new(Time.StopWatch, 0d, "00:00:00"),
        new(Time.StopWatch, 0.5d, "00:00:500"),
        new(Time.StopWatch, 0.55d, "00:00:550"),
        new(Time.StopWatch, 0.555d, "00:00:555"),
        new(Time.StopWatch, 1d, "00:01:00"),
        new(Time.StopWatch, 1.5d, "00:01:500"),
        new(Time.StopWatch, 60d, "01:00:00"),
        new(Time.StopWatch, 60.5002d, "01:00:500"),
        new(Time.StopWatch, 3600d, "1:00:00:00"),
        new(Time.StopWatch, 3600.5002d, "1:00:00:500"),
    ];
}
