using System.Reflection;
using System.Runtime.CompilerServices;
using GarageConsoleApp;
using Xunit;





namespace App.Tests;


public class GarageTests
{
    
    [Fact]
    public void Count_IfGarageIsEmpty_ReturnsZero()
    {
        // arrange
        Garage<Vehicle> garage = new(3);

        // act
        int result = garage.Count();

        // assert
        Assert.Equal(0, result);
    }


    [Fact]
    public void AddVehicle_IfGarageHasSpace_ReturnsTrue()
    {
        //arrange
        Garage<Vehicle> garage = new(3);

        // act 
        bool result = garage.AddVehicle(car);

        // assert
        Assert.True(result);
    }
}