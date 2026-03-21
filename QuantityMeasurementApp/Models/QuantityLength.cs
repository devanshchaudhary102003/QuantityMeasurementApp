using System;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Models
{
    public class QuantityLength
    {
        public double Value;
        public LengthUnit Unit;

        public QuantityLength(double value, LengthUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public double GetValue()
        {
            return Value;
        }

        public LengthUnit GetUnit()
        {
            return Unit;
        }

        public double ConvertToFeet()
        {
            return Unit.ConvertToBaseUnit(Value);
        }
        
        // =====================================================
        // UC5: Static Conversion API
        // =====================================================

        public static double Convert(double value, LengthUnit sourceUnit, LengthUnit targetUnit)
        {
            double baseValue = sourceUnit.ConvertToBaseUnit(value);
            return targetUnit.ConvertFromBaseUnit(baseValue);
        }
        
        // =====================================================
        // UC5: Instance Conversion
        // =====================================================

        public static QuantityLength Add(QuantityLength first, QuantityLength second)
        {
            double firstBase = first.Unit.ConvertToBaseUnit(first.Value);
            double secondBase = second.Unit.ConvertToBaseUnit(second.Value);

            double sumBase = firstBase + secondBase;
            double result = first.Unit.ConvertFromBaseUnit(sumBase);

            return new QuantityLength(result, first.Unit);
        }

        // =========================
        // UC6: Addition (Result in first operand unit)
        // =========================
        public static QuantityLength Add(double firstValue, LengthUnit firstUnit, double secondValue, LengthUnit secondUnit)
        {
            var first = new QuantityLength(firstValue, firstUnit);
            var second = new QuantityLength(secondValue, secondUnit);

            return Add(first, second);
        }

        public QuantityLength Add(QuantityLength other)
        {
            return Add(this, other);
        }

        /// UC7:
        /// Adds two QuantityLength values and returns the result
        /// in the explicitly specified target unit.
        /// Example:
        /// (1 Feet) + (12 Inch), target = Yard => Quantity(0.666..., Yard)

        public static QuantityLength Add(QuantityLength first, QuantityLength second, LengthUnit targetUnit)
        {
            double firstBase = first.Unit.ConvertToBaseUnit(first.Value);
            double secondBase = second.Unit.ConvertToBaseUnit(second.Value);

            double sumBase = firstBase + secondBase;
            double result = targetUnit.ConvertFromBaseUnit(sumBase);

            return new QuantityLength(result, targetUnit);
        }

        public static QuantityLength Add(double firstValue, LengthUnit firstUnit,
                                         double secondValue, LengthUnit secondUnit,
                                         LengthUnit targetUnit)
        {
            var first = new QuantityLength(firstValue, firstUnit);
            var second = new QuantityLength(secondValue, secondUnit);

            return Add(first, second, targetUnit);
        }

        public QuantityLength Add(QuantityLength other, LengthUnit targetUnit)
        {
            return Add(this, other, targetUnit);
        }
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if(obj is null)
            {
                return false;
            }

            if(obj.GetType() != typeof(QuantityLength))
            {
                return false;
            }

            QuantityLength other = (QuantityLength)obj;

            return Math.Abs(this.Unit.ConvertToBaseUnit(this.Value) - other.Unit.ConvertToBaseUnit(other.Value)) < 0.0001;
        }

        public override int GetHashCode()
        {
            return ConvertToFeet().GetHashCode();
        }
    }
}