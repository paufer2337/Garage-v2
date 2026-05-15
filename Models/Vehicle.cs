using System;
using System.Threading;




namespace GarageConsoleApp;

public abstract class Vehicle
{
    
    public string RegNumber { get; }
    public string Color { get; }
    public int WheelAmount { get; }
 

    protected Vehicle(string regNumber, string color, int wheelAmount)
    {
        RegNumber = regNumber.Replace(" ", "").Replace("-", "").ToUpper();
        Color = color;
        WheelAmount = wheelAmount;
    }

    public virtual string GetInfo()
    {
        return $"| {GetType().Name} | {RegNumber} | {Color} | {WheelAmount}";
    }

    public virtual string GetExtraInfo()
    {
        return "";
    }

}