using System.Collections;





namespace GarageConsoleApp;


public class GarageHandler
{
    
    private readonly Garage<Vehicle> garage;

    public string GarageType { get; }
    public string OneVehicleType { get; }
    public int Capacity => garage.Capacity;

    public int Count()
    {
        return garage.Count();
    }

    public GarageHandler(int capacity, string garageType, string oneVehicleType)
    {
        garage = new Garage<Vehicle>(capacity);
        GarageType = garageType;
        OneVehicleType = oneVehicleType;
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


}