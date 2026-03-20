using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    public class FeetServices
    {
        public bool AreEqual(Feet FeetOne , Feet FeetTwo)
        {
            if(FeetOne == null || FeetTwo == null)
            {
                return false;
            }

            return FeetOne.Equals(FeetTwo);
        }
    }
}