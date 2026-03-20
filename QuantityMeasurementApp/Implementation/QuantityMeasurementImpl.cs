using System;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;
using QuantityMeasurementApp.Menu;
using QuantityMeasurementApp.Interface;

namespace QuantityMeasurementApp.Implementation
{
    public class QuantityMeasurementImpl : IQuantityMeasurement
    {
        public void Feet()
        {
            Console.WriteLine("Enter First Value in Feet: ");
            double FeetInputOne = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Second Value in Feet: ");
            double FeetInputTwo = Convert.ToDouble(Console.ReadLine());

            Feet FeetOne = new Feet(FeetInputOne);
            Feet FeetTwo = new Feet(FeetInputTwo);

            FeetServices service = new FeetServices();
            bool result = service.AreEqual(FeetOne,FeetTwo);

            Console.WriteLine("Comparison Result: ");
            Console.WriteLine(result ? "Equal (true)" : "Not Equal (false)");
        }
    }
}