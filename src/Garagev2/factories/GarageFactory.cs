using System;






namespace GarageConsoleApp;

public static class GarageFactory
{
    public static GarageHandler CreateGarage()
    {
        ConsoleUI.ShowHeader("Create Garage");

        ShowGarageTypes();

        int garageChoice = Helpers.GetValidInt("Select garage type: ", 1, 6);
        int capacity = Helpers.GetValidInt("Enter garage capacity: ", 1, 500);
        string garageTypeName = "";
        string allowedVehicleType = "";


        switch (garageChoice)
        {
            case 1:
                garageTypeName = "Car Garage";
                allowedVehicleType = "Car";
                break;

            case 2:
                garageTypeName = "Motorcycle Garage";
                allowedVehicleType = "Motorcycle";
                break;

            case 3:
                garageTypeName = "Bus Garage";
                allowedVehicleType = "Bus";
                break;

            case 4:
                garageTypeName = "Hangar";
                allowedVehicleType = "Airplane";
                break;

            case 5:
                garageTypeName = "Harbor";
                allowedVehicleType = "Boat";
                break;

            case 6:
                garageTypeName = "Mixed Garage";
                allowedVehicleType = "All";
                break;
        }

        ConsoleUI.ShowSuccess($"{garageTypeName} created with {capacity} parking spaces.");

        return new GarageHandler(capacity, garageTypeName, allowedVehicleType);
    }

    private static void ShowGarageTypes()
    {

        ConsoleUI.ShowHeader("Garage Types:");

        ConsoleUI.ShowMessage("[1] Car Garage");
        ConsoleUI.ShowMessage("[2] Motorcycle Garage");
        ConsoleUI.ShowMessage("[3] Bus Garage");
        ConsoleUI.ShowMessage("[4] Hangar");
        ConsoleUI.ShowMessage("[5] Harbor");
        ConsoleUI.ShowMessage("[6] Mixed Garage");
        ConsoleUI.ShowMessage("");

    }
}