using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Tests.Testing
{
    [TestClass]
    public class FeetEqualityTests
    {
        private FeetServices service;

        [TestInitialize]
        public void SetUp()
        {
            service = new FeetServices();
        }

        [TestMethod]
        public void GivenSameValue()
        {
            Feet FeetSameValueOne = new Feet(1.0);
            Feet FeetSameValueTwo = new Feet(1.0);

            bool result = service.AreEqual(FeetSameValueOne, FeetSameValueTwo);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void GivenDifferentValue()
        {
            Feet FeetDifferentValueOne = new Feet(1.0);
            Feet FeetDifferentValueTwo = new Feet(2.0);

            bool result = service.AreEqual(FeetDifferentValueOne, FeetDifferentValueTwo);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void GivenNullObject()
        {
            Feet FeetNullObjectValue = new Feet(1.0);

            bool result = service.AreEqual(FeetNullObjectValue, null);

            Assert.AreEqual(false, result, "Expected comparison with null to return false.");
        }

        [TestMethod]
        public void GivenSameReference()
        {
            Feet FeetSameReferenceValue = new Feet(1.0);

            bool result = service.AreEqual(FeetSameReferenceValue, FeetSameReferenceValue);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void GivenDifferentType()
        {
            Feet FeetDifferentType = new Feet(1.0);
            object obj = new object();

            bool result = FeetDifferentType.Equals(obj);

            Assert.AreEqual(false, result);
        }
    }
}