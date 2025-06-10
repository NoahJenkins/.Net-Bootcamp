// Simple Calculator Program
// Performs basic arithmetic operations: +, -, *, /

Console.WriteLine("Simple Calculator");
Console.WriteLine("=================");

bool continueCalculating = true;

while (continueCalculating)
{
    try
    {
        Console.Write("Enter first number: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter an operator (+, -, *, /): ");
        string? operation = Console.ReadLine();

        Console.Write("Enter second number: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        double result = 0;
        bool validOperation = true;

        switch (operation)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                else
                {
                    Console.WriteLine("Error: Division by zero is not allowed!");
                    validOperation = false;
                }
                break;
            default:
                Console.WriteLine("Error: Invalid operator!");
                validOperation = false;
                break;
        }

        if (validOperation)
        {
            Console.WriteLine($"Result: {num1} {operation} {num2} = {result}");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Error: Please enter valid numbers!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }

    Console.Write("\nDo you want to perform another calculation? (y/n): ");
    string? response = Console.ReadLine()?.ToLower();
    continueCalculating = response == "y" || response == "yes";

    if (continueCalculating)
    {
        Console.WriteLine();
    }
}

Console.WriteLine("Thank you for using the calculator!");
