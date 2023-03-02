namespace PersonalSite.Extension;

public static class DateExtension
{
    public static string GetRelativeTime(this DateTime date)
    {
        const int second = 1;
        const int minute = 60 * second;
        const int hour = 60 * minute;
        const int day = 24 * hour;
        const int month = 30 * day;

        var ts = new TimeSpan(DateTime.UtcNow.Ticks - date.Ticks);
        var delta = Math.Abs(ts.TotalSeconds);

        switch (delta)
        {
            case < 1 * minute:
                return ts.Seconds == 1 ? "1 second ago" : ts.Seconds + " seconds ago";
            case < 2 * minute:
                return "1 minute ago";
            case < 45 * minute:
                return ts.Minutes + " minutes ago";
            case < 90 * minute:
                return "1 hour ago";
            case < 24 * hour:
                return ts.Hours + " hours ago";
            case < 48 * hour:
                return "yesterday";
            case < 30 * day:
                return ts.Days + " days ago";
            case < 12 * month:
            {
                var months = Convert.ToInt32(Math.Floor((double) ts.Days / 30));
                return months <= 1 ? "1 month ago" : months + " months ago";
            }
            default:
            {
                var years = Convert.ToInt32(Math.Floor((double) ts.Days / 365));
                return years <= 1 ? "1 year ago" : years + " years ago";
            }
        }
    }
}