using Nager.Date;

namespace SpinTEK;

public class SalaryReminder
{
    private Calendar _calendar;
    private int _inputYear;
    
    private List<DateTime>? _payDays = new List<DateTime>();
    private List<DateTime>? _reminderDays = new List<DateTime>();

    public SalaryReminder(string year)
    {
        _inputYear = Convert.ToInt32(year);
        var holidays = DateSystem.GetPublicHolidays(_inputYear, Nager.Date.CountryCode.EE);
        _calendar = new Calendar(holidays);
        Console.WriteLine(holidays);
    }
    
    public void CreateSalaryReminder()
    {
        for (int i = 0; i < 12; i++)
        {
            DateTime salaryDate = new DateTime(_inputYear, i + 1, 10);

            salaryDate = Calculator.CalculateSalaryDate(salaryDate);
            DateTime reminderDate = Calculator.CalculateReminderDate(salaryDate);
            
            _payDays!.Add(salaryDate);
            _reminderDays!.Add(reminderDate);
        }
    }

    public void WriteToCsv()
    {
        
    }


}