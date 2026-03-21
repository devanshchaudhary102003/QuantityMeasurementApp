using System;

namespace QuantityMeasurementApp.Enums
{    public enum WeightUnit
    {
        Kilogram,
        Gram,
        Pound
    }
    public static class WeightUnitExtension
    {
        public static double ConvertToKilogram(this WeightUnit unit)
        {
            if (unit == WeightUnit.Kilogram)
            {
                return 1.0;
            }   
            else if (unit == WeightUnit.Gram)
            {
                return 0.001;
            }
            else if (unit == WeightUnit.Pound)
            {
                return 0.453592;
            }
            else
            {
                throw new ArgumentException("Unsupported Weight Unit");
            }
        }

        public static double ConvertToBaseUnit(this WeightUnit unit, double value)
        {
            return value * unit.ConvertToKilogram();
        }

        public static double ConvertFromBaseUnit(this WeightUnit unit, double baseValue)
        {
            return baseValue / unit.ConvertToKilogram();
        }
    }
}