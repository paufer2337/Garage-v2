using System.Reflection;
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
}