using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Tests
{
    /// <summary>
    /// Unit tests for validating value-based equality behavior of Inches class.
    /// Ensures compliance with equality contract and null/type safety.
    /// </summary>
    [TestClass]
    public class InchesEqualityTests
    {
        public InchesServices service;

        /// <summary>
        /// Initializes required dependencies before each test execution.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            service = new InchesServices();
        }

        /// <summary>
        /// GIVEN two Inches objects with identical values
        /// WHEN compared
        /// THEN result should be true.
        /// </summary>
        [TestMethod]
        public void GivenSameInchesValue()
        {
            //Arrange
            Inches SameValueInchesOne = new Inches(2.0);
            Inches SameValueInchesTwo = new Inches(2.0);

            //Act
            bool result = service.AreEqual(SameValueInchesOne,SameValueInchesTwo);

            //Assert
            Assert.AreEqual(true,result);
        }
        
         /// <summary>
        /// GIVEN two Inches objects with different values
        /// WHEN compared
        /// THEN result should be false.
        /// </summary>
        [TestMethod]
        public void GivenDifferentInchesValue()
        {
            //Arrange
            Inches DifferentValueInchesOne = new Inches(2.0);
            Inches DifferentValueInchesTwo = new Inches(4.0);

            //Act
            bool result = service.AreEqual(DifferentValueInchesOne,DifferentValueInchesTwo);

            //Assert
            Assert.AreEqual(false,result);
        }

        /// <summary>
        /// GIVEN a valid Inches object and null
        /// WHEN compared
        /// THEN result should be false.
        /// </summary>
        [TestMethod]
        public void GivenNullInches()
        {
            //Arrange 
            Inches NullValueInches = new Inches(2.0);

            //Act
            bool result = service.AreEqual(NullValueInches,null);

            //Assert
            Assert.AreEqual(false,result);
        }

        /// <summary>
        /// GIVEN the same Inches reference
        /// WHEN compared
        /// THEN result should be true (Reflexive property).
        /// </summary>
        [TestMethod]
        public void GivenSameInchesReference()
        {
            //Arrange
            Inches ReferenceInches = new Inches(2.0);

            //Act
            bool result = service.AreEqual(ReferenceInches,ReferenceInches);

            //Assert
            Assert.AreEqual(true,result);
        }

        /// <summary>
        /// GIVEN an Inches object and a different object type
        /// WHEN Equals is invoked
        /// THEN result should be false.
        /// </summary>
        [TestMethod]
        public void GivenDifferentTypeOfInches()
        {
            //Arrange
            Inches DifferentTypeInches = new Inches(2.0);
            object obj = new object();

            //Act
            bool result = DifferentTypeInches.Equals(obj);

            //Assert
            Assert.AreEqual(false,result);
        }
    }
}