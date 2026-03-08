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
        private InchesServices service = null!;

        /// <summary>
        /// Initializes required dependencies before each test execution.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            service = new InchesServices();
        }

        [TestMethod]
        public void GivenSameInchesValue()
        {
            Inches SameValueInchesOne = new Inches(2.0);
            Inches SameValueInchesTwo = new Inches(2.0);

            bool result = service.AreEqual(SameValueInchesOne, SameValueInchesTwo);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenDifferentInchesValue()
        {
            Inches DifferentValueInchesOne = new Inches(2.0);
            Inches DifferentValueInchesTwo = new Inches(4.0);

            bool result = service.AreEqual(DifferentValueInchesOne, DifferentValueInchesTwo);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenNullInches()
        {
            Inches NullValueInches = new Inches(2.0);

            bool result = service.AreEqual(NullValueInches, null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenSameInchesReference()
        {
            Inches ReferenceInches = new Inches(2.0);

            bool result = service.AreEqual(ReferenceInches, ReferenceInches);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenDifferentTypeOfInches()
        {
            Inches DifferentTypeInches = new Inches(2.0);
            object obj = new object();

            bool result = DifferentTypeInches.Equals(obj);

            Assert.IsFalse(result);
        }
    }
}