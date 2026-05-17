using System.Collections.Generic;





namespace GarageConsoleApp;

public interface IHandler
{
    int Capacity { get; }
    bool IsFull { get; }

    bool CreateGarage(int capacity);
    bool AddVehicle(IVehicle vehicle);
    bool RemoveVehicle(string regNumber);
    bool ContainsRegNumber(string regNumber);
    IVehicle? FindByRegNumber(string regNumber);
    IEnumerable<IVehicle> GetAllVehicles();
    IDictionary<string, int> GetVehicleTypeCounts();
    IEnumerable<IVehicle> SearchVehicles(string? type = null, string? color = null, int? wheels = null);
}
