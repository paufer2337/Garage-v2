using System;
using System.Threading;



namespace GarageConsoleApp;

public static class Helpers
{
    public static string GetValidText(string message)
    {
        while (true)
        {
            Console.Write(message);
            
            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                return input.Trim();
            }
            ConsoleUI.ShowError("Input cannot be empty. Please try again.");
            Console.WriteLine();
        }
        
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

            ConsoleUI.ShowError(errorMessage ?? $"Invalid input. Please enter a valid number.");
            Console.WriteLine();
        }
    }

    public static double GetValidDouble(string message, double min = 0, double max = double.MaxValue, string? errorMessage = null)
    {
        
        double value;
        while (true)
        {
            Console.WriteLine();
            Console.Write(message);
            
            if (double.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
            {
                return value;
            }

            ConsoleUI.ShowError(errorMessage ?? $"Invalid input. Please enter a number between {min} and {max}.");
            Console.WriteLine();
        }
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

            ConsoleUI.ShowError("Input can only contain letters.");
            Console.WriteLine();
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