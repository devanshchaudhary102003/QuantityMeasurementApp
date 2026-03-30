using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Model;

namespace QuantityMeasurementApp.Tests
{
    [TestClass]
    public class QuantitySubtractDivisionTests
    {
        private const double EPSILON = 1e-6;

        [TestMethod]
        public void testSubtraction_SameUnit_FeetMinusFeet()
        {
            var q1 = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);
            var q2 = new Quantity<LengthUnit>(5.0, LengthUnit.Feet);

            var result = q1.Subtract(q2);

            Assert.AreEqual(5.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Feet, result.Unit);
        }

        [TestMethod]
        public void testSubtraction_SameUnit_LitreMinusLitre()
        {
            var q1 = new Quantity<VolumeUnit>(10.0, VolumeUnit.Litre);
            var q2 = new Quantity<VolumeUnit>(3.0, VolumeUnit.Litre);

            var result = q1.Subtract(q2);

            Assert.AreEqual(7.0, result.Value, EPSILON);
            Assert.AreEqual(VolumeUnit.Litre, result.Unit);
        }

        [TestMethod]
        public void testSubtraction_CrossUnit_FeetMinusInches()
        {
            var q1 = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);
            var q2 = new Quantity<LengthUnit>(6.0, LengthUnit.Inch);

            var result = q1.Subtract(q2);

