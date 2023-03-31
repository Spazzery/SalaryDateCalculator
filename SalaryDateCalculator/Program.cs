namespace SpinTEK;

class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 2)
        {
            string command = args[0];
            string inputYear = args[1];
            
            SalaryReminder salaryReminder = new SalaryReminder(inputYear);
            salaryReminder.CreateSalaryReminder();
            
            if (command.ToLower() == "show")
                salaryReminder.CreateAndShowTable();
            
            else if (command.ToLower() == "write")
                salaryReminder.WriteToCsv();

            else {
                Console.WriteLine("Incorrect command input: " + command);
                ShowHelp();
            }

        }
        else {
            Console.WriteLine("Incorrect arguments.");
            ShowHelp();
        }
    }

    private static void ShowHelp()
    {
        Console.WriteLine("-------------------------");
        Console.WriteLine("Usage: SalaryDateCalculator.exe <command> <year>");
        Console.WriteLine("Available commands:");
        Console.WriteLine("Show - prints the table into CLI");
        Console.WriteLine("Write - writes the result into a CSV file");
        Console.WriteLine("-------------------------");
    }
}