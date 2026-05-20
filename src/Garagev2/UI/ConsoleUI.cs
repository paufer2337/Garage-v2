using System;




namespace GarageConsoleApp;

public static class ConsoleUI
{
    public static void ShowHeader(string title)
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("========================================");
        Console.WriteLine($" {title}");
        Console.WriteLine("========================================");
        
        Console.ResetColor();
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
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Success: {message}");
        Console.ResetColor();
    }

    public static void ShowError(string message)
    {
        Console.WriteLine();
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

        Console.WriteLine("[1] Create New garage");
        Console.WriteLine("[2] Create Populated Garage");
        Console.WriteLine();
        Console.WriteLine("[0] Exit");

        Console.WriteLine();
        Console.Write("Select option: ");
    }

    public static void ShowMainMenu(string garageType, int parkedVehicles, int capacity)
    {
        
        ShowHeader("Garage 2.0");

        int remainingSpots = capacity - parkedVehicles;
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($" Garage Type: {garageType}");
        Console.WriteLine($" Vehicles Parked: {parkedVehicles}/{capacity}");

        if (remainingSpots == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else if (remainingSpots <= 3)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }

        Console.WriteLine($" Remaining Spots: {remainingSpots}");

        Console.ResetColor();

        Console.WriteLine();

        Console.WriteLine("[1] List parked vehicles");
        Console.WriteLine("[2] List vehicle types");
        Console.WriteLine();
        Console.WriteLine("[3] ADD vehicle");
        Console.WriteLine("[4] REMOVE vehicle");
        Console.WriteLine();
        Console.WriteLine("[5] Search by registration number");
        Console.WriteLine("[6] Search by properties");

        Console.WriteLine();

        Console.WriteLine("[7] Create new or switch garage");
        Console.WriteLine("[8] Save garage");
        Console.WriteLine("[9] Load garage");

        Console.WriteLine();

        Console.WriteLine("[0] Exit");

        Console.WriteLine();
        Console.Write("Select option: ");
    }


    public static void ShowVehicleList(IEnumerable<Vehicle> vehicles)
    {
        ShowHeader("Parked Vehicles");

        bool foundVehicle = false;
        int vehicleNr = 1;

        Console.WriteLine("| No.  Type       RegNr       Color        Wheels     Extra              |");
        Console.WriteLine("| ---------------------------------------------------------------------- |");

        foreach (Vehicle vehicle in vehicles)
        {
            
            Console.WriteLine($" [{vehicleNr}] " +
                $"{vehicle.GetType().Name,-13}" +
                $"{vehicle.RegNumber,-12}" +
                $"{vehicle.Color,-14}" +
                $"{vehicle.WheelAmount,-8}" +
                $"{vehicle.GetExtraInfo(),-19} ");

            vehicleNr++;
            foundVehicle = true;
        }

        if (!foundVehicle)
        {
            ShowMessage("~ No parked vehicles found. ~", ConsoleColor.DarkYellow);
        }

    }


    public static void ShowVehicle(Vehicle vehicle)
    {
        ShowHeader("Vehicle Found");
        ShowMessage("");

        ShowMessage($"Type: {vehicle.GetType().Name}");
        ShowMessage($"Registration Number: {vehicle.RegNumber}");
        ShowMessage($"Color: {vehicle.Color}");
        ShowMessage($"Wheels: {vehicle.WheelAmount}");
        ShowMessage($"Extra Attribute: {vehicle.GetExtraInfo()}");
    }
    
}