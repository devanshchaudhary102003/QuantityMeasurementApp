using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    /// <summary>
    /// Service responsible for comparing measurement objects.
    /// Encapsulates equality comparison logic.
    /// </summary>
    
    public class FeetServices
    {
        /// <summary>
        /// Compares two Feet measurement objects for equality.
        /// </summary>
        /// <param name="a">First measurement.</param>
        /// <param name="b">Second measurement.</param>
        /// <returns>
        /// True if both measurements are equal; otherwise false.
        /// Returns false if either parameter is null.
        /// </returns>
        
        public bool AreEqual(Feet FeetOne, Feet FeetTwo)
        {
            if(FeetOne == null || FeetTwo == null)
            {
                return false;
            }
            return FeetOne.Equals(FeetTwo);
        }
    }
}