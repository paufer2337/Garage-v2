using System;
using System.Threading;



namespace GarageConsoleApp;

public class Motorcycle : Vehicle
{
    public int CylinderVolume { get; }

    public Motorcycle(string regNumber, string color, int wheelAmount, int cylinderVolume)
        : base(regNumber, color, wheelAmount)
    {
        CylinderVolume = ValidatePositiveInt(cylinderVolume, nameof(cylinderVolume), min: 50, max: 2500);
    }

    public override string GetExtraInfo()
    {
        return $"{CylinderVolume} cc";
    }
}