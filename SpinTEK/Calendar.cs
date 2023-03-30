namespace SpinTEK;

public class Calendar
{
    private IList<DateTime> _holidays;
    
    public Calendar(IList<DateTime> holidays)
    {
        _holidays = holidays;
    }

    public IList<DateTime> GetPublicHolidays()
    {
        return _holidays;
    }
    
    public bool IsHoliday(DateTime date)
    {
        return _holidays.Contains(date);
    }
}