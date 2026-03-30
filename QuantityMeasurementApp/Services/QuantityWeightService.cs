using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Model;

namespace QuantityMeasurementApp.Services
{
    public class QuantityWeightService
    {
        public bool Compare(Quantity<WeightUnit> q1, Quantity<WeightUnit> q2)
        {
            return q1.Equals(q2);
        }
    }
}