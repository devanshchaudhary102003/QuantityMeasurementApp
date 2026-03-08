using System;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Represents a unit-aware weight quantity.
    ///
    /// PURPOSE:
    /// This class encapsulates a numeric weight value together with its
    /// corresponding measurement unit.
    ///
    /// DESIGN APPROACH:
    /// - Follows the Value Object design pattern.
    /// - Ensures immutability (operations return new objects).
    /// - Delegates unit conversion responsibility to the WeightUnit enum.
    ///
    /// BASE UNIT:
    /// All weight calculations are normalized to Kilogram (kg).
    ///
    /// Supported Units:
    /// - Kilogram (kg)  -> Base unit
    /// - Gram (g)
    /// - Pound (lb)
    ///
    /// ARCHITECTURAL BENEFITS:
    /// - Separation of concerns
    /// - High cohesion
    /// - Low coupling
    /// - Scalable design for future measurement categories
    ///
    /// RELATED USE CASES:
    /// UC9 – Weight Measurement Equality, Conversion, and Addition
    /// </summary>
    public class QuantityWeight
    {
        /// <summary>
        /// Numeric magnitude of the weight.
        /// </summary>
        public double Value;

        /// <summary>
        /// Unit associated with the weight value.
        /// </summary>
        public WeightUnit Unit;

        /// <summary>
        /// Initializes a new instance of the QuantityWeight class.
        ///
        /// NOTE:
        /// Constructor assigns value and unit.
        /// Additional validation (NaN, Infinity, null unit) can be added
        /// depending on business rules.
        /// </summary>
        /// <param name="value">Weight numeric value</param>
        /// <param name="unit">Weight unit</param>
        public QuantityWeight(double value, WeightUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        /// <summary>
        /// Retrieves the numeric weight value.
        /// </summary>
        public double GetValue()
        {
            return Value;
        }

        /// <summary>
        /// Retrieves the unit of the weight.
        /// </summary>
        public WeightUnit GetUnit()
        {
            return Unit;
        }

        /// <summary>
        /// Converts the current weight to the base unit (Kilogram).
        ///
        /// DESIGN PRINCIPLE:
        /// Delegates conversion responsibility to the WeightUnit enum.
        ///
        /// Formula:
        /// baseValue = Unit.ConvertToBaseUnit(Value)
        /// </summary>
        /// <returns>Weight value expressed in kilograms</returns>
        public double ConvertToKilogram()
        {
            return Unit.ConvertToBaseUnit(Value);
        }

        /// <summary>
        /// Converts a raw numeric weight value between two units.
        ///
        /// CONVERSION STRATEGY:
        /// 1. Convert source value to base unit (Kilogram)
        /// 2. Convert base unit to target unit
        ///
        /// This ensures consistent and scalable conversions.
        /// </summary>
        /// <param name="value">Original value</param>
        /// <param name="sourceUnit">Source unit</param>
        /// <param name="targetUnit">Target unit</param>
        /// <returns>Converted numeric value</returns>
        public static double Convert(double value, WeightUnit sourceUnit, WeightUnit targetUnit)
        {
            double baseValue = sourceUnit.ConvertToBaseUnit(value);
            return targetUnit.ConvertFromBaseUnit(baseValue);
        }

        /// <summary>
        /// Converts the current weight object into a specified target unit.
        ///
        /// IMMUTABILITY:
        /// This method does not modify the existing object.
        /// Instead, it returns a new QuantityWeight instance.
        /// </summary>
        /// <param name="targetUnit">Desired output unit</param>
        /// <returns>New QuantityWeight instance in target unit</returns>
        public QuantityWeight ConvertTo(WeightUnit targetUnit)
        {
            double convertedValue = Convert(this.Value, this.Unit, targetUnit);
            return new QuantityWeight(convertedValue, targetUnit);
        }

        /// <summary>
        /// Adds two QuantityWeight objects.
        ///
        /// RESULT UNIT:
        /// The result is expressed in the unit of the first operand.
        ///
        /// Example:
        /// 1 Kilogram + 1000 Gram = 2 Kilogram
        /// </summary>
        /// <param name="first">First weight object</param>
        /// <param name="second">Second weight object</param>
        /// <returns>Sum expressed in the first operand's unit</returns>
        public static QuantityWeight Add(QuantityWeight first, QuantityWeight second)
        {
            double firstBase = first.Unit.ConvertToBaseUnit(first.Value);
            double secondBase = second.Unit.ConvertToBaseUnit(second.Value);

            double sumBase = firstBase + secondBase;

            double result = first.Unit.ConvertFromBaseUnit(sumBase);

            return new QuantityWeight(result, first.Unit);
        }

        /// <summary>
        /// Adds two QuantityWeight objects and returns the result
        /// in a specified target unit.
        ///
        /// Example:
        /// Add(1 kg, 1000 g, Gram) -> 2000 g
        /// </summary>
        /// <param name="first">First operand</param>
        /// <param name="second">Second operand</param>
        /// <param name="targetUnit">Desired output unit</param>
        /// <returns>New QuantityWeight representing the sum</returns>
        public static QuantityWeight Add(QuantityWeight first, QuantityWeight second, WeightUnit targetUnit)
        {
            double firstBase = first.Unit.ConvertToBaseUnit(first.Value);
            double secondBase = second.Unit.ConvertToBaseUnit(second.Value);

            double sumBase = firstBase + secondBase;

            double result = targetUnit.ConvertFromBaseUnit(sumBase);

            return new QuantityWeight(result, targetUnit);
        }

        /// <summary>
        /// Instance method version of addition.
        ///
        /// Allows syntax like:
        /// weight1.Add(weight2)
        /// </summary>
        public QuantityWeight Add(QuantityWeight other)
        {
            return Add(this, other);
        }

        /// <summary>
        /// Instance method addition with explicit target unit.
        /// </summary>
        public QuantityWeight Add(QuantityWeight other, WeightUnit targetUnit)
        {
            return Add(this, other, targetUnit);
        }

        /// <summary>
        /// Determines whether two weight quantities represent
        /// the same physical weight.
        ///
        /// COMPARISON STRATEGY:
        /// 1. Convert both values to base unit (Kilogram)
        /// 2. Compare normalized values
        ///
        /// This allows cross-unit equality comparison.
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj is null)
                return false;

            if (obj.GetType() != typeof(QuantityWeight))
                return false;

            QuantityWeight other = (QuantityWeight)obj;

            double firstValue = this.Unit.ConvertToBaseUnit(this.Value);
            double secondValue = other.Unit.ConvertToBaseUnit(other.Value);

            return firstValue == secondValue;
        }

        /// <summary>
        /// Generates hash code based on normalized base unit value.
        ///
        /// Ensures consistency with Equals() implementation.
        /// </summary>
        public override int GetHashCode()
        {
            return ConvertToKilogram().GetHashCode();
        }

        /// <summary>
        /// Returns a readable representation of the weight object.
        ///
        /// Example Output:
        /// Quantity(5.0, Kilogram)
        /// </summary>
        public override string ToString()
        {
            return $"Quantity({Value}, {Unit})";
        }
    }
}