using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Enums;
using System;

namespace QuantityMeasurementApp.Tests
{
    [TestClass]
    public class QuantityLengthConversionTestsThree
    {
        private const double EPSILON = 1e-6;

        [TestMethod]
        public void testConversion_FeetToInches()
        {
            double result = QuantityLength.Convert(1.0, LengthUnit.Feet, LengthUnit.Inch);

            Assert.AreEqual(12.0, result, EPSILON);
        }

        [TestMethod]
        public void testConversion_InchesToFeet()
        {
            double result = QuantityLength.Convert(24.0, LengthUnit.Inch, LengthUnit.Feet);

            Assert.AreEqual(2.0, result, EPSILON);
        }

        [TestMethod]
        public void testConversion_YardsToInches()
        {
            double result = QuantityLength.Convert(1.0, LengthUnit.Yard, LengthUnit.Inch);

            Assert.AreEqual(36.0, result, EPSILON);
        }

        [TestMethod]
        public void testConversion_InchesToYards()
        {
            double result = QuantityLength.Convert(72.0, LengthUnit.Inch, LengthUnit.Yard);

            Assert.AreEqual(2.0, result, EPSILON);
        }

        [TestMethod]
        public void testConversion_CentimetersToInches()
        {
            double result = QuantityLength.Convert(2.54, LengthUnit.Centimeter, LengthUnit.Inch);

            Assert.AreEqual(1.0, result, 0.001);
        }

        [TestMethod]
        public void testConversion_FeatToYard()
        {
            double result = QuantityLength.Convert(6.0, LengthUnit.Feet, LengthUnit.Yard);

            Assert.AreEqual(2.0, result, EPSILON);
        }

        [TestMethod]
        public void testConversion_RoundTrip_PreservesValue()
        {
            double originalValue = 5.75;

            double toInches = QuantityLength.Convert(originalValue, LengthUnit.Feet, LengthUnit.Inch);
            double backToFeet = QuantityLength.Convert(toInches, LengthUnit.Inch, LengthUnit.Feet);

            Assert.AreEqual(originalValue, backToFeet, EPSILON);
        }

        [TestMethod]
        public void testConversion_ZeroValue()
        {
            double result = QuantityLength.Convert(0.0, LengthUnit.Feet, LengthUnit.Inch);

            Assert.AreEqual(0.0, result, EPSILON);
        }

        [TestMethod]
        public void testConversion_NegativeValue()
        {
            double result = QuantityLength.Convert(-1.0, LengthUnit.Feet, LengthUnit.Inch);

            Assert.AreEqual(-12.0, result, EPSILON);
        }

        [TestMethod]
        public void testConversion_PrecisionTolerance()
        {
            double result = QuantityLength.Convert(1.0, LengthUnit.Centimeter, LengthUnit.Inch);

            Assert.IsTrue(Math.Abs(result - 0.393701) < EPSILON);
        }
    }
}