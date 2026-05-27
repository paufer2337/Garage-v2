using GarageConsoleApp;
using Xunit;




namespace App.Tests;

public class TestGarageHandler
{
    [Fact]
    public void AddVehicle_IfGarageHasSpace_ReturnsTrue()
    {
        // arrange
        GarageHandler garageHandler = new(3, "Mixed", "Vehicle");
        Car car = new("ABC123", "Red", 4, "Gasoline");

        // act
        bool result = garageHandler.AddVehicle(car);

        // assert
        Assert.True(result);
    }
}
