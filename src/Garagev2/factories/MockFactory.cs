using System;





namespace GarageConsoleApp;

public static class MockFactory
{
    public static GarageHandler CreateMockGarage(string garageType)
    {
        return garageType switch
        {
            "Car" => CreateCarGarage(),
            "Motorcycle" => CreateMotorcycleGarage(),
            "Bus" => CreateBusGarage(),
            "Boat" => CreateBoatGarage(),
            "Airplane" => CreateAirplaneGarage(),
            "Mixed" => CreateMixedGarage(),
            _ => CreateMixedGarage()
        };
    }

    private static GarageHandler CreateCarGarage()
    {
        GarageHandler garage = new GarageHandler(10, "Car Garage", "Car");

        garage.AddVehicle(new Car("ABC101", "RED", 4, "Gasoline"));
        garage.AddVehicle(new Car("ABC102", "PINK", 4, "Diesel"));
        garage.AddVehicle(new Car("ABC103", "RED", 4, "Gasoline"));
        garage.AddVehicle(new Car("ABC104", "WHITE", 4, "Diesel"));
        garage.AddVehicle(new Car("ABC105", "PINK", 4, "Gasoline"));

        return garage;
    }

    private static GarageHandler CreateMotorcycleGarage()
    {
        GarageHandler garage = new GarageHandler(10, "Motorcycle Garage", "Motorcycle");

        garage.AddVehicle(new Motorcycle("MCY101", "BLACK", 2, 600));
        garage.AddVehicle(new Motorcycle("MCY102", "GREEN", 2, 750));
        garage.AddVehicle(new Motorcycle("MCY103", "BLACK", 3, 900));
        garage.AddVehicle(new Motorcycle("MCY104", "WHITE", 2, 1200));
        garage.AddVehicle(new Motorcycle("MCY105", "GREEN", 2, 250));

        return garage;
    }

    private static GarageHandler CreateBusGarage()
    {
        GarageHandler garage = new GarageHandler(10, "Bus Garage", "Bus");

        garage.AddVehicle(new Bus("BUS101", "YELLOW", 4, 55));
        garage.AddVehicle(new Bus("BUS102", "RED", 6, 55));
        garage.AddVehicle(new Bus("BUS103", "YELLOW", 4, 80));
        garage.AddVehicle(new Bus("BUS104", "WHITE", 6, 80));
        garage.AddVehicle(new Bus("BUS105", "YELLOW", 4, 100));

        return garage;
    }

    private static GarageHandler CreateBoatGarage()
    {
        GarageHandler garage = new GarageHandler(10, "Harbor", "Boat");

        garage.AddVehicle(new Boat("BAT101", "BLUE", 0, 5.5));
        garage.AddVehicle(new Boat("BAT102", "BLUE", 0, 10.0));
        garage.AddVehicle(new Boat("BAT103", "RED", 0, 5.5));
        garage.AddVehicle(new Boat("BAT104", "BLUE", 0, 12.0));
        garage.AddVehicle(new Boat("BAT105", "GREEN", 0, 10.0));

        return garage;
    }

    private static GarageHandler CreateAirplaneGarage()
    {
        GarageHandler garage = new GarageHandler(10, "Hangar", "Airplane");

        garage.AddVehicle(new Airplane("AIR101", "WHITE", 3, 1));
        garage.AddVehicle(new Airplane("AIR102", "BLUE", 4, 2));
        garage.AddVehicle(new Airplane("AIR103", "WHITE", 5, 1));
        garage.AddVehicle(new Airplane("AIR104", "WHITE", 6, 2));
        garage.AddVehicle(new Airplane("AIR105", "GREEN", 3, 1));

        return garage;
    }

    private static GarageHandler CreateMixedGarage()
    {
        GarageHandler garage = new GarageHandler(10, "Mixed Garage", "All");

        garage.AddVehicle(new Car("MIX101", "RED", 4, "Gasoline"));
        garage.AddVehicle(new Motorcycle("MIX102", "BLACK", 2, 600));
        garage.AddVehicle(new Bus("MIX103", "YELLOW", 6, 70));
        garage.AddVehicle(new Boat("MIX104", "WHITE", 0, 8.5));
        garage.AddVehicle(new Airplane("MIX105", "BLUE", 3, 1));

        return garage;
    }
}