using System;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Represents a measurement value in Inches.
    /// This class is immutable and follows value-based equality.
    /// </summary>
    public sealed class Inches
    {
        /// <summary>
        /// Backing field to store the measurement value.
        /// Marked as readonly to ensure immutability.
        /// </summary>
        private readonly double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Inches"/> class.
        /// </summary>
        /// <param name="value">Measurement value in inches.</param>
        public Inches(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the measurement value.
        /// </summary>
        /// <returns>Measurement in inches.</returns>
        public double GetValue()
        {
            return value;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current instance.
        /// Implements value-based equality comparison.
        /// </summary>
        /// <param name="obj">Object to compare with current instance.</param>
        /// <returns>
        /// True if both objects are of type Inches and contain the same value;
        /// otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            // Reflexive property check
            if (ReferenceEquals(this, obj))
                return true;

            // Null check
            if (obj is null)
                return false;

            // Type safety check
            if (obj.GetType() != typeof(Inches))
                return false;

            // Safe casting
            Inches other = (Inches)obj;

            // Floating-point comparison
            return value.CompareTo(other.value) == 0;
        }

        /// <summary>
        /// Returns a hash code for the current instance.
        /// Required when overriding Equals().
        /// </summary>
        /// <returns>Hash code based on value.</returns>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}