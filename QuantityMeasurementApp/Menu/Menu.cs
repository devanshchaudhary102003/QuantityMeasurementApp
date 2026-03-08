using System;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Menu
{
    /// <summary>
    /// Represents the presentation layer of the Quantity Measurement Application.
    ///
    /// RESPONSIBILITIES:
    /// - Display available console operations
    /// - Capture user input
    /// - Delegate conversion, comparison, and addition logic to generic Quantity<U>
    ///
    /// UC10 DESIGN:
    /// This menu works with the generic Quantity<U> model for multiple
    /// measurement categories such as Length and Weight.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Displays the main application menu continuously
        /// until the user chooses to exit.
        /// </summary>
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\n===== Quantity Measurement Application =====");

                Console.WriteLine("\n----- Generic Length Operations -----");
                Console.WriteLine("1. Compare Lengths");
                Console.WriteLine("2. Convert Length");
                Console.WriteLine("3. Add Lengths (First Unit)");
                Console.WriteLine("4. Add Lengths (Target Unit)");

                Console.WriteLine("\n----- Generic Weight Operations -----");
                Console.WriteLine("5. Compare Weights");
                Console.WriteLine("6. Convert Weight");
                Console.WriteLine("7. Add Weights (First Unit)");
                Console.WriteLine("8. Add Weights (Target Unit)");

                Console.WriteLine("\n9. Exit");
                Console.Write("\nEnter choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a numeric option.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        CompareLengths();
                        break;

                    case 2:
                        ConvertLength();
                        break;

                    case 3:
                        AddLengths();
                        break;

                    case 4:
                        AddLengthsWithTargetUnit();
                        break;

                    case 5:
                        CompareWeights();
                        break;

                    case 6:
                        ConvertWeight();
                        break;

                    case 7:
                        AddWeights();
                        break;

                    case 8:
                        AddWeightsWithTargetUnit();
                        break;

                    case 9:
                        Console.WriteLine("Exiting Application...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        /// <summary>
        /// Compares two generic length quantities for equality.
        /// </summary>
        private void CompareLengths()
        {
            Console.WriteLine("Select first length unit:");
            LengthUnit unitOne = ReadLengthUnit();

            Console.Write("Enter first value: ");
            double valueOne = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select second length unit:");
            LengthUnit unitTwo = ReadLengthUnit();

            Console.Write("Enter second value: ");
            double valueTwo = Convert.ToDouble(Console.ReadLine());

            var first = new Quantity<LengthUnit>(valueOne, unitOne);
            var second = new Quantity<LengthUnit>(valueTwo, unitTwo);

            Console.WriteLine(first.Equals(second) ? "Equal" : "Not Equal");
        }

        /// <summary>
        /// Converts a length quantity from one unit to another.
        /// </summary>
        private void ConvertLength()
        {
            Console.WriteLine("Select source length unit:");
            LengthUnit source = ReadLengthUnit();

            Console.Write("Enter value: ");
            double value = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select target length unit:");
            LengthUnit target = ReadLengthUnit();

            var quantity = new Quantity<LengthUnit>(value, source);
            var result = quantity.ConvertTo(target);

            Console.WriteLine($"Converted Value: {result}");
        }

        /// <summary>
        /// Adds two length quantities and returns result
        /// in the first operand's unit.
        /// </summary>
        private void AddLengths()
        {
            Console.WriteLine("Select first length unit:");
            LengthUnit unitOne = ReadLengthUnit();

            Console.Write("Enter first value: ");
            double valueOne = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select second length unit:");
            LengthUnit unitTwo = ReadLengthUnit();

            Console.Write("Enter second value: ");
            double valueTwo = Convert.ToDouble(Console.ReadLine());

            var first = new Quantity<LengthUnit>(valueOne, unitOne);
            var second = new Quantity<LengthUnit>(valueTwo, unitTwo);

            var result = first.Add(second);
            Console.WriteLine($"Result: {result}");
        }

        /// <summary>
        /// Adds two length quantities and returns result
        /// in a user-specified target unit.
        /// </summary>
        private void AddLengthsWithTargetUnit()
        {
            Console.WriteLine("Select first length unit:");
            LengthUnit unitOne = ReadLengthUnit();

            Console.Write("Enter first value: ");
            double valueOne = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select second length unit:");
            LengthUnit unitTwo = ReadLengthUnit();

            Console.Write("Enter second value: ");
            double valueTwo = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select target length unit:");
            LengthUnit target = ReadLengthUnit();

            var first = new Quantity<LengthUnit>(valueOne, unitOne);
            var second = new Quantity<LengthUnit>(valueTwo, unitTwo);

            var result = first.Add(second, target);
            Console.WriteLine($"Result: {result}");
        }

        /// <summary>
        /// Compares two generic weight quantities for equality.
        /// </summary>
        private void CompareWeights()
        {
            Console.WriteLine("Select first weight unit:");
            WeightUnit unitOne = ReadWeightUnit();

            Console.Write("Enter first value: ");
            double valueOne = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select second weight unit:");
            WeightUnit unitTwo = ReadWeightUnit();

            Console.Write("Enter second value: ");
            double valueTwo = Convert.ToDouble(Console.ReadLine());

            var first = new Quantity<WeightUnit>(valueOne, unitOne);
            var second = new Quantity<WeightUnit>(valueTwo, unitTwo);

            Console.WriteLine(first.Equals(second) ? "Equal" : "Not Equal");
        }

        /// <summary>
        /// Converts a weight quantity from one unit to another.
        /// </summary>
        private void ConvertWeight()
        {
            Console.WriteLine("Select source weight unit:");
            WeightUnit source = ReadWeightUnit();

            Console.Write("Enter value: ");
            double value = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select target weight unit:");
            WeightUnit target = ReadWeightUnit();

            var quantity = new Quantity<WeightUnit>(value, source);
            var result = quantity.ConvertTo(target);

            Console.WriteLine($"Converted Value: {result}");
        }

        /// <summary>
        /// Adds two weight quantities and returns result
        /// in the first operand's unit.
        /// </summary>
        private void AddWeights()
        {
            Console.WriteLine("Select first weight unit:");
            WeightUnit unitOne = ReadWeightUnit();

            Console.Write("Enter first value: ");
            double valueOne = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select second weight unit:");
            WeightUnit unitTwo = ReadWeightUnit();

            Console.Write("Enter second value: ");
            double valueTwo = Convert.ToDouble(Console.ReadLine());

            var first = new Quantity<WeightUnit>(valueOne, unitOne);
            var second = new Quantity<WeightUnit>(valueTwo, unitTwo);

            var result = first.Add(second);
            Console.WriteLine($"Result: {result}");
        }

        /// <summary>
        /// Adds two weight quantities and returns result
        /// in a user-specified target unit.
        /// </summary>
        private void AddWeightsWithTargetUnit()
        {
            Console.WriteLine("Select first weight unit:");
            WeightUnit unitOne = ReadWeightUnit();

            Console.Write("Enter first value: ");
            double valueOne = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select second weight unit:");
            WeightUnit unitTwo = ReadWeightUnit();

            Console.Write("Enter second value: ");
            double valueTwo = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select target weight unit:");
            WeightUnit target = ReadWeightUnit();

            var first = new Quantity<WeightUnit>(valueOne, unitOne);
            var second = new Quantity<WeightUnit>(valueTwo, unitTwo);

            var result = first.Add(second, target);
            Console.WriteLine($"Result: {result}");
        }

        /// <summary>
        /// Reads a length unit from console input.
        /// </summary>
        /// <returns>Selected LengthUnit value.</returns>
        private LengthUnit ReadLengthUnit()
        {
            Console.WriteLine("1. Feet");
            Console.WriteLine("2. Inch");
            Console.WriteLine("3. Yard");
            Console.WriteLine("4. Centimeter");

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

        /// <summary>
        /// Reads a weight unit from console input.
        /// </summary>
        /// <returns>Selected WeightUnit value.</returns>
        private WeightUnit ReadWeightUnit()
        {
            Console.WriteLine("1. Kilogram");
            Console.WriteLine("2. Gram");
            Console.WriteLine("3. Pound");

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