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
        Inch
    }

    /// <summary>
    /// Provides extension methods for <see cref="LengthUnit"/>.
    /// 
    /// This class encapsulates unit-specific business logic
    /// such as conversion factors, keeping the enum clean and
    /// adhering to the Single Responsibility Principle (SRP).
    /// 
    /// Design Benefits:
    /// - Keeps enum simple and readable
    /// - Allows scalable addition of new behaviors
    /// - Promotes separation of concerns
    /// </summary>
    public static class LengthUnitExtension
    {
        /// <summary>
        /// Returns the conversion multiplier required to convert
        /// the specified <see cref="LengthUnit"/> into the base unit (Feet).
        /// 
        /// This method is implemented as an extension method
        /// to provide fluent usage:
        /// <code>
        /// double valueInFeet = unit.ToFeetFactor();
        /// </code>
        /// </summary>
        /// <param name="unit">
        /// The length unit whose conversion factor is required.
        /// </param>
        /// <returns>
        /// A double representing the multiplier to convert
        /// the given unit into Feet.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when an unsupported or undefined LengthUnit is provided.
        /// This ensures fail-fast behavior for invalid enum values.
        /// </exception>
        public static double ToFeetFactor(this LengthUnit unit)
        {
            return unit switch
            {
                // Base unit: 1 Feet = 1 Feet
                LengthUnit.Feet => 1.0,

                // 1 Inch = 1/12 Feet
                LengthUnit.Inch => 1.0 / 12.0,

                // Defensive programming:
                // Ensures application fails explicitly if enum is extended
                // but conversion logic is not updated.
                _ => throw new ArgumentException("Unsupported Length Unit")
            };
        }
    }
}