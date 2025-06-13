// Simple Todo List Application
// Learn about List<T>, CRUD operations, and basic menu systems

List<string> todoItems = new List<string>(); // Create a list to store todo items
bool isRunning = true;

Console.WriteLine("Simple Todo List");
Console.WriteLine("================");

while (isRunning)
{
    ShowMenu();
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddTodoItem();
            break;
        case "2":
            ViewTodoItems();
            break;
        case "3":
            RemoveTodoItem();
            break;
        case "4":
            ClearAllItems();
            break;
        case "5":
            isRunning = false;
            Console.WriteLine("Goodbye!");
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
        Console.Clear();
    }
}

void ShowMenu()
{
    Console.WriteLine("\n--- Todo List Menu ---");
    Console.WriteLine("1. Add Todo Item");
    Console.WriteLine("2. View All Items");
    Console.WriteLine("3. Remove Item");
    Console.WriteLine("4. Clear All Items");
    Console.WriteLine("5. Exit");
    Console.Write("Choose an option (1-5): ");
}

void AddTodoItem()
{
    Console.Write("Enter a new todo item: ");
    string? newItem = Console.ReadLine();
    
    if (!string.IsNullOrWhiteSpace(newItem))
    {
        todoItems.Add(newItem);
        Console.WriteLine("Item added successfully!");
    }
    else
    {
        Console.WriteLine("Item cannot be empty!");
    }
}

void ViewTodoItems()
{
    if (todoItems.Count == 0)
    {
        Console.WriteLine("No todo items found.");
        return;
    }

    Console.WriteLine("\n--- Your Todo Items ---");
    for (int i = 0; i < todoItems.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todoItems[i]}");
    }
}

void RemoveTodoItem()
{
    if (todoItems.Count == 0)
    {
        Console.WriteLine("No items to remove.");
        return;
    }

    ViewTodoItems();
    Console.Write("Enter the number of the item to remove: ");
    
    try
    {
        int index = Convert.ToInt32(Console.ReadLine()) - 1;
        
        if (index >= 0 && index < todoItems.Count)
        {
            string removedItem = todoItems[index];
            todoItems.RemoveAt(index);
            Console.WriteLine($"Removed: {removedItem}");
        }
        else
        {
            Console.WriteLine("Invalid item number!");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Please enter a valid number!");
    }
}

void ClearAllItems()
{
    if (todoItems.Count == 0)
    {
        Console.WriteLine("No items to clear.");
        return;
    }

    Console.Write("Are you sure you want to clear all items? (y/n): ");
    string? confirmation = Console.ReadLine()?.ToLower();
    
    if (confirmation == "y" || confirmation == "yes")
    {
        todoItems.Clear();
        Console.WriteLine("All items cleared!");
    }
}
