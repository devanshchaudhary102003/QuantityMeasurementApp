using System;

namespace QuantityMeasurementApp.Enums
{
    /// <summary>
    /// Supported temperature units.
    /// Base unit: Celsius
    ///
    /// UC14 RULE:
    /// Temperature supports:
    /// - Equality comparison
    /// - Conversion
    ///
    /// Temperature does NOT support:
    /// - Addition
    /// - Subtraction
    /// - Division
    ///
    /// NOTE:
    /// Temperature conversion is non-linear.
    /// </summary>
    public enum TemperatureUnit
    {
        Celsius,
        Fahrenheit,
        Kelvin
    }

    /// <summary>
    /// Extension methods for TemperatureUnit.
    /// </summary>
    public static class TemperatureUnitExtensions
    {
        /// <summary>
        /// Returns a nominal factor for compatibility.
        /// For temperature, arithmetic conversion is non-linear,
        /// so this is not used for real conversion formulas.
        /// </summary>
        public static double GetConversionFactor(this TemperatureUnit unit)
        {
            return 1.0;
        }

        /// <summary>
        /// Converts temperature value to base unit Celsius.
        /// </summary>
        public static double ConvertToBaseUnit(this TemperatureUnit unit, double value)
        {
            return unit switch
            {
                TemperatureUnit.Celsius => value,
                TemperatureUnit.Fahrenheit => (value - 32.0) * 5.0 / 9.0,
                TemperatureUnit.Kelvin => value - 273.15,
                _ => throw new ArgumentException("Invalid temperature unit.")
            };
        }

        /// <summary>
        /// Converts a Celsius base-unit value to target temperature unit.
        /// </summary>
        public static double ConvertFromBaseUnit(this TemperatureUnit unit, double baseValue)
        {
            return unit switch
            {
                TemperatureUnit.Celsius => baseValue,
                TemperatureUnit.Fahrenheit => (baseValue * 9.0 / 5.0) + 32.0,
                TemperatureUnit.Kelvin => baseValue + 273.15,
                _ => throw new ArgumentException("Invalid temperature unit.")
            };
        }

        public static string GetUnitName(this TemperatureUnit unit)
        {
            return unit switch
            {
                TemperatureUnit.Celsius => "Celsius",
                TemperatureUnit.Fahrenheit => "Fahrenheit",
                TemperatureUnit.Kelvin => "Kelvin",
                _ => throw new ArgumentException("Invalid temperature unit.")
            };
        }

        public static bool SupportsArithmetic(this TemperatureUnit unit)
        {
            return false;
        }

        /// <summary>
        /// Throws a clear exception for unsupported arithmetic operations.
        /// </summary>
        public static void ValidateOperationSupport(this TemperatureUnit unit, string operation)
        {
            throw new UnsupportedOperationException(
                $"Temperature does not support {operation}. " +
                "Only comparison and conversion are supported for temperature measurements.");
        }
    }

    /// <summary>
    /// Simple domain exception for unsupported operations.
    /// </summary>
    public class UnsupportedOperationException : Exception
    {
        public UnsupportedOperationException(string message) : base(message)
        {
        }
    }
}