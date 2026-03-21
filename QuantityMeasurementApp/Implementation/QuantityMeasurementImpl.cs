using System;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;
using QuantityMeasurementApp.Menu;
using QuantityMeasurementApp.Interface;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Implementation
{
    public class QuantityMeasurementImpl : IQuantityMeasurement
    {
        
        public void Feet()
        {
            Console.WriteLine("Enter First Value in Feet: ");
            double FeetInputOne = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Second Value in Feet: ");
            double FeetInputTwo = Convert.ToDouble(Console.ReadLine());

            Feet FeetOne = new Feet(FeetInputOne);
            Feet FeetTwo = new Feet(FeetInputTwo);

            FeetServices service = new FeetServices();
            bool result = service.AreEqual(FeetOne,FeetTwo);

            Console.WriteLine("Comparison Result: ");
            Console.WriteLine(result ? "Equal (true)" : "Not Equal (false)");
        }

        public void Inches()
        {
            Console.WriteLine("Enter First Value in Inch: ");
            double InchInputOne = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Second Value in Inch: ");
            double InchInputTwo = Convert.ToDouble(Console.ReadLine());

            Inches InchOne = new Inches(InchInputOne);
            Inches InchTwo = new Inches(InchInputTwo);

            InchesService service = new InchesService();
            bool result = service.AreEqual(InchOne,InchTwo);

            Console.WriteLine("Comparison Result: ");
            Console.WriteLine(result ? "Equal (true)" : "Not Equal (false)");
        }

        public void CompareLength()
        {
            Console.WriteLine("Select Unit For First Value: ");
            LengthUnit unitOne = ReadUnit();

            Console.WriteLine("Enter First Value: ");
            double ValueOne = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select Unit For Second Value: ");
            LengthUnit unitTwo = ReadUnit();

            Console.WriteLine("Enter Second Value: ");
            double ValueTwo = Convert.ToDouble(Console.ReadLine());

            QuantityLength firstLength = new QuantityLength(ValueOne,unitOne);
            QuantityLength secondLength = new QuantityLength(ValueTwo,unitTwo);

            bool result = QuantityLengthService.Equals(firstLength,secondLength);

            Console.WriteLine(result ? "Equal (true)" : "Not Equal (false)");
        }

        public void ConvertLength()
        {
            Console.WriteLine("Select Source Unit: ");
            LengthUnit sourceUnit = ReadUnit();

            Console.WriteLine("Enter Source Value: ");
            double sourceValue = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select Target Unit: ");
            LengthUnit targetUnit = ReadUnit();

            double result = QuantityLength.Convert(sourceValue,sourceUnit,targetUnit);
            Console.WriteLine($"Converted Result: {result} {targetUnit}");
        }

        public void AddLength()
        {
            Console.WriteLine("Select Unit For First Value: ");
            LengthUnit unitOne = ReadUnit();

            Console.WriteLine("Enter First Value: ");
            double ValueOne = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select Unit For Second Value: ");
            LengthUnit unitTwo = ReadUnit();

            Console.WriteLine("Enter Second Value: ");
            double ValueTwo = Convert.ToDouble(Console.ReadLine());

            QuantityLength first = new QuantityLength(ValueOne,unitOne);
            QuantityLength second = new QuantityLength(ValueTwo,unitTwo);

            QuantityLength sum = QuantityLength.Add(first,second);

            Console.WriteLine($"Result: Quantity({sum.Value}, {sum.Unit})");
        }

        public void AddLengthWithTargetUnit()
        {
            Console.WriteLine("Select Unit For First Value: ");
            LengthUnit unitOne = ReadUnit();

            Console.WriteLine("Enter First Value: ");
            double ValueOne = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select Unit For Second Value: ");
            LengthUnit unitTwo = ReadUnit();

            Console.WriteLine("Enter Second Value: ");
            double ValueTwo = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Target Unit for Result: ");
            LengthUnit targetUnit = ReadUnit();

            QuantityLength first = new QuantityLength(ValueOne,unitOne);
            QuantityLength second = new QuantityLength(ValueTwo,unitTwo);

            QuantityLength result = QuantityLength.Add(first,second,targetUnit);
            Console.WriteLine($"Result: Quantity({result.Value}, {result.Unit})");
        }

        public LengthUnit ReadUnit()
        {
            Console.WriteLine("1. Feet");
            Console.WriteLine("2. Inch");
            Console.WriteLine("3. Yard");
            Console.WriteLine("4. Centimeter");

            Console.WriteLine("Select Unit: ");
            int UnitChoice = Convert.ToInt32(Console.ReadLine());

            switch (UnitChoice)
            {
                case 1:
                    return LengthUnit.Feet;

                case 2:
                    return LengthUnit.Inch;

                case 3:
                    return LengthUnit.Yard;

                case 4:
                    return LengthUnit.Centimeter;

                default:
                    return LengthUnit.Feet;
            }
        }
    }
}