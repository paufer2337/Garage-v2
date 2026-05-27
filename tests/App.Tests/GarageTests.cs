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
        Car car = new("ABC123", "Red", 4, "Gasoline");

        // act 
        bool result = garage.AddVehicle(car);

        // assert
        Assert.True(result);
    }

    [Fact]
    public void AddVehicle_WhenAdded_IncreaseCount()
    {
        //arrange
        Garage<Vehicle> garage = new(3);
        Car car = new("ABC123", "Red", 4, "Gasoline");

        //act
        garage.AddVehicle(car);

        // assert
        Assert.Equal(1, garage.Count());

    }

    [Fact]
    public void AddVehicle_IfGarageFull_ReturnFalse()
    {
        // arrange
        Garage<Vehicle> garage = new(1);

        Car firstCar = new("ABC123", "Red", 4, "Gasoline");
        Car secondCar = new("ABC456", "Black", 4, "Diesel");

        garage.AddVehicle(firstCar);

        // act
        bool result = garage.AddVehicle(secondCar);
        
        // assert
        Assert.False(result);
        Assert.Equal(1, garage.Count());
    }

    [Fact]
    public void RemoveVehicle_IfExists_ReturnsTrue()
    {
        // arrange
        Garage<Vehicle> garage = new(3);
        Car car = new("ABC123", "White", 4, "Diesel");
        
        garage.AddVehicle(car);

        // act
        bool result = garage.RemoveVehicle("ABC123");
        
        // assert
        Assert.True(result);

    }

    [Fact]
    public void RemoveVehicle_WhenRemoved_DecreaseCount()
    {
        // arrange
        Garage<Vehicle> garage = new(3);

        Car car = new("ABC123", "Gold", 4, "Gasoline");

        garage.AddVehicle(car);

        // act
        garage.RemoveVehicle("ABC123");
    }


    [Fact]
    public void RemoveVehicle_IfNotExist_ReturnsFalse()
    {
        // arrange
        Garage<Vehicle> garage = new(3);

        Car car = new("ABC123", "Yellow", 4, "Gasoline");

        garage.AddVehicle(car);

        // act
        bool result = garage.RemoveVehicle("ABC456");

        // assert
        Assert.False(result);
    }


    [Fact]
    public void RegNrExists_IfInputIsLowercase_ReturnsTrue()
    {
        // arrange
        Garage<Vehicle> garage = new(3);

        Car car = new("ABC123", "Black", 4, "Diesel");

        garage.AddVehicle(car);

        // act
        bool result = garage.RegNrExists("abc123");

        // assert
        Assert.True(result);
    }



    
}