            Assert.AreEqual(9.5, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Feet, result.Unit);
        }

        [TestMethod]
        public void testSubtraction_CrossUnit_InchesMinusFeet()
        {
            var q1 = new Quantity<LengthUnit>(120.0, LengthUnit.Inch);
            var q2 = new Quantity<LengthUnit>(5.0, LengthUnit.Feet);

            var result = q1.Subtract(q2);

            Assert.AreEqual(60.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Inch, result.Unit);
        }

        [TestMethod]
        public void testSubtraction_ExplicitTargetUnit_Feet()
        {
            var q1 = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);
            var q2 = new Quantity<LengthUnit>(6.0, LengthUnit.Inch);

            var result = q1.Subtract(q2, LengthUnit.Feet);

            Assert.AreEqual(9.5, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Feet, result.Unit);
        }

        [TestMethod]
        public void testSubtraction_ExplicitTargetUnit_Inches()
        {
            var q1 = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);
            var q2 = new Quantity<LengthUnit>(6.0, LengthUnit.Inch);

            var result = q1.Subtract(q2, LengthUnit.Inch);

            Assert.AreEqual(114.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Inch, result.Unit);
        }

        [TestMethod]
        public void testSubtraction_ExplicitTargetUnit_Millilitre()
        {
            var q1 = new Quantity<VolumeUnit>(5.0, VolumeUnit.Litre);
            var q2 = new Quantity<VolumeUnit>(2.0, VolumeUnit.Litre);

            var result = q1.Subtract(q2, VolumeUnit.Millilitre);

            Assert.AreEqual(3000.0, result.Value, EPSILON);
            Assert.AreEqual(VolumeUnit.Millilitre, result.Unit);
        }

        [TestMethod]
        public void testSubtraction_ResultingInNegative()
        {
            var q1 = new Quantity<LengthUnit>(5.0, LengthUnit.Feet);
            var q2 = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);

            var result = q1.Subtract(q2);

            Assert.AreEqual(-5.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Feet, result.Unit);
        }

        [TestMethod]
        public void testSubtraction_ResultingInZero()
        {
            var q1 = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);
            var q2 = new Quantity<LengthUnit>(120.0, LengthUnit.Inch);

            var result = q1.Subtract(q2);

            Assert.AreEqual(0.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Feet, result.Unit);
        }

        [TestMethod]
        public void testSubtraction_WithZeroOperand()
        {
            var q1 = new Quantity<LengthUnit>(5.0, LengthUnit.Feet);
            var q2 = new Quantity<LengthUnit>(0.0, LengthUnit.Inch);

            var result = q1.Subtract(q2);

            Assert.AreEqual(5.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testSubtraction_WithNegativeValues()
        {
            var q1 = new Quantity<LengthUnit>(5.0, LengthUnit.Feet);
            var q2 = new Quantity<LengthUnit>(-2.0, LengthUnit.Feet);

            var result = q1.Subtract(q2);

            Assert.AreEqual(7.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testSubtraction_NonCommutative()
        {
            var a = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(5.0, LengthUnit.Feet);

            var result1 = a.Subtract(b);
            var result2 = b.Subtract(a);

            Assert.AreEqual(5.0, result1.Value, EPSILON);
            Assert.AreEqual(-5.0, result2.Value, EPSILON);
            Assert.AreNotEqual(result1.Value, result2.Value, EPSILON);
        }

        [TestMethod]
        public void testSubtraction_WithLargeValues()
        {
            var q1 = new Quantity<WeightUnit>(1e6, WeightUnit.Kilogram);
            var q2 = new Quantity<WeightUnit>(5e5, WeightUnit.Kilogram);

            var result = q1.Subtract(q2);

            Assert.AreEqual(5e5, result.Value, EPSILON);
        }

        [TestMethod]
        public void testSubtraction_WithSmallValues()
        {
            var q1 = new Quantity<LengthUnit>(0.001, LengthUnit.Feet);
            var q2 = new Quantity<LengthUnit>(0.0005, LengthUnit.Feet);

            var result = q1.Subtract(q2);

            Assert.AreEqual(0.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testSubtraction_AllMeasurementCategories()
        {
            var lengthResult = new Quantity<LengthUnit>(10.0, LengthUnit.Feet)
                .Subtract(new Quantity<LengthUnit>(6.0, LengthUnit.Inch));

            var weightResult = new Quantity<WeightUnit>(10.0, WeightUnit.Kilogram)
                .Subtract(new Quantity<WeightUnit>(5000.0, WeightUnit.Gram));

            var volumeResult = new Quantity<VolumeUnit>(5.0, VolumeUnit.Litre)
                .Subtract(new Quantity<VolumeUnit>(500.0, VolumeUnit.Millilitre));

            Assert.AreEqual(9.5, lengthResult.Value, EPSILON);
            Assert.AreEqual(5.0, weightResult.Value, EPSILON);
            Assert.AreEqual(4.5, volumeResult.Value, EPSILON);
        }

        [TestMethod]
        public void testSubtraction_ChainedOperations()
        {
            var result = new Quantity<LengthUnit>(10.0, LengthUnit.Feet)
                .Subtract(new Quantity<LengthUnit>(2.0, LengthUnit.Feet))
                .Subtract(new Quantity<LengthUnit>(1.0, LengthUnit.Feet));

            Assert.AreEqual(7.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Feet, result.Unit);
        }

        [TestMethod]
        public void testDivision_SameUnit_FeetDividedByFeet()
        {
            var q1 = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);
            var q2 = new Quantity<LengthUnit>(2.0, LengthUnit.Feet);

            double result = q1.Divide(q2);

            Assert.AreEqual(5.0, result, EPSILON);
        }

        [TestMethod]
        public void testDivision_SameUnit_LitreDividedByLitre()
        {
            var q1 = new Quantity<VolumeUnit>(10.0, VolumeUnit.Litre);
            var q2 = new Quantity<VolumeUnit>(5.0, VolumeUnit.Litre);

            double result = q1.Divide(q2);

            Assert.AreEqual(2.0, result, EPSILON);
        }

        [TestMethod]
        public void testDivision_CrossUnit_FeetDividedByInches()
        {
            var q1 = new Quantity<LengthUnit>(24.0, LengthUnit.Inch);
            var q2 = new Quantity<LengthUnit>(2.0, LengthUnit.Feet);

            double result = q1.Divide(q2);

            Assert.AreEqual(1.0, result, EPSILON);
        }

        [TestMethod]
        public void testDivision_CrossUnit_KilogramDividedByGram()
        {
            var q1 = new Quantity<WeightUnit>(2.0, WeightUnit.Kilogram);
            var q2 = new Quantity<WeightUnit>(2000.0, WeightUnit.Gram);

            double result = q1.Divide(q2);

            Assert.AreEqual(1.0, result, EPSILON);
        }

        [TestMethod]
        public void testDivision_RatioGreaterThanOne()
        {
            var q1 = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);
            var q2 = new Quantity<LengthUnit>(2.0, LengthUnit.Feet);

            double result = q1.Divide(q2);

            Assert.IsTrue(result > 1.0);
            Assert.AreEqual(5.0, result, EPSILON);
        }

        [TestMethod]
        public void testDivision_RatioLessThanOne()
        {
            var q1 = new Quantity<LengthUnit>(5.0, LengthUnit.Feet);
            var q2 = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);

            double result = q1.Divide(q2);

            Assert.IsTrue(result < 1.0);
            Assert.AreEqual(0.5, result, EPSILON);
        }

        [TestMethod]
        public void testDivision_RatioEqualToOne()
        {
            var q1 = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);
            var q2 = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);

            double result = q1.Divide(q2);

            Assert.AreEqual(1.0, result, EPSILON);
        }
    }
}