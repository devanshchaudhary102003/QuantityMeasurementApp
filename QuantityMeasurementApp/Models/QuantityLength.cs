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

        /// <summary>
        
        public static QuantityLength Add(QuantityLength first, QuantityLength second)
        {
            // Convert second value into first unit
            double secondInFirstUnit = Convert(second.Value, second.Unit, first.Unit);

            // Add values (both now in first unit)
            double sum = first.Value + secondInFirstUnit;

            // Return new object (immutability)
            return new QuantityLength(sum, first.Unit);
        }

        /// UC7:
        /// Adds two QuantityLength values and returns the result
        /// in the explicitly specified target unit.
        /// Example:
        /// (1 Feet) + (12 Inch), target = Yard => Quantity(0.666..., Yard)
        /// </summary>
        public static QuantityLength Add(QuantityLength first, QuantityLength second, LengthUnit targetUnit)
        {
            // Convert both values to base unit (Feet)
            double firstInFeet = first.Value * first.Unit.ToFeetFactor();
            double secondInFeet = second.Value * second.Unit.ToFeetFactor();

            // Add in base unit
            double sumInFeet = firstInFeet + secondInFeet;

            // Convert sum from Feet to target unit
            double result = sumInFeet / targetUnit.ToFeetFactor();

            // Return new object
            return new QuantityLength(result, targetUnit);
        }

        /// <summary>
        /// Overload for raw values with explicit target unit.
        /// </summary>
        public static QuantityLength Add(double firstValue, LengthUnit firstUnit,
                                 double secondValue, LengthUnit secondUnit,
                                 LengthUnit targetUnit)
        {
            var first = new QuantityLength(firstValue, firstUnit);
            var second = new QuantityLength(secondValue, secondUnit);

            return Add(first, second, targetUnit);
        }

        /// <summary>
        /// Instance method version with explicit target unit.
        /// </summary>
        public QuantityLength Add(QuantityLength other, LengthUnit targetUnit)
        {
            return Add(this, other, targetUnit);
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