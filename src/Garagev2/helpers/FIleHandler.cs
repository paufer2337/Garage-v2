using System;
using System.Text.Json;
using System.Globalization;





namespace GarageConsoleApp;


public static class FileHandler
{
    private static readonly string filePath = 
    Path.Combine(Directory.GetCurrentDirectory(), "Data", "garage.json");

    public static void SaveToFile(GarageHandler garageHandler)
    {
        
        Directory.CreateDirectory("Data");
        
        GarageSaveData saveData = new GarageSaveData
        {
            GarageType = garageHandler.GarageType,
            AllowedVehicleType = garageHandler.AllowedVehicleType,
            Capacity = garageHandler.Capacity,
            Vehicles = garageHandler.GetVehicles().Select(CreateVehicleData).ToList()
        };

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(saveData, options);
        File.WriteAllText(filePath, json);

    }

    public static GarageHandler? LoadFromFile()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine();
            Console.WriteLine($"No file found at: {filePath}");
            return null;
        }

        string json = File.ReadAllText(filePath);
        
        if (string.IsNullOrWhiteSpace(json))
        {
            return null;
        }

        GarageSaveData? saveData = JsonSerializer.Deserialize<GarageSaveData>(json);

        if (saveData == null)
        {
            return null;
        }

        GarageHandler garage = new GarageHandler(
            saveData.Capacity, saveData.GarageType, saveData.AllowedVehicleType);

        
        foreach (VehicleData vehicleData in saveData.Vehicles)
        {
            Vehicle? vehicle = CreateVehicle(vehicleData);

            if (vehicle != null)
            {
                garage.AddVehicle(vehicle);
            }
        }

        return garage;

    }

    private static VehicleData CreateVehicleData(Vehicle vehicle)
    {
        return vehicle switch
        {
            Car car => new VehicleData
            {
                Type = "Car",
                RegNumber = car.RegNumber,
                Color = car.Color,
                WheelAmount = car.WheelAmount,
                Extra = car.FuelType
            },

            Bus bus => new VehicleData
            {
                Type = "Bus",
                RegNumber = bus.RegNumber,
                Color = bus.Color,
                WheelAmount = bus.WheelAmount,
                Extra = bus.SeatAmount.ToString()
            },

            Motorcycle motorcycle => new VehicleData
            {
                Type = "Motorcycle",
                RegNumber = motorcycle.RegNumber,
                Color = motorcycle.Color,
                WheelAmount = motorcycle.WheelAmount,
                Extra = motorcycle.CylinderVolume.ToString()
            },

            Boat boat => new VehicleData
            {
                Type = "Boat",
                RegNumber = boat.RegNumber,
                Color = boat.Color,
                WheelAmount = boat.WheelAmount,
                Extra = boat.Length.ToString(CultureInfo.InvariantCulture)
            },

            Airplane airplane => new VehicleData
            {
                Type = "Airplane",
                RegNumber = airplane.RegNumber,
                Color = airplane.Color,
                WheelAmount = airplane.WheelAmount,
                Extra = airplane.EngineAmount.ToString()
            },

            _ => throw new InvalidOperationException("Unknown vehicle type.")
        };
    }

    private static Vehicle? CreateVehicle(VehicleData vehicleData)
    {
        try
        {
            return vehicleData.Type switch
            {
                "Car" => new Car(
                    vehicleData.RegNumber,
                    vehicleData.Color,
                    vehicleData.WheelAmount,
                    vehicleData.Extra
                ),

                "Bus" => new Bus(
                    vehicleData.RegNumber,
                    vehicleData.Color,
                    vehicleData.WheelAmount,
                    int.Parse(vehicleData.Extra)
                ),

                "Motorcycle" => new Motorcycle(
                    vehicleData.RegNumber,
                    vehicleData.Color,
                    vehicleData.WheelAmount,
                    int.Parse(vehicleData.Extra)
                ),

                "Boat" => new Boat(
                    vehicleData.RegNumber,
                    vehicleData.Color,
                    vehicleData.WheelAmount,
                    double.Parse(vehicleData.Extra, CultureInfo.InvariantCulture)
                ),

                "Airplane" => new Airplane(
                    vehicleData.RegNumber,
                    vehicleData.Color,
                    vehicleData.WheelAmount,
                    int.Parse(vehicleData.Extra)
                ),

                _ => null
            };
        }

        catch
        {
            return null;
        }
    }

    private class GarageSaveData
    {
        public string GarageType { get; set; } = "";
        public string AllowedVehicleType { get; set; } = "";
        public int Capacity { get; set; }
        public List<VehicleData> Vehicles { get; set; } = new();
    }

    private class VehicleData
    {
        public string Type { get; set; } = "";
        public string RegNumber { get; set; } = "";
        public string Color { get; set; } = "";
        public int WheelAmount { get; set; }
        public string Extra { get; set; } = "";
    }

}
