using System;




namespace GarageConsoleApp;

public static class ConsoleUI
{
    public static void ShowHeader(string title)
    {
        Console.Clear();

        Console.WriteLine("========================================");
        Console.WriteLine($" {title}");
        Console.WriteLine("========================================");
        Console.WriteLine();
    }

    public static void ShowMessage(string message, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    

    public static void ShowSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Success: {message}");
        Console.ResetColor();
    }

    public static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {message}");
        Console.ResetColor();
    }

    public static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public static void ShowStartMenu()
    {
        
        ShowHeader("Garage 2.0");

        Console.WriteLine("No active garage selected.");
        Console.WriteLine();

        Console.WriteLine("[1] Create new garage");
        Console.WriteLine("[2] Load garage from file");
        Console.WriteLine();
        Console.WriteLine("[0] Exit");

        Console.WriteLine();
        Console.Write("Select option: ");
    }

    public static void ShowMainMenu(string garageName, int parkedVehicles, int capacity)
    {
        
        ShowHeader("Garage 2.0");

        Console.WriteLine($"Active garage: {garageName}");
        Console.WriteLine($"Vehicles parked: {parkedVehicles}/{capacity}");

        Console.WriteLine();

        Console.WriteLine("[1] List parked vehicles");
        Console.WriteLine("[2] List vehicle types");
        Console.WriteLine("[3] Add vehicle");
        Console.WriteLine("[4] Remove vehicle");
        Console.WriteLine("[5] Search by registration number");
        Console.WriteLine("[6] Search by properties");

        Console.WriteLine();

        Console.WriteLine("[7] Create or switch garage");
        Console.WriteLine("[8] Save garage");
        Console.WriteLine("[9] Load garage");

        Console.WriteLine();

        Console.WriteLine("[0] Exit");

        Console.WriteLine();
        Console.Write("Select option: ");
    }
    
}