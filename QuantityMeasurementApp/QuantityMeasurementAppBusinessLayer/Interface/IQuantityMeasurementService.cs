using QuantityMeasurementAppModelLayer.DTOs;
using QuantityMeasurementAppModelLayer.Models;

namespace QuantityMeasurementAppBusinessLayer.Interface
{
    public interface IQuantityMeasurementService
    {
        bool Compare(QuantityDTO first, QuantityDTO second);
        QuantityModel Add(QuantityDTO first, QuantityDTO second);
        List<QuantityMeasurementEntity> GetHistory();
    }
}