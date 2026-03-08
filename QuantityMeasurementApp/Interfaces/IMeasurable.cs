namespace QuantityMeasurementApp.Interfaces
{
    /// <summary>
    /// Defines the common contract for all measurable unit types.
    ///
    /// PURPOSE:
    /// This interface standardizes unit behavior across multiple
    /// measurement categories such as Length, Weight, and future
    /// categories like Volume or Temperature.
    ///
    /// DESIGN BENEFITS:
    /// - Promotes abstraction and polymorphism
    /// - Eliminates duplication across different unit enums
    /// - Enables the generic Quantity&lt;U&gt; model to operate uniformly
    ///   on any supported measurement category
    ///
    /// CONTRACT:
    /// Any measurable unit must know:
    /// - its conversion factor relative to a base unit
    /// - how to convert a value to the base unit
    /// - how to convert a base unit value back into itself
    /// - how to expose a readable unit name
    /// </summary>
    public interface IMeasurable
    {
        /// <summary>
        /// Returns the conversion factor of the current unit
        /// relative to its category base unit.
        /// </summary>
        double GetConversionFactor();

        /// <summary>
        /// Converts a value expressed in the current unit
        /// into the category base unit.
        /// </summary>
        /// <param name="value">Value in the current unit.</param>
        /// <returns>Equivalent value in base unit.</returns>
        double ConvertToBaseUnit(double value);

        /// <summary>
        /// Converts a base unit value into the current unit.
        /// </summary>
        /// <param name="baseValue">Value in base unit.</param>
        /// <returns>Equivalent value in current unit.</returns>
        double ConvertFromBaseUnit(double baseValue);

        /// <summary>
        /// Returns a user-friendly name of the unit.
        /// </summary>
        string GetUnitName();
    }
}