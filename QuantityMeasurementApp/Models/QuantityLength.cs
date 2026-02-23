using System;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Represents a generic length quantity.
    /// 
    /// This class follows the DRY principle by eliminating duplication
    /// between individual unit classes like Feet and Inches.
    /// 
    /// It supports:
    /// - Unit-based value storage
    /// - Conversion to a common base unit (Feet)
    /// - Equality comparison across different length units
    /// </summary>
    public class QuantityLength
    {
        /// <summary>
        /// Numeric value of the length measurement.
        /// </summary>
        public double Value;

        /// <summary>
        /// Unit type of the measurement (Feet, Inches, etc.).
        /// </summary>
        public LengthUnit Unit;

        /// <summary>
        /// Returns the stored numeric value.
        /// </summary>
        /// <returns>Length value.</returns>
        public double GetValue()
        {
            return Value;
        }

        /// <summary>
        /// Returns the unit type of the measurement.
        /// </summary>
        /// <returns>LengthUnit enum value.</returns>
        public LengthUnit GetUnit()
        {
            return Unit;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantityLength"/> class.
        /// </summary>
        /// <param name="Value">Numeric value of the length.</param>
        /// <param name="Unit">Unit type of the length.</param>
        /// <exception cref="ArgumentException">
        /// Can be extended to throw exception if value is invalid.
        /// </exception>
        public QuantityLength(double Value, LengthUnit Unit)
        {
            this.Value = Value;
            this.Unit = Unit;
        }

        /// <summary>
        /// Converts the current length to the base unit (Feet).
        /// 
        /// All equality comparisons are performed in feet
        /// to maintain consistency across different units.
        /// </summary>
        /// <returns>Equivalent value in feet.</returns>
        public double ConvertToFeet()
        {
            return Value * Unit.ToFeetFactor();
        }

        /// <summary>
        /// Determines whether the specified object is equal
        /// to the current QuantityLength instance.
        /// 
        /// Equality is determined after converting both values
        /// to a common base unit (Feet).
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>
        /// True if both quantities represent the same length;
        /// otherwise, false.
        /// </returns>
        public override bool Equals(object? obj)
        {
            // Reflexive property:
            // If both references point to same object, they are equal.
            if (ReferenceEquals(this, obj))
                return true;

            // Null check:
            // If the other object is null, they cannot be equal.
            if (obj is null)
                return false;

            // Type safety check:
            // Ensure object is of expected type.
            // (Important for preventing invalid casting.)
            if (obj.GetType() != typeof(QuantityLength)) // ⚠ Logical issue here — see note below.
                return false;

            // Safe casting after type validation.
            QuantityLength other = (QuantityLength)obj;

            // Floating-point precision comparison:
            // Direct comparison using == is unsafe for double values.
            // A small tolerance (epsilon) is used.
            return Math.Abs(this.ConvertToFeet() - other.ConvertToFeet()) < 0.0001;
        }

        /// <summary>
        /// Returns hash code based on converted base value.
        /// Ensures consistency with Equals override.
        /// </summary>
        /// <returns>Hash code of the converted length.</returns>
        public override int GetHashCode()
        {
            return ConvertToFeet().GetHashCode();
        }
    }
}