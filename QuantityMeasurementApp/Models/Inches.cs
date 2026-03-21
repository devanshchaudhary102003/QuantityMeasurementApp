using System;

namespace QuantityMeasurementApp.Models
{
    public class Inches
    {
        private double Value;

        public Inches(double value)
        {
            Value = value;
        }

        public double GetValue()
        {
            return Value;
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

            if(obj.GetType() != typeof(Inches))
            {
                return false;
            }

            Inches other = (Inches)obj;

            return Value.CompareTo(other.Value) == 0;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}