using System;





namespace GarageConsoleApp;

public static class VehicleFactory
{
    public static Vehicle? CreateVehicle(GarageHandler garageHandler)
    {
        ConsoleUI.ShowHeader("Add Vehicle");

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

        string regNumber = ReadRegNumber(garageHandler);
        string color = Helpers.GetValidText("Enter color: ");

        return choice switch
        {
            "1" => CreateCar(regNumber, color),
            "2" => CreateMotorcycle(regNumber, color),
            "3" => CreateBus(regNumber, color),
            "4" => CreateBoat(regNumber, color),
            "5" => CreateAirplane(regNumber, color),
            _ => null
        };
    }

    private static Car CreateCar(string regNumber, string color)
    {
        int wheels = GetExactWheels("Car", 4);
        string fuelType = Helpers.GetValidText("Enter fuel type (Gasoline/Diesel): ");

        return new Car(regNumber, color, wheels, fuelType);
    }

    private static Motorcycle CreateMotorcycle(string regNumber, string color)
    {
        int wheels = GetWheelRange("Motorcycle", 2, 3);
        int cylinderVolume = Helpers.GetValidInt("Enter cylinder volume (cc): ");

        return new Motorcycle(regNumber, color, wheels, cylinderVolume);
    }

    private static Bus CreateBus(string regNumber, string color)
    {
        int wheels = GetWheelRange("Bus", 4, 10);
        int seats = Helpers.GetValidInt("Enter number of seats: ");

        return new Bus(regNumber, color, wheels, seats);
    }

    private static Boat CreateBoat(string regNumber, string color)
    {
        int wheels = GetExactWheels("Boat", 0);
        double length = Helpers.GetValidDouble("Enter length in meters: ");

        return new Boat(regNumber, color, wheels, length);
    }

    private static Airplane CreateAirplane(string regNumber, string color)
    {
        int wheels = GetWheelRange("Airplane", 3, 18);
        int engines = Helpers.GetValidInt("Enter number of engines: ");

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

            if (regNumber.Length != 6)
            {
                ConsoleUI.ShowError("Registration number must be exactly 6 characters, example ABC123.");
                continue;
            }

            if (garageHandler.RegNrExists(regNumber))
            {
                ConsoleUI.ShowError($"Registration number {regNumber} already exists.");
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
        }
    }
}