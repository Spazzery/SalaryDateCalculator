namespace SpinTEK;

public static class Calculator
{

    public static DateTime CalculateSalaryDate(DateTime salaryDate)
    {
        if (salaryDate.DayOfWeek == DayOfWeek.Saturday)
            return salaryDate.AddDays(-1);
        else if (salaryDate.DayOfWeek == DayOfWeek.Sunday)
            return salaryDate.AddDays(-2);
        else if (Calendar.isHoliday(salaryDate))
        {
            return CalculateWhenOnHoliday(salaryDate);
        }
        else
            return salaryDate;
    }

    public static DateTime CalculateWhenOnHoliday(DateTime inputDate)
    {
        while (Calendar.isHoliday(inputDate))
            inputDate = inputDate.AddDays(-1);
        
        if (inputDate.DayOfWeek == DayOfWeek.Saturday)
            return inputDate.AddDays(-1);
        else if (inputDate.DayOfWeek == DayOfWeek.Sunday)
            return inputDate.AddDays(-2);

        throw new NotImplementedException();
    }

    public static DateTime CalculateReminderDate(DateTime salaryDate)
    {
        throw new NotImplementedException();
    }
    
}