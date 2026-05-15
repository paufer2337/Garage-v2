using System;
using System.Threading;




namespace GarageConsoleApp; 

class Program
{
    private static Garage? garage;

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
                        garage!.ParkedVehicles();
                        Helpers.Pause();
                        break;
                    
                    case "2":
                        garage!.VehiclesByType();
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

                    case "8":
                        FileHandler.LoadFromFile(garage!);
                        Helpers.Pause();
                        break;

                    case "99":
                        Console.WriteLine("Exiting the program...");
                        Thread.Sleep(800);
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
        garage = new Garage(capacity);

        Console.WriteLine("|");
        Console.WriteLine($"| ~ Garage created with {capacity} parking slots. ~");
        Thread.Sleep(1500);
    }

    static void PopulateGarage()
    {
        Console.Clear();
        Console.WriteLine("▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▀▄▀▄▀▄▀▄▀▄");
        Console.WriteLine();
        Console.WriteLine("===== POPULATE GARAGE FROM START =====");
        Console.WriteLine();
        Console.WriteLine("▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▀▄▀▄▀▄▀▄▀");
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
        Console.WriteLine("| How many vehicles do you want to add? (max " + garage!.Capacity + "): ");

        int amount;
        while (!int.TryParse(Console.ReadLine(), out amount) || amount < 1 || amount > garage!.Capacity)
        {
            Console.WriteLine();
            Console.Write("| Invalid input. Please enter a valid number of vehicles to add (1-" + garage!.Capacity + "): ");
        }

        Console.Clear();

        for (int i = 0; i < amount; i++)
        {
            AddVehicle();
        }
        
    }

    static void AddVehicle()
    {
        Console.Clear();
        Console.WriteLine(" ▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄");
        Console.WriteLine("|                             |");
        Console.WriteLine("| ==== ADD A NEW VEHICLE ==== |");
        Console.WriteLine("|                             |");
        Console.WriteLine(" ▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀");
        
        if (garage!.IsFull())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("| Garage is full. Cannot add more vehicles.");
            Console.WriteLine("|");
            Console.WriteLine("| Please remove a vehicle before adding a new one.");
            Console.WriteLine("| Or create a new garage with larger capacity.");
            Console.ResetColor();

            Helpers.Pause();
            return;
        }

        Console.WriteLine();
        Console.WriteLine("| Adding a new vehicle to the garage.");
        Console.WriteLine("|");
        Console.WriteLine("| [1] Car");
        Console.WriteLine("| [2] Motorcycle");
        Console.WriteLine("| [3] Bus");
        Console.WriteLine("| [4] Boat");
        Console.WriteLine("| [5] Airplane");
        Console.WriteLine("|");
        Console.WriteLine("| [0] Back");
        Console.WriteLine();
        Console.Write("Select vehicle type: ");

        string? action = Console.ReadLine();

        if (action == "0")
        {
            return;
        }

        Console.WriteLine();

        string regNumber = Helpers.GetValidText("| Enter registration number: ").Replace(" ", "").Replace("-", "").ToUpper();

        while (garage!.RegNrExists(regNumber)) 
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"| Registration number {regNumber} is not unique.");
            Console.Write("| There is already a vehicle registered with that number.");
            Console.WriteLine();
            Console.ResetColor();

            Console.WriteLine();
            regNumber = Helpers.GetValidText("| Please enter a unique registration number: ").Replace(" ", "").Replace("-", "").ToUpper();
        }


        string color = Helpers.GetValidText("| Enter color: ");
        int wheelAmount = Helpers.GetValidInt("| Enter number of wheels: ");
        
        
        Vehicle? vehicle = null;
        switch (action)
        {
            case "1":
                string fuelType = Helpers.GetValidText("| Enter fuel type (Gasoline/Diesel): ");
                vehicle = new Car(regNumber, color, wheelAmount, fuelType);
                break;
            case "2":
                int cylinderVolume = Helpers.GetValidInt("| Enter cylinder volume (cc): ");
                vehicle = new Motorcycle(regNumber, color, wheelAmount, cylinderVolume);
                break;
            case "3":
                int seatAmount = Helpers.GetValidInt("| Enter number of seats: ");
                vehicle = new Bus(regNumber, color, wheelAmount, seatAmount);
                break;
            case "4":
                double length = Helpers.GetValidDouble("| Enter length (Meters): ");
                vehicle = new Boat(regNumber, color, wheelAmount, length);
                break;
            case "5":
                int engineAmount = Helpers.GetValidInt("| Enter number of engines: ");
                vehicle = new Airplane(regNumber, color, wheelAmount, engineAmount);
                break;
            default:
                Console.WriteLine();
                Console.WriteLine("Invalid selection.");
                Helpers.CountDownToMenu();
                return;
        }

        Console.WriteLine();
        bool added = garage!.AddVehicle(vehicle);

        Console.WriteLine();

        if (added)
        {
            Console.WriteLine($"| Vehicle {vehicle.RegNumber} added to the garage.");

            FileHandler.SaveToFile(garage!);
        }
        else
        {
            Console.WriteLine(" Vehicle could not be added.");
        }
        
        Helpers.CountDownToMenu();
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

        bool removed = garage!.RemoveVehicle(regNumber);

        Console.WriteLine();

        if (removed)
        {
            Console.WriteLine($"Vehicle {regNumber} removed from the garage.");

            FileHandler.SaveToFile(garage!);
        }
        else
        {
            Console.WriteLine($"No vehicle with registration number {regNumber} found in the garage.");
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

        Vehicle? foundVehicle = garage!.SearchByRegNr(regNumber);

        Console.WriteLine("|");

        if (foundVehicle != null)
        {
            Console.WriteLine("| Vehicle found:");
            Console.WriteLine("|");
            Console.WriteLine(foundVehicle.GetInfo());
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine($"No vehicle with registration number {regNumber} found in the garage.");
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

        garage!.SearchByProperty(action, searchValue);

        Helpers.Pause();
    }

    
}