using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Tests
{
    [TestClass]
    public class InchesEqualityTests
    {
        public InchesService service;

        [TestInitialize]
        public void SetUp()
        {
            service = new InchesService();
        }

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