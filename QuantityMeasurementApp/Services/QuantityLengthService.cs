using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Model;

namespace QuantityMeasurementApp.Services
{
    public class QuantityLengthService
    {
        public bool Compare(Quantity<LengthUnit> q1, Quantity<LengthUnit> q2)
        {
            return q1.Equals(q2);
        }
    }
}