using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Tests
{
    [TestClass]
    public class QuantityWeightTests
    {
        private const double EPSILON = 1e-6;

        [TestMethod]
        public void testEquality_KilogramToKilogram_SameValue()
        {
            var a = new QuantityWeight(1.0, WeightUnit.Kilogram);
            var b = new QuantityWeight(1.0, WeightUnit.Kilogram);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_KilogramToKilogram_DifferentValue()
        {
            var a = new QuantityWeight(1.0, WeightUnit.Kilogram);
            var b = new QuantityWeight(2.0, WeightUnit.Kilogram);

            Assert.IsFalse(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_KilogramToGram_EquivalentValue()
        {
            var a = new QuantityWeight(1.0, WeightUnit.Kilogram);
            var b = new QuantityWeight(1000.0, WeightUnit.Gram);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_GramToKilogram_EquivalentValue()
        {
            var a = new QuantityWeight(1000.0, WeightUnit.Gram);
            var b = new QuantityWeight(1.0, WeightUnit.Kilogram);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_NullComparison()
        {
            var a = new QuantityWeight(1.0, WeightUnit.Kilogram);

            Assert.IsFalse(a.Equals(null));
        }

        [TestMethod]
        public void testEquality_SameReference()
        {
            var a = new QuantityWeight(1.0, WeightUnit.Kilogram);

            Assert.IsTrue(a.Equals(a));
        }

        [TestMethod]
        public void testEquality_ZeroValue()
        {
            var a = new QuantityWeight(0.0, WeightUnit.Kilogram);
            var b = new QuantityWeight(0.0, WeightUnit.Gram);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_NegativeWeight()
        {
            var a = new QuantityWeight(-1.0, WeightUnit.Kilogram);
            var b = new QuantityWeight(-1000.0, WeightUnit.Gram);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_LargeWeightValue()
        {
            var a = new QuantityWeight(1000000.0, WeightUnit.Gram);
            var b = new QuantityWeight(1000.0, WeightUnit.Kilogram);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_SmallWeightValue()
        {
            var a = new QuantityWeight(0.001, WeightUnit.Kilogram);
            var b = new QuantityWeight(1.0, WeightUnit.Gram);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testConversion_PoundToKilogram()
        {
            var a = new QuantityWeight(2.20462, WeightUnit.Pound);
            QuantityWeight result = a.ConvertTo(WeightUnit.Kilogram);

            Assert.AreEqual(1.0, result.Value, 0.001);
            Assert.AreEqual(WeightUnit.Kilogram, result.Unit);
        }

        [TestMethod]
        public void testConversion_KilogramToPound()
        {
            var a = new QuantityWeight(1.0, WeightUnit.Kilogram);
            QuantityWeight result = a.ConvertTo(WeightUnit.Pound);

            Assert.AreEqual(2.20462, result.Value, 0.001);
            Assert.AreEqual(WeightUnit.Pound, result.Unit);
        }

        [TestMethod]
        public void testConversion_SameUnit()
        {
            var a = new QuantityWeight(5.0, WeightUnit.Kilogram);
            QuantityWeight result = a.ConvertTo(WeightUnit.Kilogram);

            Assert.AreEqual(5.0, result.Value, EPSILON);
            Assert.AreEqual(WeightUnit.Kilogram, result.Unit);
        }

        [TestMethod]
        public void testConversion_ZeroValue()
        {
            var a = new QuantityWeight(0.0, WeightUnit.Kilogram);
            QuantityWeight result = a.ConvertTo(WeightUnit.Gram);

            Assert.AreEqual(0.0, result.Value, EPSILON);
            Assert.AreEqual(WeightUnit.Gram, result.Unit);
        }

        [TestMethod]
        public void testConversion_NegativeValue()
        {
            var a = new QuantityWeight(-1.0, WeightUnit.Kilogram);
            QuantityWeight result = a.ConvertTo(WeightUnit.Gram);

            Assert.AreEqual(-1000.0, result.Value, EPSILON);
            Assert.AreEqual(WeightUnit.Gram, result.Unit);
        }

        [TestMethod]
        public void testConversion_RoundTrip()
        {
            var a = new QuantityWeight(1.5, WeightUnit.Kilogram);

            QuantityWeight gram = a.ConvertTo(WeightUnit.Gram);
            QuantityWeight kilogram = gram.ConvertTo(WeightUnit.Kilogram);

            Assert.AreEqual(1.5, kilogram.Value, EPSILON);
            Assert.AreEqual(WeightUnit.Kilogram, kilogram.Unit);
        }

        [TestMethod]
        public void testAddition_SameUnit_KilogramPlusKilogram()
        {
            var a = new QuantityWeight(1.0, WeightUnit.Kilogram);
            var b = new QuantityWeight(2.0, WeightUnit.Kilogram);

            QuantityWeight result = QuantityWeight.Add(a, b);

            Assert.AreEqual(3.0, result.Value, EPSILON);
            Assert.AreEqual(WeightUnit.Kilogram, result.Unit);
        }

        [TestMethod]
        public void testAddition_CrossUnit_KilogramPlusGram()
        {
            var a = new QuantityWeight(1.0, WeightUnit.Kilogram);
            var b = new QuantityWeight(1000.0, WeightUnit.Gram);

            QuantityWeight result = QuantityWeight.Add(a, b);

            Assert.AreEqual(2.0, result.Value, EPSILON);
            Assert.AreEqual(WeightUnit.Kilogram, result.Unit);
        }

        [TestMethod]
        public void testAddition_CrossUnit_PoundPlusKilogram()
        {
            var a = new QuantityWeight(2.20462, WeightUnit.Pound);
            var b = new QuantityWeight(1.0, WeightUnit.Kilogram);

            QuantityWeight result = QuantityWeight.Add(a, b);

            Assert.AreEqual(4.40924, result.Value, 0.01);
            Assert.AreEqual(WeightUnit.Pound, result.Unit);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_Gram()
        {
            var a = new QuantityWeight(1.0, WeightUnit.Kilogram);
            var b = new QuantityWeight(1000.0, WeightUnit.Gram);

            QuantityWeight result = QuantityWeight.Add(a, b, WeightUnit.Gram);

            Assert.AreEqual(2000.0, result.Value, EPSILON);
            Assert.AreEqual(WeightUnit.Gram, result.Unit);
        }

        [TestMethod]
        public void testAddition_WithZero()
        {
            var a = new QuantityWeight(5.0, WeightUnit.Kilogram);
            var b = new QuantityWeight(0.0, WeightUnit.Gram);

            QuantityWeight result = QuantityWeight.Add(a, b);

            Assert.AreEqual(5.0, result.Value, EPSILON);
            Assert.AreEqual(WeightUnit.Kilogram, result.Unit);
        }

        [TestMethod]
        public void testAddition_NegativeValues()
        {
            var a = new QuantityWeight(5.0, WeightUnit.Kilogram);
            var b = new QuantityWeight(-2000.0, WeightUnit.Gram);

            QuantityWeight result = QuantityWeight.Add(a, b);

            Assert.AreEqual(3.0, result.Value, EPSILON);
            Assert.AreEqual(WeightUnit.Kilogram, result.Unit);
        }

        [TestMethod]
        public void testAddition_LargeValues()
        {
            var a = new QuantityWeight(1e6, WeightUnit.Kilogram);
            var b = new QuantityWeight(1e6, WeightUnit.Kilogram);

            QuantityWeight result = QuantityWeight.Add(a, b);

            Assert.AreEqual(2e6, result.Value, EPSILON);
            Assert.AreEqual(WeightUnit.Kilogram, result.Unit);
        }

        [TestMethod]
        public void testEquality_WeightVsLength_Incompatible()
        {
            var weight = new QuantityWeight(1.0, WeightUnit.Kilogram);
            var length = new QuantityLength(1.0, LengthUnit.Feet);

            Assert.IsFalse(weight.Equals(length));
        }
    }
}