using System;

namespace QuantityMeasurementApp.Enums
{
    public enum LengthUnit
    {
        Feet,
        Inch,
        Yard,
        Centimeter

    }

    public static class LengthUnitExtension
    {
        public static double ToFeetFactor(this LengthUnit unit)
        {
            if(unit == LengthUnit.Feet)
            {
                return 1.0; // already in feet
            }

            else if(unit == LengthUnit.Inch)
            {
                return 1.0 / 12.0;  // convert inch to feet
            }

            else if(unit == LengthUnit.Yard)
            {
                return 3.0; 
            }

            else if(unit == LengthUnit.Centimeter)
            {
                return 0.393701 / 12.0;  
            }

            else
            {
                throw new ArgumentException("Unsupported Length Unit");
            }
        }

        /// Converts a value in the current unit into base unit (Feet).
        /// Example:
        /// 12 Inch -> 1 Feet
        public static double ConvertToBaseUnit(this LengthUnit unit, double value)
        {
            return value * unit.ToFeetFactor();
        }

        /// Converts a value in base unit (Feet) into the current unit.
        /// Example:
        /// 1 Feet -> 12 Inch
        public static double ConvertFromBaseUnit(this LengthUnit unit, double baseValue)
        {
            return baseValue / unit.ToFeetFactor();
        }
    }
}