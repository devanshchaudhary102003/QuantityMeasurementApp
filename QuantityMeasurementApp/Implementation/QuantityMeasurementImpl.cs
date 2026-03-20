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

        public void Inches()
        {
            Console.WriteLine("Enter First Value in Inch: ");
            double InchInputOne = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Second Value in Inch: ");
            double InchInputTwo = Convert.ToDouble(Console.ReadLine());

            Inches InchOne = new Inches(InchInputOne);
            Inches InchTwo = new Inches(InchInputTwo);

            InchesService service = new InchesService();
            bool result = service.AreEqual(InchOne,InchTwo);

            Console.WriteLine("Comparison Result: ");
            Console.WriteLine(result ? "Equal (true)" : "Not Equal (false)");
        }
    }
}