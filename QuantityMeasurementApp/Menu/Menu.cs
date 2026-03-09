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
    /// - Delegate comparison, conversion, and arithmetic logic to the generic Quantity<U> model
    ///
    /// UC10 / UC11 / UC12 DESIGN INTENT:
    /// This menu is intentionally kept thin and procedural.
    /// It contains no measurement formulas, no conversion mathematics,
    /// and no category-specific business rules beyond input mapping.
    ///
    /// BENEFITS:
    /// - Preserves Separation of Concerns
    /// - Keeps menu logic easy to maintain
    /// - Allows new measurement categories (such as Volume) to be integrated
    ///   with minimal change to the presentation layer
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Displays the main application menu continuously until the user exits.
        ///
        /// CONTROL FLOW:
        /// - Show all supported generic operations
        /// - Accept numeric menu input
        /// - Route execution to the corresponding handler method
        ///
        /// ERROR HANDLING:
        /// Invalid menu input is rejected without terminating the application.
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

                Console.WriteLine("\n----- Generic Volume Operations -----");
                Console.WriteLine("9. Compare Volumes");
                Console.WriteLine("10. Convert Volume");
                Console.WriteLine("11. Add Volumes (First Unit)");
                Console.WriteLine("12. Add Volumes (Target Unit)");

                Console.WriteLine("\n----- UC12 Arithmetic Operations -----");
                Console.WriteLine("13. Subtract Quantities");
                Console.WriteLine("14. Divide Quantities");

                Console.WriteLine("\n15. Exit");
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
                        CompareVolumes();
                        break;

                    case 10:
                        ConvertVolume();
                        break;

                    case 11:
                        AddVolumes();
                        break;

                    case 12:
                        AddVolumesWithTargetUnit();
                        break;

                    case 13:
                        SubtractQuantities();
                        break;

                    case 14:
                        DivideQuantities();
                        break;

                    case 15:
                        Console.WriteLine("Exiting Application...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        // =========================================================
        // LENGTH OPERATIONS
        // =========================================================

        /// <summary>
        /// Compares two length quantities for equality.
        ///
        /// DESIGN NOTE:
        /// This method only gathers user input and delegates equality logic
        /// to Quantity&lt;LengthUnit&gt;. No comparison logic is implemented here.
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
        ///
        /// DESIGN NOTE:
        /// The conversion path is handled entirely by Quantity&lt;LengthUnit&gt;
        /// and LengthUnit conversion behavior.
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
        /// Adds two length quantities and returns the result
        /// in the unit of the first operand.
        ///
        /// DEFAULT ADDITION RULE:
        /// When no target unit is explicitly provided, the generic Quantity&lt;U&gt;
        /// implementation returns the sum in the first operand's unit.
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
        /// Adds two length quantities and returns the result
        /// in a user-selected target unit.
        ///
        /// DESIGN NOTE:
        /// This uses the overloaded Add method that accepts a target unit.
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

        // =========================================================
        // WEIGHT OPERATIONS
        // =========================================================

        /// <summary>
        /// Compares two weight quantities for equality.
        ///
        /// DESIGN NOTE:
        /// Weight comparison follows the exact same generic workflow
        /// as length comparison, demonstrating category scalability.
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
        ///
        /// DESIGN NOTE:
        /// Menu does not know the formula between kilograms, grams, and pounds.
        /// It delegates the work to the generic domain model.
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
        /// Adds two weight quantities and returns the result
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
        /// Adds two weight quantities and returns the result
        /// in a user-selected target unit.
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

        // =========================================================
        // VOLUME OPERATIONS - UC11
        // =========================================================

        /// <summary>
        /// Compares two volume quantities for equality.
        ///
        /// UC11 PURPOSE:
        /// Validates that the generic Quantity&lt;U&gt; architecture supports
        /// a third independent category without changing business logic.
        ///
        /// DESIGN NOTE:
        /// Comparison semantics are fully delegated to Quantity&lt;VolumeUnit&gt;.
        /// </summary>
        private void CompareVolumes()
        {
            Console.WriteLine("Select first volume unit:");
            VolumeUnit unitOne = ReadVolumeUnit();

            Console.Write("Enter first value: ");
            double valueOne = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select second volume unit:");
            VolumeUnit unitTwo = ReadVolumeUnit();

            Console.Write("Enter second value: ");
            double valueTwo = Convert.ToDouble(Console.ReadLine());

            var first = new Quantity<VolumeUnit>(valueOne, unitOne);
            var second = new Quantity<VolumeUnit>(valueTwo, unitTwo);

            Console.WriteLine(first.Equals(second) ? "Equal" : "Not Equal");
        }

        /// <summary>
        /// Converts a volume quantity from one unit to another.
        ///
        /// UC11 SUPPORTED UNITS:
        /// - Litre
        /// - Millilitre
        /// - Gallon
        ///
        /// DESIGN NOTE:
        /// Conversion logic is delegated to VolumeUnit and Quantity&lt;VolumeUnit&gt;.
        /// </summary>
        private void ConvertVolume()
        {
            Console.WriteLine("Select source volume unit:");
            VolumeUnit source = ReadVolumeUnit();

            Console.Write("Enter value: ");
            double value = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select target volume unit:");
            VolumeUnit target = ReadVolumeUnit();

            var quantity = new Quantity<VolumeUnit>(value, source);
            var result = quantity.ConvertTo(target);

            Console.WriteLine($"Converted Value: {result}");
        }

        /// <summary>
        /// Adds two volume quantities and returns the result
        /// in the unit of the first operand.
        ///
        /// DEFAULT ADDITION RULE:
        /// This method uses the implicit-target overload of Add().
        /// </summary>
        private void AddVolumes()
        {
            Console.WriteLine("Select first volume unit:");
            VolumeUnit unitOne = ReadVolumeUnit();

            Console.Write("Enter first value: ");
            double valueOne = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select second volume unit:");
            VolumeUnit unitTwo = ReadVolumeUnit();

            Console.Write("Enter second value: ");
            double valueTwo = Convert.ToDouble(Console.ReadLine());

            var first = new Quantity<VolumeUnit>(valueOne, unitOne);
            var second = new Quantity<VolumeUnit>(valueTwo, unitTwo);

            var result = first.Add(second);
            Console.WriteLine($"Result: {result}");
        }

        /// <summary>
        /// Adds two volume quantities and returns the result
        /// in a user-selected target unit.
        ///
        /// UC11 PURPOSE:
        /// Demonstrates that the explicit target-unit addition overload works
        /// for the new volume category without any specialization.
        /// </summary>
        private void AddVolumesWithTargetUnit()
        {
            Console.WriteLine("Select first volume unit:");
            VolumeUnit unitOne = ReadVolumeUnit();

            Console.Write("Enter first value: ");
            double valueOne = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select second volume unit:");
            VolumeUnit unitTwo = ReadVolumeUnit();

            Console.Write("Enter second value: ");
            double valueTwo = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select target volume unit:");
            VolumeUnit target = ReadVolumeUnit();

            var first = new Quantity<VolumeUnit>(valueOne, unitOne);
            var second = new Quantity<VolumeUnit>(valueTwo, unitTwo);

            var result = first.Add(second, target);
            Console.WriteLine($"Result: {result}");
        }

        // =========================================================
        // UC12 ARITHMETIC OPERATIONS
        // =========================================================

        /// <summary>
        /// Handles subtraction workflow for all supported measurement categories.
        ///
        /// UC12 PURPOSE:
        /// Allows the user to subtract two quantities belonging to the same
        /// measurement category and optionally express the result in a chosen target unit.
        ///
        /// DESIGN NOTE:
        /// This method only routes control to category-specific input handlers.
        /// Actual subtraction logic remains inside Quantity&lt;U&gt;.
        /// </summary>
        private void SubtractQuantities()
        {
            Console.WriteLine("\nSelect subtraction category:");
            Console.WriteLine("1. Length");
            Console.WriteLine("2. Weight");
            Console.WriteLine("3. Volume");
            Console.Write("Enter choice: ");

            if (!int.TryParse(Console.ReadLine(), out int categoryChoice))
            {
                Console.WriteLine("Invalid category input.");
                return;
            }

            switch (categoryChoice)
            {
                case 1:
                    SubtractLengths();
                    break;

                case 2:
                    SubtractWeights();
                    break;

                case 3:
                    SubtractVolumes();
                    break;

                default:
                    Console.WriteLine("Invalid category choice.");
                    break;
            }
        }

        /// <summary>
        /// Handles division workflow for all supported measurement categories.
        ///
        /// UC12 PURPOSE:
        /// Allows the user to divide one quantity by another quantity of the same category.
        /// The returned result is dimensionless and represented as a double ratio.
        ///
        /// DESIGN NOTE:
        /// The menu captures input and delegates arithmetic to Quantity&lt;U&gt;.
        /// No division or conversion formulas are implemented here.
        /// </summary>
        private void DivideQuantities()
        {
            Console.WriteLine("\nSelect division category:");
            Console.WriteLine("1. Length");
            Console.WriteLine("2. Weight");
            Console.WriteLine("3. Volume");
            Console.Write("Enter choice: ");

            if (!int.TryParse(Console.ReadLine(), out int categoryChoice))
            {
                Console.WriteLine("Invalid category input.");
                return;
            }

            switch (categoryChoice)
            {
                case 1:
                    DivideLengths();
                    break;

                case 2:
                    DivideWeights();
                    break;

                case 3:
                    DivideVolumes();
                    break;

                default:
                    Console.WriteLine("Invalid category choice.");
                    break;
            }
        }

        /// <summary>
        /// Reads two length quantities from the user and performs subtraction.
        ///
        /// OPERATION MODES:
        /// - Implicit target unit: result is returned in first operand's unit
        /// - Explicit target unit: result is returned in user-selected target unit
        /// </summary>
        private void SubtractLengths()
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

            Console.Write("Do you want result in a target unit? (yes/no): ");
            string choice = Console.ReadLine()?.Trim().ToLower() ?? "no";

            if (choice == "yes")
            {
                Console.WriteLine("Select target length unit:");
                LengthUnit target = ReadLengthUnit();

                var result = first.Subtract(second, target);
                Console.WriteLine($"Result: {result}");
            }
            else
            {
                var result = first.Subtract(second);
                Console.WriteLine($"Result: {result}");
            }
        }

        /// <summary>
        /// Reads two weight quantities from the user and performs subtraction.
        /// </summary>
        private void SubtractWeights()
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

            Console.Write("Do you want result in a target unit? (yes/no): ");
            string choice = Console.ReadLine()?.Trim().ToLower() ?? "no";

            if (choice == "yes")
            {
                Console.WriteLine("Select target weight unit:");
                WeightUnit target = ReadWeightUnit();

                var result = first.Subtract(second, target);
                Console.WriteLine($"Result: {result}");
            }
            else
            {
                var result = first.Subtract(second);
                Console.WriteLine($"Result: {result}");
            }
        }

        /// <summary>
        /// Reads two volume quantities from the user and performs subtraction.
        /// </summary>
        private void SubtractVolumes()
        {
            Console.WriteLine("Select first volume unit:");
            VolumeUnit unitOne = ReadVolumeUnit();

            Console.Write("Enter first value: ");
            double valueOne = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select second volume unit:");
            VolumeUnit unitTwo = ReadVolumeUnit();

            Console.Write("Enter second value: ");
            double valueTwo = Convert.ToDouble(Console.ReadLine());

            var first = new Quantity<VolumeUnit>(valueOne, unitOne);
            var second = new Quantity<VolumeUnit>(valueTwo, unitTwo);

            Console.Write("Do you want result in a target unit? (yes/no): ");
            string choice = Console.ReadLine()?.Trim().ToLower() ?? "no";

            if (choice == "yes")
            {
                Console.WriteLine("Select target volume unit:");
                VolumeUnit target = ReadVolumeUnit();

                var result = first.Subtract(second, target);
                Console.WriteLine($"Result: {result}");
            }
            else
            {
                var result = first.Subtract(second);
                Console.WriteLine($"Result: {result}");
            }
        }

        /// <summary>
        /// Reads two length quantities from the user and performs division.
        ///
        /// RETURN:
        /// Returns a dimensionless scalar ratio.
        /// Example:
        /// 24 Inch / 2 Feet = 1
        /// </summary>
        private void DivideLengths()
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

            double result = first.Divide(second);
            Console.WriteLine($"Division Result: {result}");
        }

        /// <summary>
        /// Reads two weight quantities from the user and performs division.
        /// </summary>
        private void DivideWeights()
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

            double result = first.Divide(second);
            Console.WriteLine($"Division Result: {result}");
        }

        /// <summary>
        /// Reads two volume quantities from the user and performs division.
        /// </summary>
        private void DivideVolumes()
        {
            Console.WriteLine("Select first volume unit:");
            VolumeUnit unitOne = ReadVolumeUnit();

            Console.Write("Enter first value: ");
            double valueOne = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select second volume unit:");
            VolumeUnit unitTwo = ReadVolumeUnit();

            Console.Write("Enter second value: ");
            double valueTwo = Convert.ToDouble(Console.ReadLine());

            var first = new Quantity<VolumeUnit>(valueOne, unitOne);
            var second = new Quantity<VolumeUnit>(valueTwo, unitTwo);

            double result = first.Divide(second);
            Console.WriteLine($"Division Result: {result}");
        }

        // =========================================================
        // UNIT INPUT HELPERS
        // =========================================================

        /// <summary>
        /// Reads a length unit selection from console input.
        ///
        /// AVAILABLE OPTIONS:
        /// 1 -> Feet
        /// 2 -> Inch
        /// 3 -> Yard
        /// 4 -> Centimeter
        ///
        /// NOTE:
        /// A default fallback is returned for invalid selection to avoid
        /// immediate application failure during demonstration runs.
        /// In a stricter production design, this could throw validation errors instead.
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
        /// Reads a weight unit selection from console input.
        ///
        /// AVAILABLE OPTIONS:
        /// 1 -> Kilogram
        /// 2 -> Gram
        /// 3 -> Pound
        ///
        /// NOTE:
        /// Invalid input currently falls back to Kilogram for usability.
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

        /// <summary>
        /// Reads a volume unit selection from console input.
        ///
        /// UC11 AVAILABLE OPTIONS:
        /// 1 -> Litre
        /// 2 -> Millilitre
        /// 3 -> Gallon
        ///
        /// DESIGN NOTE:
        /// This helper is the only new menu-level mapping required to support
        /// the new measurement category, which demonstrates the scalability
        /// of the UC10 generic architecture.
        /// </summary>
        /// <returns>Selected VolumeUnit value.</returns>
        private VolumeUnit ReadVolumeUnit()
        {
            Console.WriteLine("1. Litre");
            Console.WriteLine("2. Millilitre");
            Console.WriteLine("3. Gallon");

            int choice = Convert.ToInt32(Console.ReadLine());

            return choice switch
            {
                1 => VolumeUnit.Litre,
                2 => VolumeUnit.Millilitre,
                3 => VolumeUnit.Gallon,
                _ => VolumeUnit.Litre
            };
        }
    }
}