using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Enums;
using System;

namespace QuantityMeasurementApp.Tests
{
    [TestClass]
    public class QuantityLengthAdditionWithTargetUnitTests
    {
        private const double EPSILON = 1e-6;

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_Feet()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(12.0, LengthUnit.Inch);

            QuantityLength result = QuantityLength.Add(a, b, LengthUnit.Feet);

            Assert.AreEqual(2.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Feet, result.Unit);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_Inches()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(12.0, LengthUnit.Inch);

            QuantityLength result = QuantityLength.Add(a, b, LengthUnit.Inch);

            Assert.AreEqual(24.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Inch, result.Unit);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_Yards()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(12.0, LengthUnit.Inch);

            QuantityLength result = QuantityLength.Add(a, b, LengthUnit.Yard);

            Assert.AreEqual(0.666666, result.Value, 0.001);
            Assert.AreEqual(LengthUnit.Yard, result.Unit);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_Centimeters()
        {
            var a = new QuantityLength(1.0, LengthUnit.Inch);
            var b = new QuantityLength(1.0, LengthUnit.Inch);

            QuantityLength result = QuantityLength.Add(a, b, LengthUnit.Centimeter);

            Assert.AreEqual(5.08, result.Value, 0.01);
            Assert.AreEqual(LengthUnit.Centimeter, result.Unit);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_SameAsFirstOperand()
        {
            var a = new QuantityLength(2.0, LengthUnit.Yard);
            var b = new QuantityLength(3.0, LengthUnit.Feet);

            QuantityLength result = QuantityLength.Add(a, b, LengthUnit.Yard);

            Assert.AreEqual(3.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Yard, result.Unit);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_SameAsSecondOperand()
        {
            var a = new QuantityLength(2.0, LengthUnit.Yard);
            var b = new QuantityLength(3.0, LengthUnit.Feet);

            QuantityLength result = QuantityLength.Add(a, b, LengthUnit.Feet);

            Assert.AreEqual(9.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Feet, result.Unit);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_Commutativity()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(12.0, LengthUnit.Inch);

            QuantityLength resultOne = QuantityLength.Add(a, b, LengthUnit.Yard);
            QuantityLength resultTwo = QuantityLength.Add(b, a, LengthUnit.Yard);

            Assert.AreEqual(resultOne.Value, resultTwo.Value, EPSILON);
            Assert.AreEqual(resultOne.Unit, resultTwo.Unit);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_WithZero()
        {
            var a = new QuantityLength(5.0, LengthUnit.Feet);
            var b = new QuantityLength(0.0, LengthUnit.Inch);

            QuantityLength result = QuantityLength.Add(a, b, LengthUnit.Yard);

            Assert.AreEqual(1.666666, result.Value, 0.001);
            Assert.AreEqual(LengthUnit.Yard, result.Unit);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_NegativeValues()
        {
            var a = new QuantityLength(5.0, LengthUnit.Feet);
            var b = new QuantityLength(-2.0, LengthUnit.Feet);

            QuantityLength result = QuantityLength.Add(a, b, LengthUnit.Inch);

            Assert.AreEqual(36.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Inch, result.Unit);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_LargeToSmallScale()
        {
            var a = new QuantityLength(1000.0, LengthUnit.Feet);
            var b = new QuantityLength(500.0, LengthUnit.Feet);

            QuantityLength result = QuantityLength.Add(a, b, LengthUnit.Inch);

            Assert.AreEqual(18000.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Inch, result.Unit);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_SmallToLargeScale()
        {
            var a = new QuantityLength(12.0, LengthUnit.Inch);
            var b = new QuantityLength(12.0, LengthUnit.Inch);

            QuantityLength result = QuantityLength.Add(a, b, LengthUnit.Yard);

            Assert.AreEqual(0.666666, result.Value, 0.001);
            Assert.AreEqual(LengthUnit.Yard, result.Unit);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_PrecisionTolerance()
        {
            var a = new QuantityLength(2.54, LengthUnit.Centimeter);
            var b = new QuantityLength(1.0, LengthUnit.Inch);

            QuantityLength result = QuantityLength.Add(a, b, LengthUnit.Centimeter);

            Assert.AreEqual(5.08, result.Value, 0.01);
            Assert.AreEqual(LengthUnit.Centimeter, result.Unit);
        }
    }
}