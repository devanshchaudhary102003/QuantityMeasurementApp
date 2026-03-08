using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Enums;
using System;

namespace QuantityMeasurementApp.Tests
{
    /// <summary>
    /// Test suite for validating UC5 – Unit-to-Unit Conversion functionality
    /// of the QuantityLength domain model.
    ///
    /// Scope:
    /// - Verifies mathematical correctness of conversion logic
    /// - Validates cross-unit normalization via base unit (Feet)
    /// - Ensures floating-point tolerance handling
    /// - Confirms immutability behavior of ConvertTo() instance method
    ///
    /// Design Validation:
    /// All tests assume that conversion is performed using:
    ///     result = value × (sourceFactor / targetFactor)
    ///
    /// Base unit normalization: FEET
    /// </summary>
    [TestClass]
    public class QuantityLengthConversionTests3
    {
        /// <summary>
        /// Floating-point comparison tolerance.
        /// Used to avoid false negatives due to minor precision deviations.
        /// </summary>
        private const double EPSILON = 1e-6;

        /// <summary>
        /// Validates conversion from Feet to Inches.
        /// 1 Foot = 12 Inches.
        /// </summary>
        [TestMethod]
        public void testConversion_FeetToInches()
        {
            double result = QuantityLength.Convert(1.0, LengthUnit.Feet, LengthUnit.Inch);

            Assert.AreEqual(12.0, result, EPSILON);
        }

        /// <summary>
        /// Validates conversion from Inches to Feet.
        /// 24 Inches = 2 Feet.
        /// </summary>
        [TestMethod]
        public void testConversion_InchesToFeet()
        {
            double result = QuantityLength.Convert(24.0, LengthUnit.Inch, LengthUnit.Feet);

            Assert.AreEqual(2.0, result, EPSILON);
        }

        /// <summary>
        /// Validates conversion from Yards to Inches.
        /// 1 Yard = 36 Inches.
        /// </summary>
        [TestMethod]
        public void testConversion_YardsToInches()
        {
            double result = QuantityLength.Convert(1.0, LengthUnit.Yard, LengthUnit.Inch);

            Assert.AreEqual(36.0, result, EPSILON);
        }

        /// <summary>
        /// Validates conversion from Inches to Yards.
        /// 72 Inches = 2 Yards.
        /// </summary>
        [TestMethod]
        public void testConversion_InchesToYards()
        {
            double result = QuantityLength.Convert(72.0, LengthUnit.Inch, LengthUnit.Yard);

            Assert.AreEqual(2.0, result, EPSILON);
        }

        /// <summary>
        /// Validates conversion from Centimeters to Inches.
        /// 2.54 cm ≈ 1 inch.
        ///
        /// Uses relaxed tolerance due to decimal precision.
        /// </summary>
        [TestMethod]
        public void testConversion_CentimetersToInches()
        {
            double result = QuantityLength.Convert(2.54, LengthUnit.Centimeter, LengthUnit.Inch);

            Assert.AreEqual(1.0, result, 0.001);
        }

        /// <summary>
        /// Validates conversion from Feet to Yard.
        /// 6 Feet = 2 Yards.
        /// </summary>
        [TestMethod]
        public void testConversion_FeatToYard()
        {
            double result = QuantityLength.Convert(6.0, LengthUnit.Feet, LengthUnit.Yard);

            Assert.AreEqual(2.0, result, EPSILON);
        }

        /// <summary>
        /// Validates round-trip conversion accuracy.
        ///
        /// Converts:
        /// Feet → Inches → Feet
        ///
        /// Ensures that the original value is preserved within tolerance.
        /// </summary>
        [TestMethod]
        public void testConversion_RoundTrip_PreservesValue()
        {
            double originalValue = 5.75;

            double toInches = QuantityLength.Convert(originalValue, LengthUnit.Feet, LengthUnit.Inch);
            double backToFeet = QuantityLength.Convert(toInches, LengthUnit.Inch, LengthUnit.Feet);

            Assert.AreEqual(originalValue, backToFeet, EPSILON);
        }

        /// <summary>
        /// Ensures zero conversion remains zero across units.
        /// </summary>
        [TestMethod]
        public void testConversion_ZeroValue()
        {
            double result = QuantityLength.Convert(0.0, LengthUnit.Feet, LengthUnit.Inch);

            Assert.AreEqual(0.0, result, EPSILON);
        }

        /// <summary>
        /// Ensures negative values preserve sign after conversion.
        /// -1 Foot = -12 Inches.
        /// </summary>
        [TestMethod]
        public void testConversion_NegativeValue()
        {
            double result = QuantityLength.Convert(-1.0, LengthUnit.Feet, LengthUnit.Inch);

            Assert.AreEqual(-12.0, result, EPSILON);
        }

        /// <summary>
        /// Validates precision tolerance logic for centimeter to inch conversion.
        /// Ensures result lies within acceptable floating-point bounds.
        /// </summary>
        [TestMethod]
        public void testConversion_PrecisionTolerance()
        {
            double result = QuantityLength.Convert(1.0, LengthUnit.Centimeter, LengthUnit.Inch);

            Assert.IsTrue(Math.Abs(result - 0.393701) < EPSILON);
        }

        /// <summary>
        /// Validates instance-level conversion using ConvertTo().
        /// Ensures:
        /// - New object is returned
        /// - Value is correctly converted
        /// - Target unit is assigned correctly
        /// </summary>
        [TestMethod]
        public void testConversion_InstanceConvertTo_FeetToInch()
        {
            var length = new QuantityLength(1.0, LengthUnit.Feet);

            QuantityLength converted = length.ConvertTo(LengthUnit.Inch);

            Assert.AreEqual(12.0, converted.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Inch, converted.Unit);
        }

        /// <summary>
        /// Validates ConvertTo() for Inch to Yard transformation.
        /// 36 Inches = 1 Yard.
        /// </summary>
        [TestMethod]
        public void testConversion_InstanceConvertTo_InchToYard()
        {
            var length = new QuantityLength(36.0, LengthUnit.Inch);

            QuantityLength converted = length.ConvertTo(LengthUnit.Yard);

            Assert.AreEqual(1.0, converted.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Yard, converted.Unit);
        }
    }
}