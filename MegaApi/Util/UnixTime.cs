﻿
using System;
public static class UnixDateTimeHelper
{
    private const string InvalidUnixEpochErrorMessage = "Unix epoc starts January 1st, 1970";
    /// <summary>
    ///   Convert a long into a DateTime
    /// </summary>
    public static DateTime FromUnixTime(this long self)
    {
        var ret = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return ret.AddSeconds(self).ToLocalTime();
    }

    /// <summary>
    ///   Convert a DateTime into a long
    /// </summary>
    public static long ToUnixTime(this DateTime self)
    {

        if (self == DateTime.MinValue)
        {
            return 0;
        }
        var epoc = new DateTime(1970, 1, 1);
        var delta = self.ToUniversalTime() - epoc;

        if (delta.TotalSeconds < 0) throw new ArgumentOutOfRangeException(InvalidUnixEpochErrorMessage);

        return (long)delta.TotalSeconds;
    }

}