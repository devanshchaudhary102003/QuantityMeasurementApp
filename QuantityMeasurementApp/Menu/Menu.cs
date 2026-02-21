using System;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Menu
{
    /// <summary>
    /// Presentation layer responsible for:
    /// - Displaying menu options
    /// - Capturing user input
    /// - Delegating comparison logic to service layer
    /// </summary>
    public class Menu
    {
        /// <summary>Service dependency for Feet comparisons.</summary>
        private readonly FeetServices feetServices;

        /// <summary>Service dependency for Inches comparisons.</summary>
        private readonly InchesServices inchesServices;

        /// <summary>
        /// Initializes Menu with required service dependencies.
        /// </summary>
        public Menu()
        {
            feetServices = new FeetServices();
            inchesServices = new InchesServices();
        }

        /// <summary>
        /// Displays menu and executes selected operation.
        /// </summary>
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("===== Quantity Measurement Application =====");
                Console.WriteLine("1. Check Feet Equality");
                Console.WriteLine("2. Check Inches Equality");
                Console.WriteLine("3. Exit");
                Console.WriteLine();

                Console.Write("Select an option: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CheckFeetEquality();
                        break;

                    case 2:
                        CheckInchesEquality();
                        break;

                    case 3:
                        Console.WriteLine("Exiting Application...");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice. Please select a valid option.");
                        break;
                }
            }
        }

        /// <summary>
        /// Reads Feet values and compares them using FeetServices.
        /// </summary>
        private void CheckFeetEquality()
        {
            Console.Write("Enter first value in feet: ");
            double value1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter second value in feet: ");
            double value2 = Convert.ToDouble(Console.ReadLine());

            Feet a = new Feet(value1);
            Feet b = new Feet(value2);

            bool result = feetServices.AreEqual(a, b);

            Console.WriteLine(result ? "Equal (true)" : "Not Equal (false)");
        }

        /// <summary>
        /// Reads Inches values and compares them using InchesServices.
        /// </summary>
        private void CheckInchesEquality()
        {
            Console.Write("Enter first value in inches: ");
            double value1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter second value in inches: ");
            double value2 = Convert.ToDouble(Console.ReadLine());

            Inches a = new Inches(value1);
            Inches b = new Inches(value2);

            bool result = inchesServices.AreEqual(a, b);

            Console.WriteLine(result ? "Equal (true)" : "Not Equal (false)");
        }
    }
}