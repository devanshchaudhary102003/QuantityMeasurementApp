namespace ModelLayer.Models
{
    /// <summary>
    /// DTO used across controller and service layers.
    /// </summary>
    public class QuantityDTO
    {
        public double Value { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string MeasurementType { get; set; } = string.Empty;

        public QuantityDTO()
        {
        }

        public QuantityDTO(double value, string unit, string measurementType)
        {
            Value = value;
            Unit = unit;
            MeasurementType = measurementType;
        }
    }
}