using System;
using System.Threading;



namespace GarageConsoleApp;

public class Bus : Vehicle
{
    public int SeatAmount { get; }

    public Bus(string regNumber, string color, int wheelAmount, int seatAmount)
        : base(regNumber, color, wheelAmount)
    {
        SeatAmount = seatAmount;
    }

    public override string GetExtraInfo()
    {
        return $"{SeatAmount} seats";
    }
}