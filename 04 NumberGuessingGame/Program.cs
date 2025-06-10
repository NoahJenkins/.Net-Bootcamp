// Number Guessing Game
// Player tries to guess a random number between 1-100

Console.WriteLine("Welcome to the Number Guessing Game!");
Console.WriteLine("====================================");

Random random = new Random(); // Create random number generator
int targetNumber = random.Next(1, 101); // Generate random number 1-100
int attempts = 0;
int maxAttempts = 7;
bool hasWon = false;

Console.WriteLine("I'm thinking of a number between 1 and 100.");
Console.WriteLine($"You have {maxAttempts} attempts to guess it!");

while (attempts < maxAttempts && !hasWon)
{
    Console.Write($"\nAttempt {attempts + 1}: Enter your guess: ");
    
    try
    {
        int guess = Convert.ToInt32(Console.ReadLine());
        attempts++;

        if (guess == targetNumber)
        {
            hasWon = true;
            Console.WriteLine($"🎉 Congratulations! You guessed it in {attempts} attempts!");
        }
        else if (guess < targetNumber)
        {
            Console.WriteLine("Too low! Try a higher number.");
        }
        else
        {
            Console.WriteLine("Too high! Try a lower number.");
        }

        // Show remaining attempts
        if (!hasWon && attempts < maxAttempts)
        {
            Console.WriteLine($"Attempts remaining: {maxAttempts - attempts}");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Please enter a valid number!");
        // Don't count invalid input as an attempt
        attempts--;
    }
}

if (!hasWon)
{
    Console.WriteLine($"\n😞 Game Over! The number was {targetNumber}");
}

Console.WriteLine("\nThanks for playing!");
