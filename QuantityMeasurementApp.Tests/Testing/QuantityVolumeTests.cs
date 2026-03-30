using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Model;
using System;

namespace QuantityMeasurementApp.Tests
{
    [TestClass]
    public class QuantityVolumeTests
    {
        [TestMethod]
        public void Test_VolumeUnit_Factors()
        {
            Assert.AreEqual(1.0, VolumeUnit.Litre.ToVolumeFactor());
            Assert.AreEqual(0.001, VolumeUnit.Millilitre.ToVolumeFactor());
            Assert.AreEqual(3.78541, VolumeUnit.Gallon.ToVolumeFactor());
        }

        [TestMethod]
        public void Test_ConvertToBaseUnit()
        {
            Assert.AreEqual(5.0, VolumeUnit.Litre.ConvertToBaseUnit(5.0));
            Assert.AreEqual(1.0, VolumeUnit.Millilitre.ConvertToBaseUnit(1000.0));
            Assert.AreEqual(3.78541, VolumeUnit.Gallon.ConvertToBaseUnit(1.0));
        }

        [TestMethod]
        public void Test_ConvertFromBaseUnit()
        {
            Assert.AreEqual(2.0, VolumeUnit.Litre.ConvertFromBaseUnit(2.0));
            Assert.AreEqual(1000.0, VolumeUnit.Millilitre.ConvertFromBaseUnit(1.0));
            Assert.AreEqual(1.0, VolumeUnit.Gallon.ConvertFromBaseUnit(3.78541));
        }


        [TestMethod]
        public void Test_Equality_SameUnit()
        {
            var a = new Quantity<VolumeUnit>(2.0, VolumeUnit.Litre);
            var b = new Quantity<VolumeUnit>(2.0, VolumeUnit.Litre);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void Test_Equality_Litre_Millilitre()
        {
            var litre = new Quantity<VolumeUnit>(1.0, VolumeUnit.Litre);
            var ml = new Quantity<VolumeUnit>(1000.0, VolumeUnit.Millilitre);

            Assert.IsTrue(litre.Equals(ml));
        }

        [TestMethod]
        public void Test_Zero_Value()
        {
            var a = new Quantity<VolumeUnit>(0.0, VolumeUnit.Litre);
            var b = new Quantity<VolumeUnit>(0.0, VolumeUnit.Millilitre);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void Test_Negative_Value()
        {
            var a = new Quantity<VolumeUnit>(-1.0, VolumeUnit.Litre);
            var b = new Quantity<VolumeUnit>(-1000.0, VolumeUnit.Millilitre);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void Test_Conversion_Litre_To_ML()
        {
            var litre = new Quantity<VolumeUnit>(1.0, VolumeUnit.Litre);
            var result = litre.ConvertTo(VolumeUnit.Millilitre);

            Assert.AreEqual(1000.0, result.Value);
        }

        [TestMethod]
        public void Test_Conversion_ML_To_Litre()
        {
            var ml = new Quantity<VolumeUnit>(1000.0, VolumeUnit.Millilitre);
            var result = ml.ConvertTo(VolumeUnit.Litre);

            Assert.AreEqual(1.0, result.Value);
        }

        [TestMethod]
        public void Test_Conversion_Gallon_To_Litre()
        {
            var gallon = new Quantity<VolumeUnit>(1.0, VolumeUnit.Gallon);
            var result = gallon.ConvertTo(VolumeUnit.Litre);

            Assert.AreEqual(3.78541, result.Value);
        }


        [TestMethod]
        public void Test_Addition_SameUnit()
        {
            var a = new Quantity<VolumeUnit>(2.0, VolumeUnit.Litre);
            var b = new Quantity<VolumeUnit>(3.0, VolumeUnit.Litre);

            var result = a.Add(b, VolumeUnit.Litre);

            Assert.AreEqual(5.0, result.Value);
        }

        [TestMethod]
        public void Test_Addition_Litre_ML()
        {
            var litre = new Quantity<VolumeUnit>(1.0, VolumeUnit.Litre);
            var ml = new Quantity<VolumeUnit>(1000.0, VolumeUnit.Millilitre);

            var result = litre.Add(ml, VolumeUnit.Litre);

            Assert.AreEqual(2.0, result.Value);
        }

        [TestMethod]
        public void Test_Addition_WithZero()
        {
            var a = new Quantity<VolumeUnit>(5.0, VolumeUnit.Litre);
            var zero = new Quantity<VolumeUnit>(0.0, VolumeUnit.Millilitre);

            var result = a.Add(zero, VolumeUnit.Litre);

            Assert.AreEqual(5.0, result.Value);
        }

        [TestMethod]
        public void Test_Addition_Negative()
        {
            var a = new Quantity<VolumeUnit>(5.0, VolumeUnit.Litre);
            var b = new Quantity<VolumeUnit>(-2.0, VolumeUnit.Litre);

            var result = a.Add(b, VolumeUnit.Litre);

            Assert.AreEqual(3.0, result.Value);
        }
    }
}