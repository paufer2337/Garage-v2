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

    public static int GetValidInt(string message)
    {

        int value;

        Console.Write(message);

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out value) && value >= 0)
            {
                return value;
            }
            ConsoleUI.ShowError("Invalid input. Please enter a valid number.");
            ConsoleUI.ShowMessage("");
        }
    }

    public static int GetValidInt(string message, int min, int max)
    {

        int value;
        while (true)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
            {
                return value;
            }

            ConsoleUI.ShowError($"Invalid input. Please enter a number between {min} and {max}.");
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