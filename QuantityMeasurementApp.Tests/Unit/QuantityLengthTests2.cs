using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Tests
{
    [TestClass]
    public class QuantityLengthTests2
    {
        [TestMethod]
        public void testEquality_YardToYard_SameValue()
        {
            var a = new QuantityLength(1.0, LengthUnit.Yard);
            var b = new QuantityLength(1.0, LengthUnit.Yard);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_YardToYard_DifferentValue()
        {
            var a = new QuantityLength(1.0, LengthUnit.Yard);
            var b = new QuantityLength(2.0, LengthUnit.Yard);

            Assert.IsFalse(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_YardToFeet_EquivalentValue()
        {
            var a = new QuantityLength(1.0, LengthUnit.Yard);
            var b = new QuantityLength(3.0, LengthUnit.Feet);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_FeetToYard_EquivalentValue()
        {
            var a = new QuantityLength(3.0, LengthUnit.Feet);
            var b = new QuantityLength(1.0, LengthUnit.Yard);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_YardToInch_EquivalentValue()
        {
            var a = new QuantityLength(1.0, LengthUnit.Yard);
            var b = new QuantityLength(36.0, LengthUnit.Inch);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_InchToYard_EquivalentValue()
        {
            var a = new QuantityLength(36.0, LengthUnit.Inch);
            var b = new QuantityLength(1.0, LengthUnit.Yard);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_YardToFeet_NonEquivalentValue()
        {
            var a = new QuantityLength(1.0, LengthUnit.Yard);
            var b = new QuantityLength(2.0, LengthUnit.Feet);

            Assert.IsFalse(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_CentimeterToCentimeter_SameValue()
        {
            var a = new QuantityLength(2.0, LengthUnit.Centimeter);
            var b = new QuantityLength(2.0, LengthUnit.Centimeter);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_CentimeterToCentimeter_DifferentValue()
        {
            var a = new QuantityLength(2.0, LengthUnit.Centimeter);
            var b = new QuantityLength(3.0, LengthUnit.Centimeter);

            Assert.IsFalse(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_CentimeterToInch_EquivalentValue()
        {
            var a = new QuantityLength(1.0, LengthUnit.Centimeter);
            var b = new QuantityLength(0.393701, LengthUnit.Inch);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_InchToCentimeter_EquivalentValue()
        {
            var a = new QuantityLength(0.393701, LengthUnit.Inch);
            var b = new QuantityLength(1.0, LengthUnit.Centimeter);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_CentimeterToFeet_NonEquivalentValue()
        {
            var a = new QuantityLength(1.0, LengthUnit.Centimeter);
            var b = new QuantityLength(1.0, LengthUnit.Feet);

            Assert.IsFalse(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_MultiUnit_TransitiveProperty()
        {
            var yard = new QuantityLength(1.0, LengthUnit.Yard);
            var Feet = new QuantityLength(3.0, LengthUnit.Feet);
            var Inch = new QuantityLength(36.0, LengthUnit.Inch);

            Assert.IsTrue(yard.Equals(Feet));
            Assert.IsTrue(Feet.Equals(Inch));
            Assert.IsTrue(yard.Equals(Inch));
        }

        [TestMethod]
        public void testEquality_YardameReference()
        {
            var a = new QuantityLength(2.0, LengthUnit.Yard);
            Assert.IsTrue(a.Equals(a));
        }

        [TestMethod]
        public void testEquality_YardNullComparison()
        {
            var a = new QuantityLength(2.0, LengthUnit.Yard);
            Assert.IsFalse(a.Equals(null));
        }

        [TestMethod]
        public void testEquality_AllUnits_ComplexScenario()
        {
            var yard = new QuantityLength(2.0, LengthUnit.Yard);
            var Feet = new QuantityLength(6.0, LengthUnit.Feet);
            var Inch = new QuantityLength(72.0, LengthUnit.Inch);

            Assert.IsTrue(yard.Equals(Feet));
            Assert.IsTrue(Feet.Equals(Inch));
            Assert.IsTrue(yard.Equals(Inch));
        }
    }
}