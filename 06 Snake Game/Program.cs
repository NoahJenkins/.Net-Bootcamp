// Snake Game - Console Application
// Learn about 2D arrays, game loops, and keyboard input

using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static int width = 20;
    static int height = 20;
    static int score = 0;
    static bool gameOver = false;
    
    static int headX = 10, headY = 10;
    static int foodX = 15, foodY = 15;
    static List<(int x, int y)> snake = new List<(int, int)>();
    static string direction = "RIGHT";
    
    static void Main()
    {
        Console.CursorVisible = false;
        
        Console.WriteLine("Welcome to Snake Game!");
        Console.WriteLine("Use arrow keys to move. Press any key to start...");
        if (!Console.IsInputRedirected)
        {
            Console.ReadKey(true);
        }
        else
        {
            Console.ReadLine();
        }
        
        snake.Add((headX, headY));
        GenerateFood();
        
        while (!gameOver)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                ChangeDirection(key);
            }
            
            Update();
            Draw();
            Thread.Sleep(200);
        }
        
        Console.Clear();
        Console.WriteLine("=== GAME OVER ===");
        Console.WriteLine($"Final Score: {score}");
        Console.WriteLine("Press any key to exit...");
        if (!Console.IsInputRedirected)
        {
            Console.ReadKey();
        }
        else
        {
            Console.ReadLine();
        }
    }
    
    static void ChangeDirection(ConsoleKeyInfo key)
    {
        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
                if (direction != "DOWN") direction = "UP";
                break;
            case ConsoleKey.DownArrow:
                if (direction != "UP") direction = "DOWN";
                break;
            case ConsoleKey.LeftArrow:
                if (direction != "RIGHT") direction = "LEFT";
                break;
            case ConsoleKey.RightArrow:
                if (direction != "LEFT") direction = "RIGHT";
                break;
            case ConsoleKey.Escape:
                gameOver = true;
                break;
        }
    }
    
    static void Update()
    {
        // Move head
        switch (direction)
        {
            case "UP": headY--; break;
            case "DOWN": headY++; break;
            case "LEFT": headX--; break;
            case "RIGHT": headX++; break;
        }
        
        // Check wall collision
        if (headX < 0 || headX >= width || headY < 0 || headY >= height)
        {
            gameOver = true;
            return;
        }
        
        // Check self collision
        if (snake.Contains((headX, headY)))
        {
            gameOver = true;
            return;
        }
        
        snake.Insert(0, (headX, headY));
        
        // Check food collision
        if (headX == foodX && headY == foodY)
        {
            score++;
            GenerateFood();
        }
        else
        {
            snake.RemoveAt(snake.Count - 1);
        }
    }
    
    static void GenerateFood()
    {
        Random rand = new Random();
        do
        {
            foodX = rand.Next(0, width);
            foodY = rand.Next(0, height);
        } while (snake.Contains((foodX, foodY)));
    }
    
    static void Draw()
    {
        Console.Clear();
        
        // Create a 2D char array to represent the game board
        char[,] board = new char[height + 2, width + 2];
        
        // Initialize with spaces
        for (int i = 0; i < height + 2; i++)
        {
            for (int j = 0; j < width + 2; j++)
            {
                board[i, j] = ' ';
            }
        }
        
        // Draw borders
        for (int i = 0; i < width + 2; i++)
        {
            board[0, i] = '#';
            board[height + 1, i] = '#';
        }
        for (int i = 0; i < height + 2; i++)
        {
            board[i, 0] = '#';
            board[i, width + 1] = '#';
        }
        
        // Draw snake
        foreach (var segment in snake)
        {
            if (segment.x >= 0 && segment.x < width && segment.y >= 0 && segment.y < height)
            {
                board[segment.y + 1, segment.x + 1] = 'O';
            }
        }
        
        // Draw food


















        // Draw food
        if (foodX >= 0 && foodX < width && foodY >= 0 && foodY < height)
        {
            board[foodY + 1, foodX + 1] = '*';
        }
        
        // Print the board
        for (int i = 0; i < height + 2; i++)
        {
            for (int j = 0; j < width + 2; j++)
            {
                Console.Write(board[i, j]);
            }
            Console.WriteLine();
        }
        
        // Draw score and instructions
        Console.WriteLine($"Score: {score}");
        Console.WriteLine("Use arrow keys to move. Press ESC to quit.");
    }
}
