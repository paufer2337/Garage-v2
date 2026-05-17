using System;
using System.Threading;





namespace GarageConsoleApp;

public class Car : Vehicle
{
    public string FuelType { get; }
    
    public Car(string regNumber, string color, int wheelAmount, string fuelType)
        : base(regNumber, color, wheelAmount)
    {
        FuelType = ValidateText(fuelType, nameof(fuelType));
    }

    public override string GetExtraInfo()
    {
        return $"{FuelType}";
    }
}