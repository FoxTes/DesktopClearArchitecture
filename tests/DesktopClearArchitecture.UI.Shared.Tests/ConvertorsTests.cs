namespace DesktopClearArchitecture.UI.Shared.Tests;

using System.Globalization;
using DesktopClearArchitecture.Shared.Convertors;
using FluentAssertions;
using Xunit;

/// <summary>
/// Convertors test.
/// </summary>
public class ConvertorsTests
{
    /// <summary>
    /// Celsius to fahrenheit test.
    /// </summary>
    /// <param name="celsius">Celsius.</param>
    /// <param name="fahrenheit">Fahrenheit.</param>
    [Theory]
    [InlineData(0d, 32d)]
    [InlineData(1d, 34d)]
    [InlineData(-101d, -150d)]
    public void CelsiusToFahrenheitConvertTest(double celsius, double fahrenheit)
    {
        var convertor = new CelsiusToFahrenheitConvertor();

        convertor.Convert(celsius, typeof(double), null, new CultureInfo("en-us"))
            .Should()
            .Be(fahrenheit);
    }

    /// <summary>
    /// Fahrenheit ti celsius test.
    /// </summary>
    [Fact]
    public void FahrenheitToCelsiusConvertTest()
    {
        var convertor = new CelsiusToFahrenheitConvertor();

        convertor.ConvertBack(32d, typeof(double), null, new CultureInfo("en-us"))
            .Should()
            .Be(0d);
    }
}