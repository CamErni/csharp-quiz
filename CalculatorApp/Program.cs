using System.Security.Cryptography.X509Certificates;
using Serilog;
namespace CalculatorApp;


class Program
{
    static void Main(string[] args)
    {
       
        double num1 = 0;
        double num2 = 0;
        Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();

        try
        {
            Console.WriteLine("Enter the first number:");
            
            num1 = Convert.ToDouble(Console.ReadLine());
        
            Console.WriteLine("Enter the second number:");
            num2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the operation (add, subtract, multiply, divide):");
            string operation = Console.ReadLine()?.ToLower() ?? string.Empty;
            if (operation != "add" && operation != "subtract" && operation != "multiply" && operation != "divide")
            {
                Console.WriteLine("An error occurred: The specified operation is not supported.\nCalculation attempt finished.");
                Log.Error("An error occurred: The specified operation is not supported.");
                throw new InvalidOperationException("An error occurred: The specified operation is not supported.");
            }

            var calculator = new Calculator();
            double result = calculator.PerformOperation(num1, num2, operation);
            Console.WriteLine($"The result is: {result}");

            Console.WriteLine("Calculation attempt finished.");
        }
        catch (FormatException)
        {
            Log.Error("Invalid input. Please enter numeric values.\nCalculation attempt finished.");
            Console.WriteLine("Invalid input. Please enter numeric values.\nCalculation attempt finished.");

        }

    Log.CloseAndFlush();
            
    
    }
 
}