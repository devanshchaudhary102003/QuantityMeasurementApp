using System;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Models
{
    public class QuantityLength
    {
        private double Value;
        private LengthUnit Unit;

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