using System;
using System.Text.RegularExpressions;




namespace GarageConsoleApp;

public abstract class Vehicle : IVehicle
{
    private static readonly Regex RegNumberPattern = new("^[A-Z]{3}[0-9]{3}$", RegexOptions.Compiled);

    public string RegNumber { get; }
    public string Color { get; }
    public int WheelAmount { get; }
    public string VehicleType => GetType().Name;

    protected Vehicle(string regNumber, string color, int wheelAmount)
    {
        RegNumber = NormalizeRegNumber(regNumber);
        ValidateRegNumber(RegNumber);
        Color = ValidateText(color, nameof(color));
        WheelAmount = ValidateWheelAmount(wheelAmount);
    }

    public virtual string GetInfo()
    {
        return $"| {VehicleType} | {RegNumber} | {Color} | {WheelAmount}";
    }

    public virtual string GetExtraInfo()
    {
        return string.Empty;
    }

    private static string NormalizeRegNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Registration number cannot be empty.", nameof(value));
        }

        string normalized = value.Replace(" ", string.Empty)
                                 .Replace("-", string.Empty)
                                 .ToUpperInvariant();

        return normalized;
    }

    private static void ValidateRegNumber(string regNumber)
    {
        if (!RegNumberPattern.IsMatch(regNumber))
        {
            throw new ArgumentException("Registration number must use format ABC123 (three letters followed by three digits).", nameof(regNumber));
        }
    }

    protected static string ValidateText(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Text value cannot be empty.", parameterName);
        }

        return value.Trim();
    }

    protected static int ValidatePositiveInt(int value, string parameterName, int min = 1, int max = int.MaxValue)
    {
        if (value < min)
        {
            throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} must be at least {min}.");
        }

        if (value > max)
        {
            throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} cannot be greater than {max}.");
        }

        return value;
    }

    protected static double ValidatePositiveDouble(double value, string parameterName, double min = 0.1, double max = double.MaxValue)
    {
        if (value < min)
        {
            throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} must be at least {min}.");
        }

        if (value > max)
        {
            throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} cannot be greater than {max}.");
        }

        return value;
    }

    private static int ValidateWheelAmount(int wheelAmount)
    {
        if (wheelAmount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(wheelAmount), "Wheel amount cannot be negative.");
        }

        if (wheelAmount > 18)
        {
            throw new ArgumentOutOfRangeException(nameof(wheelAmount), "Wheel amount is unreasonably large.");
        }

        return wheelAmount;
    }
}
