using System;
namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Represents a measurement value in Feet.
    /// This class is immutable and follows value-based equality.
    /// </summary>
    
    public sealed class Feet
    {
        /// <summary>
        /// Backing field to store the measurement value.
        /// Marked as readonly to ensure immutability.
        /// </summary>
        private readonly double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Feet"/> class.
        /// </summary>
        /// <param name="value">Measurement value in feet.</param>
        
        public Feet(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the measurement value.
        /// </summary>
        /// <returns>Measurement in feet.</returns>
        
        public double GetValue()
        {
            return value;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// Implements value-based equality comparison.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>
        /// True if the specified object is a Feet instance with the same value;
        /// otherwise, false.
        /// </returns>
        
        public override bool Equals(object obj)
        {
            // Check reference equality (Reflexive property)
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            // Return false if object is null
            if(obj is null)
            {
                return false;
            }

            // Ensure type safety
            if(obj.GetType() != typeof(Feet))
            {
                return false;
            }

            // Safe cast
            Feet other = (Feet)obj;

            // Use CompareTo for floating-point comparison
            return value.CompareTo(other.value) == 0;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// Must be overridden when Equals() is overridden.
        /// </summary>
        /// <returns>Hash code based on measurement value.</returns>

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}