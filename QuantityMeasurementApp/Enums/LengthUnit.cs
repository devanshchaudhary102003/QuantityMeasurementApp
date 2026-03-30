using System;

namespace QuantityMeasurementApp.Enums
{
    /// <summary>
    /// Represents supported units for length measurement.
    ///
    /// BASE UNIT:
    /// Feet is treated as the base unit for all length conversions.
    ///
    /// SUPPORTED UNITS:
    /// - Feet
    /// - Inch
    /// - Yard
    /// - Centimeter
    ///
    /// DESIGN NOTE:
    /// Conversion responsibility is centralized through extension methods,
    /// which keeps the enum lightweight while preserving clean separation
    /// of concerns.
    /// </summary>
    public enum LengthUnit
    {
        /// <summary>
        /// Represents measurement in feet.
        /// Base unit for length category.
        /// </summary>
        Feet,

        /// <summary>
        /// Represents measurement in inches.
        /// 1 Inch = 1/12 Feet.
        /// </summary>
        Inch,

        /// <summary>
        /// Represents measurement in yards.
        /// 1 Yard = 3 Feet.
        /// </summary>
        Yard,

        /// <summary>
        /// Represents measurement in centimeters.
        /// 1 Centimeter = 1 / 30.48 Feet.
        /// </summary>
        Centimeter
    }

    /// <summary>
    /// Provides conversion-related behavior for <see cref="LengthUnit"/>.
    ///
    /// RESPONSIBILITY:
    /// - Expose conversion factor relative to base unit
    /// - Convert values to base unit
    /// - Convert values from base unit
    /// - Provide readable unit names
    ///
    /// DESIGN BENEFITS:
    /// - Centralized conversion logic
    /// - Improved maintainability
    /// - Reduced duplication across quantity models
    /// </summary>
    public static class LengthUnitExtension
    {
        /// <summary>
        /// Returns the conversion factor required to convert
        /// the specified length unit into the base unit (Feet).
        /// </summary>
        /// <param name="unit">Length unit.</param>
        /// <returns>Conversion factor relative to feet.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when an unsupported enum value is supplied.
        /// </exception>
        public static double GetConversionFactor(this LengthUnit unit)
        {
            return unit switch
            {
                LengthUnit.Feet => 1.0,
                LengthUnit.Inch => 1.0 / 12.0,
                LengthUnit.Yard => 3.0,
                LengthUnit.Centimeter => 1.0 / 30.48,
                _ => throw new ArgumentException("Unsupported Length Unit")
            };
        }

        /// <summary>
        /// Converts a value in the specified unit to the base unit (Feet).
        /// </summary>
        /// <param name="unit">Source unit.</param>
        /// <param name="value">Original value.</param>
        /// <returns>Equivalent value in feet.</returns>
        public static double ConvertToBaseUnit(this LengthUnit unit, double value)
        {
            return value * unit.GetConversionFactor();
        }

        /// <summary>
        /// Converts a value from the base unit (Feet) to the specified unit.
        /// </summary>
        /// <param name="unit">Target unit.</param>
        /// <param name="baseValue">Value in feet.</param>
        /// <returns>Equivalent value in target unit.</returns>
        public static double ConvertFromBaseUnit(this LengthUnit unit, double baseValue)
        {
            return baseValue / unit.GetConversionFactor();
        }

        /// <summary>
        /// Returns a readable name for the current length unit.
        /// </summary>
        /// <param name="unit">Length unit.</param>
        /// <returns>Unit name as string.</returns>
        public static string GetUnitName(this LengthUnit unit)
        {
            return unit.ToString();
        }
        public static void ValidateOperationSupport(this LengthUnit unit, string operation)
        {
            // Length supports all current arithmetic operations.
        }
    }
}