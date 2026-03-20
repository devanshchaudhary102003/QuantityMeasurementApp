using System;

namespace QuantityMeasurementApp.Enums
{
    public enum LengthUnit
    {
        Feet,
        Inch,

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

            else
            {
                throw new ArgumentException("Unsupported Length Unit");
            }
        }
    }
}