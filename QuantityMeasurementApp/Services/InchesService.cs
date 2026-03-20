using System;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    public class InchesService
    {
        public bool AreEqual(Inches InchOne, Inches InchTwo)
        {
            if(InchOne == null || InchTwo == null)
            {
                return false;
            }

            return InchOne.Equals(InchTwo);
        }
    }
}