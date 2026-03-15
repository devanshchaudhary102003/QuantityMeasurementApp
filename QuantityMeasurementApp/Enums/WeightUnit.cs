using System;

namespace QuantityMeasurementApp.Enums
{
    /// <summary>
    /// Represents supported units for weight measurement.
    ///
    /// BASE UNIT:
    /// Kilogram is treated as the base unit for all weight conversions.
    ///
    /// SUPPORTED UNITS:
    /// - Kilogram
    /// - Gram
    /// - Pound
    ///
    /// DESIGN NOTE:
    /// Unit-specific conversion logic is encapsulated in extension methods
    /// to maintain separation of concerns and improve scalability.
    /// </summary>
    public enum WeightUnit
    {
        /// <summary>
        /// Represents measurement in kilograms.
        /// Base unit for weight category.
        /// </summary>
        Kilogram,

        /// <summary>
        /// Represents measurement in grams.
        /// 1 Gram = 0.001 Kilogram.
        /// </summary>
        Gram,

        /// <summary>
        /// Represents measurement in pounds.
        /// 1 Pound ≈ 0.453592 Kilogram.
        /// </summary>
        Pound
    }

    /// <summary>
    /// Provides conversion-related behavior for <see cref="WeightUnit"/>.
    ///
    /// RESPONSIBILITY:
    /// - Expose conversion factor relative to base unit
    /// - Convert values to base unit
    /// - Convert values from base unit
    /// - Provide readable unit names
    /// </summary>
    public static class WeightUnitExtension
    {
        /// <summary>
        /// Returns the conversion factor required to convert
        /// the specified weight unit into the base unit (Kilogram).
        /// </summary>
        /// <param name="unit">Weight unit.</param>
        /// <returns>Conversion factor relative to kilogram.</returns>
        public static double GetConversionFactor(this WeightUnit unit)
        {
            return unit switch
            {
                WeightUnit.Kilogram => 1.0,
                WeightUnit.Gram => 0.001,
                WeightUnit.Pound => 0.453592,
                _ => throw new ArgumentException("Unsupported Weight Unit")
            };
        }

        /// <summary>
        /// Converts a value in the specified weight unit
        /// to the base unit (Kilogram).
        /// </summary>
        /// <param name="unit">Source weight unit.</param>
        /// <param name="value">Original value.</param>
        /// <returns>Equivalent value in kilograms.</returns>
        public static double ConvertToBaseUnit(this WeightUnit unit, double value)
        {
            return value * unit.GetConversionFactor();
        }

        /// <summary>
        /// Converts a value from the base unit (Kilogram)
        /// to the specified target unit.
        /// </summary>
        /// <param name="unit">Target weight unit.</param>
        /// <param name="baseValue">Value in kilograms.</param>
        /// <returns>Equivalent value in target unit.</returns>
        public static double ConvertFromBaseUnit(this WeightUnit unit, double baseValue)
        {
            return baseValue / unit.GetConversionFactor();
        }

        /// <summary>
        /// Returns a readable name for the current weight unit.
        /// </summary>
        /// <param name="unit">Weight unit.</param>
        /// <returns>Unit name as string.</returns>
        public static string GetUnitName(this WeightUnit unit)
        {
            return unit.ToString();
        }
        public static void ValidateOperationSupport(this WeightUnit unit, string operation)
        {
            // Weight supports all current arithmetic operations.
        }
    }
}