using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;




namespace GarageConsoleApp;


public static class FileHandler
{
    private static readonly string filePath = 
    Path.Combine(Directory.GetCurrentDirectory(), "Data", "garage.csv");

    public static void SaveToFile(Garage garage)
    {
        
        Directory.CreateDirectory("Data");
        
        List<string> lines = new List<string>();
        lines.Add("Type;RegNumber;Color;Wheels;Extra");

        foreach (Vehicle? vehicle in garage.GetVehicles())
        {
            if (vehicle == null)
            {
                continue;
            }


            if (vehicle is Car car)
            {
                lines.Add($"Car;{car.RegNumber};{car.Color};{car.WheelAmount};{car.FuelType}");
            }
            else if (vehicle is Bus bus)
            {
                lines.Add($"Bus;{bus.RegNumber};{bus.Color};{bus.WheelAmount};{bus.SeatAmount}");
            }
            else if (vehicle is Motorcycle motorcycle)
            {
                lines.Add($"Motorcycle;{motorcycle.RegNumber};{motorcycle.Color};{motorcycle.WheelAmount};{motorcycle.CylinderVolume}");
            }
            else if (vehicle is Boat boat)
            {
                lines.Add($"Boat;{boat.RegNumber};{boat.Color};{boat.WheelAmount};{boat.Length}");
            }
            else if (vehicle is Airplane airplane)
            {
                lines.Add($"Airplane;{airplane.RegNumber};{airplane.Color};{airplane.WheelAmount};{airplane.EngineAmount}");
            }
            
        }

        File.WriteAllLines(filePath, lines);
        Console.WriteLine($"| File path: {filePath}");
        Console.WriteLine($"| Vehicles saved: {lines.Count - 1}");
    }

    public static void LoadFromFile(Garage garage)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("|");
            Console.WriteLine($"| No file found at: {filePath}");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        int loadCount = 0;

        foreach (string line in lines.Skip(1))
        {
            string[] parts = line.Split(';');

            if (parts.Length < 5)
            {
                continue;
            }

            string type = parts[0];
            string regNumber = parts[1];
            string color = parts[2];
            int wheelAmount = int.Parse(parts[3]);
            string extraInfo = parts[4];

            Vehicle? vehicle = null;

            switch (type)
            {
                case "Car":
                    vehicle = new Car(regNumber, color, wheelAmount, extraInfo);
                    break;

                case "Bus":
                    vehicle = new Bus(regNumber, color, wheelAmount, int.Parse(extraInfo));
                    break;

                case "Motorcycle":
                    vehicle = new Motorcycle(regNumber, color, wheelAmount, int.Parse(extraInfo));
                    break;

                case "Boat":
                    vehicle = new Boat(regNumber, color, wheelAmount, double.Parse(extraInfo));
                    break;

                case "Airplane":
                    vehicle = new Airplane(regNumber, color, wheelAmount, int.Parse(extraInfo));
                    break;
            }

            if (vehicle != null && garage.AddVehicle(vehicle))
            {
                loadCount++;
            }

        }

        Console.WriteLine("|");
        Console.WriteLine($"| Garage loaded from file: {filePath}");
        Console.WriteLine($"| Total vehicles loaded: {loadCount}");
    }
}