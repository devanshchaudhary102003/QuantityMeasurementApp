using System;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Generic immutable quantity model that supports multiple
    /// measurement categories such as Length, Weight, and Volume.
    ///
    /// TYPE PARAMETER:
    /// U represents the unit type for a specific category.
    ///
    /// DESIGN GOAL:
    /// - Reuse one quantity model across all measurement categories
    /// - Keep unit-specific conversion logic inside enum extensions
    /// - Preserve category isolation between Length, Weight, and Volume
    /// </summary>
    /// <typeparam name="U">Unit enum type</typeparam>
    public class Quantity<U>
    {
        /// <summary>
        /// Numeric value of the quantity.
        /// </summary>
        public double Value { get; }

        /// <summary>
        /// Unit associated with the quantity value.
        /// </summary>
        public U Unit { get; }

        /// <summary>
        /// Tolerance used for floating-point equality comparison.
        /// </summary>
        private const double EPSILON = 1e-5;

        /// <summary>
        /// Creates a new immutable quantity instance.
        /// </summary>
        /// <param name="value">Measurement value</param>
        /// <param name="unit">Measurement unit</param>
        public Quantity(double value, U unit)
        {
            ValidateFinite(value, nameof(value));
            Value = value;
            Unit = unit;
        }

        /// <summary>
        /// Returns the stored numeric value.
        /// </summary>
        public double GetValue()
        {
            return Value;
        }

        /// <summary>
        /// Returns the stored unit.
        /// </summary>
        public U GetUnit()
        {
            return Unit;
        }

        /// <summary>
        /// Converts the current quantity into its category base unit.
        ///
        /// SUPPORTED CATEGORIES:
        /// - Length
        /// - Weight
        /// - Volume
        ///
        /// EXCEPTION:
        /// Throws when an unsupported unit category is used.
        /// </summary>
        private double ConvertToBaseUnit()
        {
            if (Unit is LengthUnit lengthUnit)
                return lengthUnit.ConvertToBaseUnit(Value);

            if (Unit is WeightUnit weightUnit)
                return weightUnit.ConvertToBaseUnit(Value);

            if (Unit is VolumeUnit volumeUnit)
                return volumeUnit.ConvertToBaseUnit(Value);

            throw new ArgumentException("Unsupported measurement category.");
        }

        /// <summary>
        /// Converts a normalized base-unit value into the requested target unit.
        /// </summary>
        /// <param name="baseValue">Normalized base-unit value</param>
        /// <param name="targetUnit">Desired target unit</param>
        private double ConvertFromBaseUnit(double baseValue, U targetUnit)
        {
            if (targetUnit is LengthUnit lengthUnit)
                return lengthUnit.ConvertFromBaseUnit(baseValue);

            if (targetUnit is WeightUnit weightUnit)
                return weightUnit.ConvertFromBaseUnit(baseValue);

            if (targetUnit is VolumeUnit volumeUnit)
                return volumeUnit.ConvertFromBaseUnit(baseValue);

            throw new ArgumentException("Unsupported measurement category.");
        }

        /// <summary>
        /// Converts the current quantity into the specified target unit.
        /// </summary>
        /// <param name="targetUnit">Target unit for conversion</param>
        /// <returns>New converted quantity</returns>
        public Quantity<U> ConvertTo(U targetUnit)
        {
            ValidateTargetUnit(targetUnit);

            double baseValue = ConvertToBaseUnit();
            double convertedValue = ConvertFromBaseUnit(baseValue, targetUnit);

            return new Quantity<U>(convertedValue, targetUnit);
        }

        /// <summary>
        /// Adds another quantity of the same category and returns
        /// the result in the current quantity's unit.
        /// </summary>
        /// <param name="other">Other quantity to add</param>
        /// <returns>New quantity in current unit</returns>
        public Quantity<U> Add(Quantity<U> other)
        {
            double thisBase = ConvertToBaseUnit();
            double otherBase = other.ConvertToBaseUnit();

            double sumBase = thisBase + otherBase;
            double resultValue = ConvertFromBaseUnit(sumBase, Unit);

            return new Quantity<U>(resultValue, Unit);
        }

        /// <summary>
        /// Adds another quantity of the same category and returns
        /// the result in a user-specified target unit.
        /// </summary>
        /// <param name="other">Other quantity to add</param>
        /// <param name="targetUnit">Desired result unit</param>
        /// <returns>New quantity in target unit</returns>
        public Quantity<U> Add(Quantity<U> other, U targetUnit)
        {
            double thisBase = ConvertToBaseUnit();
            double otherBase = other.ConvertToBaseUnit();

            double sumBase = thisBase + otherBase;
            double resultValue = ConvertFromBaseUnit(sumBase, targetUnit);

            return new Quantity<U>(resultValue, targetUnit);
        }

        /// <summary>
        /// Rounds a numeric result to two decimal places for arithmetic consistency.
        /// </summary>
        /// <param name="value">Value to round</param>
        /// <returns>Rounded value</returns>
        private double RoundToTwoDecimals(double value)
        {
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Validates that the provided quantity is not null.
        /// </summary>
        /// <param name="other">Quantity to validate</param>
        private void ValidateQuantity(Quantity<U> other)
        {
            if (other == null)
                throw new ArgumentException("Other quantity cannot be null.");
        }

        /// <summary>
        /// Validates that the provided numeric value is finite.
        /// </summary>
        /// <param name="value">Numeric value to validate</param>
        /// <param name="paramName">Logical parameter name</param>
        private void ValidateFinite(double value, string paramName)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException($"{paramName} must be a finite number.");
        }

        /// <summary>
        /// Validates that the target unit is not null.
        /// </summary>
        /// <param name="targetUnit">Target unit</param>
        private void ValidateTargetUnit(U targetUnit)
        {
            if (targetUnit == null)
                throw new ArgumentException("Target unit cannot be null.");
        }

        /// <summary>
        /// UC12:
        /// Subtracts another quantity of the same category and returns
        /// the result in the current quantity's unit.
        ///
        /// PROPERTY:
        /// Subtraction is non-commutative.
        /// </summary>
        /// <param name="other">Other quantity to subtract</param>
        /// <returns>New quantity in current unit</returns>
        public Quantity<U> Subtract(Quantity<U> other)
        {
            ValidateQuantity(other);
            ValidateFinite(Value, nameof(Value));
            ValidateFinite(other.Value, nameof(other.Value));

            double thisBase = ConvertToBaseUnit();
            double otherBase = other.ConvertToBaseUnit();

            double differenceBase = thisBase - otherBase;
            double resultValue = ConvertFromBaseUnit(differenceBase, Unit);
            resultValue = RoundToTwoDecimals(resultValue);

            return new Quantity<U>(resultValue, Unit);
        }

        /// <summary>
        /// UC12:
        /// Subtracts another quantity of the same category and returns
        /// the result in a user-specified target unit.
        /// </summary>
        /// <param name="other">Other quantity to subtract</param>
        /// <param name="targetUnit">Desired result unit</param>
        /// <returns>New quantity in target unit</returns>
        public Quantity<U> Subtract(Quantity<U> other, U targetUnit)
        {
            ValidateQuantity(other);
            ValidateTargetUnit(targetUnit);
            ValidateFinite(Value, nameof(Value));
            ValidateFinite(other.Value, nameof(other.Value));

            double thisBase = ConvertToBaseUnit();
            double otherBase = other.ConvertToBaseUnit();

            double differenceBase = thisBase - otherBase;
            double resultValue = ConvertFromBaseUnit(differenceBase, targetUnit);
            resultValue = RoundToTwoDecimals(resultValue);

            return new Quantity<U>(resultValue, targetUnit);
        }

        /// <summary>
        /// UC12:
        /// Divides this quantity by another quantity of the same category.
        ///
        /// RETURN TYPE:
        /// Returns a dimensionless scalar ratio as double.
        ///
        /// PROPERTY:
        /// Division is non-commutative.
        /// </summary>
        /// <param name="other">Divisor quantity</param>
        /// <returns>Dimensionless scalar ratio</returns>
        public double Divide(Quantity<U> other)
        {
            ValidateQuantity(other);
            ValidateFinite(Value, nameof(Value));
            ValidateFinite(other.Value, nameof(other.Value));

            double thisBase = ConvertToBaseUnit();
            double otherBase = other.ConvertToBaseUnit();

            if (Math.Abs(otherBase) < EPSILON)
                throw new ArithmeticException("Division by zero quantity is not allowed.");

            return thisBase / otherBase;
        }

        /// <summary>
        /// Compares this quantity with another object for value equality.
        ///
        /// EQUALITY RULE:
        /// - Same category only
        /// - Comparison performed in normalized base unit
        /// - Floating-point tolerance applied
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>True if equivalent, otherwise false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj is not Quantity<U> other)
                return false;

            if (Unit == null || other.Unit == null)
                return false;

            if (Unit.GetType() != other.Unit.GetType())
                return false;

            return Math.Abs(ConvertToBaseUnit() - other.ConvertToBaseUnit()) < EPSILON;
        }

        /// <summary>
        /// Generates a hash code for the quantity.
        ///
        /// NOTE:
        /// For consistent equality semantics, hash code is derived from
        /// normalized base-unit value and runtime unit category.
        /// </summary>
        public override int GetHashCode()
        {
            double normalized = Math.Round(ConvertToBaseUnit(), 5);
            return HashCode.Combine(normalized, Unit?.GetType());
        }

        /// <summary>
        /// Returns a readable string representation of the quantity.
        /// </summary>
        public override string ToString()
        {
            return $"{Value} {Unit}";
        }
    }
}