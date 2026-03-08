using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Tests
{
    /// <summary>
    /// Test suite validating value-based equality behavior of the
    /// QuantityLength domain model.
    ///
    /// PURPOSE:
    /// - Verifies cross-unit normalization logic
    /// - Ensures value-object semantics are preserved
    /// - Validates reflexive, symmetric, and transitive properties
    /// - Confirms null safety and reference equality handling
    ///
    /// DESIGN PRINCIPLE:
    /// Equality comparison is performed by converting both values
    /// to a common base unit (Feet) before comparison.
    ///
    /// This test class ensures that equality logic behaves consistently
    /// across all supported length units.
    /// </summary>
    [TestClass]
    public class QuantityLengthTests2
    {
        /// <summary>
        /// Verifies equality when both objects contain
        /// the same value and same unit.
        /// </summary>
        [TestMethod]
        public void testEquality_YardToYard_SameValue()
        {
            var YardSameValueOne = new QuantityLength(1.0, LengthUnit.Yard);
            var YardSameValueTwo = new QuantityLength(1.0, LengthUnit.Yard);

            Assert.IsTrue(YardSameValueOne.Equals(YardSameValueTwo));
        }

        /// <summary>
        /// Verifies inequality when same unit but different values.
        /// </summary>
        [TestMethod]
        public void testEquality_YardToYard_DifferentValue()
        {
            var YardDifferentValueOne = new QuantityLength(1.0, LengthUnit.Yard);
            var YardDifferentValueTwo = new QuantityLength(2.0, LengthUnit.Yard);

            Assert.IsFalse(YardDifferentValueOne.Equals(YardDifferentValueTwo));
        }

        /// <summary>
        /// Validates cross-unit equivalence:
        /// 1 Yard = 3 Feet.
        /// </summary>
        [TestMethod]
        public void testEquality_YardToFeet_EquivalentValue()
        {
            var YardValue = new QuantityLength(1.0, LengthUnit.Yard);
            var FeetValue = new QuantityLength(3.0, LengthUnit.Feet);

            Assert.IsTrue(YardValue.Equals(FeetValue));
        }

        /// <summary>
        /// Validates symmetric property of equality:
        /// a.Equals(b) == b.Equals(a)
        /// </summary>
        [TestMethod]
        public void testEquality_FeetToYard_EquivalentValue()
        {
            var FeetValue = new QuantityLength(3.0, LengthUnit.Feet);
            var YardValue = new QuantityLength(1.0, LengthUnit.Yard);

            Assert.IsTrue(FeetValue.Equals(YardValue));
        }

        /// <summary>
        /// Validates 1 Yard equals 36 Inches.
        /// </summary>
        [TestMethod]
        public void testEquality_YardToInches_EquivalentValue()
        {
            var YardValue = new QuantityLength(1.0, LengthUnit.Yard);
            var InchesValue = new QuantityLength(36.0, LengthUnit.Inch);

            Assert.IsTrue(YardValue.Equals(InchesValue));
        }

        /// <summary>
        /// Reverse-direction validation for symmetry.
        /// </summary>
        [TestMethod]
        public void testEquality_InchesToYard_EquivalentValue()
        {
            var InchesValue = new QuantityLength(36.0, LengthUnit.Inch);
            var YardValue = new QuantityLength(1.0, LengthUnit.Yard);

            Assert.IsTrue(InchesValue.Equals(YardValue));
        }

        /// <summary>
        /// Validates inequality across units when values
        /// do not represent the same physical measurement.
        /// </summary>
        [TestMethod]
        public void testEquality_YardToFeet_NonEquivalentValue()
        {
            var YardValue = new QuantityLength(1.0, LengthUnit.Yard);
            var FeetValue = new QuantityLength(2.0, LengthUnit.Feet);

            Assert.IsFalse(YardValue.Equals(FeetValue));
        }

        /// <summary>
        /// Validates centimeter to inch equivalence:
        /// 1 cm ≈ 0.393701 inches.
        /// </summary>
        [TestMethod]
        public void testEquality_centimetersToInches_EquivalentValue()
        {
            var CentimeterValue = new QuantityLength(1.0, LengthUnit.Centimeter);
            var InchesValue = new QuantityLength(0.393701, LengthUnit.Inch);

            Assert.IsTrue(CentimeterValue.Equals(InchesValue));
        }

        /// <summary>
        /// Validates centimeter to feet inequality.
        /// </summary>
        [TestMethod]
        public void testEquality_centimetersToFeet_NonEquivalentValue()
        {
            var CentimeterValue = new QuantityLength(1.0, LengthUnit.Centimeter);
            var FeetValue = new QuantityLength(1.0, LengthUnit.Feet);

            Assert.IsFalse(CentimeterValue.Equals(FeetValue));
        }

        /// <summary>
        /// Validates transitive property of equality:
        /// If A == B and B == C, then A == C.
        /// </summary>
        [TestMethod]
        public void testEquality_MultiUnit_TransitiveProperty()
        {
            var YardValue = new QuantityLength(1.0, LengthUnit.Yard);
            var FeetValue = new QuantityLength(3.0, LengthUnit.Feet);
            var InchesValue = new QuantityLength(36.0, LengthUnit.Inch);

            Assert.IsTrue(YardValue.Equals(FeetValue));
            Assert.IsTrue(FeetValue.Equals(InchesValue));
            Assert.IsTrue(YardValue.Equals(InchesValue));
        }

        /// <summary>
        /// Validates null comparison handling.
        /// Equality with null should always return false.
        /// </summary>
        [TestMethod]
        public void testEquality_YardWithNullUnit()
        {
            var YardValue = new QuantityLength(2.0, LengthUnit.Yard);

            Assert.IsFalse(YardValue.Equals(null));
        }

        /// <summary>
        /// Validates reflexive property:
        /// Object must equal itself.
        /// </summary>
        [TestMethod]
        public void testEquality_YardSameReference()
        {
            var YardValue = new QuantityLength(2.0, LengthUnit.Yard);

            Assert.IsTrue(YardValue.Equals(YardValue));
        }

        /// <summary>
        /// Additional null safety validation.
        /// </summary>
        [TestMethod]
        public void testEquality_YardNullComparison()
        {
            var YardValue = new QuantityLength(2.0, LengthUnit.Yard);

            Assert.IsFalse(YardValue.Equals(null));
        }

        /// <summary>
        /// Validates equality for same unit and same value.
        /// </summary>
        [TestMethod]
        public void testEquality_CentimeterToCentimeter_SameValue()
        {
            var a = new QuantityLength(2.0, LengthUnit.Centimeter);
            var b = new QuantityLength(2.0, LengthUnit.Centimeter);

            Assert.IsTrue(a.Equals(b));
        }

        /// <summary>
        /// Validates inequality for same unit but different values.
        /// </summary>
        [TestMethod]
        public void testEquality_CentimeterToCentimeter_DifferentValue()
        {
            var a = new QuantityLength(2.0, LengthUnit.Centimeter);
            var b = new QuantityLength(3.0, LengthUnit.Centimeter);

            Assert.IsFalse(a.Equals(b));
        }

        /// <summary>
        /// Validates inch to centimeter equivalence.
        /// </summary>
        [TestMethod]
        public void testEquality_InchToCentimeter_EquivalentValue()
        {
            var a = new QuantityLength(0.393701, LengthUnit.Inch);
            var b = new QuantityLength(1.0, LengthUnit.Centimeter);

            Assert.IsTrue(a.Equals(b));
        }

        /// <summary>
        /// Validates equality across multiple units in a complex scenario:
        /// 2 Yards = 6 Feet = 72 Inches.
        /// </summary>
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