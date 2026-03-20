using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Enums;
using System;

namespace QuantityMeasurementApp.Tests
{
    [TestClass]
    public class QuantityLengthTests
    {
        [TestMethod]
        public void testEquality_FeetToFeet_SameValue()
        {
            var QuantityLengthFeetSameValueOne = new QuantityLength(1.0, LengthUnit.Feet);
            var QuantityLengthFeetSameValueTwo = new QuantityLength(1.0, LengthUnit.Feet);

            Assert.IsTrue(QuantityLengthFeetSameValueOne.Equals(QuantityLengthFeetSameValueTwo));
        }

        [TestMethod]
        public void testEquality_InchToInch_SameValue()
        {
            var QuantityLengthFeetDifferentValueOne = new QuantityLength(1.0, LengthUnit.Inch);
            var QuantityLengthFeetDifferentValueTwo = new QuantityLength(1.0, LengthUnit.Inch);

            Assert.IsTrue(QuantityLengthFeetDifferentValueOne.Equals(QuantityLengthFeetDifferentValueTwo));
        }

        [TestMethod]
        public void testEquality_FeetToInch_EquivalentValue()
        {
            var QuantityLengthFeetToInchValueOne = new QuantityLength(1.0, LengthUnit.Feet);
            var QuantityLengthFeetToInchValueTwo = new QuantityLength(12.0, LengthUnit.Inch);

            Assert.IsTrue(QuantityLengthFeetToInchValueOne.Equals(QuantityLengthFeetToInchValueTwo));
        }

        [TestMethod]
        public void testEquality_InchToFeet_EquivalentValue()
        {
            var QuantityLengthInchToFeetValueOne = new QuantityLength(12.0, LengthUnit.Inch);
            var QuantityLengthInchToFeetValueTwo = new QuantityLength(1.0, LengthUnit.Feet);

            Assert.IsTrue(QuantityLengthInchToFeetValueOne.Equals(QuantityLengthInchToFeetValueTwo));
        }

        [TestMethod]
        public void testEquality_FeetToFeet_DifferentValue()
        {
            var QuantityLengthFeetToFeetValueOne = new QuantityLength(1.0, LengthUnit.Feet);
            var QuantityLengthInchToFeetValueTwo = new QuantityLength(2.0, LengthUnit.Feet);

            Assert.IsFalse(QuantityLengthFeetToFeetValueOne.Equals(QuantityLengthInchToFeetValueTwo));
        }

        [TestMethod]
        public void testEquality_InchToInch_DifferentValue()
        {
            var QuantityLengthInchToInchValueOne = new QuantityLength(1.0, LengthUnit.Inch);
            var QuantityLengthInchToInchValueTwo = new QuantityLength(2.0, LengthUnit.Inch);

            Assert.IsFalse(QuantityLengthInchToInchValueOne.Equals(QuantityLengthInchToInchValueTwo));
        }

        [TestMethod]
        public void testEquality_SameReference()
        {
            var QuantityLengthSameReferenceValue = new QuantityLength(1.0, LengthUnit.Feet);

            Assert.IsTrue(QuantityLengthSameReferenceValue.Equals(QuantityLengthSameReferenceValue));
        }

        [TestMethod]
        public void testEquality_NullComparison()
        {
            var QuantityLengthNullComparisonValue = new QuantityLength(1.0, LengthUnit.Feet);

            Assert.IsFalse(QuantityLengthNullComparisonValue.Equals(null));
        }

        [TestMethod]
        public void testEquality_InvalidValue()
        {
            var QuantityLengthInvalidValue = new QuantityLength(double.NaN, LengthUnit.Feet);
        }
    }
}