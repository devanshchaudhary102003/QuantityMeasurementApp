using QuantityMeasurementAppModelLayer.DTOs;
using QuantityMeasurementAppModelLayer.Entity;

namespace QuantityMeasurementAppBusinessLayer.Interface
{
    public interface IQuantityMeasurementService
    {
        bool Compare(QuantityDTO first, QuantityDTO second,int userId);
        QuantityDTO Add(QuantityDTO first, QuantityDTO second,int userId);
        QuantityDTO Subtract(QuantityDTO first, QuantityDTO second,int userId);
        double Divide(QuantityDTO first, QuantityDTO second, int userId);
        QuantityDTO Convert(QuantityDTO source, string targetUnit,int userId);
        IEnumerable<QuantityMeasurementEntity> GetHistory(int userId);
    }
}