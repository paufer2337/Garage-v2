using System;
using System.Threading;



namespace GarageConsoleApp;

public class Motorcycle : Vehicle
{
    public int CylinderVolume { get; }

    public Motorcycle(string regNumber, string color, int wheelAmount, int cylinderVolume)
        : base(regNumber, color, wheelAmount)
    {
        CylinderVolume = cylinderVolume;
    }

    public override string GetExtraInfo()
    {
        return $"{CylinderVolume} cc";
    }
}