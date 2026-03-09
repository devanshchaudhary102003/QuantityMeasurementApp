using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    /// <summary>
    /// Provides service-level operations for generic quantities.
    /// </summary>
    public class QuantityLengthServices
    {
        public bool AreEqual<U>(Quantity<U> first, Quantity<U> second) where U : struct, System.Enum
        {
            if (first == null || second == null)
            {
                return false;
            }

            return first.Equals(second);
        }
    }
}