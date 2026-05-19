using System;
using System.Text.RegularExpressions;
using System.Linq;




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
        Color = ValidateText(color, nameof(color)).ToUpperInvariant();
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

    private static string ValidateText(string value, string name)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Text value cannot be empty.", name);
        }

        string trimmed = value.Trim();

        if (!trimmed.All(char.IsLetter))
        {
            throw new ArgumentException("Text value can only contain letters.", name);
        }

        return value.Trim();
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
