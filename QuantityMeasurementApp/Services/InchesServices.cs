using System;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    /// <summary>
    /// Service class responsible for handling business logic 
    /// related to Inches measurement comparison.
    /// </summary>
    public class InchesServices
    {
        /// <summary>
        /// Compares two Inches objects for equality.
        /// </summary>
        /// <param name="InchOne">First Inches object to compare.</param>
        /// <param name="InchTwo">Second Inches object to compare.</param>
        /// <returns>
        /// Returns true if both Inches objects are equal;
        /// Returns false if either object is null or values are not equal.
        /// </returns>
        /// <remarks>
        /// This method relies on the overridden Equals() method 
        /// implemented inside the Inches model class.
        /// Null safety is handled before performing comparison.
        /// </remarks>
        public bool AreEqual(Inches InchOne, Inches InchTwo)
        {
            // Validate input parameters to avoid NullReferenceException
            if (InchOne == null || InchTwo == null)
            {
                return false;
            }

            // Delegate equality comparison to the model's Equals() implementation
            return InchOne.Equals(InchTwo);
        }
    }
}