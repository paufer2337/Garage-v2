namespace GarageConsoleApp;

public interface IVehicle
{
    string RegNumber { get; }
    string Color { get; }
    int WheelAmount { get; }
    string VehicleType { get; }

    string GetInfo();
    string GetExtraInfo();
}
