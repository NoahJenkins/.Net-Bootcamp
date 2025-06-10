// Password Generator Application
// Learn about Random class, string manipulation, and user input validation

using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Password Generator");
        Console.WriteLine("=================");
        
        bool continueGenerating = true;
        
        while (continueGenerating)
        {
            try
            {
                // Get password requirements
                int length = GetPasswordLength();
                PasswordOptions options = GetPasswordOptions();
                
                // Generate password
                string password = GeneratePassword(length, options);
                
                // Display result
                Console.WriteLine($"\nGenerated Password: {password}");
                Console.WriteLine($"Password Strength: {AnalyzeStrength(password, options)}");
                
                // Ask to continue
                Console.Write("\nGenerate another password? (y/n): ");
                string? response = Console.ReadLine()?.ToLower();
                continueGenerating = response == "y" || response == "yes";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        
        Console.WriteLine("Thanks for using Password Generator!");
    }
    
    static int GetPasswordLength()
    {
        Console.Write("Enter password length (8-128): ");
        if (int.TryParse(Console.ReadLine(), out int length))
        {
            if (length >= 8 && length <= 128)
                return length;
        }
        throw new ArgumentException("Invalid length. Must be between 8 and 128.");
    }
    
    static PasswordOptions GetPasswordOptions()
    {
        PasswordOptions options = new PasswordOptions();
        
        Console.WriteLine("\nPassword Options:");
        options.IncludeLowercase = GetYesNo("Include lowercase letters? (y/n): ");
        options.IncludeUppercase = GetYesNo("Include uppercase letters? (y/n): ");
        options.IncludeNumbers = GetYesNo("Include numbers? (y/n): ");
        options.IncludeSymbols = GetYesNo("Include symbols? (y/n): ");
        options.ExcludeSimilar = GetYesNo("Exclude similar characters (0,O,l,1)? (y/n): ");
        
        if (!options.IncludeLowercase && !options.IncludeUppercase && 
            !options.IncludeNumbers && !options.IncludeSymbols)
        {
            throw new ArgumentException("At least one character type must be selected.");
        }
        
        return options;
    }
    
    static bool GetYesNo(string prompt)
    {
        Console.Write(prompt);
        string? response = Console.ReadLine()?.ToLower();
        return response == "y" || response == "yes";
    }
    
    static string GeneratePassword(int length, PasswordOptions options)
    {
        StringBuilder characterSet = new StringBuilder();
        StringBuilder password = new StringBuilder();
        Random random = new Random();
        
        // Build character set
        if (options.IncludeLowercase)
        {
            string chars = options.ExcludeSimilar ? "abcdefghijkmnopqrstuvwxyz" : "abcdefghijklmnopqrstuvwxyz";
            characterSet.Append(chars);
        }
        if (options.IncludeUppercase)
        {
            string chars = options.ExcludeSimilar ? "ABCDEFGHIJKMNPQRSTUVWXYZ" : "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            characterSet.Append(chars);
        }
        if (options.IncludeNumbers)
        {
            string chars = options.ExcludeSimilar ? "23456789" : "0123456789";
            characterSet.Append(chars);
        }
        if (options.IncludeSymbols)
        {
            characterSet.Append("!@#$%^&*()_+-=[]{}|;:,.<>?");
        }
        
        string availableChars = characterSet.ToString();
        
        // Generate password
        for (int i = 0; i < length; i++)
        {
            int index = random.Next(availableChars.Length);
            password.Append(availableChars[index]);
        }
        
        return password.ToString();
    }
    
    static string AnalyzeStrength(string password, PasswordOptions options)
    {
        int score = 0;
        
        if (password.Length >= 12) score += 2;
        else if (password.Length >= 8) score += 1;
        
        if (options.IncludeLowercase) score += 1;
        if (options.IncludeUppercase) score += 1;
        if (options.IncludeNumbers) score += 1;
        if (options.IncludeSymbols) score += 2;
        if (options.ExcludeSimilar) score += 1;
        
        return score switch
        {
            >= 7 => "Very Strong",
            >= 5 => "Strong",
            >= 3 => "Medium",
            _ => "Weak"
        };
    }
}

class PasswordOptions
{
    public bool IncludeLowercase { get; set; } = true;
    public bool IncludeUppercase { get; set; } = true;
    public bool IncludeNumbers { get; set; } = true;
    public bool IncludeSymbols { get; set; } = false;
    public bool ExcludeSimilar { get; set; } = false;
}
