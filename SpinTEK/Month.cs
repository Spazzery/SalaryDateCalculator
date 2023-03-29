namespace SpinTEK;

public class Month
{
    List<string> _monthNames = new List<string>{"January", "February", "March", "April", "May", "June", "August", "September", "October", "November", "December"};
    
    private string _name;

    private List<DateTime>? _holidays;

    public Month(int i)
    {
        _name = _monthNames[i];
        addHolidays();
    }

    private void addHolidays()
    {
        
    }
    
}