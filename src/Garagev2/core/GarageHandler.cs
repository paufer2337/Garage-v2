using System;
using System.Collections.Generic;
using System.Linq;




namespace GarageConsoleApp;


public class GarageHandler : IHandler
{
    
    private readonly Garage<Vehicle> garage;

    public string GarageType { get; }
    public string AllowedVehicleType { get; }
    public int Capacity => garage.Capacity;

    public int Count()
    {
        return garage.Count();
    }

    public GarageHandler(int capacity, string garageType, string allowedVehicleType)
    {
        garage = new Garage<Vehicle>(capacity);
        GarageType = garageType;
        AllowedVehicleType = allowedVehicleType;
    }

    public bool AddVehicle(Vehicle vehicle)
    {
        return garage.AddVehicle(vehicle);
    }

    public bool RegNrExists(string regNumber)
    {
        return garage.RegNrExists(regNumber);
    }

    
    public bool RemoveVehicle(string regNumber)
    {
        return garage.RemoveVehicle(regNumber);
    }


    public Vehicle? FindVehicle(string regNumber)
    {
        return garage.SearchByRegNr(regNumber);
    }


    public IEnumerable<Vehicle> GetVehicles()
    {
        return garage.GetVehicles();
    }


    public bool IsFull()
    {
        return garage.IsFull();
    }


    public Vehicle? GetVehicleIndex(int index)
    {
        return garage.GetVehicles().ElementAtOrDefault(index - 1);
    }

    public IEnumerable<Vehicle> FindByColor(string color)
    {
        return garage.GetVehicles()
            .Where(vehicle => vehicle.Color.Equals(color, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Vehicle> SearchVehicles(string? type = null, string? color = null, int? wheels = null)
    {
        return garage.GetVehicles()
            .Where(vehicle =>
                (type == null || vehicle.VehicleType.Equals(type, StringComparison.OrdinalIgnoreCase)) &&
                (color == null || vehicle.Color.Equals(color, StringComparison.OrdinalIgnoreCase)) &&
                (wheels == null || vehicle.WheelAmount == wheels));
    }

    public Dictionary<string, int> GetVehicleTypeCounts()
    {
        return garage.GetVehicles()
            .GroupBy(vehicle => vehicle.VehicleType)
            .ToDictionary(group => group.Key, group => group.Count());
    }
}