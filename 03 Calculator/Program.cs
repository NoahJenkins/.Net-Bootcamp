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

        // Switch statement: evaluates the 'operation' variable and executes matching case
        switch (operation)
        {
            // Case: defines a specific value to match against the switch expression
            case "+":
                result = num1 + num2;
                break; // Break: exits the switch statement to prevent fall-through to next case
            case "-":
                result = num1 - num2;
                break; // Break: exits the switch statement
            case "*":
                result = num1 * num2;
                break; // Break: exits the switch statement
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
                break; // Break: exits the switch statement
            // Default: executes when no case matches the switch expression
            default:
                Console.WriteLine("Error: Invalid operator!");
                validOperation = false;
                break; // Break: exits the switch statement (optional for default case)
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

    // \n is an escape sequence that creates a new line (line break) in the output
    Console.Write("\nDo you want to perform another calculation? (y/n): ");
    string? response = Console.ReadLine()?.ToLower();
    continueCalculating = response == "y" || response == "yes";

    if (continueCalculating)
    {
        Console.WriteLine();
    }
}

Console.WriteLine("Thank you for using the calculator!");
