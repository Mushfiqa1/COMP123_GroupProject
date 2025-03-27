using System.Globalization;

namespace Student4;

public partial struct DayTime
{
    private long minutes;
    private static readonly DateTime Year23 = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc);


    public DayTime(long minutes)
    {
        this.minutes = minutes;
    }

    public static DayTime operator +(DayTime lhs, int minutes)
    {
        return new DayTime(lhs.minutes + minutes);
    }

    public override string ToString()
    {
        DateTime dateTime = Year23.AddMinutes(minutes);
        return dateTime.ToString("yyyy-MM-dd HH:mm");
    }
}



