using System;
using System.Threading;
using System.Linq;




namespace GarageConsoleApp; 

class Program
{
    static GarageHandler? garageHandler;

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
            
            ConsoleUI.ShowMainMenu(garageHandler!.GarageType, garageHandler.Count(), garageHandler.Capacity);
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

        ConsoleUI.ShowHeader("Remove Vehicle");
        ConsoleUI.ShowVehicleList(garageHandler.GetVehicles());
        Console.WriteLine();
        ConsoleUI.ShowMessage(" [0] Back");
        Console.WriteLine();

        string regNumber = Helpers.GetValidText("Enter registration number of the vehicle to remove: ").ToUpper();

        if (regNumber == "0")
        {
            return;
        }

        bool removed = garageHandler!.RemoveVehicle(regNumber);


        if (removed)
        {
            ConsoleUI.ShowSuccess($"Vehicle {regNumber} removed from the garage.");

            //FileHandler.SaveToFile(garageHandler!);
        }
        else
        {
            ConsoleUI.ShowError($"No vehicle with registration number {regNumber} found in the garage.");
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
        ConsoleUI.ShowMessage("");

        string color = Helpers.GetValidText("Enter color to search: ").ToUpper();

        IEnumerable<Vehicle> vehicles = garageHandler.GetVehicles();

        IEnumerable<Vehicle> matches = vehicles.Where(v =>
        v. Color.Equals(color, StringComparison.OrdinalIgnoreCase));

        ConsoleUI.ShowMessage("");
        ConsoleUI.ShowVehicleList(matches);
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

    
}