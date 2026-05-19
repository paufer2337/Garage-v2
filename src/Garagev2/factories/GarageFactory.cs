using System;






namespace GarageConsoleApp;

public static class GarageFactory
{
    public static GarageHandler CreateGarage()
    {
        ConsoleUI.ShowHeader("Create Garage");

        ShowGarageTypes();

        int garageChoice = Helpers.GetValidInt("Select garage type: ", 1, 5);
        int capacity = Helpers.GetValidInt("Enter garage capacity: ", 1, 500);
        string garageTypeName = "";

        ConsoleUI.ShowMessage("");

        switch (garageChoice)
        {
            case 1:
                ConsoleUI.ShowSuccess($"Standard Garage created with {capacity} parking spaces.");
                break;

            case 2:
                ConsoleUI.ShowSuccess($"Motorcycle Garage created with {capacity} parking spaces.");
                break;

            case 3:
                ConsoleUI.ShowSuccess($"Bus Garage created with {capacity} parking spaces.");
                break;

            case 4:
                ConsoleUI.ShowSuccess($"Hangar created with {capacity} parking spaces.");
                break;

            case 5:
                ConsoleUI.ShowSuccess($"Harbor created with {capacity} parking spaces.");
                break;
        }


        return new GarageHandler(capacity, garageTypeName);
    }

    private static void ShowGarageTypes()
    {

        ConsoleUI.ShowHeader("Garage Types:");

        ConsoleUI.ShowMessage("[1] Standard Garage");
        ConsoleUI.ShowMessage("[2] Motorcycle Garage");
        ConsoleUI.ShowMessage("[3] Bus Garage");
        ConsoleUI.ShowMessage("[4] Hangar");
        ConsoleUI.ShowMessage("[5] Harbor");
        ConsoleUI.ShowMessage("");

    }
}