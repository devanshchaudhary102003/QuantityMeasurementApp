using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Tests.Unit
{
    /// <summary>
    /// Contains unit tests for validating value-based equality
    /// behavior of the Feet class.
    /// 
    /// These tests ensure compliance with:
    /// - Equality contract (Reflexive, Symmetric, Null handling)
    /// - Type safety
    /// - Value-based comparison
    /// </summary>
    [TestClass]
    public class FeetEqualityTests
    {
        private FeetServices service;
        /// <summary>
        /// Initializes required dependencies before each test execution.
        /// Ensures each test runs in isolation.
        /// </summary>

        [TestInitialize]
        public void SetUp()
        {
            service = new FeetServices();
        }
        /// <summary>
        /// GIVEN two Feet objects with identical values
        /// WHEN equality comparison is performed
        /// THEN result should be true.
        /// </summary>

        [TestMethod]
        public void GivenSameValue()
        {
            //Arrange
            Feet FeetSameValueOne = new Feet(1.0);
            Feet FeetSameValueTwo = new Feet(1.0);

            //Act
            bool result = service.AreEqual(FeetSameValueOne,FeetSameValueTwo);

            //Assert
            Assert.AreEqual(true,result);
        }

        /// <summary>
        /// GIVEN two Feet objects with different values
        /// WHEN equality comparison is performed
        /// THEN result should be false.
        /// </summary>

        [TestMethod]
        public void GivenDifferentValue()
        {
            // Arrange
            Feet FeetDifferentValueOne = new Feet(1.0);
            Feet FeetDifferentValueTwo = new Feet(2.0);

            // Act
            bool result = service.AreEqual(FeetDifferentValueOne,FeetDifferentValueTwo);

            // Assert
            Assert.AreEqual(false,result);
        }

        /// <summary>
        /// GIVEN a valid Feet object and a null reference
        /// WHEN equality comparison is performed
        /// THEN result should be false.
        /// </summary>
        [TestMethod]
        public void GivenNullObject()
        {
            // Arrange
            Feet FeetNullObjectValue = new Feet(1.0);

            // Act
            bool result = service.AreEqual(FeetNullObjectValue, null);

            // Assert
            Assert.AreEqual(false, result, "Expected comparison with null to return false.");
        }

        /// <summary>
        /// GIVEN the same Feet object reference
        /// WHEN equality comparison is performed
        /// THEN result should be true (Reflexive property).
        /// </summary>
        [TestMethod]
        public void GivenSameReference()
        {
            //Arrange
            Feet FeetSameReferenceValue = new Feet(1.0);

            //Act
            bool result = service.AreEqual(FeetSameReferenceValue,FeetSameReferenceValue);

            //Assert
            Assert.AreEqual(true,result);
        }

        /// <summary>
        /// GIVEN a Feet object and an object of different type
        /// WHEN Equals() method is invoked
        /// THEN result should be false.
        /// </summary>
        [TestMethod]
        public void GivenDifferentType()
        {
            // Arrange
            Feet FeetDifferentType = new Feet(1.0);
            object obj = new object();

            // Act
            bool result = FeetDifferentType.Equals(obj);

            // Assert
            Assert.AreEqual(false,result);
        }
    }
}