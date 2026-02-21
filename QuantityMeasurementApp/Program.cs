using System;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp
{
    /// <summary>
    /// Entry point of the Quantity Measurement Application.
    /// Responsible for handling user interaction and invoking 
    /// business services for equality comparison.
    /// </summary>
    
    public class Program
    {
        /// <summary>
        /// Application execution starts here.
        /// Handles user input, validation, object creation,
        /// and displays comparison result.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        
        public static void Main(string[] args)
        {
            Console.WriteLine("=========== Quantity Measurement Application ===============");
            Console.WriteLine("UC1: Feet Measurement Equality Check");
            Console.WriteLine();

            try
            {
                // Read first input
                Console.WriteLine("Enter first value in feet: ");
                string FeetInputOne = Console.ReadLine();

                // Read second input
                Console.WriteLine("Enter second value in feet: ");
                string FeetInputTwo = Console.ReadLine();

                // Validate numeric input using TryParse
                if(!double.TryParse(FeetInputOne, out double FeetValueOne))
                {
                    Console.WriteLine("Invalid input for first value. Please enter a numeric value.");
                    return;
                }

                if(!double.TryParse(FeetInputTwo, out double FeetValueTwo))
                {
                    Console.WriteLine("Invalid input for second value. Please enter a numeric value.");
                    return;
                }

                // Create measurement objects (Encapsulation)
                Feet FeetOne = new Feet(FeetValueOne);
                Feet FeetTwo = new Feet(FeetValueTwo);

                // Invoke business service
                FeetServices service = new FeetServices();
                bool result = service.AreEqual(FeetOne,FeetTwo);

                // Display result
                Console.WriteLine();
                Console.WriteLine("Comparison Result: ");
                Console.WriteLine(result ? "Equal (true)" : "Not Equal (false)");
            }

            catch(Exception ex)
            {
                // Generic exception handling for unexpected runtime errors
                Console.WriteLine("An unexpected error occurs");
                Console.WriteLine(ex.Message);
            }

            finally
            {
                Console.WriteLine();
                Console.WriteLine("Application execution completed.");
            }
        }
    }
}
/*out is used when a method needs to return more than one value.
Since a method can normally return only one value, C# allows 
using out parameters to send extra values back.*/