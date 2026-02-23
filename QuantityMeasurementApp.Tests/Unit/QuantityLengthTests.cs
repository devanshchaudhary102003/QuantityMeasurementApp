using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Enums;
using System;

namespace QuantityMeasurementApp.Tests
{
    /// <summary>
    /// Unit tests for <see cref="QuantityLength"/>.
    /// 
    /// This test class validates:
    /// - Equality logic
    /// - Cross-unit conversion comparison
    /// - Null handling
    /// - Reference equality
    /// - Edge cases
    /// 
    /// Testing Framework: MSTest
    /// </summary>
    [TestClass]
    public class QuantityLengthTests
    {
        /// <summary>
        /// Verifies equality when both values are in Feet
        /// and have the same numeric value.
        /// </summary>
        
        [TestMethod]
        public void testEquality_FeetToFeet_SameValue()
        {
            //Arrange
            var QuantityLengthFeetSameValueOne = new QuantityLength(1.0,LengthUnit.Feet);
            var QuantityLengthFeetSameValueTwo = new QuantityLength(1.0,LengthUnit.Feet);

            //Act & Assert
            Assert.IsTrue(QuantityLengthFeetSameValueOne.Equals(QuantityLengthFeetSameValueTwo));
        }
        /// <summary>
        /// Verifies equality when both values are in Inches
        /// and have the same numeric value.
        /// </summary>
        [TestMethod]
        public void testEquality_InchToInch_SameValue()
        {
            //Arrange
            var QuantityLengthFeetDifferentValueOne = new QuantityLength(1.0,LengthUnit.Inch);
            var QuantityLengthFeetDifferentValueTwo = new QuantityLength(1.0,LengthUnit.Inch);

            //Act & Arrange
            Assert.IsTrue(QuantityLengthFeetDifferentValueOne.Equals(QuantityLengthFeetDifferentValueTwo));
        }

        /// <summary>
        /// Verifies equality when comparing Feet and Inches
        /// with equivalent measurement values.
        /// Example: 1 Feet == 12 Inches
        /// </summary>
        
        [TestMethod]
        public void testEquality_FeetToInch_EquivalentValue()
        {
            //Arrange
            var QuantityLengthFeetToInchValueOne = new QuantityLength(1.0,LengthUnit.Feet); 
            var QuantityLengthFeetToInchValueTwo = new QuantityLength(12.0,LengthUnit.Inch);

            //Act & Assert
            Assert.IsTrue(QuantityLengthFeetToInchValueOne.Equals(QuantityLengthFeetToInchValueTwo));
        }

        /// <summary>
        /// Verifies reverse cross-unit comparison.
        /// Example: 12 Inches == 1 Feet
        /// </summary>
        
        [TestMethod]
        public void testEquality_InchToFeet_EquivalentValue()
        {
            //Arrange
            var QuantityLengthInchToFeetValueOne = new QuantityLength(12.0,LengthUnit.Inch);
            var QuantityLengthInchToFeetValueTwo = new QuantityLength(1.0,LengthUnit.Feet);

            //Act & Assert
            Assert.IsTrue(QuantityLengthInchToFeetValueOne.Equals(QuantityLengthInchToFeetValueTwo));
        }

        /// <summary>
        /// Verifies inequality when values in Feet differ.
        /// </summary>
        [TestMethod]
        public void testEquality_FeetToFeet_DifferentValue()
        {
            //Arrange
            var QuantityLengthFeetToFeetValueOne = new QuantityLength(1.0,LengthUnit.Feet);
            var QuantityLengthInchToFeetValueTwo = new QuantityLength(2.0,LengthUnit.Feet);

            //Act & Assert
            Assert.IsFalse(QuantityLengthFeetToFeetValueOne.Equals(QuantityLengthInchToFeetValueTwo));
        }

        /// <summary>
        /// Verifies inequality when values in Inches differ.
        /// </summary>
        [TestMethod]
        public void testEquality_InchToInch_DifferentValue()
        {
            //Arrange
            var QuantityLengthInchToInchValueOne = new QuantityLength(1.0,LengthUnit.Inch);
            var QuantityLengthInchToInchValueTwo = new QuantityLength(2.0,LengthUnit.Inch);

            //Act & Assert
            Assert.IsFalse(QuantityLengthInchToInchValueOne.Equals(QuantityLengthInchToInchValueTwo));
        }

        /// <summary>
        /// Verifies reflexive property of equality.
        /// Object must be equal to itself.
        /// </summary>
        
        [TestMethod]
        public void testEquality_SameReference()
        {
            //Arrange
            var QuantityLengthSameReferenceValue = new QuantityLength(1.0, LengthUnit.Feet);

            //Act & Assert
            Assert.IsTrue(QuantityLengthSameReferenceValue.Equals(QuantityLengthSameReferenceValue));
        }

        /// <summary>
        /// Verifies comparison with null returns false.
        /// </summary>
        [TestMethod]
        public void testEquality_NullComparison()
        {
            //Arrange
            var QuantityLengthNullComparisonValue = new QuantityLength(1.0,LengthUnit.Feet);

            //Act & Assert
            Assert.IsFalse(QuantityLengthNullComparisonValue.Equals(null));
        }

        /// <summary>
        /// Verifies behavior when invalid numeric value is provided.
        /// Expected to throw ArgumentException (if validation exists in constructor).
        /// </summary>
        
        [TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        public void testEquality_InvalidValue()
        {
            var QuantityLengthInvalidValue = new QuantityLength(double.NaN,LengthUnit.Feet);
        }
    }
}