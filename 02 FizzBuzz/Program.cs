// FizzBuzz Program
// Prints numbers 1-100, but replaces:
// - Multiples of 3 with "Fizz"
// - Multiples of 5 with "Buzz" 
// - Multiples of both 3 and 5 with "FizzBuzz"

Console.WriteLine("FizzBuzz Program");
Console.WriteLine("================");

for (int i = 1; i <= 100; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
    }
    else if (i % 3 == 0)
    {
        Console.WriteLine("Fizz");
    }
    else if (i % 5 == 0)
    {
        Console.WriteLine("Buzz");
    }
    else
    {
        Console.WriteLine(i);
    }
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
