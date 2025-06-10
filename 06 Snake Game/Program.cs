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
        Console.SetWindowSize(width + 20, height + 10);
        
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
        
        Console.SetCursorPosition(0, height + 2);
        Console.WriteLine($"Game Over! Final Score: {score}");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
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
        
        // Draw borders
        for (int i = 0; i < width + 2; i++)
        {
            Console.SetCursorPosition(i, 0);
            Console.Write("#");
            Console.SetCursorPosition(i, height + 1);
            Console.Write("#");
        }
        for (int i = 0; i < height + 2; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write("#");
            Console.SetCursorPosition(width + 1, i);
            Console.Write("#");
        }
        
        // Draw snake
        foreach (var segment in snake)
        {
            Console.SetCursorPosition(segment.x + 1, segment.y + 1);
            Console.Write("O");
        }
        
        // Draw food
        Console.SetCursorPosition(foodX + 1, foodY + 1);
        Console.Write("*");
        
        // Draw score
        Console.SetCursorPosition(0, height + 3);
        Console.WriteLine($"Score: {score}");
        Console.WriteLine("Use arrow keys to move. Press any key to start/continue...");
    }
}
