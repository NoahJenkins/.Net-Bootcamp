// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string? name = Console.ReadLine(); // Read user input from the console

Console.WriteLine($"Hello, {name}!"); // Output a greeting to the user

int age = 23; // Declare an integer variable to store age
Console.WriteLine($"You are {age} years old!"); // Output the age to the user

Console.WriteLine(long.MaxValue); // Output the maximum value of a long integer
Console.WriteLine(long.MinValue); // Output the minimum value of a long integer

double negativeDouble = -123.456; // Declare a double variable with a negative value
Console.WriteLine(negativeDouble); // Output the negative double value

decimal decimalValue = 123.456m; // Declare a decimal variable, it must have an 'm' suffix
Console.WriteLine(decimalValue); // Output the decimal value

bool isTrue = true; // Declare a boolean variable
Console.WriteLine(isTrue); // Output the boolean value

//Floating point numbers
float floatValue = 123.456f; // Declare a float variable, it must have an 'f' suffix
Console.WriteLine(floatValue); // Output the float value

// Character and string types
char character = 'A'; // Declare a character variable
Console.WriteLine(character); // Output the character value


string ageValue = "23"; // Declare a string variable to store age as a string

int ageNewValue = Convert.ToInt32(ageValue); // Convert the string to an integer    
Console.WriteLine($"Converted age: {ageNewValue}"); // Output the converted age
