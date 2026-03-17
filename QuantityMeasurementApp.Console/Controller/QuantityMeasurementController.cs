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

        public QuantityDTO AddQuantities(QuantityDTO first, QuantityDTO second)
        {
            return _service.Add(first, second);
        }

        public QuantityDTO SubtractQuantities(QuantityDTO first, QuantityDTO second)
        {
            return _service.Subtract(first, second);
        }

        public QuantityDTO MultiplyQuantity(QuantityDTO quantity, double factor)
        {
            return _service.Multiply(quantity, factor);
        }

        public QuantityDTO DivideQuantity(QuantityDTO quantity, double divisor)
        {
            return _service.Divide(quantity, divisor);
        }

        public QuantityDTO ConvertQuantity(QuantityDTO quantity, string targetUnit)
        {
            return _service.Convert(quantity, targetUnit);
        }

        public List<QuantityMeasurementEntity> GetAllHistory()
        {
            return _service.GetHistory();
        }
    }
}