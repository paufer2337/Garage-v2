using System.Collections;
using System.Linq;





namespace GarageConsoleApp;


public class GarageHandler
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
}