using System;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Menu
{
    /// <summary>
    /// Presentation Layer (UI) for Quantity Measurement Application.
    ///
    /// RESPONSIBILITIES:
    /// - Display menu options
    /// - Read and validate user inputs (format-level validation only)
    /// - Delegate domain operations to Service/Model layer
    ///
    /// NON-RESPONSIBILITIES:
    /// - No conversion or comparison business rules should be implemented here.
    /// - No direct unit conversion math should exist in this layer.
    ///
    /// This keeps the application aligned with:
    /// - Separation of Concerns (SoC)
    /// - Single Responsibility Principle (SRP)
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Service responsible for Feet equality comparison (UC1/UC2).
        /// </summary>
        private readonly FeetServices feetServices;

        /// <summary>
        /// Service responsible for Inches equality comparison (UC1/UC2).
        /// </summary>
        private readonly InchesServices inchesServices;

        /// <summary>
        /// Service responsible for unit-aware length equality comparison (UC3/UC4).
        /// </summary>
        private readonly QuantityLengthServices quantityLengthServices;

        /// <summary>
        /// Constructor initializes service dependencies.
        /// In larger systems, Dependency Injection (DI) container would be preferred.
        /// </summary>
        public Menu()
        {
            feetServices = new FeetServices();
            inchesServices = new InchesServices();
            quantityLengthServices = new QuantityLengthServices();
        }

        /// <summary>
        /// Displays the main menu in a loop until the user selects Exit.
        /// Handles high-level navigation only (UI routing).
        /// </summary>
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("===== Quantity Measurement Application =====");
                Console.WriteLine("1. Check Feet Equality");
                Console.WriteLine("2. Check Inches Equality");
                Console.WriteLine("3. Compare Lengths (Feet, Inch, Yard, Centimeter)");
                Console.WriteLine("4. Convert Length (Unit to Unit)");
                Console.WriteLine("5. Exit");

                Console.Write("Select an option: ");

                // Defensive input parsing: prevents runtime failures for non-numeric input.
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter numeric choice.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        CheckFeetEquality();
                        break;

                    case 2:
                        CheckInchesEquality();
                        break;

                    case 3:
                        CompareLengths();
                        break;

                    case 4:
                        ConvertLength();
                        break;

                    case 5:
                        Console.WriteLine("Exiting Application...");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice. Please select a valid option.");
                        break;
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Reads two numeric values (Feet) from user and delegates equality check
        /// to <see cref="FeetServices"/>.
        /// </summary>
        private void CheckFeetEquality()
        {
            Console.Write("Enter first value in feet: ");
            if (!double.TryParse(Console.ReadLine(), out double value1))
            {
                Console.WriteLine("Invalid numeric input.");
                return;
            }

            Console.Write("Enter second value in feet: ");
            if (!double.TryParse(Console.ReadLine(), out double value2))
            {
                Console.WriteLine("Invalid numeric input.");
                return;
            }

            Feet firstFeet = new Feet(value1);
            Feet secondFeet = new Feet(value2);

            bool result = feetServices.AreEqual(firstFeet, secondFeet);

            Console.WriteLine(result ? "Equal (true)" : "Not Equal (false)");
        }

        /// <summary>
        /// Reads two numeric values (Inches) from user and delegates equality check
        /// to <see cref="InchesServices"/>.
        /// </summary>
        private void CheckInchesEquality()
        {
            Console.Write("Enter first value in inches: ");
            if (!double.TryParse(Console.ReadLine(), out double value1))
            {
                Console.WriteLine("Invalid numeric input.");
                return;
            }

            Console.Write("Enter second value in inches: ");
            if (!double.TryParse(Console.ReadLine(), out double value2))
            {
                Console.WriteLine("Invalid numeric input.");
                return;
            }

            Inches firstInches = new Inches(value1);
            Inches secondInches = new Inches(value2);

            bool result = inchesServices.AreEqual(firstInches, secondInches);

            Console.WriteLine(result ? "Equal (true)" : "Not Equal (false)");
        }

        /// <summary>
        /// UC3/UC4:
        /// Reads two values with units and delegates unit-aware equality logic
        /// to <see cref="QuantityLengthServices"/>.
        /// </summary>
        public void CompareLengths()
        {
            Console.WriteLine("Select Unit for First Value: ");
            LengthUnit unitOne = ReadUnit();

            Console.Write("Enter First Value: ");
            if (!double.TryParse(Console.ReadLine(), out double valueOne))
            {
                Console.WriteLine("Invalid numeric input.");
                return;
            }

            Console.WriteLine("Select Unit for Second Value: ");
            LengthUnit unitTwo = ReadUnit();

            Console.Write("Enter second value: ");
            if (!double.TryParse(Console.ReadLine(), out double valueTwo))
            {
                Console.WriteLine("Invalid numeric input.");
                return;
            }

            QuantityLength firstLength = new QuantityLength(valueOne, unitOne);
            QuantityLength secondLength = new QuantityLength(valueTwo, unitTwo);

            bool result = quantityLengthServices.AreEqual(firstLength, secondLength);

            Console.WriteLine(result ? "Equal (true)" : "Not Equal (false)");
        }

        /// <summary>
        /// UC5:
        /// Reads source unit, numeric value, and target unit from the user,
        /// then delegates conversion to the domain API <see cref="QuantityLength.Convert"/>.
        ///
        /// This method performs only input-level validation (format correctness).
        /// Conversion rules remain encapsulated in the model layer.
        /// </summary>
        public void ConvertLength()
        {
            Console.WriteLine("Select Source Unit: ");
            LengthUnit source = ReadUnit();

            Console.Write("Enter Value: ");
            if (!double.TryParse(Console.ReadLine(), out double value))
            {
                Console.WriteLine("Invalid numeric input.");
                return;
            }

            Console.WriteLine("Select Target Unit: ");
            LengthUnit target = ReadUnit();

            try
            {
                double result = QuantityLength.Convert(value, source, target);

                // Output formatting: prints both target unit and converted magnitude.
                Console.WriteLine($"Converted Result: {result} {target}");
            }
            catch (ArgumentException ex)
            {
                // Defensive: in case domain layer throws exception due to unsupported unit.
                Console.WriteLine($"Conversion Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Reads the unit choice from console and maps it to <see cref="LengthUnit"/>.
        ///
        /// ENTERPRISE NOTES:
        /// - Uses TryParse to avoid application crashes from invalid input.
        /// - Defaults to Feet if user input is invalid (fail-safe behavior).
        /// - In production systems, you might re-prompt user instead of defaulting.
        /// </summary>
        private LengthUnit ReadUnit()
        {
            Console.WriteLine("1. Feet");
            Console.WriteLine("2. Inch");
            Console.WriteLine("3. Yard");
            Console.WriteLine("4. Centimeter");

            Console.Write("Select unit: ");

            // TryParse prevents FormatException and keeps console app stable.
            if (!int.TryParse(Console.ReadLine(), out int unitChoice))
            {
                Console.WriteLine("Invalid unit input. Defaulting to Feet.");
                return LengthUnit.Feet;
            }

            switch (unitChoice)
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
                    Console.WriteLine("Unsupported unit choice. Defaulting to Feet.");
                    return LengthUnit.Feet;
            }
        }
    }
}