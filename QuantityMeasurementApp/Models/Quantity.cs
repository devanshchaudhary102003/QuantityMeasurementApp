using System;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Generic immutable quantity model that supports multiple
    /// measurement categories such as Length, Weight, Volume, and Temperature.
    ///
    /// TYPE PARAMETER:
    /// U represents the unit type for a specific category.
    ///
    /// DESIGN GOALS:
    /// - Reuse one quantity model across all supported measurement categories
    /// - Keep unit-specific conversion logic inside enum extension methods
    /// - Preserve category isolation through generic typing
    /// - Centralize arithmetic validation and execution to enforce DRY
    ///
    /// UC13:
    /// - Eliminates duplication across Add, Subtract, and Divide
    /// - Uses centralized validation and base-unit arithmetic helpers
    ///
    /// UC14:
    /// - Adds Temperature category support
    /// - Allows conversion and equality for temperature
    /// - Blocks unsupported arithmetic operations for temperature
    ///   through centralized operation-support validation
    /// </summary>
    /// <typeparam name="U">Unit enum type</typeparam>
    public class Quantity<U> where U : struct, Enum
    {
        /// <summary>
        /// Numeric value of the quantity.
        /// </summary>
        public double Value { get; }

        /// <summary>
        /// Unit associated with the quantity value.
        /// </summary>
        public U Unit { get; }

        /// <summary>
        /// Tolerance used for floating-point equality comparison.
        /// </summary>
        private const double EPSILON = 1e-5;

        /// <summary>
        /// Internal arithmetic operation selector used to centralize
        /// common arithmetic logic in one helper method.
        /// </summary>
        private enum ArithmeticOperation
        {
            Add,
            Subtract,
            Divide
        }

        /// <summary>
        /// Creates a new immutable quantity instance.
        ///
        /// VALIDATION:
        /// - Value must be finite
        /// - Unit must be a defined enum value
        /// </summary>
        /// <param name="value">Measurement value</param>
        /// <param name="unit">Measurement unit</param>
        public Quantity(double value, U unit)
        {
            ValidateFinite(value, nameof(value));
            ValidateUnit(unit, nameof(unit));

            Value = value;
            Unit = unit;
        }

        /// <summary>
        /// Returns the stored numeric value.
        /// </summary>
        public double GetValue()
        {
            return Value;
        }

        /// <summary>
        /// Returns the stored unit.
        /// </summary>
        public U GetUnit()
        {
            return Unit;
        }

        /// <summary>
        /// Converts the current quantity into its category base unit.
        ///
        /// SUPPORTED CATEGORIES:
        /// - Length
        /// - Weight
        /// - Volume
        /// - Temperature
        ///
        /// DESIGN NOTE:
        /// Each category owns its own conversion logic through enum extension methods.
        /// This class only routes execution to the correct conversion implementation.
        /// </summary>
        /// <returns>Equivalent numeric value in the category base unit.</returns>
        private double ConvertToBaseUnit()
        {
            if (Unit is LengthUnit lengthUnit)
                return lengthUnit.ConvertToBaseUnit(Value);

            if (Unit is WeightUnit weightUnit)
                return weightUnit.ConvertToBaseUnit(Value);

            if (Unit is VolumeUnit volumeUnit)
                return volumeUnit.ConvertToBaseUnit(Value);

            if (Unit is TemperatureUnit temperatureUnit)
                return temperatureUnit.ConvertToBaseUnit(Value);

            throw new ArgumentException("Unsupported measurement category.");
        }

        /// <summary>
        /// Converts a normalized base-unit value into the requested target unit.
        ///
        /// DESIGN NOTE:
        /// Temperature is handled here as well. Even though temperature arithmetic
        /// is restricted, temperature conversion and equality are fully supported.
        /// </summary>
        /// <param name="baseValue">Normalized base-unit value</param>
        /// <param name="targetUnit">Desired target unit</param>
        /// <returns>Converted numeric value in the requested target unit.</returns>
        private double ConvertFromBaseUnit(double baseValue, U targetUnit)
        {
            if (targetUnit is LengthUnit lengthUnit)
                return lengthUnit.ConvertFromBaseUnit(baseValue);

            if (targetUnit is WeightUnit weightUnit)
                return weightUnit.ConvertFromBaseUnit(baseValue);

            if (targetUnit is VolumeUnit volumeUnit)
                return volumeUnit.ConvertFromBaseUnit(baseValue);

            if (targetUnit is TemperatureUnit temperatureUnit)
                return temperatureUnit.ConvertFromBaseUnit(baseValue);

            throw new ArgumentException("Unsupported measurement category.");
        }

        /// <summary>
        /// Converts the current quantity into the specified target unit.
        ///
        /// DESIGN NOTE:
        /// This works for all supported categories, including temperature.
        /// </summary>
        /// <param name="targetUnit">Target unit for conversion</param>
        /// <returns>New converted quantity</returns>
        public Quantity<U> ConvertTo(U targetUnit)
        {
            ValidateTargetUnit(targetUnit);

            double baseValue = ConvertToBaseUnit();
            double convertedValue = ConvertFromBaseUnit(baseValue, targetUnit);

            return new Quantity<U>(convertedValue, targetUnit);
        }

        /// <summary>
        /// Adds another quantity of the same category and returns
        /// the result in the current quantity's unit.
        ///
        /// NOTE:
        /// This method delegates to the explicit-target overload,
        /// using the current unit as the implicit result unit.
        /// </summary>
        /// <param name="other">Other quantity to add</param>
        /// <returns>New quantity in current unit</returns>
        public Quantity<U> Add(Quantity<U> other)
        {
            return Add(other, Unit);
        }

        /// <summary>
        /// Adds another quantity of the same category and returns
        /// the result in a user-specified target unit.
        ///
        /// UC13:
        /// Common validation and arithmetic logic are centralized.
        ///
        /// UC14:
        /// Arithmetic support is validated before execution.
        /// Temperature will be rejected here with a meaningful exception.
        ///
        /// ROUNDING RULE:
        /// Addition preserves full computed precision to maintain
        /// backward compatibility with earlier use cases and existing tests.
        /// </summary>
        /// <param name="other">Other quantity to add</param>
        /// <param name="targetUnit">Desired result unit</param>
        /// <returns>New quantity in target unit</returns>
        public Quantity<U> Add(Quantity<U> other, U targetUnit)
        {
            ValidateArithmeticOperands(other, targetUnit, true, "addition");

            double resultBase = PerformBaseArithmetic(other, ArithmeticOperation.Add);
            double resultValue = ConvertFromBaseUnit(resultBase, targetUnit);

            return new Quantity<U>(resultValue, targetUnit);
        }

        /// <summary>
        /// Subtracts another quantity of the same category and returns
        /// the result in the current quantity's unit.
        ///
        /// NOTE:
        /// This method delegates to the explicit-target overload,
        /// using the current unit as the implicit result unit.
        /// </summary>
        /// <param name="other">Other quantity to subtract</param>
        /// <returns>New quantity in current unit</returns>
        public Quantity<U> Subtract(Quantity<U> other)
        {
            return Subtract(other, Unit);
        }

        /// <summary>
        /// Subtracts another quantity of the same category and returns
        /// the result in a user-specified target unit.
        ///
        /// UC13:
        /// Common validation and arithmetic logic are centralized.
        ///
        /// UC14:
        /// Arithmetic support is validated before execution.
        /// Temperature will be rejected here with a meaningful exception.
        ///
        /// ROUNDING RULE:
        /// Subtraction result is rounded to two decimal places
        /// for arithmetic consistency with prior use cases.
        /// </summary>
        /// <param name="other">Other quantity to subtract</param>
        /// <param name="targetUnit">Desired result unit</param>
        /// <returns>New quantity in target unit</returns>
        public Quantity<U> Subtract(Quantity<U> other, U targetUnit)
        {
            ValidateArithmeticOperands(other, targetUnit, true, "subtraction");

            double resultBase = PerformBaseArithmetic(other, ArithmeticOperation.Subtract);
            double resultValue = ConvertFromBaseUnit(resultBase, targetUnit);
            resultValue = RoundToTwoDecimals(resultValue);

            return new Quantity<U>(resultValue, targetUnit);
        }

        /// <summary>
        /// Divides this quantity by another quantity of the same category.
        ///
        /// RETURN TYPE:
        /// Returns a dimensionless scalar ratio as double.
        ///
        /// UC14:
        /// Arithmetic support is validated before execution.
        /// Temperature will be rejected here with a meaningful exception.
        /// </summary>
        /// <param name="other">Divisor quantity</param>
        /// <returns>Dimensionless scalar ratio</returns>
        public double Divide(Quantity<U> other)
        {
            ValidateArithmeticOperands(other, null, false, "division");
            return PerformBaseArithmetic(other, ArithmeticOperation.Divide);
        }

        /// <summary>
        /// Centralized validation helper for all arithmetic operations.
        ///
        /// VALIDATES:
        /// - Other quantity is not null
        /// - Current and other numeric values are finite
        /// - Current category supports requested arithmetic operation
        /// - Other category supports requested arithmetic operation
        /// - Target unit is valid when required
        ///
        /// DESIGN BENEFIT:
        /// Validation rules now live in one place, which enforces DRY
        /// and guarantees consistent behavior across Add, Subtract, and Divide.
        /// </summary>
        /// <param name="other">Other quantity operand</param>
        /// <param name="targetUnit">Target unit when required</param>
        /// <param name="targetUnitRequired">Indicates whether target unit must be validated</param>
        /// <param name="operationName">Logical name of the operation being requested</param>
        private void ValidateArithmeticOperands(Quantity<U> other, U? targetUnit, bool targetUnitRequired, string operationName)
        {
            ValidateQuantity(other);
            ValidateFinite(Value, nameof(Value));
            ValidateFinite(other.Value, nameof(other.Value));

            ValidateOperationSupport(Unit, operationName);
            ValidateOperationSupport(other.Unit, operationName);

            if (targetUnitRequired)
            {
                if (!targetUnit.HasValue)
                    throw new ArgumentException("Target unit is required.");

                ValidateTargetUnit(targetUnit.Value);
            }
        }

        /// <summary>
        /// Centralized helper for performing arithmetic after validation.
        ///
        /// FLOW:
        /// - Convert both operands to base unit
        /// - Execute requested arithmetic operation
        /// - Return result in base-unit form
        ///
        /// NOTE:
        /// For addition and subtraction, caller converts result from base unit
        /// into desired target unit.
        /// For division, caller directly returns the dimensionless result.
        /// </summary>
        /// <param name="other">Other quantity operand</param>
        /// <param name="operation">Arithmetic operation to perform</param>
        /// <returns>Base-unit arithmetic result or scalar ratio</returns>
        private double PerformBaseArithmetic(Quantity<U> other, ArithmeticOperation operation)
        {
            double thisBase = ConvertToBaseUnit();
            double otherBase = other.ConvertToBaseUnit();

            switch (operation)
            {
                case ArithmeticOperation.Add:
                    return thisBase + otherBase;

                case ArithmeticOperation.Subtract:
                    return thisBase - otherBase;

                case ArithmeticOperation.Divide:
                    if (Math.Abs(otherBase) < EPSILON)
                        throw new ArithmeticException("Division by zero quantity is not allowed.");

                    return thisBase / otherBase;

                default:
                    throw new ArgumentException("Unsupported arithmetic operation.");
            }
        }

        /// <summary>
        /// Validates whether the supplied unit supports the requested operation.
        ///
        /// UC14 PURPOSE:
        /// Some categories, such as temperature, do not support arithmetic
        /// operations in a meaningful way. This method routes validation
        /// to the unit-category-specific extension method.
        /// </summary>
        /// <param name="unit">Unit whose category capability is being checked</param>
        /// <param name="operationName">Operation name such as addition, subtraction, or division</param>
        private void ValidateOperationSupport(U unit, string operationName)
        {
            if (unit is LengthUnit lengthUnit)
            {
                lengthUnit.ValidateOperationSupport(operationName);
                return;
            }

            if (unit is WeightUnit weightUnit)
            {
                weightUnit.ValidateOperationSupport(operationName);
                return;
            }

            if (unit is VolumeUnit volumeUnit)
            {
                volumeUnit.ValidateOperationSupport(operationName);
                return;
            }

            if (unit is TemperatureUnit temperatureUnit)
            {
                temperatureUnit.ValidateOperationSupport(operationName);
                return;
            }

            throw new ArgumentException("Unsupported measurement category.");
        }

        /// <summary>
        /// Rounds a numeric result to two decimal places.
        /// </summary>
        /// <param name="value">Value to round</param>
        /// <returns>Rounded value</returns>
        private double RoundToTwoDecimals(double value)
        {
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Validates that the provided quantity is not null.
        /// </summary>
        /// <param name="other">Quantity to validate</param>
        private void ValidateQuantity(Quantity<U> other)
        {
            if (other == null)
                throw new ArgumentException("Other quantity cannot be null.");
        }

        /// <summary>
        /// Validates that the provided numeric value is finite.
        /// </summary>
        /// <param name="value">Numeric value to validate</param>
        /// <param name="paramName">Logical parameter name</param>
        private void ValidateFinite(double value, string paramName)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException($"{paramName} must be a finite number.");
        }

        /// <summary>
        /// Validates that the target unit is defined and usable.
        /// </summary>
        /// <param name="targetUnit">Target unit</param>
        private void ValidateTargetUnit(U targetUnit)
        {
            ValidateUnit(targetUnit, nameof(targetUnit));
        }

        /// <summary>
        /// Validates that the provided enum value is a defined unit constant.
        /// </summary>
        /// <param name="unit">Unit value to validate</param>
        /// <param name="paramName">Logical parameter name</param>
        private void ValidateUnit(U unit, string paramName)
        {
            if (!Enum.IsDefined(typeof(U), unit))
                throw new ArgumentException($"Invalid unit specified for {paramName}.");
        }

        /// <summary>
        /// Compares this quantity with another object for value equality.
        ///
        /// EQUALITY RULE:
        /// - Same generic category only
        /// - Comparison performed in normalized base unit
        /// - Floating-point tolerance applied
        ///
        /// UC14 NOTE:
        /// Temperature equality works through base-unit conversion exactly
        /// the same way as other supported categories.
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>True if equivalent, otherwise false</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj is not Quantity<U> other)
                return false;

            return Math.Abs(ConvertToBaseUnit() - other.ConvertToBaseUnit()) < EPSILON;
        }

        /// <summary>
        /// Generates a hash code for the quantity.
        ///
        /// NOTE:
        /// For consistent equality semantics, hash code is derived from
        /// normalized base-unit value and the generic unit category.
        /// </summary>
        /// <returns>Hash code for the quantity instance</returns>
        public override int GetHashCode()
        {
            double normalized = Math.Round(ConvertToBaseUnit(), 5);
            return HashCode.Combine(normalized, typeof(U));
        }

        /// <summary>
        /// Returns a readable string representation of the quantity.
        /// </summary>
        /// <returns>Human-readable quantity text</returns>
        public override string ToString()
        {
            return $"{Value} {Unit}";
        }
    }
}