namespace QMAOperationService.DTOs
{
    public class QuantityDTO
    {
        public double Value { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }

    public class QuantityInputDTO
    {
        public QuantityDTO? QuantityOne { get; set; }
        public QuantityDTO? QuantityTwo { get; set; }
    }

    public class ConvertDTO
    {
        public QuantityDTO? QuantityOne { get; set; }
        public string TargetUnit { get; set; } = string.Empty;
    }

    // DTO used when calling HistoryService over HTTP
    public class SaveHistoryDTO
    {
        public int UserId { get; set; }
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public string Unit1 { get; set; } = string.Empty;
        public string Unit2 { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Operation { get; set; } = string.Empty;
        public double Result { get; set; }
    }

    public enum LengthUnit { Inch, Feet, Yard, Centimeter }
    public enum WeightUnit { Gram, Kilogram, Tonne }
    public enum VolumeUnit { Milliliter, Liter, Gallon }
    public enum TemperatureUnit { Celsius, Fahrenheit, Kelvin }
}
