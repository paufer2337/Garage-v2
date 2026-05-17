using System;
using System.Threading;



namespace GarageConsoleApp;

public class Boat : Vehicle
{
    public double Length { get; }

    public Boat(string regNumber, string color, int wheelAmount, double length)
        : base(regNumber, color, wheelAmount)
    {
        Length = ValidatePositiveDouble(length, nameof(length), min: 0.5, max: 100);
    }

    public override string GetExtraInfo()
    {
        return $"{Length} m";
    }
}