using System;
using System.Threading;



namespace GarageConsoleApp;

public static class Helpers
{
    public static string GetValidText(string message)
    {
        Console.Write(message);
        
        string? input = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(input))
        {
            
            Console.WriteLine("Input cannot be empty. Please try again.");
            Console.WriteLine();
            input = Console.ReadLine();
        }
     

        return input;
    }


    public static int GetValidInt(string message, int min = 0, int max = int.MaxValue, string? errorMessage = null)
    {

        int value;
        while (true)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
            {
                return value;
            }

            ConsoleUI.ShowError(errorMessage ?? $"Invalid input. Please enter a number between {min} and {max}.");
            ConsoleUI.ShowMessage("");
        }
    }

    public static double GetValidDouble(string message)
    {
        Console.Write(message);
        
        double value;
        while (!double.TryParse(Console.ReadLine(), out value) || value < 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            Console.WriteLine();
        }

        return value;
    }


    public static string GetOnlyText(string message)
    {
        while (true)
        {
            Console.Write(message);

            string? input = Console.ReadLine()?.Trim();

            if (!string.IsNullOrWhiteSpace(input) && input.All(char.IsLetter))
            {
                return input;
            }

            ConsoleUI.ShowError("\nInput can only contain letters.");
        }
    }


    public static void CountDownToMenu()
    {
        Console.WriteLine();

        for (int i = 3; i > 0; i--)
        {
            Console.Write($"\rReturning to menu in {i}...   ");
            Thread.Sleep(1000);
        }

        Console.WriteLine();

    }
}