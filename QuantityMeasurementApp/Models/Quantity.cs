using System;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Represents a generic, type-safe measurement quantity.
    ///
    /// PURPOSE:
    /// This class unifies all measurable categories such as Length and Weight
    /// into a single reusable model.
    ///
    /// DESIGN BENEFITS:
    /// - Eliminates duplication across category-specific quantity classes
    /// - Supports equality, conversion, and arithmetic generically
    /// - Preserves type safety through generic type parameters
    /// - Scales easily to future categories (Volume, Temperature, etc.)
    ///
    /// TYPE PARAMETER:
    /// U must be an enum representing a measurement category unit.
    ///
    /// EXAMPLES:
    /// - Quantity&lt;LengthUnit&gt;
    /// - Quantity&lt;WeightUnit&gt;
    /// </summary>
    public class Quantity<U> where U : struct, Enum
    {
        /// <summary>
        /// Tolerance used for floating-point equality comparison.
        /// Prevents false negatives caused by precision limitations.
        /// </summary>
        private const double EPSILON = 1e-6;

        /// <summary>
        /// Numeric measurement value.
        /// Immutable after construction.
        /// </summary>
        public double Value { get; }

        /// <summary>
        /// Unit associated with the measurement value.
        /// Immutable after construction.
        /// </summary>
        public U Unit { get; }

        /// <summary>
        /// Initializes a new instance of the Quantity class.
        /// </summary>
        /// <param name="value">Numeric measurement value.</param>
        /// <param name="unit">Associated unit enum value.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the supplied value is NaN or Infinity.
        /// </exception>
        public Quantity(double value, U unit)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                throw new ArgumentException("Value must be a finite number.");
            }

            Value = value;
            Unit = unit;
        }

        /// <summary>
        /// Returns the numeric quantity value.
        /// </summary>
        public double GetValue()
        {
            return Value;
        }

        /// <summary>
        /// Returns the unit associated with this quantity.
        /// </summary>
        public U GetUnit()
        {
            return Unit;
        }

        /// <summary>
        /// Converts the current quantity into its category base unit.
        ///
        /// CATEGORY MAPPING:
        /// - Length → Feet
        /// - Weight → Kilogram
        /// </summary>
        /// <returns>Equivalent value in base unit.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the measurement category is unsupported.
        /// </exception>
        private double ConvertToBaseUnit()
        {
            if (Unit is LengthUnit lengthUnit)
            {
                return lengthUnit.ConvertToBaseUnit(Value);
            }

            if (Unit is WeightUnit weightUnit)
            {
                return weightUnit.ConvertToBaseUnit(Value);
            }

            throw new ArgumentException("Unsupported measurement category.");
        }

        /// <summary>
        /// Converts a base-unit value into the specified target unit.
        /// </summary>
        /// <param name="baseValue">Value expressed in base unit.</param>
        /// <param name="targetUnit">Target unit.</param>
        /// <returns>Equivalent value in target unit.</returns>
        private static double ConvertFromBaseUnit(double baseValue, U targetUnit)
        {
            if (targetUnit is LengthUnit lengthUnit)
            {
                return lengthUnit.ConvertFromBaseUnit(baseValue);
            }

            if (targetUnit is WeightUnit weightUnit)
            {
                return weightUnit.ConvertFromBaseUnit(baseValue);
            }

            throw new ArgumentException("Unsupported measurement category.");
        }

        /// <summary>
        /// Converts this quantity to the specified target unit.
        ///
        /// IMMUTABILITY:
        /// This method does not mutate the current object.
        /// A new Quantity instance is returned.
        /// </summary>
        /// <param name="targetUnit">Target unit for conversion.</param>
        /// <returns>New Quantity expressed in target unit.</returns>
        public Quantity<U> ConvertTo(U targetUnit)
        {
            double baseValue = ConvertToBaseUnit();
            double convertedValue = ConvertFromBaseUnit(baseValue, targetUnit);

            return new Quantity<U>(convertedValue, targetUnit);
        }

        /// <summary>
        /// Adds another quantity of the same measurement category.
        /// The result is returned in the unit of the current object.
        /// </summary>
        /// <param name="other">Other quantity to add.</param>
        /// <returns>New Quantity representing the sum.</returns>
        public Quantity<U> Add(Quantity<U> other)
        {
            double firstBase = this.ConvertToBaseUnit();
            double secondBase = other.ConvertToBaseUnit();

            double sumBase = firstBase + secondBase;
            double result = ConvertFromBaseUnit(sumBase, this.Unit);

            return new Quantity<U>(result, this.Unit);
        }

        /// <summary>
        /// Adds another quantity and returns the result
        /// in the explicitly specified target unit.
        /// </summary>
        /// <param name="other">Other quantity to add.</param>
        /// <param name="targetUnit">Desired unit of the result.</param>
        /// <returns>New Quantity representing the sum.</returns>
        public Quantity<U> Add(Quantity<U> other, U targetUnit)
        {
            double firstBase = this.ConvertToBaseUnit();
            double secondBase = other.ConvertToBaseUnit();

            double sumBase = firstBase + secondBase;
            double result = ConvertFromBaseUnit(sumBase, targetUnit);

            return new Quantity<U>(result, targetUnit);
        }

        /// <summary>
        /// Determines whether this quantity represents the same physical
        /// measurement as another quantity of the same category.
        ///
        /// COMPARISON STRATEGY:
        /// - Reject null
        /// - Reject different generic runtime type
        /// - Reject cross-category units
        /// - Convert both values to base unit
        /// - Compare using epsilon tolerance
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if both quantities are equivalent; otherwise false.</returns>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj is null)
                return false;

            if (obj.GetType() != typeof(Quantity<U>))
                return false;

            Quantity<U> other = (Quantity<U>)obj;

            if (this.Unit.GetType() != other.Unit.GetType())
                return false;

            double firstBase = this.ConvertToBaseUnit();
            double secondBase = other.ConvertToBaseUnit();

            return Math.Abs(firstBase - secondBase) < EPSILON;
        }

        /// <summary>
        /// Returns hash code based on normalized base-unit value.
        /// Ensures consistency with Equals().
        /// </summary>
        /// <returns>Hash code for the quantity.</returns>
        public override int GetHashCode()
        {
            return ConvertToBaseUnit().GetHashCode();
        }

        /// <summary>
        /// Returns a readable string representation of the quantity.
        /// </summary>
        /// <returns>Formatted quantity string.</returns>
        public override string ToString()
        {
            return $"Quantity({Value}, {Unit})";
        }
    }
}