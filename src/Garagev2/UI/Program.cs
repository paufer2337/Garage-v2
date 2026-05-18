using System;
using System.Threading;




namespace GarageConsoleApp; 

class Program
{
    private static GarageHandler? garageHandler;

    static void Main()
    {

        ShowStartMenu();

        if (garageHandler == null)
        {
            return;
        }

        ShowMainMenu();
    }

    static void ShowStartMenu()
    {
        
        string? action = "";

        while (action != "0" && garageHandler == null)
        {
            
            ConsoleUI.ShowStartMenu();
            action = Console.ReadLine();

            switch (action)
            {
                case "1":
                CreateGarage();
                break;

                case "2":
                ConsoleUI.ShowMessage("Load from file will be added later.", ConsoleColor.Yellow);
                ConsoleUI.Pause();
                break;

                case "0":
                ConsoleUI.ShowMessage("Exiting application...", ConsoleColor.Blue);
                Thread.Sleep(1000);
                break;

                default:
                ConsoleUI.ShowError("Invalid selection. Please try again.");
                ConsoleUI.Pause();
                break;
            }
        }
    }


    static void ShowMainMenu()
    {
        string? action = "";

        while (action != "0")
        {
            
            ConsoleUI.ShowMainMenu("Garage", 0, garageHandler!.Capacity);
            action = Console.ReadLine();

            switch (action)
            {
                case "1":
                ShowParkedVehicles();
                break;

                case "2":
                ConsoleUI.ShowMessage("Vehicle will be added later.", ConsoleColor.Yellow);
                ConsoleUI.Pause();
                break;

                case "3":
                AddVehicle();
                break;

                case "4":
                RemoveVehicle();
                break;

                case "5":
                SearchByRegNr();
                break;

                case "6":
                ConsoleUI.ShowMessage("Search by properties will be added later.", ConsoleColor.Yellow);
                ConsoleUI.Pause();
                break;

                case "7":
                CreateGarage();
                break;

                case "8":
                ConsoleUI.ShowMessage("Save garage will be added later.", ConsoleColor.Yellow);
                ConsoleUI.Pause();
                break;

                case "9":
                ConsoleUI.ShowMessage("Load garage will be added later.", ConsoleColor.Yellow);
                ConsoleUI.Pause();
                break;

                case "0":
                ConsoleUI.ShowMessage("Exiting application...", ConsoleColor.Blue);
                Thread.Sleep(1000);
                break;

                default:
                ConsoleUI.ShowError("Invalid selection. Please try again.");
                ConsoleUI.Pause();
                break;
            }
        }
    }

  
        
        
    
    static void CreateGarage()
    {
        GarageHandler? newGarage = GarageFactory.CreateGarage();

        if (newGarage == null)
        {
            ConsoleUI.ShowMessage("No garage was created.", ConsoleColor.DarkYellow);
            ConsoleUI.Pause();
            return;
        }

        garageHandler = newGarage;
        ConsoleUI.ShowSuccess("Garage created successfully.");
        ConsoleUI.Pause();
    }

    static void PopulateGarage()
    {
        ConsoleUI.ShowHeader("Populate Garage from Start");

        string? input = Console.ReadLine();

        if (input?.ToLower() != "y")
        {
            Console.Clear();
            Console.WriteLine();
            ConsoleUI.ShowMessage("~ Garage starts empty. ~", ConsoleColor.DarkYellow);
            Helpers.CountDownToMenu();
            return;
        }
        
        Console.WriteLine("");
        ConsoleUI.ShowMessage("How many vehicles do you want to add? (max " + garageHandler!.IsFull() + "): ");

        int amount;
        while (!int.TryParse(Console.ReadLine(), out amount) || amount < 1 || amount > garageHandler!.Capacity)
        {
            Console.WriteLine();
            ConsoleUI.ShowMessage("Invalid input.", ConsoleColor.DarkYellow);
            ConsoleUI.ShowMessage("Please enter a valid number of vehicles to add (1-" + garageHandler!.Capacity + "): ");
        }

        Console.Clear();

        for (int i = 0; i < amount; i++)
        {
            AddVehicle();
        }
        
    }

