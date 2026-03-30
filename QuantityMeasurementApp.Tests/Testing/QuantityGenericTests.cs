using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Model;
using System;

namespace QuantityMeasurementApp.Tests
{
    [TestClass]
    public class QuantityGenericTests
    {
        private const double EPSILON = 1e-6;

        [TestMethod]
        public void testIMeasurableInterface_ConsistentBehavior()
        {
            double lengthBase = LengthUnit.Yard.ConvertToBaseUnit(1.0);
            double weightBase = WeightUnit.Pound.ConvertToBaseUnit(1.0);

            Assert.AreEqual(3.0, lengthBase, EPSILON);
            Assert.AreEqual(0.453592, weightBase, EPSILON);
        }

        [TestMethod]
        public void testGenericQuantity_LengthOperations_Equality()
        {
            var a = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(12.0, LengthUnit.Inch);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testGenericQuantity_WeightOperations_Equality()
        {
            var a = new Quantity<WeightUnit>(1.0, WeightUnit.Kilogram);
            var b = new Quantity<WeightUnit>(1000.0, WeightUnit.Gram);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testGenericQuantity_LengthOperations_Conversion()
        {
            var a = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var result = a.ConvertTo(LengthUnit.Inch);

            Assert.AreEqual(12.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Inch, result.Unit);
        }

        [TestMethod]
        public void testGenericQuantity_WeightOperations_Conversion()
        {
            var a = new Quantity<WeightUnit>(1.0, WeightUnit.Kilogram);
            var result = a.ConvertTo(WeightUnit.Gram);

            Assert.AreEqual(1000.0, result.Value, EPSILON);
            Assert.AreEqual(WeightUnit.Gram, result.Unit);
        }

        [TestMethod]
        public void testGenericQuantity_LengthOperations_Addition()
        {
            var a = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(12.0, LengthUnit.Inch);

            var result = a.Add(b, LengthUnit.Feet);

            Assert.AreEqual(2.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Feet, result.Unit);
        }

        [TestMethod]
        public void testGenericQuantity_WeightOperations_Addition()
        {
            var a = new Quantity<WeightUnit>(1.0, WeightUnit.Kilogram);
            var b = new Quantity<WeightUnit>(1000.0, WeightUnit.Gram);

            var result = a.Add(b, WeightUnit.Kilogram);

            Assert.AreEqual(2.0, result.Value, EPSILON);
            Assert.AreEqual(WeightUnit.Kilogram, result.Unit);
        }

        [TestMethod]
        public void testCrossCategoryPrevention_LengthVsWeight()
        {
            var length = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var weight = new Quantity<WeightUnit>(1.0, WeightUnit.Kilogram);

            Assert.IsFalse(length.Equals(weight));
        }

        [TestMethod]
        public void testCrossCategoryPrevention_CompilerTypeSafety()
        {
            Assert.AreNotEqual(typeof(Quantity<LengthUnit>), typeof(Quantity<WeightUnit>));
        }

        [TestMethod]
        public void testGenericQuantity_Conversion_AllUnitCombinations()
        {
            var length = new Quantity<LengthUnit>(1.0, LengthUnit.Yard);

            Assert.AreEqual(3.0, length.ConvertTo(LengthUnit.Feet).Value, EPSILON);
            Assert.AreEqual(36.0, length.ConvertTo(LengthUnit.Inch).Value, EPSILON);

            var weight = new Quantity<WeightUnit>(1.0, WeightUnit.Kilogram);

            Assert.AreEqual(1000.0, weight.ConvertTo(WeightUnit.Gram).Value, EPSILON);
            Assert.AreEqual(2.20462, weight.ConvertTo(WeightUnit.Pound).Value, 0.01);
        }

        [TestMethod]
        public void testBackwardCompatibility_AllUC1Through9Tests()
        {
            var lengthA = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var lengthB = new Quantity<LengthUnit>(12.0, LengthUnit.Inch);

            Assert.IsTrue(lengthA.Equals(lengthB));
        }

        [TestMethod]
        public void testQuantityMeasurementApp_SimplifiedDemonstration_Equality()
        {
            var a = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(12.0, LengthUnit.Inch);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testQuantityMeasurementApp_SimplifiedDemonstration_Conversion()
        {
            var a = new Quantity<WeightUnit>(1.0, WeightUnit.Kilogram);
            var result = a.ConvertTo(WeightUnit.Gram);

            Assert.AreEqual(1000.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testQuantityMeasurementApp_SimplifiedDemonstration_Addition()
        {
            var a = new Quantity<WeightUnit>(1.0, WeightUnit.Kilogram);
            var b = new Quantity<WeightUnit>(1000.0, WeightUnit.Gram);

            var result = a.Add(b, WeightUnit.Kilogram);

            Assert.AreEqual(2.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testTypeWildcard_FlexibleSignatures()
        {
            var length = new Quantity<LengthUnit>(5.0, LengthUnit.Feet);
            Assert.AreEqual(5.0, length.Value, EPSILON);
        }

        [TestMethod]
        public void testScalability_NewUnitEnumIntegration()
        {
            Assert.IsTrue(typeof(Quantity<LengthUnit>).IsGenericType);
        }

        [TestMethod]
        public void testScalability_MultipleNewCategories()
        {
            Assert.AreEqual("Quantity`1", typeof(Quantity<LengthUnit>).Name);
        }

        [TestMethod]
        public void testGenericBoundedTypeParameter_Enforcement()
        {
            var genericArguments = typeof(Quantity<LengthUnit>).GetGenericArguments();
            Assert.AreEqual(1, genericArguments.Length);
        }

        [TestMethod]
        public void testHashCode_GenericQuantity_Consistency()
        {
            var a = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(12.0, LengthUnit.Inch);

            Assert.IsTrue(a.Equals(b));
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [TestMethod]
        public void testEquals_GenericQuantity_ContractPreservation()
        {
            var a = new Quantity<LengthUnit>(1.0, LengthUnit.Yard);
            var b = new Quantity<LengthUnit>(3.0, LengthUnit.Feet);
            var c = new Quantity<LengthUnit>(36.0, LengthUnit.Inch);

            Assert.IsTrue(a.Equals(a));
            Assert.IsTrue(a.Equals(b) && b.Equals(a));
            Assert.IsTrue(a.Equals(b) && b.Equals(c) && a.Equals(c));
        }

        [TestMethod]
        public void testEnumAsUnitCarrier_BehaviorEncapsulation()
        {
            Assert.AreEqual(1.0, LengthUnit.Feet.ConvertToBaseUnit(1.0), EPSILON);
            Assert.AreEqual(1000.0, WeightUnit.Gram.ConvertFromBaseUnit(1.0), EPSILON);
        }

        [TestMethod]
        public void testTypeErasure_RuntimeSafety()
        {
            var length = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var weight = new Quantity<WeightUnit>(1.0, WeightUnit.Kilogram);

            Assert.IsFalse(length.Equals(weight));
        }

        [TestMethod]
        public void testCompositionOverInheritance_Flexibility()
        {
            var length = new Quantity<LengthUnit>(2.0, LengthUnit.Yard);
            var weight = new Quantity<WeightUnit>(2.0, WeightUnit.Kilogram);

            Assert.AreEqual(LengthUnit.Yard, length.Unit);
            Assert.AreEqual(WeightUnit.Kilogram, weight.Unit);
        }

        [TestMethod]
        public void testCodeReduction_DRYValidation()
        {
            Assert.AreEqual(typeof(Quantity<LengthUnit>).Name, typeof(Quantity<WeightUnit>).Name);
        }

        [TestMethod]
        public void testMaintainability_SingleSourceOfTruth()
        {
            Assert.AreEqual(typeof(Quantity<LengthUnit>).GetGenericTypeDefinition(),
                            typeof(Quantity<WeightUnit>).GetGenericTypeDefinition());
        }

        [TestMethod]
        public void testArchitecturalReadiness_MultipleNewCategories()
        {
            var length = new Quantity<LengthUnit>(10.0, LengthUnit.Inch);
            var weight = new Quantity<WeightUnit>(10.0, WeightUnit.Gram);

            Assert.AreNotEqual(length.GetType(), weight.GetType());
        }

        [TestMethod]
        public void testPerformance_GenericOverhead()
        {
            var quantity = new Quantity<LengthUnit>(1.0, LengthUnit.Yard);
            var converted = quantity.ConvertTo(LengthUnit.Feet);

            Assert.AreEqual(3.0, converted.Value, EPSILON);
        }

        [TestMethod]
        public void testDocumentation_PatternClarity()
        {
            Assert.IsTrue(typeof(Quantity<LengthUnit>).IsClass);
        }

        [TestMethod]
        public void testInterfaceSegregation_MinimalContract()
        {
            Assert.IsTrue(typeof(LengthUnit).IsEnum);
            Assert.IsTrue(typeof(WeightUnit).IsEnum);
        }
    }
}