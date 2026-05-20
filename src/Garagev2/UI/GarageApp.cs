using System;
using System.Threading;
using System.Linq;




namespace GarageConsoleApp;

public class GarageApp
{
    static GarageHandler? garageHandler;

    public void Run()
    {

        Console.CancelKeyPress += OnExit;

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

            if (action == null)
            {
                Exit();
            }

            switch (action)
            {
                case "1":
                CreateGarage();
                break;

                case "2":
                LoadGarage();
                break;

                case "0":
                ConsoleUI.ShowMessage("Exiting application...", ConsoleColor.Blue);
                Thread.Sleep(1000);
                break;

                default:
                ConsoleUI.ShowMessage("");
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
            
            ConsoleUI.ShowMainMenu(garageHandler!.GarageType, garageHandler.Count(), garageHandler.Capacity);
            action = Console.ReadLine();

            if (action == null)
            {
                Exit();
            }

            switch (action)
            {
                case "1":
                ShowParkedVehicles();
                break;

                case "2":
                ListVehicleTypes();
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
                SearchByProperties();
                break;

                case "7":
                CreateGarage();
                break;

                case "8":
                SaveGarage();
                break;

                case "9":
                LoadGarage();
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
        garageHandler = GarageFactory.CreateGarage();

        ConsoleUI.Pause();
    }

    static void PopulateGarage()
    {
        ConsoleUI.ShowHeader("Populate Garage from Start");
        ConsoleUI.ShowMessage("");

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
        
        if (garageHandler == null)
        {
            Console.Clear();
            ConsoleUI.ShowError("No active garage. Please create a garage first.");
            Helpers.CountDownToMenu();
            return;
        }
        
        
        if (garageHandler!.IsFull())
        {
            Console.Clear();
            ConsoleUI.ShowHeader("Garage is Full!");
            ConsoleUI.ShowMessage("");
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
            ConsoleUI.ShowSuccess($"Vehicle {vehicle.GetType().Name} with registration number {vehicle.RegNumber} added to the garage.");
        }
        else
        {
            ConsoleUI.ShowError("Vehicle could not be added.");
        }
        
        ConsoleUI.Pause();
    } 


    static void RemoveVehicle()
    {
        if (garageHandler == null)
        {
            Console.Clear();
            ConsoleUI.ShowError("No active garage. Please create a garage first.");
            Helpers.CountDownToMenu();
            return;
        }

        ConsoleUI.ShowVehicleList(garageHandler.GetVehicles());
        Console.WriteLine();
        ConsoleUI.ShowMessage(" [0] Back");
        Console.WriteLine();

        int choice = Helpers.GetValidInt(" Select index number to remove the vehicle: ", 0, garageHandler.Count(), "Please select a valid index number or type '0' to go back.");

        if (choice == 0)
        {
            return;
        }

        Vehicle? vehicle = garageHandler.GetVehicleIndex(choice);

        if (vehicle == null)
        {
            ConsoleUI.ShowError("Vehicle could not be found.");
            ConsoleUI.Pause();
            return;
        }

        bool removed = garageHandler.RemoveVehicle(vehicle.RegNumber);


        if (removed)
        {
            ConsoleUI.ShowSuccess($"{vehicle.VehicleType} {vehicle.RegNumber} removed from the garage.");
        }
        else
        {
            ConsoleUI.ShowError("Vehicle could not be removed, please try again.");
        }

        ConsoleUI.Pause();
    } 

    static void LoadGarage()
    {   
        GarageHandler? loadedGarage = FileHandler.LoadFromFile();

        if (loadedGarage == null)
        {
            ConsoleUI.ShowError("No saved garage could be loaded.");
            ConsoleUI.Pause();
        }

        if (garageHandler != null && garageHandler.AllowedVehicleType != loadedGarage!.AllowedVehicleType)
        {
            ConsoleUI.ShowError(
            $"Cannot load saved {loadedGarage.GarageType} into current {garageHandler.GarageType}.");

            ConsoleUI.ShowMessage(
            $"Create a {loadedGarage.GarageType} first if you want to use this saved file.",
            ConsoleColor.Yellow);

            ConsoleUI.Pause();
            return;
        }

        if (garageHandler != null && garageHandler.Count() > 0)
        {
            ConsoleUI.ShowError("\nWarning! Loading this file will replace your current vehicles.");
            ConsoleUI.ShowMessage("Do you want to continue? (y/n): ", ConsoleColor.Yellow);

            string? confirm = Console.ReadLine();

            if (confirm?.ToLower() != "y")
            {
                ConsoleUI.ShowMessage("Load cancelled.", ConsoleColor.DarkYellow);
                ConsoleUI.Pause();
                return;
            }
        }

        garageHandler = loadedGarage;
        ConsoleUI.ShowSuccess("Garage loaded successfully");
        ConsoleUI.Pause();
    }

    static void SaveGarage()
    {
        if (garageHandler == null)
        {
            ConsoleUI.ShowError("No active garage to save.");
        }
        else
        {
            FileHandler.SaveToFile(garageHandler);
            ConsoleUI.ShowSuccess("Garage saved successfully.");
        }

        ConsoleUI.Pause();
    }

    static void SearchByRegNr()
    {
        if (garageHandler == null)
        {
            Console.Clear();
            ConsoleUI.ShowError("No active garage. Please create a garage first.");
            Helpers.CountDownToMenu();
            return;
        }
        ConsoleUI.ShowHeader("Search by Registration Number");
        ConsoleUI.ShowMessage("");

        string regNumber = Helpers.GetValidText("Enter registration number to search: ").ToUpper();

        Vehicle? Vehicle = garageHandler!.FindVehicle(regNumber);


        if (Vehicle == null)
        {
            ConsoleUI.ShowError($"No vehicle with registration number {regNumber} found in the garage.");
        }
        else
        {
            ConsoleUI.ShowSuccess("Vehicle found:");
            ConsoleUI.ShowMessage("");
            ConsoleUI.ShowVehicle(Vehicle);
        }
       

        ConsoleUI.Pause();
    } 


    static void SearchByProperties()
    {
        if (garageHandler == null)
        {
            Console.Clear();
            ConsoleUI.ShowError("No active garage. Please create a garage first.");
            Helpers.CountDownToMenu();
            return;
        }

        ConsoleUI.ShowHeader("Search by Properties");
        ConsoleUI.ShowMessage("[1] Search by vehicle type");
        ConsoleUI.ShowMessage("[2] Search by color");
        ConsoleUI.ShowMessage("[3] Search by wheel amount");
        ConsoleUI.ShowMessage("[4] Combined search");
        ConsoleUI.ShowMessage("");
        ConsoleUI.ShowMessage("[0] Back");        
        ConsoleUI.ShowMessage("");

        string? choice = Console.ReadLine();
        IEnumerable<Vehicle> matches;

        switch (choice)
        {
            case "1":
            string type = Helpers.GetValidText("Enter vehicle type: ");
            matches = garageHandler.FindByType(type);
            break;

            case "2":
                string color = Helpers.GetOnlyText("Enter color: ").ToUpper();
                matches = garageHandler.FindByColor(color);
                break;

            case "3":
                int wheels = Helpers.GetValidInt("Enter wheel amount: ", 0, 20);
                matches = garageHandler.FindByWheels(wheels);
                break;

            case "4":
                matches = CombinedSearch();
                break;

            case "0":
                return;

            default:
                ConsoleUI.ShowError("Invalid selection. Please try again.");
                Console.WriteLine();
                ConsoleUI.Pause();
                return;
        }

        ShowSearchResult(matches);

    }

    static IEnumerable<Vehicle> CombinedSearch()
    {
        ConsoleUI.ShowMessage("Leave empty if you do not want to search by that property.");
        ConsoleUI.ShowMessage("");

        Console.Write("Vehicle type: ");
        string? type = Console.ReadLine();

        Console.Write("Color: ");
        string? color = Console.ReadLine();

        Console.Write("Wheels: ");
        string? wheelsInput = Console.ReadLine();

        int? wheels = null;

        if (int.TryParse(wheelsInput, out int parsedWheels))
        {
            wheels = parsedWheels;
        }

        return garageHandler!.SearchVehicles(type, color, wheels);
    }


    static void ShowSearchResult(IEnumerable<Vehicle> matches)
    {
        ConsoleUI.ShowMessage("");

        if (!matches.Any())
        {
            ConsoleUI.ShowError("No vehicles matched your search.");
        }
        else
        {
            ConsoleUI.ShowVehicleList(matches);
        }

        ConsoleUI.Pause();
    }

    static void ShowParkedVehicles()
    {
        if (garageHandler == null)
        {
            Console.Clear();
            ConsoleUI.ShowError("No active garage. Please create a garage first.");
            Helpers.CountDownToMenu();
            return;
        }

        ConsoleUI.ShowVehicleList(garageHandler.GetVehicles());
        ConsoleUI.Pause();
    }

    static void ListVehicleTypes()
    {
        if (garageHandler == null)
        {
            Console.Clear();
            ConsoleUI.ShowError("No active garage. Please create a garage first.");
            Helpers.CountDownToMenu();
            return;
        }

        Dictionary<string, int> typeCounts = garageHandler.GetVehicleTypeCounts();

        if (!typeCounts.Any())
        {
            ConsoleUI.ShowMessage("There are no parked vehicles yet.", ConsoleColor.DarkYellow);
            ConsoleUI.Pause();
            return;
        }

        ConsoleUI.ShowHeader("Parked Vehicle Types");
        ConsoleUI.ShowMessage("");

        foreach (var type in typeCounts)
        {
            Console.WriteLine($"{type.Key}: {type.Value}");
        }

        ConsoleUI.Pause();
    }

    private static void Exit()
    {
        Console.WriteLine();
        Console.WriteLine();
        ConsoleUI.ShowMessage("Exiting application...", ConsoleColor.Blue);
        
        Thread.Sleep(1000);

        Environment.Exit(0);
    }

    private static void OnExit(object? sender, ConsoleCancelEventArgs e)
    {
        e.Cancel = true;
        
        Console.Clear();

        Exit();
    }

    
}