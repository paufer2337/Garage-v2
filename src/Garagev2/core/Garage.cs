using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;






namespace GarageConsoleApp;


public class Garage <T> : IEnumerable<T> where T : Vehicle
{
    private readonly T?[] vehicles;
    public int Capacity { get; }

    public Garage(int capacity)
    {
        Capacity = capacity;
        vehicles = new T?[capacity];
    }

    
    public bool AddVehicle(T vehicle)
    {
        
        if (RegNrExists(vehicle.RegNumber))
        {
            {
                return false;
            }
        }

        for (int i = 0; i < Capacity; i++)
        {
            if (vehicles[i] == null)
            {
                vehicles[i] = vehicle;
                return true;
            }
        }
        return false;

        
    }

        public bool RegNrExists(string regNumber)
        {
            
            string checkRegNr = NormalizeRegNumber(regNumber);
            
            foreach (T? parkedVehicle in vehicles)
            {
                if (parkedVehicle != null && parkedVehicle.RegNumber.ToUpper() == checkRegNr)
                {
                    return true;
                }
            }
            return false;
        }

    public bool RemoveVehicle(string regNumber)
    {
        
        string checkRegNr = NormalizeRegNumber(regNumber);
        
        for (int i = 0; i < Capacity; i++)
        {
            if (vehicles[i] != null && vehicles[i]!.RegNumber == checkRegNr)
            {
                vehicles[i] = null;
                return true;
            }
        }
        return false;
    } 



    public T? SearchByRegNr(string regNumber)
    {
        foreach (T? parkedVehicle in vehicles)
        {
            if (parkedVehicle != null && parkedVehicle.RegNumber == regNumber)
            {
                return parkedVehicle;
            }
        }

        return null;
    }


    public IEnumerable<T> GetVehicles()
    {
        foreach (T? vehicle in vehicles)
        {
            if (vehicle != null)
            {
                yield return vehicle;
            }
        }
    }

    
    public bool IsFull()
    {
        for (int i = 0; i < Capacity; i++)
        {
            if (vehicles[i] == null)
            {
                return false;
            }
        }

        return true;
    }

    public int Count()
    {
        int count = 0;

        foreach (T? vehicle in vehicles)
        {
            if (vehicle != null)
            {
                count++;
            }
        }
        return count;   

    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (T? vehicle in vehicles)
        {
            if (vehicle != null)
            {
                yield return vehicle;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private static string NormalizeRegNumber(string regNumber)
    {
        return regNumber.Replace(" ", "").Replace("-", "").ToUpper();
    }
    
}