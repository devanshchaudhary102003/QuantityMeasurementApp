using System;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Model
{
    public class Quantity<U> where U : Enum
    {
        public double Value { get; }
        public U Unit { get; }

        public Quantity(double value, U unit)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Invalid value");

            Value = value;
            Unit = unit;
        }

        private double ToBase(double value, U unit)
        {
            if (unit is LengthUnit l)
                return l.ConvertToBaseUnit(value);

            if (unit is WeightUnit w)
                return w.ConvertToBaseUnit(value);

            throw new ArgumentException("Unsupported unit");
        }

        private double FromBase(double baseValue, U unit)
        {
            if (unit is LengthUnit l)
                return l.ConvertFromBaseUnit(baseValue);

            if (unit is WeightUnit w)
                return w.ConvertFromBaseUnit(baseValue);

            throw new ArgumentException("Unsupported unit");
        }

        public override bool Equals(object obj)
        {
            if (obj is not Quantity<U> other)
                return false;

            double base1 = ToBase(Value, Unit);
            double base2 = ToBase(other.Value, other.Unit);

            return Math.Round(base1, 2) == Math.Round(base2, 2);
        }

        public override int GetHashCode()
        {
            double baseValue = ToBase(Value, Unit);
            return Math.Round(baseValue, 2).GetHashCode();
        }

        public Quantity<U> ConvertTo(U targetUnit)
        {
            double baseValue = ToBase(Value, Unit);
            double result = FromBase(baseValue, targetUnit);

            return new Quantity<U>(Math.Round(result, 2), targetUnit);
        }

        public Quantity<U> Add(Quantity<U> other, U targetUnit)
        {
            double base1 = ToBase(Value, Unit);
            double base2 = ToBase(other.Value, other.Unit);

            double sum = base1 + base2;
            double result = FromBase(sum, targetUnit);

            return new Quantity<U>(Math.Round(result, 2), targetUnit);
        }

        public override string ToString()
        {
            return $"{Value} {Unit}";
        }
    }
}