using System;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Represents a unit-aware length quantity.
    ///
    /// DESIGN INTENT:
    /// - Implements Value Object semantics.
    /// - Normalizes all equality comparisons using base unit (Feet).
    /// - Provides static and instance-level conversion APIs (UC5).
    ///
    /// ARCHITECTURAL BENEFITS:
    /// - DRY principle (centralized conversion logic)
    /// - Strong typing via LengthUnit enum
    /// - Immutable domain model (recommended best practice)
    /// </summary>
    public sealed class QuantityLength
    {
        /// <summary>
        /// Floating-point tolerance used for equality comparison.
        /// Prevents false negatives due to precision errors.
        /// </summary>
        private const double EPSILON = 1e-6;

        /// <summary>
        /// Numeric magnitude of the length.
        /// Immutable after construction.
        /// </summary>
        public double Value { get; }

        /// <summary>
        /// Unit associated with the value.
        /// Immutable after construction.
        /// </summary>
        public LengthUnit Unit { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="QuantityLength"/>.
        /// </summary>
        /// <param name="value">Numeric magnitude.</param>
        /// <param name="unit">Measurement unit.</param>
        public QuantityLength(double value, LengthUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        /// <summary>
        /// Converts current value to base unit (Feet).
        /// </summary>
        public double ConvertToFeet()
        {
            return Value * Unit.ToFeetFactor();
        }

        // =====================================================
        // UC5: Static Conversion API
        // =====================================================

        /// <summary>
        /// Converts a numeric value from source unit to target unit.
        ///
        /// Formula:
        ///     result = value × (sourceFactor / targetFactor)
        /// </summary>
        public static double Convert(double value, LengthUnit sourceUnit, LengthUnit targetUnit)
        {
            double sourceFactor = sourceUnit.ToFeetFactor();
            double targetFactor = targetUnit.ToFeetFactor();

            double valueInFeet = value * sourceFactor;
            return valueInFeet / targetFactor;
        }

        // =====================================================
        // UC5: Instance Conversion
        // =====================================================

        /// <summary>
        /// Converts the current object to a new QuantityLength
        /// with the specified target unit.
        /// </summary>
        public QuantityLength ConvertTo(LengthUnit targetUnit)
        {
            double convertedValue = Convert(this.Value, this.Unit, targetUnit);
            return new QuantityLength(convertedValue, targetUnit);
        }

        // =========================
        // UC6: Addition (Result in first operand unit)
        // =========================

        /// <summary>
        /// Adds two QuantityLength values and returns the sum in the unit of the first operand.
        /// Example: (1 Feet) + (12 Inch) = (2 Feet)
        /// </summary>

        public static QuantityLength Add(QuantityLength First, QuantityLength Second)
        {
            // Convert second value into first unit
            double secondInFirstUnit = Convert(Second.Value, Second.Unit, First.Unit);

            // Add values (both now in first unit)
            double sum = First.Value + secondInFirstUnit;

            // Return new object (immutability)
            return new QuantityLength(sum,First.Unit);
        }

        // <summary>
        /// Overload: Adds raw values with units. Result is returned in unit of first operand.
        /// Example: Add(1, Feet, 12, Inch) -> Quantity(2, Feet)
        /// </summary>
        
        public static QuantityLength Add(double firstValue, LengthUnit firstUnit, double secondValue, LengthUnit secondUnit)
        {
            var first = new QuantityLength(firstValue,firstUnit);
            var second = new QuantityLength(secondValue,secondUnit);

            return Add(first,second);
        }

        /// <summary>
        /// Instance method: adds another QuantityLength to current object.
        /// Result is returned in current object's unit.
        /// </summary>
        
        public QuantityLength Add(QuantityLength other)
        {
            return Add(this,other);
        }
        
        // =====================================================
        // Equality Logic (Value Object Semantics)
        // =====================================================

        /// <summary>
        /// Determines whether two QuantityLength instances
        /// represent the same physical measurement.
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj is not QuantityLength other)
                return false;

            double firstValue = this.ConvertToFeet();
            double secondValue = other.ConvertToFeet();

            return Math.Abs(firstValue - secondValue) < EPSILON;
        }

        /// <summary>
        /// Returns hash code based on normalized base value.
        /// Ensures consistency with Equals implementation.
        /// </summary>
        public override int GetHashCode()
        {
            return ConvertToFeet().GetHashCode();
        }

        /// <summary>
        /// Provides readable debugging representation.
        /// </summary>
        public override string ToString()
        {
            return $"Quantity({Value}, {Unit})";
        }
    }
}