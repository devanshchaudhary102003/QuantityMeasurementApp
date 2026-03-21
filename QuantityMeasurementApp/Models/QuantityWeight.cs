using System;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Models
{
    public class QuantityWeight
    {
        public double Value;
        public WeightUnit Unit;

        public QuantityWeight(double value, WeightUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public double GetValue()
        {
            return Value;
        }

        public WeightUnit GetUnit()
        {
            return Unit;
        }

        public double ConvertToKilogram()
        {
            return Unit.ConvertToBaseUnit(Value);
        }
        

        public static double Convert(double value, WeightUnit sourceUnit, WeightUnit targetUnit)
        {
            double baseValue = sourceUnit.ConvertToBaseUnit(value);
            return targetUnit.ConvertFromBaseUnit(baseValue);
        }
        

        public static QuantityWeight Add(QuantityWeight first, QuantityWeight second)
        {
            double firstBase = first.Unit.ConvertToBaseUnit(first.Value);
            double secondBase = second.Unit.ConvertToBaseUnit(second.Value);

            double sumBase = firstBase + secondBase;
            double result = first.Unit.ConvertFromBaseUnit(sumBase);

            return new QuantityWeight(result, first.Unit);
        }
        public static QuantityWeight Add(double firstValue, WeightUnit firstUnit, double secondValue, WeightUnit secondUnit)
        {
            var first = new QuantityWeight(firstValue, firstUnit);
            var second = new QuantityWeight(secondValue, secondUnit);

            return Add(first, second);
        }

        public QuantityWeight Add(QuantityWeight other)
        {
            return Add(this, other);
        }

        public static QuantityWeight Add(QuantityWeight first, QuantityWeight second, WeightUnit targetUnit)
        {
            double firstBase = first.Unit.ConvertToBaseUnit(first.Value);
            double secondBase = second.Unit.ConvertToBaseUnit(second.Value);

            double sumBase = firstBase + secondBase;
            double result = targetUnit.ConvertFromBaseUnit(sumBase);

            return new QuantityWeight(result, targetUnit);
        }

        public static QuantityWeight Add(double firstValue, WeightUnit firstUnit,
                                         double secondValue, WeightUnit secondUnit,
                                         WeightUnit targetUnit)
        {
            var first = new QuantityWeight(firstValue, firstUnit);
            var second = new QuantityWeight(secondValue, secondUnit);

            return Add(first, second, targetUnit);
        }

        public QuantityWeight Add(QuantityWeight other, WeightUnit targetUnit)
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

            if(obj.GetType() != typeof(QuantityWeight))
            {
                return false;
            }

            QuantityWeight other = (QuantityWeight)obj;

            return Math.Abs(this.Unit.ConvertToBaseUnit(this.Value) - other.Unit.ConvertToBaseUnit(other.Value)) < 0.0001;
        }

        public override int GetHashCode()
        {
            return ConvertToKilogram().GetHashCode();
        }
    }
}