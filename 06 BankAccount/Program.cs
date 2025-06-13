// Bank Account Simulator
// Learn about classes, objects, encapsulation, and methods

// BankAccount class definition
public class BankAccount
{
    // Private fields (encapsulation)
    private string accountHolder;
    private decimal balance;
    private string accountNumber;

    // Constructor to initialize a new bank account
    public BankAccount(string holder, decimal initialBalance = 0)
    {
        accountHolder = holder;
        balance = initialBalance;
        accountNumber = GenerateAccountNumber();
    }

    // Properties to access private fields safely
    public string AccountHolder => accountHolder;
    public decimal Balance => balance;
    public string AccountNumber => accountNumber;

    // Method to deposit money
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Deposited ${amount:F2}. New balance: ${balance:F2}");
        }
        else
        {
            Console.WriteLine("Deposit amount must be positive!");
        }
    }

    // Method to withdraw money
    public void Withdraw(decimal amount)
    {
        if (amount > 0)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Withdrew ${amount:F2}. New balance: ${balance:F2}");
            }
            else
            {
                Console.WriteLine("Insufficient funds!");
            }
        }
        else
        {
            Console.WriteLine("Withdrawal amount must be positive!");
        }
    }

    // Method to display account information
    public void DisplayAccountInfo()
    {
        Console.WriteLine($"\n--- Account Information ---");
        Console.WriteLine($"Account Number: {accountNumber}");
        Console.WriteLine($"Account Holder: {accountHolder}");
        Console.WriteLine($"Current Balance: ${balance:F2}");
    }

    // Private method to generate account number
    private string GenerateAccountNumber()
    {
        Random random = new Random();
        return $"ACC{random.Next(10000, 99999)}";
    }
}

// Main program
class Program
{
    static void Main()
    {
        Console.WriteLine("Bank Account Simulator");
        Console.WriteLine("======================");

        // Create a new bank account
        Console.Write("Enter account holder name: ");
        string? name = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(name))
        {
            name = "Unknown";
        }

        Console.Write("Enter initial deposit amount (or press Enter for $0): ");
        string? initialAmountInput = Console.ReadLine();
        decimal initialAmount = 0;

        if (!string.IsNullOrWhiteSpace(initialAmountInput))
        {
            if (!decimal.TryParse(initialAmountInput, out initialAmount) || initialAmount < 0)
            {
                initialAmount = 0;
                Console.WriteLine("Invalid amount. Starting with $0.");
            }
        }

        BankAccount account = new BankAccount(name, initialAmount);
        Console.WriteLine($"\nAccount created successfully!");
        account.DisplayAccountInfo();

        bool isRunning = true;
        while (isRunning)
        {
            ShowMenu();
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PerformDeposit(account);
                    break;
                case "2":
                    PerformWithdrawal(account);
                    break;
                case "3":
                    account.DisplayAccountInfo();
                    break;
                case "4":
                    isRunning = false;
                    Console.WriteLine("Thank you for using Bank Account Simulator!");
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }

            if (isRunning)
            {
                Console.WriteLine("\nPress any key to continue...");
                if (Console.IsInputRedirected)
                {
                    Console.ReadLine();
                }
                else
                {
                    Console.ReadKey();
                }
                Console.WriteLine();
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("\n--- Banking Menu ---");
        Console.WriteLine("1. Deposit Money");
        Console.WriteLine("2. Withdraw Money");
        Console.WriteLine("3. View Account Info");
        Console.WriteLine("4. Exit");
        Console.Write("Choose an option (1-4): ");
    }

    static void PerformDeposit(BankAccount account)
    {
        Console.Write("Enter deposit amount: $");
        string? input = Console.ReadLine();
        
        if (decimal.TryParse(input, out decimal amount))
        {
            account.Deposit(amount);
        }
        else
        {
            Console.WriteLine("Invalid amount entered!");
        }
    }

    static void PerformWithdrawal(BankAccount account)
    {
        Console.Write("Enter withdrawal amount: $");
        string? input = Console.ReadLine();
        
        if (decimal.TryParse(input, out decimal amount))
        {
            account.Withdraw(amount);
        }
        else
        {
            Console.WriteLine("Invalid amount entered!");
        }
    }
}
