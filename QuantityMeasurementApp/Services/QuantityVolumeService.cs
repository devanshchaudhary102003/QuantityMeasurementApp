using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Model;

namespace QuantityMeasurementApp.Services
{
    public class QuantityVolumeService
    {
        public bool Compare(Quantity<VolumeUnit> quantityOne, Quantity<VolumeUnit> quantityTwo)
        {
            return quantityOne.Equals(quantityTwo);
        }
    }
}