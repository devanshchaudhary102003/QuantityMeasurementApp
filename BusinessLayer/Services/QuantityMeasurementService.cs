using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces;
using ModelLayer.Models;

namespace BusinessLayer.Services
{
    public class QuantityMeasurementService : IQuantityMeasurementService
    {
        private const double EPSILON = 1e-6;
        private readonly IQuantityMeasurementRepository _repository;

        public QuantityMeasurementService(IQuantityMeasurementRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public QuantityMeasurementEntity Compare(QuantityDTO left, QuantityDTO right)
        {
            return Execute("COMPARE", left, right, () =>
            {
                ValidateNotNull(left, nameof(left));
                ValidateNotNull(right, nameof(right));
                ValidateCompatible(left, right);

                double leftBase = UnitCatalog.ConvertToBaseUnit(left.MeasurementType, left.Unit, left.Value);
                double rightBase = UnitCatalog.ConvertToBaseUnit(right.MeasurementType, right.Unit, right.Value);

                bool result = Math.Abs(leftBase - rightBase) < EPSILON;
                return new QuantityMeasurementEntity("COMPARE", left, right, comparisonResult: result);
            });
        }

        public QuantityMeasurementEntity Convert(QuantityDTO source, string targetUnit)
        {
            return Execute("CONVERT", source, null, () =>
            {
                ValidateNotNull(source, nameof(source));
                ValidateQuantity(source);

                if (string.IsNullOrWhiteSpace(targetUnit))
                    throw new QuantityMeasurementException("Target unit is required.");

                if (!UnitCatalog.IsUnitValidForMeasurement(source.MeasurementType, targetUnit))
                    throw new QuantityMeasurementException(
                        $"Target unit '{targetUnit}' is not valid for measurement type '{source.MeasurementType}'.");

                double baseValue = UnitCatalog.ConvertToBaseUnit(source.MeasurementType, source.Unit, source.Value);
                double convertedValue = UnitCatalog.ConvertFromBaseUnit(source.MeasurementType, targetUnit, baseValue);

                var resultDto = new QuantityDTO(convertedValue, targetUnit, source.MeasurementType);
                return new QuantityMeasurementEntity("CONVERT", source, null, quantityResult: resultDto);
            });
        }

        public QuantityMeasurementEntity Add(QuantityDTO left, QuantityDTO right)
        {
            return Execute("ADD", left, right, () =>
            {
                ValidateNotNull(left, nameof(left));
                ValidateNotNull(right, nameof(right));
                ValidateCompatible(left, right);
                ValidateArithmeticSupported(left.MeasurementType);

                double leftBase = UnitCatalog.ConvertToBaseUnit(left.MeasurementType, left.Unit, left.Value);
                double rightBase = UnitCatalog.ConvertToBaseUnit(right.MeasurementType, right.Unit, right.Value);
                double resultBase = leftBase + rightBase;
                double resultValue = UnitCatalog.ConvertFromBaseUnit(left.MeasurementType, left.Unit, resultBase);

                var resultDto = new QuantityDTO(resultValue, left.Unit, left.MeasurementType);
                return new QuantityMeasurementEntity("ADD", left, right, quantityResult: resultDto);
            });
        }

        public QuantityMeasurementEntity Subtract(QuantityDTO left, QuantityDTO right)
        {
            return Execute("SUBTRACT", left, right, () =>
            {
                ValidateNotNull(left, nameof(left));
                ValidateNotNull(right, nameof(right));
                ValidateCompatible(left, right);
                ValidateArithmeticSupported(left.MeasurementType);

                double leftBase = UnitCatalog.ConvertToBaseUnit(left.MeasurementType, left.Unit, left.Value);
                double rightBase = UnitCatalog.ConvertToBaseUnit(right.MeasurementType, right.Unit, right.Value);
                double resultBase = leftBase - rightBase;
                double resultValue = UnitCatalog.ConvertFromBaseUnit(left.MeasurementType, left.Unit, resultBase);

                var resultDto = new QuantityDTO(resultValue, left.Unit, left.MeasurementType);
                return new QuantityMeasurementEntity("SUBTRACT", left, right, quantityResult: resultDto);
            });
        }

        public QuantityMeasurementEntity Divide(QuantityDTO left, QuantityDTO right)
        {
            return Execute("DIVIDE", left, right, () =>
            {
                ValidateNotNull(left, nameof(left));
                ValidateNotNull(right, nameof(right));
                ValidateCompatible(left, right);

                double numerator = UnitCatalog.ConvertToBaseUnit(left.MeasurementType, left.Unit, left.Value);
                double denominator = UnitCatalog.ConvertToBaseUnit(right.MeasurementType, right.Unit, right.Value);

                if (Math.Abs(denominator) < EPSILON)
                    throw new QuantityMeasurementException("Division by zero is not allowed.");

                double scalar = numerator / denominator;
                return new QuantityMeasurementEntity("DIVIDE", left, right, scalarResult: scalar);
            });
        }

        public IReadOnlyList<QuantityMeasurementEntity> GetHistory()
        {
            return _repository.GetAll();
        }

        private QuantityMeasurementEntity Execute(
            string operation,
            QuantityDTO? left,
            QuantityDTO? right,
            Func<QuantityMeasurementEntity> action)
        {
            try
            {
                QuantityMeasurementEntity entity = action();
                _repository.Save(entity);
                return entity;
            }
            catch (Exception ex) when (ex is QuantityMeasurementException or ArgumentException or InvalidOperationException)
            {
                var errorEntity = new QuantityMeasurementEntity(operation, left, right, ex.Message);
                _repository.Save(errorEntity);
                return errorEntity;
            }
        }

        private static void ValidateNotNull(object? obj, string paramName)
        {
            if (obj is null)
                throw new QuantityMeasurementException($"{paramName} cannot be null.");
        }

        private static void ValidateQuantity(QuantityDTO dto)
        {
            if (!UnitCatalog.IsSupportedMeasurementType(dto.MeasurementType))
                throw new QuantityMeasurementException($"Unsupported measurement type '{dto.MeasurementType}'.");

            if (!UnitCatalog.IsUnitValidForMeasurement(dto.MeasurementType, dto.Unit))
                throw new QuantityMeasurementException(
                    $"Unit '{dto.Unit}' is not valid for measurement type '{dto.MeasurementType}'.");
        }

        private static void ValidateCompatible(QuantityDTO left, QuantityDTO right)
        {
            ValidateQuantity(left);
            ValidateQuantity(right);

            if (!UnitCatalog.AreCompatible(left, right))
                throw new QuantityMeasurementException("Cross-category operations are not allowed.");
        }

        private static void ValidateArithmeticSupported(string measurementType)
        {
            if (!UnitCatalog.SupportsArithmetic(measurementType))
                throw new QuantityMeasurementException(
                    $"Arithmetic operations are not supported for measurement type '{measurementType}'.");
        }
    }
}