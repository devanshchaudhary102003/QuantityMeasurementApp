using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Model
{
    public class Quantity<U> where U : Enum
    {
        private const double EPSILON = 1e-5;

        public double Value { get; }
        public U Unit { get; }

        public Quantity(double value, U unit)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Invalid value");

            Value = value;
            Unit = unit ?? throw new ArgumentException("Unit cannot be null");
        }

        
        // 🔹 ENUM FOR OPERATIONS (UC13 CORE)
        
        private enum ArithmeticOperation
        {
            ADD,
            SUBTRACT,
            DIVIDE
        }

        // 🔹 CENTRAL VALIDATION (DRY)
        
        private void Validate(Quantity<U> other, U targetUnit, bool targetRequired)
        {
            if (other == null)
                throw new ArgumentException("Quantity cannot be null");

            if (double.IsNaN(other.Value) || double.IsInfinity(other.Value))
                throw new ArgumentException("Invalid value");

            if (targetRequired && targetUnit == null)
                throw new ArgumentException("Target unit cannot be null");
        }

        // 🔹 BASE CONVERSION
       
        private double ToBase(double value, U unit)
        {
            if (unit is LengthUnit l)
                return l.ConvertToBaseUnit(value);

            if (unit is WeightUnit w)
                return w.ConvertToBaseUnit(value);

            if (unit is VolumeUnit v)
                return v.ConvertToBaseUnit(value);

            throw new ArgumentException("Unsupported unit");
        }

        private double FromBase(double baseValue, U unit)
        {
            if (unit is LengthUnit l)
                return l.ConvertFromBaseUnit(baseValue);

            if (unit is WeightUnit w)
                return w.ConvertFromBaseUnit(baseValue);

            if (unit is VolumeUnit v)
                return v.ConvertFromBaseUnit(baseValue);

            throw new ArgumentException("Unsupported unit");
        }

        private double Round(double value) => Math.Round(value, 2);

        
        // CORE HELPER METHOD (UC13)
       
        private double PerformBaseArithmetic(Quantity<U> other, ArithmeticOperation op)
        {
            double base1 = ToBase(Value, Unit);
            double base2 = ToBase(other.Value, other.Unit);

            return op switch
            {
                ArithmeticOperation.ADD => base1 + base2,
                ArithmeticOperation.SUBTRACT => base1 - base2,
                ArithmeticOperation.DIVIDE => base2 == 0
                    ? throw new ArithmeticException("Division by zero")
                    : base1 / base2,
                _ => throw new ArgumentException("Invalid operation")
            };
        }

        // ADD (REFactored)
        
        public Quantity<U> Add(Quantity<U> other)
        {
            return Add(other, Unit);
        }

        public Quantity<U> Add(Quantity<U> other, U targetUnit)
        {
            Validate(other, targetUnit, true);

            double baseResult = PerformBaseArithmetic(other, ArithmeticOperation.ADD);
            double result = FromBase(baseResult, targetUnit);

            return new Quantity<U>(Round(result), targetUnit);
        }

        // SUBTRACT (REFactored)
       
        public Quantity<U> Subtract(Quantity<U> other)
        {
            return Subtract(other, Unit);
        }

        public Quantity<U> Subtract(Quantity<U> other, U targetUnit)
        {
            Validate(other, targetUnit, true);

            double baseResult = PerformBaseArithmetic(other, ArithmeticOperation.SUBTRACT);
            double result = FromBase(baseResult, targetUnit);

            return new Quantity<U>(Round(result), targetUnit);
        }

        //  DIVIDE (REFactored)
       
        public double Divide(Quantity<U> other)
        {
            Validate(other, default, false);

            return PerformBaseArithmetic(other, ArithmeticOperation.DIVIDE);
        }

        // 🔹 OTHER METHODS (UNCHANGED)
        
        public Quantity<U> ConvertTo(U targetUnit)
        {
            double baseValue = ToBase(Value, Unit);
            double result = FromBase(baseValue, targetUnit);

            return new Quantity<U>(result, targetUnit);
        }

        public override bool Equals(object obj)
        {
            if (obj is not Quantity<U> other)
                return false;

            double base1 = ToBase(Value, Unit);
            double base2 = ToBase(other.Value, other.Unit);

            return Math.Abs(base1 - base2) < EPSILON;
        }

        public override int GetHashCode()
        {
            double baseValue = ToBase(Value, Unit);
            return Math.Round(baseValue, 5).GetHashCode();
        }

        public override string ToString()
        {
            return $"{Value} {Unit}";
        }
    }
}

/* DRY Principle

Before 
Add → Validation + Conversion + Logic
Subtract → SAME
Divide → SAME

After 
All → PerformBaseArithmetic()
All → Validate()*/