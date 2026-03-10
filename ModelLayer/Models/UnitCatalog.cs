namespace ModelLayer.Models
{
    /// <summary>
    /// Centralized conversion and validation utility for all units.
    /// This is the compile-safe C# replacement for enum-interface behavior.
    /// </summary>
    public static class UnitCatalog
    {
        public static string NormalizeMeasurementType(string measurementType)
        {
            return (measurementType ?? string.Empty).Trim().ToLowerInvariant();
        }

        public static string NormalizeUnit(string unit)
        {
            return (unit ?? string.Empty).Trim().ToLowerInvariant();
        }

        public static bool IsSupportedMeasurementType(string measurementType)
        {
            measurementType = NormalizeMeasurementType(measurementType);

            return measurementType is "length" or "weight" or "volume" or "temperature";
        }

        public static bool IsUnitValidForMeasurement(string measurementType, string unit)
        {
            measurementType = NormalizeMeasurementType(measurementType);
            unit = NormalizeUnit(unit);

            return measurementType switch
            {
                "length" => unit is "feet" or "foot" or "inch" or "inches" or "yard" or "yards" or "centimeter" or "centimeters" or "cm" or "meter" or "meters" or "m",
                "weight" => unit is "gram" or "grams" or "g" or "kilogram" or "kilograms" or "kg" or "pound" or "pounds" or "lb" or "lbs" or "ounce" or "ounces" or "oz",
                "volume" => unit is "liter" or "liters" or "l" or "milliliter" or "milliliters" or "ml" or "gallon" or "gallons",
                "temperature" => unit is "celsius" or "fahrenheit" or "kelvin",
                _ => false
            };
        }

        public static double ConvertToBaseUnit(string measurementType, string unit, double value)
        {
            measurementType = NormalizeMeasurementType(measurementType);
            unit = NormalizeUnit(unit);

            return measurementType switch
            {
                "length" => ConvertLengthToBase(unit, value),       // base = meter
                "weight" => ConvertWeightToBase(unit, value),       // base = gram
                "volume" => ConvertVolumeToBase(unit, value),       // base = liter
                "temperature" => ConvertTemperatureToBase(unit, value), // base = celsius
                _ => throw new ArgumentException($"Unsupported measurement type: {measurementType}")
            };
        }

        public static double ConvertFromBaseUnit(string measurementType, string unit, double baseValue)
        {
            measurementType = NormalizeMeasurementType(measurementType);
            unit = NormalizeUnit(unit);

            return measurementType switch
            {
                "length" => ConvertLengthFromBase(unit, baseValue),
                "weight" => ConvertWeightFromBase(unit, baseValue),
                "volume" => ConvertVolumeFromBase(unit, baseValue),
                "temperature" => ConvertTemperatureFromBase(unit, baseValue),
                _ => throw new ArgumentException($"Unsupported measurement type: {measurementType}")
            };
        }

        private static double ConvertLengthToBase(string unit, double value)
        {
            return unit switch
            {
                "feet" or "foot" => value * 0.3048,
                "inch" or "inches" => value * 0.0254,
                "yard" or "yards" => value * 0.9144,
                "centimeter" or "centimeters" or "cm" => value * 0.01,
                "meter" or "meters" or "m" => value,
                _ => throw new ArgumentException($"Unsupported length unit: {unit}")
            };
        }

        private static double ConvertLengthFromBase(string unit, double baseValue)
        {
            return unit switch
            {
                "feet" or "foot" => baseValue / 0.3048,
                "inch" or "inches" => baseValue / 0.0254,
                "yard" or "yards" => baseValue / 0.9144,
                "centimeter" or "centimeters" or "cm" => baseValue / 0.01,
                "meter" or "meters" or "m" => baseValue,
                _ => throw new ArgumentException($"Unsupported length unit: {unit}")
            };
        }

        private static double ConvertWeightToBase(string unit, double value)
        {
            return unit switch
            {
                "gram" or "grams" or "g" => value,
                "kilogram" or "kilograms" or "kg" => value * 1000.0,
                "pound" or "pounds" or "lb" or "lbs" => value * 453.59237,
                "ounce" or "ounces" or "oz" => value * 28.349523125,
                _ => throw new ArgumentException($"Unsupported weight unit: {unit}")
            };
        }

        private static double ConvertWeightFromBase(string unit, double baseValue)
        {
            return unit switch
            {
                "gram" or "grams" or "g" => baseValue,
                "kilogram" or "kilograms" or "kg" => baseValue / 1000.0,
                "pound" or "pounds" or "lb" or "lbs" => baseValue / 453.59237,
                "ounce" or "ounces" or "oz" => baseValue / 28.349523125,
                _ => throw new ArgumentException($"Unsupported weight unit: {unit}")
            };
        }

        private static double ConvertVolumeToBase(string unit, double value)
        {
            return unit switch
            {
                "liter" or "liters" or "l" => value,
                "milliliter" or "milliliters" or "ml" => value / 1000.0,
                "gallon" or "gallons" => value * 3.78541,
                _ => throw new ArgumentException($"Unsupported volume unit: {unit}")
            };
        }

        private static double ConvertVolumeFromBase(string unit, double baseValue)
        {
            return unit switch
            {
                "liter" or "liters" or "l" => baseValue,
                "milliliter" or "milliliters" or "ml" => baseValue * 1000.0,
                "gallon" or "gallons" => baseValue / 3.78541,
                _ => throw new ArgumentException($"Unsupported volume unit: {unit}")
            };
        }

        private static double ConvertTemperatureToBase(string unit, double value)
        {
            return unit switch
            {
                "celsius" => value,
                "fahrenheit" => (value - 32.0) * 5.0 / 9.0,
                "kelvin" => value - 273.15,
                _ => throw new ArgumentException($"Unsupported temperature unit: {unit}")
            };
        }

        private static double ConvertTemperatureFromBase(string unit, double baseValue)
        {
            return unit switch
            {
                "celsius" => baseValue,
                "fahrenheit" => (baseValue * 9.0 / 5.0) + 32.0,
                "kelvin" => baseValue + 273.15,
                _ => throw new ArgumentException($"Unsupported temperature unit: {unit}")
            };
        }

        public static bool SupportsArithmetic(string measurementType)
        {
            measurementType = NormalizeMeasurementType(measurementType);
            return measurementType is "length" or "weight" or "volume";
        }

        public static bool AreCompatible(QuantityDTO left, QuantityDTO right)
        {
            return NormalizeMeasurementType(left.MeasurementType) ==
                   NormalizeMeasurementType(right.MeasurementType);
        }
    }
}