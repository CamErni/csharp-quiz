using Moq;
using NUnit.Framework;

namespace CalculatorApp.UnitTests;
// **Invalid Input (non-numeric value in any number)**

// ```
// Enter the first number:
// abc
// Invalid input. Please enter numeric values.
// Calculation attempt finished.
// ```

// **Division by Zero**

// ```
// Enter the first number:
// 10
// Enter the second number:
// 0
// Enter the operation (add, subtract, multiply, divide):
// divide
// Cannot divide by zero.
// Calculation attempt finished.
// ```

// **Unsupported Operation**

// ```
// Enter the first number:
// 10
// Enter the second number:
// 5
// Enter the operation (add, subtract, multiply, divide):
// modulo
// An error occurred: The specified operation is not supported.
// Calculation attempt finished.
// ```
[TestFixture]
public class CalculatorTest
{
   
    private Calculator _calculator;

   

    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();

    }

 

    
    [Test]
    public void Add_ShouldReturnCorrectSum()
    {
        // Arrange
        double a = 5;
        double b = 3;

        // Act
        double result = _calculator.PerformOperation(Convert.ToDouble(a), Convert.ToDouble(b), "add");

        // Assert
        Assert.AreEqual(8, result);
    }
    [Test]
    public void FormatException()
    {
        Assert.Throws<FormatException>(() =>_calculator.PerformInputTest("dfs", "dfaf", "add"));
    }
    [Test]
    public void InvalidOperationException()
    {
        // Arrange
        int a = 9;
        int b = 5;

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => _calculator.PerformOperation(Convert.ToDouble(a), Convert.ToDouble(b), "mewing"));
    }
    [Test]
    public void Divide_ByZero_ShouldThrowDivideByZeroException()
    {
        // Arrange
        int a = 6;
        int b = 0;

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => _calculator.PerformOperation(Convert.ToDouble(a), Convert.ToDouble(b), "divide"));
    }
    [Test]
    public void MethodUnderTest_Scenario_ExpectedBehavior()
    {
        Assert.Pass();
    }
}