namespace SpinTEK;

class Program
{
    public static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            string inputYear = args[0];

            SalaryReminder salaryReminder = new SalaryReminder(inputYear);
            salaryReminder.CreateSalaryReminder();
            salaryReminder.CreateTable();
            // salaryReminder.WriteToCsv();
        }
        else             
            Console.WriteLine("No arguments given!");

    }
}