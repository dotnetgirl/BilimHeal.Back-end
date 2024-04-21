using BilimHeal.Server.Service.Commons.Constants;

namespace BilimHeal.Server.Service.Commons.Helpers;

public class TimeHelper
{
    public static DateTime GetCurrentServerTime()
    {
        var date = DateTime.UtcNow;
        return date.AddHours(TimeConstants.UTC);
    }
}

