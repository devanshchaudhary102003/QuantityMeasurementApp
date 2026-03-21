using System;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    public class QuantityWeightService
    {
        public bool AreEqual(QuantityWeight QuantityWeightOne , QuantityWeight QuantityWeightTwo)
        {
            if(QuantityWeightOne == null || QuantityWeightTwo == null)
            {
                return false;
            }

            return QuantityWeightOne.Equals(QuantityWeightTwo);
        }
    }
}