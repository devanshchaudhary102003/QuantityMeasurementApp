using System;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Represents a unit-aware length quantity.
    /// 
    /// UC8 REFACTOR:
    /// - Conversion responsibility delegated to LengthUnit
    /// - QuantityLength focuses only on comparison and arithmetic
    /// - Public API from UC1–UC7 remains preserved
    /// </summary>
    public class QuantityLength
    {
        private const double EPSILON = 0.0001;

        public double Value;
        public LengthUnit Unit;

        public QuantityLength(double Value, LengthUnit Unit)
        {
            this.Value = Value;
            this.Unit = Unit;
        }

        public double GetValue()
        {
            return Value;
        }

        public LengthUnit GetUnit()
        {
            return Unit;
        }

        /// <summary>
        /// Converts current quantity into base unit (Feet).
        /// Delegates conversion responsibility to unit.
        /// </summary>
        public double ConvertToFeet()
        {
            return Unit.ConvertToBaseUnit(Value);
        }

        /// <summary>
        /// UC5:
        /// Converts raw numeric value from source unit to target unit.
        /// </summary>
        public static double Convert(double value, LengthUnit sourceUnit, LengthUnit targetUnit)
        {
            double baseValue = sourceUnit.ConvertToBaseUnit(value);
            return targetUnit.ConvertFromBaseUnit(baseValue);
        }

        /// <summary>
        /// UC5:
        /// Converts current quantity into target unit.
        /// </summary>
        public QuantityLength ConvertTo(LengthUnit targetUnit)
        {
            double convertedValue = Convert(this.Value, this.Unit, targetUnit);
            return new QuantityLength(convertedValue, targetUnit);
        }

        /// <summary>
        /// UC6:
        /// Adds two quantities and returns result in first operand unit.
        /// </summary>
        public static QuantityLength Add(QuantityLength first, QuantityLength second)
        {
            double firstBase = first.Unit.ConvertToBaseUnit(first.Value);
            double secondBase = second.Unit.ConvertToBaseUnit(second.Value);

            double sumBase = firstBase + secondBase;
            double result = first.Unit.ConvertFromBaseUnit(sumBase);

            return new QuantityLength(result, first.Unit);
        }

        /// <summary>
        /// UC6 overload using raw values.
        /// </summary>
        public static QuantityLength Add(double firstValue, LengthUnit firstUnit, double secondValue, LengthUnit secondUnit)
        {
            var first = new QuantityLength(firstValue, firstUnit);
            var second = new QuantityLength(secondValue, secondUnit);

            return Add(first, second);
        }

        /// <summary>
        /// UC6 instance method.
        /// </summary>
        public QuantityLength Add(QuantityLength other)
        {
            return Add(this, other);
        }

        /// <summary>
        /// UC7:
        /// Adds two quantities and returns result in explicit target unit.
        /// </summary>
        public static QuantityLength Add(QuantityLength first, QuantityLength second, LengthUnit targetUnit)
        {
            double firstBase = first.Unit.ConvertToBaseUnit(first.Value);
            double secondBase = second.Unit.ConvertToBaseUnit(second.Value);

            double sumBase = firstBase + secondBase;
            double result = targetUnit.ConvertFromBaseUnit(sumBase);

            return new QuantityLength(result, targetUnit);
        }

        /// <summary>
        /// UC7 overload using raw values.
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
        /// UC7 instance method.
        /// </summary>
        public QuantityLength Add(QuantityLength other, LengthUnit targetUnit)
        {
            return Add(this, other, targetUnit);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj is null)
                return false;

            if (obj is not QuantityLength other)
                return false;

            double firstValue = this.Unit.ConvertToBaseUnit(this.Value);
            double secondValue = other.Unit.ConvertToBaseUnit(other.Value);

            return Math.Abs(firstValue - secondValue) < EPSILON;
        }

        public override int GetHashCode()
        {
            return Math.Round(Unit.ConvertToBaseUnit(Value), 4).GetHashCode();
        }

        public override string ToString()
        {
            return $"Quantity({Value}, {Unit})";
        }
    }
}