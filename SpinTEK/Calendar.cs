namespace SpinTEK;

public class Calendar
{
    private List<DateTime> _holidays;
    
    public Calendar(int year)
    {
        GenerateHolidays();
    }

    private void GenerateHolidays()
    {
        
    }
    
    private List<DateTime> publicHolidays = new List<DateTime>
    {
        new DateTime()
    };
        

    public static bool isHoliday(DateTime)
    {
        
    }
    
    public static List<DateTime> GetPublicHolidays()
    {
        
    }
}