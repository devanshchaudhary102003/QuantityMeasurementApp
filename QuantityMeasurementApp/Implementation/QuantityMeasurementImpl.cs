using System;
using QuantityMeasurementApp.Interface;
using QuantityMeasurementApp.Model;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Implementation
{
    public class QuantityMeasurementImpl : IQuantityMeasurement
    {
        // 🔹 GENERIC CORE METHODS (UNCHANGED)

        public void Compare<U>(Quantity<U> q1, Quantity<U> q2) where U : Enum
        {
            bool result = q1.Equals(q2);
            Console.WriteLine(result ? "Equal (true)" : "Not Equal (false)");
        }

        public void Conver<U>(Quantity<U> q, U targetUnit) where U : Enum
        {
            var result = q.ConvertTo(targetUnit);
            Console.WriteLine($"Converted: {result}");
        }

        public void Add<U>(Quantity<U> q1, Quantity<U> q2, U targetUnit) where U : Enum
        {
            var result = q1.Add(q2, targetUnit);
            Console.WriteLine($"Result: {result}");
        }

        // 🔥 NEW: HANDLE METHODS (SHIFTED FROM MENU)

        public void HandleCompare()
        {
            Console.WriteLine("Select Category: 1. Length  2. Weight");
            int category = Convert.ToInt32(Console.ReadLine());

            if (category == 1)
            {
                var unit1 = ReadLengthUnit();
                Console.WriteLine("Enter First Value:");
                double v1 = Convert.ToDouble(Console.ReadLine());

                var unit2 = ReadLengthUnit();
                Console.WriteLine("Enter Second Value:");
                double v2 = Convert.ToDouble(Console.ReadLine());

                var q1 = new Quantity<LengthUnit>(v1, unit1);
                var q2 = new Quantity<LengthUnit>(v2, unit2);

                Compare(q1, q2); // 🔥 calling generic
            }
            else
            {
                var unit1 = ReadWeightUnit();
                Console.WriteLine("Enter First Value:");
                double v1 = Convert.ToDouble(Console.ReadLine());

                var unit2 = ReadWeightUnit();
                Console.WriteLine("Enter Second Value:");
                double v2 = Convert.ToDouble(Console.ReadLine());

                var q1 = new Quantity<WeightUnit>(v1, unit1);
                var q2 = new Quantity<WeightUnit>(v2, unit2);

                Compare(q1, q2); // 🔥 calling generic
            }
        }

        public void HandleConvert()
        {
            Console.WriteLine("Select Category: 1. Length  2. Weight");
            int category = Convert.ToInt32(Console.ReadLine());

            if (category == 1)
            {
                var unit = ReadLengthUnit();
                Console.WriteLine("Enter Value:");
                double value = Convert.ToDouble(Console.ReadLine());

                var target = ReadLengthUnit();

                var q = new Quantity<LengthUnit>(value, unit);
                Conver(q, target); // 🔥 calling generic
            }
            else
            {
                var unit = ReadWeightUnit();
                Console.WriteLine("Enter Value:");
                double value = Convert.ToDouble(Console.ReadLine());

                var target = ReadWeightUnit();

                var q = new Quantity<WeightUnit>(value, unit);
                Conver(q, target); // 🔥 calling generic
            }
        }

        public void HandleAdd()
        {
            Console.WriteLine("Select Category: 1. Length  2. Weight");
            int category = Convert.ToInt32(Console.ReadLine());

            if (category == 1)
            {
                var unit1 = ReadLengthUnit();
                Console.WriteLine("Enter First Value:");
                double v1 = Convert.ToDouble(Console.ReadLine());

                var unit2 = ReadLengthUnit();
                Console.WriteLine("Enter Second Value:");
                double v2 = Convert.ToDouble(Console.ReadLine());

                var target = ReadLengthUnit();

                var q1 = new Quantity<LengthUnit>(v1, unit1);
                var q2 = new Quantity<LengthUnit>(v2, unit2);

                Add(q1, q2, target); // 🔥 calling generic
            }
            else
            {
                var unit1 = ReadWeightUnit();
                Console.WriteLine("Enter First Value:");
                double v1 = Convert.ToDouble(Console.ReadLine());

                var unit2 = ReadWeightUnit();
                Console.WriteLine("Enter Second Value:");
                double v2 = Convert.ToDouble(Console.ReadLine());

                var target = ReadWeightUnit();

                var q1 = new Quantity<WeightUnit>(v1, unit1);
                var q2 = new Quantity<WeightUnit>(v2, unit2);

                Add(q1, q2, target); // 🔥 calling generic
            }
        }

        // 🔹 UNIT METHODS

        private LengthUnit ReadLengthUnit()
        {
            Console.WriteLine("1. Feet  2. Inch  3. Yard  4. Centimeter");
            int choice = Convert.ToInt32(Console.ReadLine());

            return choice switch
            {
                1 => LengthUnit.Feet,
                2 => LengthUnit.Inch,
                3 => LengthUnit.Yard,
                4 => LengthUnit.Centimeter,
                _ => LengthUnit.Feet
            };
        }

        private WeightUnit ReadWeightUnit()
        {
            Console.WriteLine("1. Kilogram  2. Gram  3. Pound");
            int choice = Convert.ToInt32(Console.ReadLine());

            return choice switch
            {
                1 => WeightUnit.Kilogram,
                2 => WeightUnit.Gram,
                3 => WeightUnit.Pound,
                _ => WeightUnit.Kilogram
            };
        }
    }
}