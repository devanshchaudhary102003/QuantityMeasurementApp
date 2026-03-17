using QuantityMeasurementAppModelLayer.DTOs;
using QuantityMeasurementAppModelLayer.Models;

namespace QuantityMeasurementAppBusinessLayer.Interface
{
    public interface IQuantityMeasurementService
    {
        bool Compare(QuantityDTO first, QuantityDTO second);
        QuantityDTO Add(QuantityDTO first, QuantityDTO second);
        QuantityDTO Subtract(QuantityDTO first, QuantityDTO second);
        QuantityDTO Multiply(QuantityDTO quantity, double factor);
        QuantityDTO Divide(QuantityDTO quantity, double divisor);
        QuantityDTO Convert(QuantityDTO source, string targetUnit);
        List<QuantityMeasurementEntity> GetHistory();
    }
}