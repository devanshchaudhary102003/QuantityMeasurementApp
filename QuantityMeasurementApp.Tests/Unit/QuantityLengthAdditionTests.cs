using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Tests
{
    [TestClass]
    public class QuantityLengthAdditionTests
    {
        private const double EPSILON = 1e-6;

        [TestMethod]
        public void testAddition_SameUnit_FeetPlusFeet()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(2.0, LengthUnit.Feet);

            QuantityLength result = QuantityLength.Add(a, b);

            Assert.AreEqual(3.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Feet, result.Unit);
        }

        [TestMethod]
        public void testAddition_SameUnit_InchPlusInch()
        {
            var a = new QuantityLength(6.0, LengthUnit.Inch);
            var b = new QuantityLength(6.0, LengthUnit.Inch);

            QuantityLength result = QuantityLength.Add(a, b);

            Assert.AreEqual(12.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Inch, result.Unit);
        }

        [TestMethod]
        public void testAddition_CrossUnit_FeetPlusInches()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(12.0, LengthUnit.Inch);

            QuantityLength result = QuantityLength.Add(a, b);

            Assert.AreEqual(2.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Feet, result.Unit);
        }

        [TestMethod]
        public void testAddition_CrossUnit_InchPlusFeet()
        {
            var a = new QuantityLength(12.0, LengthUnit.Inch);
            var b = new QuantityLength(1.0, LengthUnit.Feet);

            QuantityLength result = QuantityLength.Add(a, b);

            Assert.AreEqual(24.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Inch, result.Unit);
        }

        [TestMethod]
        public void testAddition_CrossUnit_YardPlusFeet()
        {
            var a = new QuantityLength(1.0, LengthUnit.Yard);
            var b = new QuantityLength(3.0, LengthUnit.Feet);

            QuantityLength result = QuantityLength.Add(a, b);

            Assert.AreEqual(2.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Yard, result.Unit);
        }

        [TestMethod]
        public void testAddition_CrossUnit_InchesPlusYard()
        {
            var a = new QuantityLength(36.0, LengthUnit.Inch);
            var b = new QuantityLength(1.0, LengthUnit.Yard);

            QuantityLength result = QuantityLength.Add(a, b);

            Assert.AreEqual(72.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Inch, result.Unit);
        }

        [TestMethod]
        public void testAddition_CrossUnit_CentimeterPlusInch()
        {
            var a = new QuantityLength(2.54, LengthUnit.Centimeter);
            var b = new QuantityLength(1.0, LengthUnit.Inch);

            QuantityLength result = QuantityLength.Add(a, b);

            // Expected ≈ 5.08 cm
            Assert.AreEqual(5.08, result.Value, 0.01);
            Assert.AreEqual(LengthUnit.Centimeter, result.Unit);
        }

        [TestMethod]
        public void testAddition_WithZero()
        {
            var a = new QuantityLength(5.0, LengthUnit.Feet);
            var b = new QuantityLength(0.0, LengthUnit.Inch);

            QuantityLength result = QuantityLength.Add(a, b);

            Assert.AreEqual(5.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Feet, result.Unit);
        }

        [TestMethod]
        public void testAddition_NegativeValues()
        {
            var a = new QuantityLength(5.0, LengthUnit.Feet);
            var b = new QuantityLength(-2.0, LengthUnit.Feet);

            QuantityLength result = QuantityLength.Add(a, b);

            Assert.AreEqual(3.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Feet, result.Unit);
        }

        [TestMethod]
        public void testAddition_Commutativity_BaseValueCheck()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(12.0, LengthUnit.Inch);

            QuantityLength sum1 = QuantityLength.Add(a, b); // unit: Feet
            QuantityLength sum2 = QuantityLength.Add(b, a); // unit: Inch

            // To compare commutativity fairly, compare in base unit (Feet)
            Assert.AreEqual(sum1.ConvertToFeet(), sum2.ConvertToFeet(), EPSILON);
        }

        [TestMethod]
        public void testAddition_LargeValues()
        {
            var a = new QuantityLength(1e6, LengthUnit.Feet);
            var b = new QuantityLength(1e6, LengthUnit.Feet);

            QuantityLength result = QuantityLength.Add(a, b);

            Assert.AreEqual(2e6, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Feet, result.Unit);
        }

        [TestMethod]
        public void testAddition_SmallValues()
        {
            var a = new QuantityLength(0.001, LengthUnit.Feet);
            var b = new QuantityLength(0.002, LengthUnit.Feet);

            QuantityLength result = QuantityLength.Add(a, b);

            Assert.AreEqual(0.003, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Feet, result.Unit);
        }
    }
}