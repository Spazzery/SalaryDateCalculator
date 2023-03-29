namespace SpinTEK;

class Program
{
    private static Calculator? _calc;
    
    public static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            string inputYear = args[0];
            
            _calc = new Calculator(inputYear);
            _calc.Calculate();
            Writer.WriteToCsv();
        }
        else             
            Console.WriteLine("No arguments given!");

    }
}