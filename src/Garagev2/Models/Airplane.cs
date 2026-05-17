using System;
using System.Threading;


namespace GarageConsoleApp;

public class Airplane : Vehicle
{
    public int EngineAmount { get; }

    public Airplane(string regNumber, string color, int wheelAmount, int engineAmount)
        : base(regNumber, color, wheelAmount)
    {
        EngineAmount = ValidatePositiveInt(engineAmount, nameof(engineAmount), min: 1, max: 12);
    }

    public override string GetExtraInfo()
    {
        return $"{EngineAmount} engines";
    }
}