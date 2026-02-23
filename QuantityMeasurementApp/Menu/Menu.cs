using System;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Menu
{
    /// <summary>
    /// Represents the Presentation Layer of the Quantity Measurement Application.
    /// 
    /// Responsibilities:
    /// • Displaying user menu options
    /// • Capturing and validating user input
    /// • Delegating business logic execution to Service Layer
    /// 
    /// This class strictly follows Separation of Concerns (SoC).
    /// No business logic is implemented here.
    /// </summary>
    public class Menu
    {

        /// <summary>
        /// Service responsible for Feet equality comparison.
        /// </summary>
        private readonly FeetServices feetServices;

        /// <summary>
        /// Service responsible for Inches equality comparison.
        /// </summary>
        private readonly InchesServices inchesServices;

        /// <summary>
        /// Service responsible for generic length comparison (UC3 – DRY principle).
        /// </summary>
        private readonly QuantityLengthServices quantityLengthServices;

        /// <summary>
        /// Initializes a new instance of <see cref="Menu"/>.
        /// Instantiates required service dependencies.
        /// </summary>
        public Menu()
        {
            feetServices = new FeetServices();
            inchesServices = new InchesServices();
            quantityLengthServices = new QuantityLengthServices();
        }

        /// <summary>
        /// Displays the main menu continuously until user exits.
        /// Handles routing to appropriate functionality based on user selection.
        /// </summary>
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("===== Quantity Measurement Application =====");
                Console.WriteLine("1. Check Feet Equality");
                Console.WriteLine("2. Check Inches Equality");
                Console.WriteLine("3. Compare Lengths (Feet , Inch, Yard, Centimeter)");
                Console.WriteLine("4. Exit");

                Console.Write("Select an option: ");

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
        /// Reads two Feet values from user,
        /// creates Feet model objects,
        /// and delegates equality comparison to FeetServices.
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
        /// Reads two Inches values from user,
        /// creates Inches model objects,
        /// and delegates equality comparison to InchesServices.
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
        /// Performs cross-unit comparison between two lengths.
        /// 
        /// Steps:
        /// 1. Reads unit selection for both inputs.
        /// 2. Validates numeric input.
        /// 3. Creates QuantityLength model objects.
        /// 4. Delegates comparison to QuantityLengthServices.
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
        /// Reads unit selection from user and converts it into <see cref="LengthUnit"/> enum.
        /// 
        /// Default behavior:
        /// • If input is invalid, defaults to Feet.
        /// </summary>
        /// <returns>Selected LengthUnit value.</returns>
        private LengthUnit ReadUnit()
        {
            // Display available length units to the user.
            // These options are mapped numerically for easier console selection.
            Console.WriteLine("1. Feet");
            Console.WriteLine("2. Inch");
            Console.WriteLine("3. Yard");
            Console.WriteLine("4. Centimeter");

            // Prompt user to select a unit.
            Console.Write("Select unit: ");

            // Read user input from console and convert it to integer.
            // NOTE:
            // Convert.ToInt32() will throw a FormatException if input is non-numeric.
            // In production-grade systems, TryParse should be preferred for safety.
            int unitChoice = Convert.ToInt32(Console.ReadLine());

            // Use traditional switch-case control structure
            // to map numeric selection to corresponding LengthUnit enum.
            // This ensures strong typing and avoids string-based comparisons.
            switch (unitChoice)
            {
                case 1:
                // Maps option 1 to Feet (base unit).
                return LengthUnit.Feet;

                case 2:
                // Maps option 2 to Inch.
                return LengthUnit.Inch;

                case 3:
                // Maps option 3 to Yard.
                return LengthUnit.Yard;

                case 4:
                // Maps option 4 to Centimeter.
                return LengthUnit.Centimeter;

                default:
                // Defensive fallback:
                // If user enters an unsupported number,
                // system defaults to Feet to prevent application failure.
                // In enterprise systems, logging or re-prompting may be preferable.
                return LengthUnit.Feet;
            }
        }
    }
}