using Nager.Date.Model;

namespace SpinTEK;

public class Calendar
{
    private IEnumerable<PublicHoliday> _holidays;
    
    public Calendar(IEnumerable<PublicHoliday> holidays)
    {
        _holidays = holidays;
    }

    public IEnumerable<PublicHoliday> GetPublicHolidays() {
        return _holidays;
    }
    

    public static bool isHoliday(DateTime date)
    {
        return true;
    }
}