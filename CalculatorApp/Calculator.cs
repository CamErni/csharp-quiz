namespace CalculatorApp;
using Serilog;
using Serilog.Sinks.SystemConsole;
public class Calculator
{
    
    public void PerformInputTest(object num1, object num2, string operation){
        try{
            Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();
            PerformOperation(Convert.ToDouble(num1), Convert.ToDouble(num2), operation);
        }catch (FormatException)
        {
            Log.Error("Invalid input. Please enter numeric values.");
            throw new FormatException("Invalid input. Please enter numeric values.\nCalculation attempt finished.");
      
        } Log.CloseAndFlush();
        
        
        }
    public double PerformOperation(double num1, double num2, string operation)
    {
        Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();
        
       if (operation != "add" && operation != "subtract" && operation != "multiply" && operation != "divide")
            {
                Console.WriteLine("An error occurred: The specified operation is not supported.");
                Console.WriteLine("Calculation attempt finished.");
                Log.Error("An error occurred: The specified operation is not supported.");
                throw new InvalidOperationException("An error occurred: The specified operation is not supported.");
            }
            static double SafeDivision(double x, double y)
        {
            if (y == 0)
                throw new DivideByZeroException();
            return x / y;
        }
        // TODO: Implement the PerformOperation method
        if (operation == "add"){
            return num1+num2;
        }
        if (operation == "subtract"){
            return num1-num2;
        }
        if (operation == "multiply"){
            return num1*num2;
        }
        if (operation == "divide"){
        double result;
        try
        {
            result = SafeDivision(num1, num2);
            Console.WriteLine("{0} divided by {1} = {2}", num1, num2, result);
            return result;
        }
        catch (DivideByZeroException)
        {
            Log.Information("Cannot divide by zero.");
            throw new DivideByZeroException("Cannot divide by zero./nCalculation attempt finished.");
            
        }
        }
        Log.CloseAndFlush();
        throw new NotImplementedException();
        
    }
}