using System;
namespace QuantityMeasurementApp.Enums
{
    public enum VolumeUnit
    {
        Litre,
        Millilitre,
        Gallon
    }

    public static class VolumeUnitExtension
    {
        public static double ToVolumeFactor(this VolumeUnit unit)
        {
            if(unit == VolumeUnit.Litre)
            {
                return 1.0;
            }

            else if(unit == VolumeUnit.Millilitre)
            {
                return 0.001;
            }

            else if(unit == VolumeUnit.Gallon)
            {
                return 3.78541;
            }

            else
            {
                throw new ArgumentException("Unsupported Volume Unit");
            }
        }

        public static double GetConversionFactor(this VolumeUnit unit)
        {
            return unit.ToVolumeFactor();
        }

        public static string GetUnitName(this VolumeUnit unit)
        {
            return unit.ToString();
        }

        public static double ConvertToBaseUnit(this VolumeUnit unit, double value)
        {
            return value * unit.ToVolumeFactor();
        }

        public static double ConvertFromBaseUnit(this VolumeUnit unit, double baseValue)
        {
            return baseValue / unit.ToVolumeFactor();
        }
    }
}