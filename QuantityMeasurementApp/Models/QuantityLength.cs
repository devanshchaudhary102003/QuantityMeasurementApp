using System;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Represents a unit-aware length quantity.
    ///
    /// PURPOSE:
    /// This class encapsulates a numeric value along with its measurement unit.
    /// It replaces separate unit-specific classes (Feet, Inches, etc.)
    /// and follows the DRY principle by centralizing length logic.
    ///
    /// DESIGN APPROACH:
    /// - Uses LengthUnit enum for type safety.
    /// - Converts all values to a base unit (Feet) for comparison.
    /// - Overrides Equals and GetHashCode for value-based equality.
    /// </summary>
    public class QuantityLength
    {
        /// <summary>
        /// Numeric magnitude of the length.
        /// 
        /// NOTE:
        /// In production systems, this would typically be private
        /// with a public read-only property for better encapsulation.
        /// </summary>
        public double Value;

        /// <summary>
        /// Unit associated with the numeric value.
        /// Strongly typed using LengthUnit enum.
        /// </summary>
        public LengthUnit Unit;

        /// <summary>
        /// Initializes a new instance of QuantityLength.
        /// </summary>
        /// <param name="Value">Numeric length value.</param>
        /// <param name="Unit">Unit of measurement.</param>
        /// 
        /// This constructor assigns the provided value and unit.
        /// Additional validation (e.g., negative value checks)
        /// can be introduced based on domain requirements.
        public QuantityLength(double Value, LengthUnit Unit)
        {
            this.Value = Value;
            this.Unit = Unit;
        }

        /// <summary>
        /// Returns the stored numeric value.
        /// </summary>
        /// <returns>Double value representing the length.</returns>
        public double GetValue()
        {
            return Value;
        }

        /// <summary>
        /// Returns the measurement unit.
        /// </summary>
        /// <returns>LengthUnit enum value.</returns>
        public LengthUnit GetUnit()
        {
            return Unit;
        }

        /// <summary>
        /// Converts the current length value into the base unit (Feet).
        ///
        /// All equality comparisons are performed in Feet
        /// to maintain consistency across different units.
        ///
        /// Conversion Formula:
        ///     valueInFeet = Value * Unit.ToFeetFactor()
        /// </summary>
        /// <returns>Equivalent value in Feet.</returns>
        public double ConvertToFeet()
        {
            return Value * Unit.ToFeetFactor();
        }

        /// <summary>
        /// Determines whether the specified object represents
        /// the same physical length as the current instance.
        ///
        /// Equality Logic:
        /// - Performs reference check.
        /// - Performs null check.
        /// - Ensures type safety.
        /// - Compares normalized values (converted to Feet).
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>
        /// True if both quantities represent the same length;
        /// otherwise false.
        /// </returns>
        public override bool Equals(object? obj)
        {
            // If both references point to the same object
            if (ReferenceEquals(this, obj))
                return true;

            // If the object is null
            if (obj is null)
                return false;

            // Ensure object is of same type
            if (obj.GetType() != typeof(QuantityLength))
                return false;

            QuantityLength other = (QuantityLength)obj;

            double firstValue = ConvertToFeet();
            double secondValue = other.ConvertToFeet();

            // Direct double comparison
            return firstValue == secondValue;
        }

        /// <summary>
        /// Returns hash code based on normalized (Feet) value.
        ///
        /// This ensures consistency with the Equals override.
        /// Equal objects must return equal hash codes.
        /// </summary>
        /// <returns>Hash code of converted value.</returns>
        public override int GetHashCode()
        {
            return ConvertToFeet().GetHashCode();
        }

        /// <summary>
        /// Returns a readable string representation of the quantity.
        /// Useful for debugging and logging.
        /// </summary>
        /// <returns>Formatted quantity string.</returns>
        public override string ToString()
        {
            return $"Quantity({Value}, {Unit})";
        }
    }
}