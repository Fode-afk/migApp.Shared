using System;

namespace migApp.Shared.Utils
{
    public static class DateTimeUtil
    {
        public static DateTimeOffset GetCurrentTimeFormatted(string timeZoneId)
        {
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            DateTime localDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
            return new DateTimeOffset(localDateTime, timeZone.GetUtcOffset(localDateTime));
        }
    }
}