    static void AddVehicle()
    {
        
        if (garageHandler!.IsFull())
        {
            ConsoleUI.ShowHeader("Garage is Full!");
            ConsoleUI.ShowError("Remove a vehicle or create a larger garage first.");
            ConsoleUI.Pause();
            return;
        }
    
        
        Vehicle? vehicle = VehicleFactory.CreateVehicle(garageHandler);


        if (vehicle == null)
        {
            ConsoleUI.ShowError("Vehicle creation cancelled. Returning to menu.");
            Helpers.CountDownToMenu();
            return;
        }

        bool added = garageHandler.AddVehicle(vehicle);

        if (added)
        {
            ConsoleUI.ShowSuccess($"Vehicle {vehicle.RegNumber} added to the garage.");

            //FileHandler.SaveToFile(garageHandler!);
        }
        else
        {
            ConsoleUI.ShowError("Vehicle could not be added.");
        }
        
        ConsoleUI.Pause();
    } 


    static void RemoveVehicle()
    {
        Console.Clear();
        Console.WriteLine(" ▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄");
        Console.WriteLine("|                             |");
        Console.WriteLine("| ==== REMOVE A VEHICLE ====  |");
        Console.WriteLine("|                             |");
        Console.WriteLine(" ▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀");
        Console.WriteLine();
        Console.WriteLine("| Removing a vehicle from the garage.");
        Console.WriteLine("|");
        string regNumber = Helpers.GetValidText("| Enter registration number of the vehicle to remove: ").ToUpper();

        bool removed = garageHandler!.RemoveVehicle(regNumber);

        Console.WriteLine();

        if (removed)
        {
            ConsoleUI.ShowSuccess($"Vehicle {regNumber} removed from the garage.");

            //FileHandler.SaveToFile(garageHandler!);
        }
        else
        {
            ConsoleUI.ShowError($"No vehicle with registration number {regNumber} found in the garage.");
        }

        Helpers.CountDownToMenu();
    } 

    static void SearchByRegNr()
    {
        Console.Clear();
        Console.WriteLine(" ▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄");
        Console.WriteLine("|                             |");
        Console.WriteLine("|   SEARCH VEHICLE BY REGNR   |");
        Console.WriteLine("|                             |");
        Console.WriteLine(" ▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀");
        Console.WriteLine();
        Console.WriteLine("| Searching for a vehicle by registration number.");
        Console.WriteLine("|");
        string regNumber = Helpers.GetValidText("| Enter registration number to search: ").ToUpper();

        Vehicle? foundVehicle = garageHandler!.FindVehicle(regNumber);

        Console.WriteLine("|");

        if (foundVehicle != null)
        {
            ConsoleUI.ShowSuccess("Vehicle found:");
            Console.WriteLine("");
            Console.WriteLine(foundVehicle.GetInfo());
        }
        else
        {
            ConsoleUI.ShowError($"No vehicle with registration number {regNumber} found in the garage.");
        }

        ConsoleUI.Pause();
    } 


    static void SearchByProperties()
    {
        Console.Clear();
        Console.WriteLine("  ▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄");
        Console.WriteLine("|                              |");
        Console.WriteLine("| SEARCH VEHICLE BY PROPERTIES |");
        Console.WriteLine("|                              |");
        Console.WriteLine("  ▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀");
        Console.WriteLine();
        Console.WriteLine("| [1] Type");
        Console.WriteLine("| [2] Color");
        Console.WriteLine("| [3] Wheels");
        Console.WriteLine("|");
        Console.WriteLine("| [0] Back");


        Console.WriteLine();

        Console.Write("Select property to search by: ");
        string? action = Console.ReadLine();

        if (action == "0")
        {
            return;
        }

       
        string searchValue = Helpers.GetValidText("| Search for: ");

        // garageHandler!.SearchByProperty(action, searchValue);

        ConsoleUI.Pause();
    }


    static void ShowParkedVehicles()
    {
        ConsoleUI.ShowHeader("Parked Vehicles");

        Vehicle?[] vehicles = garageHandler!.GetVehicles();

        bool foundVehicle = false;
        int vehicleNr = 1;

        Console.WriteLine("| No.  Type       RegNr       Color        Wheels     Extra              |");
        Console.WriteLine("| ---------------------------------------------------------------------- |");

        foreach (Vehicle? parkedVehicle in vehicles)
        {
            if (parkedVehicle != null)
            {
                Console.WriteLine($"| [{vehicleNr}] " +
                $"{parkedVehicle.GetType().Name,-13}" +
                $"{parkedVehicle.RegNumber,-12}" +
                $"{parkedVehicle.Color,-14}" +
                $"{parkedVehicle.WheelAmount,-8}" +
                $"{parkedVehicle.GetExtraInfo(),-19} |");

                vehicleNr++;
                foundVehicle = true;
            }
        }

        if (!foundVehicle)
        {
            ConsoleUI.ShowMessage("~ No parked vehicles found. ~", ConsoleColor.DarkYellow);
        }

        ConsoleUI.Pause();
    }

    
}