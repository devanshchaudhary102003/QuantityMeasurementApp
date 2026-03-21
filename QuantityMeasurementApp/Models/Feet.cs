using System;

namespace QuantityMeasurementApp.Models
{
    public class Feet
    {
        private double Value;

        public Feet(double value)
        {
            Value = value;
        }

        public double GetValue()
        {
            return Value;
        }

        public override bool Equals(object? obj)
        {
            // Check reference equality (Reflexive property)
            if (ReferenceEquals(this, obj))//Reference check
            {
                return true;
            }

            // Return false if object is null
            if(obj is null)//null check
            {
                return false;
            }

            //Ensure type safety
            if(obj.GetType() != typeof(Feet))//type check
            {
                return false;
            }

            //Safe cast
            Feet other = (Feet)obj;

            return Value.CompareTo(other.Value) == 0;
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}