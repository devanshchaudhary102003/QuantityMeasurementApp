namespace ModelLayer.Models
{
    /// <summary>
    /// Internal service model.
    /// </summary>
    public class QuantityModel
    {
        public double Value { get; }
        public string Unit { get; }
        public string MeasurementType { get; }

        public QuantityModel(double value, string unit, string measurementType)
        {
            Value = value;
            Unit = unit;
            MeasurementType = measurementType;
        }
    }
}