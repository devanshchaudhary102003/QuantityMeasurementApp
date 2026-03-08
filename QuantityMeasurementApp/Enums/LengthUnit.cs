using System;

namespace QuantityMeasurementApp.Enums
{
    /// <summary>
    /// Defines the supported units for length measurement.
    /// 
    /// This enumeration is intentionally minimal and represents
    /// all valid length units supported by the application.
    /// 
    /// The base unit of the system is defined as <see cref="LengthUnit.Feet"/>.
    /// All conversions are performed relative to this base unit.
    /// 
    /// Extensibility:
    /// Additional units (e.g., Yard, Meter) can be added here
    /// and handled in the corresponding extension methods.
    /// </summary>
    public enum LengthUnit
    {
        /// <summary>
        /// Represents measurement in Feet.
        /// This is the base unit for internal conversion logic.
        /// </summary>
        Feet,

        /// <summary>
        /// Represents measurement in Inches.
        /// 1 Inch = 1/12 Feet.
        /// </summary>
        Inch,

        /// <summary>
        /// Measurement in Yards.
        /// Conversion rule:
        /// 1 Yard = 3 Feet
        /// </summary>
        Yard,

        /// <summary>
        /// Measurement in Centimeters.
        /// Conversion rule:
        /// 1 Centimeter ≈ 0.393701 Inches
        /// </summary>
        Centimeter
    }

    /// <summary>
    /// Provides extension methods for LengthUnit.
    ///
    /// WHY EXTENSION METHODS?
    /// - Keeps enum clean and lightweight.
    /// - Encapsulates business logic separately (SRP – Single Responsibility Principle).
    /// - Allows fluent and readable usage:
    ///
    ///   double factor = unit.ToFeetFactor();
    ///
    /// DESIGN BENEFITS:
    /// - Separation of concerns
    /// - Easy scalability
    /// - Centralized conversion logic
    /// - Clean maintainable architecture
    /// </summary>
    public static class LengthUnitExtension
    {
                /// <summary>
        /// Returns the conversion multiplier required to convert
        /// the given LengthUnit to the base unit (Feet).
        ///
        /// FORMULA:
        ///     valueInFeet = originalValue * unit.ToFeetFactor();
        ///
        /// EXAMPLE:
        ///     12 Inches => 12 * (1/12) = 1 Foot
        ///     2 Yards   => 2 * 3 = 6 Feet
        ///
        /// This method uses a switch expression (C# modern syntax)
        /// for cleaner and more maintainable conditional logic.
        /// </summary>
        /// <param name="unit">
        /// The length unit whose conversion factor is required.
        /// </param>
        /// <returns>
        /// Double value representing multiplication factor to convert
        /// the given unit into Feet.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when:
        /// - An undefined enum value is passed
        /// - The enum is extended but conversion logic is not updated
        ///
        /// This enforces fail-fast behavior and prevents silent bugs.
        /// </exception>

        public static double ToFeetFactor(this LengthUnit unit)
        {
            return unit switch
            {
                // Base unit: 1 Feet = 1 Feet
                LengthUnit.Feet => 1.0,

                // 1 Inch = 1/12 Feet
                LengthUnit.Inch => 1.0 / 12.0,

                // 1 Yard = 3 Feet
                LengthUnit.Yard => 3.0,

                // 1 Centimeter = 0.393701 Inches
                // => in feet = 0.393701 * (1/12)
                LengthUnit.Centimeter => 1.0 / 30.48,

                // Defensive programming:
                // Ensures application fails explicitly if enum is extended
                // but conversion logic is not updated.
                _ => throw new ArgumentException("Unsupported Length Unit")
            }; 
        }
        /// <summary>
        /// Converts a value in the current unit into base unit (Feet).
        /// Example:
        /// 12 Inch -> 1 Feet
        /// </summary>
        public static double ConvertToBaseUnit(this LengthUnit unit, double value)
        {
            return value * unit.ToFeetFactor();
        }

        /// <summary>
        /// Converts a value in base unit (Feet) into the current unit.
        /// Example:
        /// 1 Feet -> 12 Inch
        /// </summary>
        public static double ConvertFromBaseUnit(this LengthUnit unit, double baseValue)
        {
            return baseValue / unit.ToFeetFactor();
        }
    }
}