using System;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
     /// <summary>
    /// Provides business-level operations for <see cref="QuantityLength"/>.
    /// 
    /// This service acts as an abstraction layer between
    /// presentation (UI) and domain model (QuantityLength).
    /// 
    /// Responsibilities:
    /// - Handle null safety
    /// - Delegate equality logic to domain model
    /// - Encapsulate business comparison behavior
    /// 
    /// Design Principle Applied:
    /// - Separation of Concerns (SoC)
    /// - Single Responsibility Principle (SRP)
    /// </summary>
    
    public class QuantityLengthServices
    {
        /// <summary>
        /// Determines whether two <see cref="QuantityLength"/> 
        /// objects represent equal measurements.
        /// 
        /// This method performs null validation before delegating
        /// comparison logic to the domain model.
        /// </summary>
        /// <param name="q1">First quantity instance.</param>
        /// <param name="q2">Second quantity instance.</param>
        /// <returns>
        /// True if both quantities are non-null and represent
        /// equivalent measurements; otherwise, false.
        /// </returns>
        
        public bool AreEqual(QuantityLength QuantityLengthOne, QuantityLength QuantityLengthTwo)
        {
            // Defensive null validation:
            // Prevents NullReferenceException and ensures predictable behavior.
            if(QuantityLengthOne == null || QuantityLengthTwo == null)
            {
                return false;
            }
            // Delegating comparison to domain entity.
            // Business logic remains inside the model (rich domain model pattern).
            return QuantityLengthOne.Equals(QuantityLengthTwo);
        }

    }
}