using System;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    public class QuantityLengthService
    {
        public bool AreEqual(QuantityLength quantityLengthOne , QuantityLength quantityLengthTwo)
        {
            if(quantityLengthOne == null || quantityLengthTwo == null)
            {
                return false;
            }

            return quantityLengthOne.Equals(quantityLengthTwo);
        }
    }
}