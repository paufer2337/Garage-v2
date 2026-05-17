using System;
using System.Threading;



namespace GarageConsoleApp;

public class Bus : Vehicle
{
    public int SeatAmount { get; }

    public Bus(string regNumber, string color, int wheelAmount, int seatAmount)
        : base(regNumber, color, wheelAmount)
    {
        SeatAmount = ValidatePositiveInt(seatAmount, nameof(seatAmount), min: 1, max: 120);
    }

    public override string GetExtraInfo()
    {
        return $"{SeatAmount} seats";
    }
}