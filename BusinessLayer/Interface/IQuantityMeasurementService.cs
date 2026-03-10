using ModelLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IQuantityMeasurementService
    {
        QuantityMeasurementEntity Compare(QuantityDTO left, QuantityDTO right);
        QuantityMeasurementEntity Convert(QuantityDTO source, string targetUnit);
        QuantityMeasurementEntity Add(QuantityDTO left, QuantityDTO right);
        QuantityMeasurementEntity Subtract(QuantityDTO left, QuantityDTO right);
        QuantityMeasurementEntity Divide(QuantityDTO left, QuantityDTO right);
        IReadOnlyList<QuantityMeasurementEntity> GetHistory();
    }
}