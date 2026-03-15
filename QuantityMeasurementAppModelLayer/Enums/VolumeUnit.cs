using System;

namespace QuantityMeasurementApp.Enums
{
    /// <summary>
    /// UC11
    /// Represents supported volume measurement units.
    ///
    /// DESIGN NOTE:
    /// In the C# implementation, enum values are kept simple and immutable.
    /// Conversion behavior is provided through extension methods so that the
    /// public usage remains clean and expressive:
    ///
    ///     VolumeUnit.Litre.GetConversionFactor();
    ///     VolumeUnit.Gallon.ConvertToBaseUnit(2.0);
    ///
    /// BASE UNIT:
    /// - Litre is the base unit for all volume conversions.
    ///
    /// CONVERSION FACTORS:
    /// - 1 Litre      = 1.0 L
    /// - 1 Millilitre = 0.001 L
    /// - 1 Gallon     = 3.78541 L
    /// </summary>
    public enum VolumeUnit
    {
        Litre,
        Millilitre,
        Gallon
    }

    /// <summary>
    /// Provides conversion and metadata behavior for <see cref="VolumeUnit"/>.
    ///
    /// RESPONSIBILITY:
    /// - Encapsulates all unit-specific conversion logic for UC11.
    /// - Keeps Quantity&lt;U&gt; generic and reusable across categories.
    ///
    /// IMPORTANT:
    /// No business logic from Quantity is duplicated here.
    /// This class is only responsible for unit semantics.
    /// </summary>
    public static class VolumeUnitExtensions
    {
        /// <summary>
        /// Returns the conversion factor of the unit relative to the base unit (Litre).
        /// </summary>
        public static double GetConversionFactor(this VolumeUnit unit)
        {
            return unit switch
            {
                VolumeUnit.Litre => 1.0,
                VolumeUnit.Millilitre => 0.001,
                VolumeUnit.Gallon => 3.78541,
                _ => throw new ArgumentOutOfRangeException(nameof(unit), "Unsupported volume unit.")
            };
        }

        /// <summary>
        /// Converts a value from the given volume unit to the base unit (Litre).
        /// </summary>
        public static double ConvertToBaseUnit(this VolumeUnit unit, double value)
        {
            return value * unit.GetConversionFactor();
        }

        /// <summary>
        /// Converts a value from the base unit (Litre) into the specified target unit.
        /// </summary>
        public static double ConvertFromBaseUnit(this VolumeUnit unit, double baseValue)
        {
            return baseValue / unit.GetConversionFactor();
        }

        /// <summary>
        /// Returns a readable display name for the unit.
        /// </summary>
        public static string GetUnitName(this VolumeUnit unit)
        {
            return unit switch
            {
                VolumeUnit.Litre => "Litre",
                VolumeUnit.Millilitre => "Millilitre",
                VolumeUnit.Gallon => "Gallon",
                _ => throw new ArgumentOutOfRangeException(nameof(unit), "Unsupported volume unit.")
            };
        }

        public static void ValidateOperationSupport(this VolumeUnit unit, string operation)
        {
            // Volume supports all current arithmetic operations.
        }
    }
}