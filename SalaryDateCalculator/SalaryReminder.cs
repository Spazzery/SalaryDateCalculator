using System.Text;
using PublicHoliday;

namespace SpinTEK;

public class SalaryReminder
{
    private Calendar _calendar;
    private int _year;

    private List<DateTime>? _payDays = new List<DateTime>();
    private List<DateTime>? _reminderDays = new List<DateTime>();

    private string? _table;

    public SalaryReminder(string year)
    {
        _year = ConvertToInt(year);
        _calendar = new Calendar(new EstoniaPublicHoliday().PublicHolidays(_year));
    }

    public void CreateSalaryReminder()
    {
        for (int i = 0; i < 12; i++)
        {
            DateTime salaryDate = new DateTime(_year, i + 1, 10);

            salaryDate = CalculateSalaryDate(salaryDate);
            DateTime reminderDate = CalculateReminderDate(salaryDate);

            _payDays!.Add(salaryDate);
            _reminderDays!.Add(reminderDate);
        }
    }


    private DateTime CalculateSalaryDate(DateTime salaryDate)
    {
        if (salaryDate.DayOfWeek == DayOfWeek.Saturday || salaryDate.DayOfWeek == DayOfWeek.Sunday ||
            _calendar.IsHoliday(salaryDate))
            return new EstoniaPublicHoliday().PreviousWorkingDay(salaryDate);
        else
            return salaryDate;
    }

    private DateTime CalculateReminderDate(DateTime salaryDate)
    {
        DateTime reminderDate = salaryDate;

        for (int i = 0; i < 3; i++)
            reminderDate = new EstoniaPublicHoliday().PreviousWorkingDayNotSameDay(reminderDate);

        return reminderDate;
    }

    public void CreateAndShowTable()
    {
        StringBuilder tableContents = new StringBuilder();
        tableContents.Append("+------------------+------------------+");
        tableContents.Append("\n");
        tableContents.Append("|   Salary Date    |   Reminder Date  |");
        tableContents.Append("\n");
        tableContents.Append("+------------------+------------------+");
        tableContents.Append("\n");

        int totalLength = 18;
        for (int i = 0; i < _payDays!.Count; i++)
        {
            string payday = _payDays![i].ToString("dd/MM/yyyy");
            string reminderDay = _reminderDays![i].ToString("dd/MM/yyyy");

            tableContents.Append("|" +
                                 payday.PadLeft((totalLength - payday.Length) / 2 + payday.Length)
                                     .PadRight(totalLength) + "|" +
                                 reminderDay.PadLeft((totalLength - reminderDay.Length) / 2 + reminderDay.Length)
                                     .PadRight(totalLength) + "|");
            tableContents.Append("\n");
        }

        tableContents.Append("+------------------+------------------+");

        _table = tableContents.ToString();

        Console.WriteLine(_table);
    }

    public void WriteToCsv()
    {
        using StreamWriter sw = new StreamWriter(_year.ToString() + ".csv");
        sw.WriteLine("salary date,reminder date");

        for (int i = 0; i < _payDays!.Count; i++)
            sw.WriteLine($"{_payDays[i].ToString("dd/MM/yyyy")},{_reminderDays![i].ToString("dd/MM/yyyy")}");

        Console.WriteLine("Finished writing into CSV! Output file: " + _year.ToString() + ".csv");
    }

    private int ConvertToInt(string year)
    {
        int result;
        try
        {
            result = Convert.ToInt32(year);
        }
        catch (FormatException)
        {
            throw new FormatException("Input number is not a valid year: " + year);
        }
        
        if (result < 1 || result > 9999)
            throw new ArgumentException("Input year can't be lower than 1 or higher than 9999");

        return result;
    }
}