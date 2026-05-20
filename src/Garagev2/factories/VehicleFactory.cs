using System;
using System.Text.RegularExpressions;





namespace GarageConsoleApp;

public static class VehicleFactory
{
    public static Vehicle? CreateVehicle(GarageHandler garageHandler)
    {
        
        ConsoleUI.ShowHeader("Add Vehicle");
        ConsoleUI.ShowMessage("");
        
        if (garageHandler.AllowedVehicleType != "All")
        {
            ConsoleUI.ShowMessage($"This garage only accepts: {garageHandler.AllowedVehicleType}");
            ConsoleUI.ShowMessage("");

            string regNumber = ReadRegNumber(garageHandler);
            string color = Helpers.GetOnlyText("Enter color: ");
            
            return garageHandler.AllowedVehicleType switch
            {
                "Car" => TryCreate(() => CreateCar(regNumber, color)),
                "Motorcycle" => TryCreate(() => CreateMotorcycle(regNumber, color)),
                "Bus" => TryCreate(() => CreateBus(regNumber, color)),
                "Airplane" => TryCreate(() => CreateAirplane(regNumber, color)),
                "Boat" => TryCreate(() => CreateBoat(regNumber, color)),
                _ => null
            };
        }

        Console.WriteLine("Choose vehicle type:");
        Console.WriteLine();
        Console.WriteLine("[1] Car");
        Console.WriteLine("[2] Motorcycle");
        Console.WriteLine("[3] Bus");
        Console.WriteLine("[4] Boat");
        Console.WriteLine("[5] Airplane");
        Console.WriteLine();
        Console.WriteLine("[0] Back");
        Console.WriteLine();
        Console.Write("Select option: ");

        string? choice = Console.ReadLine();

        if (choice == "0")
        {
            return null;
        }

        string regNumber2 = ReadRegNumber(garageHandler);
        string color2 = Helpers.GetOnlyText("Enter color: ");

        return choice switch
        {
            "1" => TryCreate (() => CreateCar(regNumber2, color2)),
            "2" => TryCreate (() => CreateMotorcycle(regNumber2, color2)),
            "3" => TryCreate (() => CreateBus(regNumber2, color2)),
            "4" => TryCreate (() => CreateBoat(regNumber2, color2)),
            "5" => TryCreate (() => CreateAirplane(regNumber2, color2)),
            _ => null
        };
    }
    

    private static Car CreateCar(string regNumber, string color)
    {
        int wheels = GetExactWheels("Car", 4);
        string fuelType;

        while (true)
        {
            string input = Helpers.GetValidText("Select Fuel Type ( [G] Gasoline / [D] Diesel ): ")
            .Trim().ToUpper();

            switch (input)
            {
                case "G":
                fuelType = "Gasoline";
                break;

                case "D":
                fuelType = "Diesel";
                break;

                default:
                ConsoleUI.ShowMessage("");
                ConsoleUI.ShowError("Invalid fuel type. Please enter 'G' or 'D'.");
                Console.WriteLine();
                continue;
            }

            break;
        }

        return new Car(regNumber, color, wheels, fuelType);
    }

    private static Motorcycle CreateMotorcycle(string regNumber, string color)
    {
        int wheels = GetWheelRange("Motorcycle", 2, 3);
        int cylinderVolume = Helpers.GetValidInt("Enter cylinder volume (cc): ", 50, 2500, "Cylinder volume must be between 50 and 2500 cc.");

        return new Motorcycle(regNumber, color, wheels, cylinderVolume);
    }

    private static Bus CreateBus(string regNumber, string color)
    {
        int wheels = GetBusWheels();
        int seats = Helpers.GetValidInt("Enter number of seats: ", 55, 100, "Bus must have between 55-100 seats.");

        return new Bus(regNumber, color, wheels, seats);
    }

    private static Boat CreateBoat(string regNumber, string color)
    {
        int wheels = GetExactWheels("Boat", 0);
        double length = Helpers.GetValidDouble("Enter length in meters: ", 5, 12, "Boat length must be between 5-12 meters.");

        return new Boat(regNumber, color, wheels, length);
    }

    private static Airplane CreateAirplane(string regNumber, string color)
    {
        int wheels = GetAirplaneWheels();
        int engines = Helpers.GetValidInt("Enter number of engines: ", 1, 2, "Airplane must have 1 or 2 engines.");

        return new Airplane(regNumber, color, wheels, engines);
    }


    private static string ReadRegNumber(GarageHandler garageHandler)
    {
        while (true)
        {
            string regNumber = Helpers
                .GetValidText("Enter registration number: ")
                .Replace(" ", "")
                .Replace("-", "")
                .ToUpper();


            if (!Regex.IsMatch(regNumber, "^[A-Z]{3}[0-9]{3}$"))
            {
                ConsoleUI.ShowError("Registration number must use format ABC123.");
                Console.WriteLine();
                continue;
            }

            if (garageHandler.RegNrExists(regNumber))
            {
                ConsoleUI.ShowError($"Registration number {regNumber} already exists.");
                Console.WriteLine();
                continue;
            }

            return regNumber;
        }
    }

    private static int GetExactWheels(string vehicleType, int expectedWheels)
    {
        while (true)
        {
            int wheels = Helpers.GetValidInt($"Enter number of wheels for {vehicleType}: ");

            if (wheels == expectedWheels)
            {
                return wheels;
            }
            ConsoleUI.ShowError($"{vehicleType} must have {expectedWheels} wheels in this system.");
            Console.WriteLine();
        }
    }

    private static int GetWheelRange(string vehicleType, int min, int max)
    {
        while (true)
        {
            int wheels = Helpers.GetValidInt($"Enter number of wheels for {vehicleType}: ");

            if (wheels >= min && wheels <= max)
            {
                return wheels;
            }

            ConsoleUI.ShowError($"{vehicleType} must have between {min} and {max} wheels.");
            Console.WriteLine();
        }
        
    }

    private static int GetBusWheels()
    {
        while (true)
        {
            int wheels = Helpers.GetValidInt(
            "Enter number of wheels for Bus: ", 4, 6, "Bus must have either 4 or 6 wheels.");

            if (wheels == 4 || wheels == 6)
            {
                return wheels;
            }

            ConsoleUI.ShowError("Bus must have either 4 or 6 wheels.");
            Console.WriteLine();
        }
    }

    private static int GetAirplaneWheels()
    {   
        return Helpers.GetValidInt(
        "Enter number of wheels for Airplane: ", 3, 6, "Airplane must have between 3 and 6 wheels.");
        
    }



    private static Vehicle? TryCreate(Func<Vehicle> createVehicle)
    {
        try
        {
            return createVehicle();
        }
        catch (ArgumentException ex)
        {
            ConsoleUI.ShowError(ex.Message);
            return null;
        }
    }
}