using System;
using System.Threading;




namespace GarageConsoleApp; 

class Program
{
    private static GarageHandler? garageHandler;

    static void Main()
    {

        CreateGarage();
        PopulateGarage();

        string? action = "";
        while (action != "99")
            {
                Console.Clear();
                Console.WriteLine(" ▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄ ");
                Console.WriteLine("");
                Console.WriteLine("  Welcome to the famous G A R A G E! ");
                Console.WriteLine("");
                Console.WriteLine(" ▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀ ");
                Console.WriteLine();
                Console.WriteLine("| [1] List all parked vehicles       |");
                Console.WriteLine("| [2] Sort vehicle by type/quantity  |");
                Console.WriteLine("|                                    |");
                Console.WriteLine("| [3] ADD vehicle                    |");
                Console.WriteLine("| [4] REMOVE vehicle                 |");
                Console.WriteLine("|                                    |");
                Console.WriteLine("| [5] Search by registration number  |");
                Console.WriteLine("| [6] Search by vehicle properties   |");
                Console.WriteLine("|                                    |");
                Console.WriteLine("| [7] Create new garage              |");
                Console.WriteLine("|                                    |");
                Console.WriteLine("| [8] Load garage from data file     |");
                Console.WriteLine("|                                    |");
                Console.WriteLine("| [99] Exit");
                Console.WriteLine();
                Console.Write("Select an action: ");

                action = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(action))
                {
                    Console.WriteLine("Invalid input. Please enter a number/action from the menu.");
                    Helpers.CountDownToMenu();
                    continue;
                }

                Console.WriteLine();

                switch (action)
                {
                    case "1":
                        ShowParkedVehicles();
                        break;
                    /*
                    case "2":
                        garage!.VehiclesByType();
                        break;
                    */
                    case "3":
                        AddVehicle();
                        break;
                    
                    case "4":
                        RemoveVehicle();
                        break;
                    
                    case "5":
                        SearchByRegNr();
                        break;

                   /* case "6":
                        SearchByProperties();
                        break;
                    */
                    case "7":
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("|");
                        Console.WriteLine("| WARNING:");
                        Console.WriteLine("| Creating a new garage will replace the current garage in memory.");
                        Console.WriteLine("| Autosave may overwrite the saved file when new vehicles are added.");
                        Console.WriteLine("|");
                        Console.ResetColor();
                        Console.WriteLine("|");
                        Console.WriteLine("| You can still load previously saved vehicles if you don't");
                        Console.WriteLine("| add any vehicles and only create a new empty garage.");
                        Console.WriteLine("|");
                        Console.WriteLine("| Do you want to continue creating a new garage? (y/n): ");
                        
                        string? input = Console.ReadLine();
                        
                        if (input?.ToLower() != "y")
                        {
                            Console.WriteLine();
                            Console.WriteLine("~ Action cancelled. Returning to menu. ~");
                            Helpers.CountDownToMenu();
                            break;
                        }

                        Helpers.Pause();
                        
                        CreateGarage(); 
                        PopulateGarage();
                        break;
                    /*
                    case "8":
                        FileHandler.LoadFromFile(garageHandler!);
                        Helpers.Pause();
                        break;
                    */
                    case "99":
                        Console.WriteLine("Exiting the program...");
                        ConsoleUI.Pause();
                        break;

                    default:
                        Console.WriteLine("Invalid selection. Please choose a valid action from the menu.");
                        Helpers.CountDownToMenu();
                        break;
                }
  
        }
        
    }
    
    static void CreateGarage()
    {
        Console.Clear();
        Console.WriteLine(" ▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄");
        Console.WriteLine("|                               |");
        Console.WriteLine("| === BUILDING A NEW GARAGE === |");
        Console.WriteLine("|                               |");
        Console.WriteLine(" ▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀");
        Console.WriteLine();
        Console.WriteLine("| Welcome! Before using the system, you need to create a garage.");
        Console.WriteLine("|");
        Console.Write("| Please enter the capacity of the garage (number of parking spots): ");

        int capacity;
        while (!int.TryParse(Console.ReadLine(), out capacity) || capacity < 3)
        {
            Console.WriteLine();
            Console.Write("| Invalid input. Please enter a valid capacity for the garage (minimum 3): ");
        }
        garageHandler = new GarageHandler(capacity);

        Console.WriteLine("|");
        Console.WriteLine($"| ~ Garage created with {capacity} parking slots. ~");
        Thread.Sleep(1500);
    }

    static void PopulateGarage()
    {
        Console.Clear();
        Console.WriteLine("▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▀▄▀▄▀▄▀▄▀");
        Console.WriteLine();
        Console.WriteLine(" ==== POPULATE GARAGE FROM START ====");
        Console.WriteLine();
        Console.WriteLine("▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀");
        Console.WriteLine();
        Console.Write("| Do you want to add vehicles from start? (y/n): ");

        string? input = Console.ReadLine();

        if (input?.ToLower() != "y")
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("~ Garage starts empty. ~");
            Helpers.CountDownToMenu();
            return;
        }
        
        Console.WriteLine("|");
        Console.WriteLine("| How many vehicles do you want to add? (max " + garageHandler!.IsFull() + "): ");

        int amount;
        while (!int.TryParse(Console.ReadLine(), out amount) || amount < 1 || amount > garageHandler!.Capacity)
        {
            Console.WriteLine();
            Console.Write("| Invalid input. Please enter a valid number of vehicles to add (1-" + garageHandler!.Capacity + "): ");
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
            ConsoleUI.ShowHeader("| Garage is Full");
            ConsoleUI.ShowError("| Remove a vehicle or create a larger garage first.");
            ConsoleUI.Pause();
            return;
        }
    
        
        Vehicle? vehicle = VehicleFactory.CreateVehicle(garageHandler);


        if (vehicle == null)
        {
            Console.WriteLine("| Vehicle creation cancelled. Returning to menu.");
            Helpers.CountDownToMenu();
            return;
        }

        bool added = garageHandler.AddVehicle(vehicle);

        if (added)
        {
            ConsoleUI.ShowSuccess($"| Vehicle {vehicle.RegNumber} added to the garage.");

            //FileHandler.SaveToFile(garageHandler!);
        }
        else
        {
            ConsoleUI.ShowError("| Vehicle could not be added.");
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
            ConsoleUI.ShowSuccess($"| Vehicle {regNumber} removed from the garage.");

            //FileHandler.SaveToFile(garageHandler!);
        }
        else
        {
            ConsoleUI.ShowError($"| No vehicle with registration number {regNumber} found in the garage.");
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
            ConsoleUI.ShowSuccess("| Vehicle found:");
            Console.WriteLine("|");
            Console.WriteLine(foundVehicle.GetInfo());
        }
        else
        {
            ConsoleUI.ShowError($"| No vehicle with registration number {regNumber} found in the garage.");
        }

        Helpers.Pause();
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

        Helpers.Pause();
    }


    static void ShowParkedVehicles()
    {
        Console.Clear();
        Console.WriteLine(" ▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄ ");
        Console.WriteLine("|                                   |");
        Console.WriteLine("|   PARKED VEHICLES IN THE GARAGE   |");
        Console.WriteLine("|                                   |");
        Console.WriteLine(" ▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀ ");
        Console.WriteLine();

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
            Console.WriteLine("~ No parked vehicles found. ~");
        }

        Helpers.Pause();
    }

    
}