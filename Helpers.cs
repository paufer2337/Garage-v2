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
        Console.Write(message);

        int value;
        while (!int.TryParse(Console.ReadLine(), out value) || value < 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid non-negative integer.");
            Console.WriteLine();
        }

        return value;
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

    public static void Pause()
    {
    Console.WriteLine();
    Console.WriteLine("Press any key to return to menu...");
    Console.ReadKey();
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