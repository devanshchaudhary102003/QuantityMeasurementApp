namespace ModelLayer.Models
{
    /// <summary>
    /// Entity used for repository persistence and standardized response handling.
    /// </summary>
    [Serializable]
    public class QuantityMeasurementEntity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string OperationType { get; private set; } = string.Empty;

        public QuantityDTO? Operand1 { get; private set; }
        public QuantityDTO? Operand2 { get; private set; }

        public QuantityDTO? QuantityResult { get; private set; }
        public bool? ComparisonResult { get; private set; }
        public double? ScalarResult { get; private set; }

        public bool IsError { get; private set; }
        public string? ErrorMessage { get; private set; }

        public QuantityMeasurementEntity(
            string operationType,
            QuantityDTO? operand1,
            QuantityDTO? operand2,
            QuantityDTO? quantityResult = null,
            bool? comparisonResult = null,
            double? scalarResult = null)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            OperationType = operationType;
            Operand1 = operand1;
            Operand2 = operand2;
            QuantityResult = quantityResult;
            ComparisonResult = comparisonResult;
            ScalarResult = scalarResult;
            IsError = false;
        }

        public QuantityMeasurementEntity(
            string operationType,
            QuantityDTO? operand1,
            QuantityDTO? operand2,
            string errorMessage)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            OperationType = operationType;
            Operand1 = operand1;
            Operand2 = operand2;
            IsError = true;
            ErrorMessage = errorMessage;
        }
    }
}