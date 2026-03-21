using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests
{
    [TestClass]
    public class QuantityLengthEnumTests
    {
        private const double EPSILON = 1e-6;

        [TestMethod]
        public void testLengthUnitEnum_FeetConstant()
        {
            Assert.AreEqual(1.0, LengthUnit.Feet.ToFeetFactor(), EPSILON);
        }

        [TestMethod]
        public void testLengthUnitEnum_InchesConstant()
        {
            Assert.AreEqual(1.0 / 12.0, LengthUnit.Inch.ToFeetFactor(), EPSILON);
        }

        [TestMethod]
        public void testLengthUnitEnum_YardsConstant()
        {
            Assert.AreEqual(3.0, LengthUnit.Yard.ToFeetFactor(), EPSILON);
        }

        [TestMethod]
        public void testLengthUnitEnum_CentimetersConstant()
        {
            Assert.AreEqual(1.0 / 30.48, LengthUnit.Centimeter.ToFeetFactor(), EPSILON);
        }

        [TestMethod]
        public void testConvertToBaseUnit_FeetToFeet()
        {
            double result = LengthUnit.Feet.ConvertToBaseUnit(5.0);

            Assert.AreEqual(5.0, result, EPSILON);
        }

        [TestMethod]
        public void testConvertToBaseUnit_InchesToFeet()
        {
            double result = LengthUnit.Inch.ConvertToBaseUnit(12.0);

            Assert.AreEqual(1.0, result, EPSILON);
        }

        [TestMethod]
        public void testConvertToBaseUnit_YardsToFeet()
        {
            double result = LengthUnit.Yard.ConvertToBaseUnit(1.0);

            Assert.AreEqual(3.0, result, EPSILON);
        }

        [TestMethod]
        public void testConvertToBaseUnit_CentimetersToFeet()
        {
            double result = LengthUnit.Centimeter.ConvertToBaseUnit(30.48);

            Assert.AreEqual(1.0, result, 0.001);
        }

        [TestMethod]
        public void testConvertFromBaseUnit_FeetToFeet()
        {
            double result = LengthUnit.Feet.ConvertFromBaseUnit(2.0);

            Assert.AreEqual(2.0, result, EPSILON);
        }

        [TestMethod]
        public void testConvertFromBaseUnit_FeetToInches()
        {
            double result = LengthUnit.Inch.ConvertFromBaseUnit(1.0);

            Assert.AreEqual(12.0, result, EPSILON);
        }

        [TestMethod]
        public void testConvertFromBaseUnit_FeetToYards()
        {
            double result = LengthUnit.Yard.ConvertFromBaseUnit(3.0);

            Assert.AreEqual(1.0, result, EPSILON);
        }

        [TestMethod]
        public void testConvertFromBaseUnit_FeetToCentimeters()
        {
            double result = LengthUnit.Centimeter.ConvertFromBaseUnit(1.0);

            Assert.AreEqual(30.48, result, 0.01);
        }

        [TestMethod]
        public void testQuantityLengthRefactored_Equality()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(12.0, LengthUnit.Inch);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testQuantityLengthRefactored_ConvertTo()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);

            QuantityLength result = a.ConvertTo(LengthUnit.Inch);

            Assert.AreEqual(12.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Inch, result.Unit);
        }

        [TestMethod]
        public void testQuantityLengthRefactored_Add()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(12.0, LengthUnit.Inch);

            QuantityLength result = QuantityLength.Add(a, b, LengthUnit.Feet);

            Assert.AreEqual(2.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Feet, result.Unit);
        }

        [TestMethod]
        public void testQuantityLengthRefactored_AddWithTargetUnit()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(12.0, LengthUnit.Inch);

            QuantityLength result = QuantityLength.Add(a, b, LengthUnit.Yard);

            Assert.AreEqual(0.666666, result.Value, 0.001);
            Assert.AreEqual(LengthUnit.Yard, result.Unit);
        }
    }
}