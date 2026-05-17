using System;
using System.Threading;





namespace GarageConsoleApp;


public class Garage
{
    private Vehicle?[] vehicles;
    public int Capacity { get; }

    public Garage(int capacity)
    {
        Capacity = capacity;
        vehicles = new Vehicle?[capacity];
    }

    
    public bool AddVehicle(Vehicle vehicle)
    {
        
        foreach (Vehicle? parkedVehicle in vehicles)
        {
            if (parkedVehicle != null && parkedVehicle.RegNumber.ToUpper() == vehicle.RegNumber.ToUpper())
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
        public bool garageFUll()
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

        public bool RegNrExists(string regNumber)
        {
            
            string checkRegNr = regNumber.Replace(" ", "").Replace("-", "").ToUpper();
            
            foreach (Vehicle? parkedVehicle in vehicles)
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
        for (int i = 0; i < Capacity; i++)
        {
            if (vehicles[i] != null && vehicles[i]!.RegNumber.ToUpper() == regNumber.ToUpper())
            {
                vehicles[i] = null;
                return true;
            }
        }
        return false;
    }

    public void ParkedVehicles()
    {
        Console.Clear();
        Console.WriteLine(" ▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄ ");
        Console.WriteLine("|                                   |");
        Console.WriteLine("|   PARKED VEHICLES IN THE GARAGE   |");
        Console.WriteLine("|                                   |");
        Console.WriteLine(" ▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀ ");
        Console.WriteLine();

        bool foundVehicle = false;
        int vehicleNr = 1;

        Console.WriteLine("| No.  Type       RegNr       Color        Wheels     Extra              |");
        Console.WriteLine("| ---------------------------------------------------------------------- |");

        foreach (Vehicle? parkedVehicle in vehicles)
        {
            if (parkedVehicle != null)
            {
                Console.WriteLine($"| [{vehicleNr}] " + 
                $"{parkedVehicle.GetType().Name,-13}" + 
                $"{parkedVehicle.RegNumber,-12}" + 
                $"{parkedVehicle.Color,-14}" + 
                $"{parkedVehicle.WheelAmount,-8}" + 
                $"{parkedVehicle.GetExtraInfo(),-19} |");
                vehicleNr++;
                foundVehicle = true;
            }
        }

        if (!foundVehicle)
        {
            Console.WriteLine("~ No parked vehicles found. ~");
        }
    }

    public void SearchByProperty(string? propertyChoice, string searchValue)
    {
        Console.Clear();
        Console.WriteLine(" ▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄");
        Console.WriteLine("|                             |");
        Console.WriteLine("|     SEARCH BY PROPERTY      |");
        Console.WriteLine("|                             |");
        Console.WriteLine(" ▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀");
        Console.WriteLine();

        bool foundVehicle = false;
        int vehicleNr = 1;

        string search = searchValue.ToUpper();

        Console.WriteLine("| No.  Type       RegNr       Color        Wheels     Extra              |");
        Console.WriteLine("| ---------------------------------------------------------------------- |");    

        foreach (Vehicle? parkedVehicle in vehicles)
        {
            if (parkedVehicle == null)
            {
                continue;
            };

            bool match = false;


            switch (propertyChoice)
            {
                case "1":
                    match = parkedVehicle.GetType().Name.ToUpper() == search;
                    break;

                case "2":
                    match = parkedVehicle.Color.ToUpper() == search;
                    break;

                case "3":
                    match = parkedVehicle.WheelAmount.ToString() == search;
                    break;

                default:
                    Console.WriteLine("Invalid property choice.");
                    return;
            }

            if (match)
            {
                Console.WriteLine($"| [{vehicleNr}] " + 
                $"{parkedVehicle.GetType().Name,-13}" + 
                $"{parkedVehicle.RegNumber,-12}" + 
                $"{parkedVehicle.Color,-14}" + 
                $"{parkedVehicle.WheelAmount,-8}" + 
                $"{parkedVehicle.GetExtraInfo(),-19} |");

                vehicleNr++;
                foundVehicle = true;
            }
        }

        if (!foundVehicle)
        {
            Console.WriteLine("~ No matching vehicles found. ~");
        }
    }



    public void VehiclesByType()
    {
        Console.Clear();
        Console.WriteLine(" ▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄");
        Console.WriteLine("|                             |");
        Console.WriteLine("|   VEHICLES BY TYPE / QTY    |");
        Console.WriteLine("|                             |");
        Console.WriteLine(" ▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀");
        Console.WriteLine();

        int cars = 0;
        int motorcycles = 0;
        int buses = 0;
        int boats = 0;
        int airplanes = 0;

        foreach (Vehicle? parkedVehicle in vehicles)
        {
            if (parkedVehicle is Car)
            {
                cars++;
            }
            else if (parkedVehicle is Motorcycle)
            {
                motorcycles++;
            }
            else if (parkedVehicle is Bus)
            {
                buses++;
            }
            else if (parkedVehicle is Boat)
            {
                boats++;
            }
            else if (parkedVehicle is Airplane)
            {
                airplanes++;
            }
            else
            {
                continue;
            }
   
        }

        int totalCount = cars + motorcycles + buses + boats + airplanes;

        if (totalCount == 0)
        {
            Console.WriteLine("~ No parked vehicles found. ~");
            Helpers.Pause();
            return;
        }

        Console.WriteLine("| Type            | Quantity |");
        Console.WriteLine("| -------------------------- |");
        Console.WriteLine($"| Car             | {cars, 8} |");
        Console.WriteLine($"| Motorcycle      | {motorcycles, 8} |");
        Console.WriteLine($"| Bus             | {buses, 8} |");
        Console.WriteLine($"| Boat            | {boats, 8} |");
        Console.WriteLine($"| Airplane        | {airplanes, 8} |");
        Console.WriteLine("| -------------------------- |");
        Console.WriteLine($"| Total           | {totalCount, 8} |");

        Helpers.Pause();
    }


    public Vehicle? SearchByRegNr(string regNumber)
    {
        foreach (Vehicle? parkedVehicle in vehicles)
        {
            if (parkedVehicle != null && parkedVehicle.RegNumber == regNumber)
            {
                return parkedVehicle;
            }
        }

        return null;
    }


    public Vehicle?[] GetVehicles()
    {
        return vehicles;
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
    
}