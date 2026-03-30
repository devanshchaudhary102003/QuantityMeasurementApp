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
            Unit = unit;
        }

        public double GetValue() => Value;
        public U GetUnit() => Unit;

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

        public Quantity<U> ConvertTo(U targetUnit)
        {
            double baseValue = ToBase(Value, Unit);
            double result = FromBase(baseValue, targetUnit);

            return new Quantity<U>(result, targetUnit);
        }
        public Quantity<U> Add(Quantity<U> other)
        {
            return Add(other, Unit);
        }

        public Quantity<U> Add(Quantity<U> other, U targetUnit)
        {
            double base1 = ToBase(Value, Unit);
            double base2 = ToBase(other.Value, other.Unit);

            double sum = base1 + base2;
            double result = FromBase(sum, targetUnit);

            return new Quantity<U>(result, targetUnit);
        }

        public override string ToString()
        {
            return $"{Value} {Unit}";
        }
    }
}