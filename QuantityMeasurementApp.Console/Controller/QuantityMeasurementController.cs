using QuantityMeasurementAppBusinessLayer.Interface;
using QuantityMeasurementAppModelLayer.DTOs;
using QuantityMeasurementAppModelLayer.Models;

namespace QuantityMeasurementApp.Console.Controller
{
    public class QuantityMeasurementController
    {
        private readonly IQuantityMeasurementService _service;

        public QuantityMeasurementController(IQuantityMeasurementService service)
        {
            _service = service;
        }

        public bool CompareQuantities(QuantityDTO first, QuantityDTO second)
        {
            return _service.Compare(first, second);
        }

        public QuantityModel AddQuantities(QuantityDTO first, QuantityDTO second)
        {
            return _service.Add(first, second);
        }

        public List<QuantityMeasurementEntity> GetAllHistory()
        {
            return _service.GetHistory();
        }
    }
}