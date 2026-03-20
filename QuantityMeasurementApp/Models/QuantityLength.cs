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
            return Value * Unit.ToFeetFactor();
        }
        
        // =====================================================
        // UC5: Static Conversion API
        // =====================================================

        public static double Convert(double value,LengthUnit sourceUnit, LengthUnit targetUnit)
        {
            double sourceFactor = sourceUnit.ToFeetFactor();
            double targetFactor = targetUnit.ToFeetFactor();

            double valueInFeet = value * sourceFactor;
            return valueInFeet / targetFactor;
        }
        
        // =====================================================
        // UC5: Instance Conversion
        // =====================================================

        public QuantityLength ConvertTo(LengthUnit targetUnit)
        {
            double convertedValue = Convert(this.Value, this.Unit, targetUnit);
            return new QuantityLength(convertedValue,targetUnit);
        }

        // =========================
        // UC6: Addition (Result in first operand unit)
        // =========================
        public static QuantityLength Add(QuantityLength first , QuantityLength second)
        {
            double secondInFirstUnit = Convert(second.Value, second.Unit, first.Unit);
            double sum = first.Value + secondInFirstUnit;

            return new QuantityLength(sum,first.Unit);
        }

        public static QuantityLength Add(double firstValue, LengthUnit firstUnit, double secondValue, LengthUnit secondUnit)
        {
            var first = new QuantityLength(firstValue,firstUnit);
            var second = new QuantityLength(secondValue,secondUnit);

            return Add(first,second);
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

            return Math.Abs(this.ConvertToFeet() - other.ConvertToFeet()) < 0.0001;
        }

        public override int GetHashCode()
        {
            return ConvertToFeet().GetHashCode();
        }
    }
}