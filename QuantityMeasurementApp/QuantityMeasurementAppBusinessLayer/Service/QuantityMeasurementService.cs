using QuantityMeasurementAppBusinessLayer.Exception;
using QuantityMeasurementAppBusinessLayer.Interface;
using QuantityMeasurementAppModelLayer.DTOs;
using QuantityMeasurementAppModelLayer.Models;
using QuantityMeasurementAppRepositoryLayer.Interface;

namespace QuantityMeasurementAppBusinessLayer.Service
{
    public class QuantityMeasurementService : IQuantityMeasurementService
    {
        private readonly IQuantityMeasurementRepository _repository;

        public QuantityMeasurementService(IQuantityMeasurementRepository repository)
        {
            _repository = repository;
        }

        public bool Compare(QuantityDTO first, QuantityDTO second)
        {
            Validate(first);
            Validate(second);

            if (!first.Category.Equals(second.Category, StringComparison.OrdinalIgnoreCase))
                throw new QuantityMeasurementException("Cannot compare different categories.");

            double firstBase = ConvertToBase(first);
            double secondBase = ConvertToBase(second);

            SaveHistory(first);
            SaveHistory(second);

            return Math.Abs(firstBase - secondBase) < 0.0001;
        }

        public QuantityModel Add(QuantityDTO first, QuantityDTO second)
        {
            Validate(first);
            Validate(second);

            if (!first.Category.Equals(second.Category, StringComparison.OrdinalIgnoreCase))
                throw new QuantityMeasurementException("Cannot add different categories.");

            if (first.Category.Equals("Temperature", StringComparison.OrdinalIgnoreCase))
                throw new QuantityMeasurementException("Addition of temperature is not supported.");

            double firstBase = ConvertToBase(first);
            double secondBase = ConvertToBase(second);

            SaveHistory(first);
            SaveHistory(second);

            return new QuantityModel
            {
                BaseValue = firstBase + secondBase,
                Unit = GetBaseUnit(first.Category),
                Category = first.Category
            };
        }

        public List<QuantityMeasurementEntity> GetHistory()
        {
            return _repository.GetAll();
        }

        private void SaveHistory(QuantityDTO dto)
        {
            _repository.Save(new QuantityMeasurementEntity
            {
                Value = dto.Value,
                Unit = dto.Unit,
                Category = dto.Category
            });
        }

        private void Validate(QuantityDTO dto)
        {
            if (dto == null)
                throw new QuantityMeasurementException("Quantity cannot be null.");

            if (string.IsNullOrWhiteSpace(dto.Category))
                throw new QuantityMeasurementException("Category is required.");

            if (string.IsNullOrWhiteSpace(dto.Unit))
                throw new QuantityMeasurementException("Unit is required.");
        }

        private double ConvertToBase(QuantityDTO dto)
        {
            string category = dto.Category.Trim().ToLower();
            string unit = dto.Unit.Trim().ToLower();

            return category switch
            {
                "length" => unit switch
                {
                    "inch" => dto.Value,
                    "feet" => dto.Value * 12,
                    "yard" => dto.Value * 36,
                    "centimeter" => dto.Value / 2.54,
                    _ => throw new QuantityMeasurementException("Invalid length unit.")
                },

                "weight" => unit switch
                {
                    "gram" => dto.Value,
                    "kilogram" => dto.Value * 1000,
                    "tonne" => dto.Value * 1000000,
                    _ => throw new QuantityMeasurementException("Invalid weight unit.")
                },

                "volume" => unit switch
                {
                    "milliliter" => dto.Value,
                    "liter" => dto.Value * 1000,
                    "gallon" => dto.Value * 3785.41,
                    _ => throw new QuantityMeasurementException("Invalid volume unit.")
                },

                "temperature" => unit switch
                {
                    "celsius" => dto.Value,
                    "fahrenheit" => (dto.Value - 32) * 5 / 9,
                    "kelvin" => dto.Value - 273.15,
                    _ => throw new QuantityMeasurementException("Invalid temperature unit.")
                },

                _ => throw new QuantityMeasurementException("Invalid category.")
            };
        }

        private string GetBaseUnit(string category)
        {
            return category.Trim().ToLower() switch
            {
                "length" => "Inch",
                "weight" => "Gram",
                "volume" => "Milliliter",
                "temperature" => "Celsius",
                _ => "Unknown"
            };
        }
    }
}