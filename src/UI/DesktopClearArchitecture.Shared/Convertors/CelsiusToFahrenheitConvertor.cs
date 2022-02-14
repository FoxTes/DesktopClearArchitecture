namespace DesktopClearArchitecture.Shared.Convertors;

using UnitsNet;
using System.Globalization;
using System.Windows.Data;

/// <summary>
/// Converts degrees Celsius to Fahrenheit.
/// </summary>
[ValueConversion(typeof(double), typeof(string))]
public class CelsiusToFahrenheitConvertor : IValueConverter
{
    /// <inheritdoc />
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double temp)
            return Math.Round(Temperature.FromDegreesCelsius(temp).DegreesFahrenheit);
        throw new Exception("Value is not double type.");
    }

    /// <inheritdoc />
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double temp)
            return Math.Round(Temperature.FromDegreesFahrenheit(temp).DegreesCelsius);
        throw new Exception("Value is not double type.");
    }
}