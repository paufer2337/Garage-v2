using System;
using System.Threading;
using System.Collections;





namespace GarageConsoleApp;


public class GarageHandler
{
    
    private readonly Garage<Vehicle> garage;

    public GarageHandler(int capacity)
    {
        garage = new Garage<Vehicle>(capacity);
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


    public Vehicle?[] GetVehicles()
    {
        return garage.GetVehicles();
    }


    public bool isFull()
    {
        return garage.IsFull();
    }
    
}