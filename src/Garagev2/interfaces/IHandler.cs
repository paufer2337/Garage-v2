using System.Collections.Generic;





namespace GarageConsoleApp;

public interface IHandler
{
    int Capacity { get; }
    string GarageType { get; }
    string AllowedVehicleType { get; }


    bool AddVehicle(Vehicle vehicle);
    bool RemoveVehicle(string regNumber);
    bool RegNrExists(string regNumber);
    bool IsFull();

    int Count();

    Vehicle? FindVehicle(string regNumber);
    Vehicle? GetVehicleIndex(int index);

    IEnumerable<Vehicle> GetVehicles();
    IEnumerable<Vehicle> FindByColor(string color);
    IEnumerable<Vehicle> SearchVehicles(string? type = null, string? color = null, int? wheels = null);

    Dictionary<string, int> GetVehicleTypeCounts();
}
