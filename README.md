## 📅 Date: 20 February 2026

# Quantity Measurement App – UC1: Feet Measurement Equality

## Overview
This project implements the first use case (UC1) of the Quantity Measurement Application.  
The goal is to compare two numerical values measured in feet and check if they are equal using proper object-oriented design principles.

---

## Objective
To implement equality comparison between two feet measurements using:
- Proper `equals()` method override
- Accurate floating-point comparison
- Null and type safety checks

---

## Features
- Represents feet measurement as an object
- Ensures immutability using `final` fields
- Uses `Double.compare()` for accurate comparison
- Handles null and invalid type comparisons safely

---

##  Project Structure
- `QuantityMeasurementApp` – Main class
- `Feet` – Inner class representing measurement in feet
- `equals()` – Overridden method for value comparison

---

## Concepts Used
- Object-Oriented Programming
- Encapsulation & Immutability
- Overriding `equals()` method
- Floating-point precision handling
- Null safety and type checking

---

## Test Scenarios
- ✔️ Same values should be equal  
- ✔️ Different values should not be equal  
- ✔️ Comparison with null should return false  
- ✔️ Same object reference should return true  

---

## Example
**Input:**  
1.0 ft and 1.0 ft  

**Output:**  
Equal (true)

---

## Conclusion
This use case builds a strong foundation for the Quantity Measurement Application by ensuring correct and reliable comparison of measurement values.

---

## 📅 Date: 23 February 2026

# Quantity Measurement App – UC2: Feet and Inches Equality

## Overview
This use case extends UC1 by adding support for **Inches measurement equality** along with Feet.  
Both Feet and Inches are treated as separate measurement types and are not directly compared with each other.

---

## Objective
To implement equality comparison for:
- Feet measurements
- Inches measurements  

While ensuring:
- Accurate floating-point comparison
- Proper object-oriented design
- Complete test coverage

---

## Features
- Separate classes for Feet and Inches
- Equality comparison using overridden `equals()` method
- Uses `Double.compare()` for precision
- Null-safe and type-safe implementation
- Separate methods for Feet and Inches comparison

---

## Project Structure
- `QuantityMeasurementApp`
  - Static methods for equality checks
- `Feet` class
- `Inches` class

---

## Working Flow
1. The main method calls:
   - Feet equality method
   - Inches equality method  
2. Values are validated to ensure they are numeric  
3. Objects of Feet/Inches are created  
4. `equals()` method is invoked  
5. Result (`true` / `false`) is returned  

---

## Concepts Used
- Object-Oriented Programming (OOP)
- Encapsulation & Immutability
- Method Overriding (`equals()`)
- Floating-point comparison using `Double.compare()`
- Null handling and type safety

---

## Test Scenarios
- ✔️ Same values should return true  
- ✔️ Different values should return false  
- ✔️ Null comparison should return false  
- ✔️ Same reference should return true  
- ✔️ Non-numeric input handling  

---

## Example

**Input:**  
1.0 inch and 1.0 inch  

**Output:**  
Equal (true)  

**Input:**  
1.0 ft and 1.0 ft  

**Output:**  
Equal (true)

---

## Limitation (Current Design)
The current implementation uses **separate Feet and Inches classes**, which leads to code duplication:

- Same constructor logic  
- Same `equals()` implementation  
- Same structure  

This violates the **DRY (Don't Repeat Yourself)** principle.

---

## Suggested Improvement
To improve the design:
- Use a **generic `Quantity` class**
- Add a **unit type parameter (Feet/Inches)**
- Centralize equality logic  

This will:
- Reduce duplication  
- Improve maintainability  
- Make the system scalable for future units  

---

## Conclusion
UC2 enhances the application by supporting multiple measurement types while maintaining robust equality checks.  
It also highlights the need for better design patterns to avoid redundancy in future use cases.

---

## 📅 Date: 26 February 2026

# Quantity Measurement App – UC3: Generic Quantity Class (DRY Principle)

## Overview
UC3 refactors the existing implementation of Feet and Inches into a **single generic Quantity class**.  
This eliminates code duplication and follows the **DRY (Don't Repeat Yourself)** principle while preserving all functionality from UC1 and UC2.

---

## Objective
To:
- Remove duplication from Feet and Inches classes  
- Introduce a **generic Quantity class**  
- Support **cross-unit comparison** (e.g., Feet ↔ Inches)  
- Improve scalability and maintainability  

---

## Features
- Generic `Quantity` class for all length measurements  
- `LengthUnit` enum for type-safe unit handling  
- Automatic unit conversion to a base unit (feet)  
- Cross-unit equality comparison  
- Clean, maintainable, and scalable design  

---

## Project Structure
- `QuantityMeasurementApp` – Main application  
- `Quantity` – Generic class representing value + unit  
- `LengthUnit` – Enum defining units and conversion factors  

---

## Working Flow
1. User provides value and unit (Feet / Inches)  
2. Input values are validated  
3. Units are validated using enum  
4. Values are converted to a **base unit (feet)**  
5. Converted values are compared using `equals()`  
6. Result (`true` / `false`) is returned  

---

## Example

**Input:**  
Quantity(1.0, "feet") and Quantity(12.0, "inches")  

**Output:**  
Equal (true)  

**Input:**  
Quantity(1.0, "inch") and Quantity(1.0, "inch")  

**Output:**  
Equal (true)

---

## Concepts Used

### DRY Principle
- Eliminates duplicate code from Feet & Inches classes  
- Centralizes logic in one class  

### Polymorphism
- Single class handles multiple unit types  

### Enum Usage
- `LengthUnit` ensures type-safe unit handling  
- Avoids hardcoded values  

### Abstraction
- Conversion logic hidden from user  

### Encapsulation
- Value + Unit bundled in one class  

### Equality Logic
- Cross-unit comparison supported  
- Uses base unit conversion for accuracy  

### Scalability
- Easy to add new units (e.g., cm, meter)  

---

## Key Design Idea

All values are converted into a **base unit (feet)** before comparison:

## Conclusion

UC3 significantly improves the design of the Quantity Measurement Application by introducing a **generic Quantity class** that eliminates code duplication present in UC1 and UC2.

By applying the **DRY principle**, the system becomes:
- More maintainable  
- More scalable for future units (cm, meter, etc.)  
- Less error-prone due to centralized logic  

Additionally, UC3 enables **cross-unit comparison** (e.g., 1 foot = 12 inches), which was not possible earlier.

Overall, this refactoring results in a cleaner, more flexible, and industry-standard design approach.

---

## 📅 Date: 27 February 2026
# Quantity Measurement App – UC4: Extended Unit Support

## Overview
UC4 extends the generic design from UC3 by adding **Yards** and **Centimeters** as new length units.  
The system now supports seamless comparison across **Feet, Inches, Yards, and Centimeters** using a scalable and DRY-compliant design.

---

## Objective
To:
- Add support for new units (Yards, Centimeters)
- Enable cross-unit comparisons across all units
- Maintain DRY principle (no code duplication)
- Ensure backward compatibility with UC1, UC2, and UC3

---

## Features
- Supports 4 units:
  - Feet
  - Inches
  - Yards
  - Centimeters  
- Cross-unit equality comparison (e.g., yard ↔ feet ↔ inches ↔ cm)
- Centralized conversion logic in enum
- No changes required in Quantity class (scalable design)

---

## Project Structure
- `Quantity` – Generic class (unchanged from UC3)
- `LengthUnit` – Extended enum with new units
- `QuantityMeasurementApp` – Demo / execution

---

## Working Flow
1. User inputs value + unit  
2. Input is validated  
3. Unit is validated via enum  
4. Values are converted to a **common base unit (feet or inches)**  
5. Converted values are compared using `equals()`  
6. Result is returned  

---

## Conversion Factors

| Unit | Conversion |
|------|-----------|
| 1 Foot | Base Unit |
| 1 Inch | 1/12 Feet |
| 1 Yard | 3 Feet |
| 1 cm | 0.393701 Inches |

---

## Example

**Input:**  
Quantity(1.0, YARDS) and Quantity(3.0, FEET)  

**Output:**  
Equal (true)  

**Input:**  
Quantity(1.0, YARDS) and Quantity(36.0, INCHES)  

**Output:**  
Equal (true)  

**Input:**  
Quantity(1.0, CENTIMETERS) and Quantity(0.393701, INCHES)  

**Output:**  
Equal (true)

---

## Concepts Used

### Scalability
- Adding new units requires only enum update  
- No changes in core logic  

### DRY Principle
- No duplication despite adding new units  

### Enum Extensibility
- Units are managed in a type-safe way  

### Conversion Logic
- Centralized and consistent  

### Mathematical Accuracy
- Precise conversion factors ensure correct comparison  

### Backward Compatibility
- UC1, UC2, UC3 functionality remains unchanged  

---

## Test Scenarios

### Yard Equality
- Quantity(1, YARDS) == Quantity(1, YARDS)

### Yard to Feet
- Quantity(1, YARDS) == Quantity(3, FEET)

### Yard to Inches
- Quantity(1, YARDS) == Quantity(36, INCHES)

### Centimeter Equality
- Quantity(2, CM) == Quantity(2, CM)

### CM to Inches
- Quantity(1, CM) == Quantity(0.393701, INCHES)

### Multi-Unit Equality
- Quantity(1, YARD) == Quantity(3, FEET) == Quantity(36, INCHES)

### Invalid Unit Handling
- Unsupported unit should throw exception  

### Null Comparison
- Comparing with null returns false  

---

## Conclusion

UC4 demonstrates the true power of a well-designed generic system.  
By simply extending the `LengthUnit` enum, new units like **Yards and Centimeters** are seamlessly integrated without modifying the core logic.

This proves:
- Strong adherence to the **DRY principle**
- High **scalability**
- Clean and maintainable architecture  

The system is now robust enough to support additional units in the future with minimal effort.

---

## 📅 Date: 09 March 2026
# Quantity Measurement App – UC5: Unit-to-Unit Conversion

## Overview
UC5 extends UC4 by introducing **explicit unit-to-unit conversion functionality**.  
Now, instead of only checking equality, the system allows converting a value from one unit to another (e.g., Feet → Inches, Yards → Feet, Centimeters → Inches).

---

## Objective
To:
- Provide a **conversion API** for length units  
- Support conversion across all units (Feet, Inches, Yards, Centimeters)  
- Maintain precision and mathematical correctness  
- Ensure robust validation and error handling  

---

## Features
- Static conversion method: `convert(value, sourceUnit, targetUnit)`  
- Instance-based conversion support  
- Centralized conversion logic using enum  
- Supports all combinations of unit conversions  
- Handles edge cases (null, NaN, infinity)  

---

## Project Structure
- `Quantity` – Generic class (from UC3/UC4)  
- `LengthUnit` – Enum with conversion factors  
- `QuantityMeasurementApp` – Demonstration methods  

---

## Working Flow
1. User provides:
   - Value  
   - Source Unit  
   - Target Unit  
2. Input validation is performed  
3. Value is converted to **base unit (feet)**  
4. Converted from base unit to target unit  
5. Final result is returned  

---

## Conversion Formula
result = value × (sourceUnit.factor / targetUnit.factor)

---

## Example

**Input:**  
convert(1.0, FEET, INCHES)  

**Output:**  
12.0  

**Input:**  
convert(3.0, YARDS, FEET)  

**Output:**  
9.0  

**Input:**  
convert(36.0, INCHES, YARDS)  

**Output:**  
1.0  

**Input:**  
convert(1.0, CENTIMETERS, INCHES)  

**Output:**  
0.393701  

---

## Concepts Used

### Enum with Conversion Factors
- Centralized conversion logic  
- Easy to extend  

### Immutability
- Enum constants are fixed and thread-safe  

### Value Object Design
- Quantity objects are immutable  

### Method Overloading
- Multiple methods for flexibility  

### Encapsulation
- Conversion logic hidden inside class  

### Exception Handling
- Invalid inputs handled properly  

---

## Test Scenarios

### Basic Conversion
- Feet ↔ Inches  
- Yards ↔ Feet  

### Cross-Unit Conversion
- Yards ↔ Inches  
- CM ↔ Feet  

### Round-Trip Accuracy
- A → B → A returns original value  

### Zero Value
- convert(0.0, FEET, INCHES) = 0.0  

### Negative Values
- convert(-1.0, FEET, INCHES) = -12.0  

### Same Unit
- convert(5.0, FEET, FEET) = 5.0  

### Precision Handling
- Floating-point tolerance (epsilon) used  

### Invalid Input
- Null unit → Exception  
- NaN / Infinity → Exception  

---

## Sample Test Cases

- `testConversion_FeetToInches()`  
- `testConversion_InchesToFeet()`  
- `testConversion_YardsToInches()`  
- `testConversion_CmToInches()`  
- `testConversion_RoundTrip()`  
- `testConversion_ZeroValue()`  
- `testConversion_NegativeValue()`  
- `testConversion_InvalidUnit()`  
- `testConversion_NaNOrInfinite()`  



## Conclusion

UC5 enhances the system by introducing a **powerful and flexible conversion API**.  
The application now supports both **comparison and conversion**, making it more practical and real-world usable.

With centralized logic, strong validation, and scalable design, the system is now:
- More robust  
- More reusable  
- Ready for advanced operations in future use cases  

---

## 📅 Date: 10 March 2026
# Quantity Measurement App – UC6: Addition of Length Units

## Overview
UC6 extends UC5 by introducing **addition operations** between length measurements.  
It allows adding two quantities of possibly different units (Feet, Inches, Yards, Centimeters) and returns the result in the **unit of the first operand**.

---

## Objective
To:
- Enable addition of two length measurements  
- Support cross-unit arithmetic (e.g., Feet + Inches)  
- Maintain immutability and precision  
- Reuse conversion logic from UC5  

---

## Features
- Add two `Quantity` objects  
- Cross-unit addition supported  
- Result returned in the unit of the first operand  
- Uses base unit normalization (feet)  
- Immutable design (returns new object)  

---

## Project Structure
- `Quantity` – Generic class with add() method  
- `LengthUnit` – Enum with conversion factors  
- `QuantityMeasurementApp` – Demo methods  

---

## Working Flow
1. Two `Quantity` objects are provided  
2. Input validation is performed  
3. Both values are converted to **base unit (feet)**  
4. Values are added  
5. Result is converted back to **unit of first operand**  
6. New `Quantity` object is returned  

---

## Addition Logic
result = (value1_in_base + value2_in_base)

---

## Convert result back to first unit:
final = result / firstUnit.factor

---

## Example

**Input:**  
add(Quantity(1.0, FEET), Quantity(2.0, FEET))  

**Output:**  
Quantity(3.0, FEET)  

**Input:**  
add(Quantity(1.0, FEET), Quantity(12.0, INCHES))  

**Output:**  
Quantity(2.0, FEET)  

**Input:**  
add(Quantity(12.0, INCHES), Quantity(1.0, FEET))  

**Output:**  
Quantity(24.0, INCHES)  

**Input:**  
add(Quantity(1.0, YARDS), Quantity(3.0, FEET))  

**Output:**  
Quantity(2.0, YARDS)  

---

## Concepts Used

### Arithmetic on Value Objects
- Domain-specific logic inside class  

### Immutability
- Original objects remain unchanged  
- New object returned  

### Reusability
- Uses UC5 conversion logic  

### Base Unit Normalization
- Simplifies cross-unit operations  

### Precision Handling
- Floating-point tolerance maintained  

### Type Safety
- Only valid units allowed  

### Mathematical Properties
- Addition is commutative  

---

## Test Scenarios

### Same Unit Addition
- 1 ft + 2 ft = 3 ft  

### Cross Unit Addition
- 1 ft + 12 in = 2 ft  

### Reverse Unit Addition
- 12 in + 1 ft = 24 in  

### Yard Conversion
- 1 yd + 3 ft = 2 yd  

### CM Conversion
- 2.54 cm + 1 in ≈ 5.08 cm  

### Identity (Zero)
- 5 ft + 0 in = 5 ft  

### Negative Values
- 5 ft + (-2 ft) = 3 ft  

### Commutativity
- A + B = B + A  

---

## Sample Test Cases

- `testAddition_SameUnit_FeetPlusFeet()`  
- `testAddition_SameUnit_InchPlusInch()`  
- `testAddition_CrossUnit_FeetPlusInches()`  
- `testAddition_CrossUnit_InchPlusFeet()`  
- `testAddition_CrossUnit_YardPlusFeet()`  
- `testAddition_CrossUnit_CmPlusInch()`  
- `testAddition_Commutativity()`  
- `testAddition_WithZero()`  
- `testAddition_NegativeValues()`  
- `testAddition_NullOperand()`  

---

## Conclusion

UC6 enhances the system by introducing **arithmetic operations on length measurements**.  
By leveraging base unit conversion and immutable design, the application now supports **accurate and scalable addition across multiple units**.

This makes the system:
- More powerful  
- More reusable  
- Closer to real-world measurement applications  

---

## 📅 Date: 11 March 2026
# Quantity Measurement App – UC7: Addition with Target Unit Specification

## Overview
UC7 extends UC6 by allowing the caller to **explicitly specify the target unit** for the result of an addition operation.  
Instead of returning the result in the unit of the first operand, the result can now be expressed in **any supported unit** (Feet, Inches, Yards, Centimeters).

---

## Objective
To:
- Add flexibility in result representation  
- Allow explicit target unit specification  
- Maintain immutability and precision  
- Reuse existing conversion logic  

---

## Features
- Add two `Quantity` objects with a specified target unit  
- Result returned in **user-defined unit**  
- Supports all unit combinations  
- Reuses UC5 conversion logic  
- Maintains backward compatibility with UC6  

---

## Project Structure
- `Quantity` – Generic class with overloaded `add()` method  
- `LengthUnit` – Enum with conversion factors  
- `QuantityMeasurementApp` – Demo methods  

---

##  Working Flow
1. Two `Quantity` objects + target unit provided  
2. Input validation is performed  
3. Both values are converted to **base unit (feet)**  
4. Values are added  
5. Result is converted to **specified target unit**  
6. New `Quantity` object is returned  

---

## ⚙️ Addition Logic
baseSum = value1_in_base + value2_in_base
final = baseSum / targetUnit.factor


---

## Example

**Input:**  
add(Quantity(1.0, FEET), Quantity(12.0, INCHES), FEET)  

**Output:**  
Quantity(2.0, FEET)  

**Input:**  
add(Quantity(1.0, FEET), Quantity(12.0, INCHES), INCHES)  

**Output:**  
Quantity(24.0, INCHES)  

**Input:**  
add(Quantity(1.0, FEET), Quantity(12.0, INCHES), YARDS)  

**Output:**  
Quantity(~0.667, YARDS)  

**Input:**  
add(Quantity(36.0, INCHES), Quantity(1.0, YARDS), FEET)  

**Output:**  
Quantity(6.0, FEET)  

---

## Concepts Used

### Method Overloading
- `add(a, b)` → UC6 behavior  
- `add(a, b, targetUnit)` → UC7 behavior  

### Explicit Parameter Control
- Caller decides result unit  

### DRY Principle
- Shared logic reused internally  

### Immutability
- Returns new object, original unchanged  

### Conversion Reusability
- Uses UC5 base conversion  

### Functional Design
- Pure function behavior (same input → same output)  

---

## Test Scenarios

### Target Unit = First Operand
- Result in FEET  

### Target Unit = Second Operand
- Result in INCHES  

### Target Unit = Different Unit
- Result in YARDS / CM  

### Commutativity
- A + B = B + A (same target unit)  

### Zero Handling
- 5 ft + 0 in → correct result  

### Negative Values
- Handles subtraction via addition  

### Large/Small Values
- Precision maintained  

### Invalid Input
- Null target unit → exception  

---

## Sample Test Cases

- `testAddition_TargetUnit_Feet()`  
- `testAddition_TargetUnit_Inches()`  
- `testAddition_TargetUnit_Yards()`  
- `testAddition_TargetUnit_Centimeters()`  
- `testAddition_Commutativity_WithTargetUnit()`  
- `testAddition_WithZero_TargetUnit()`  
- `testAddition_NegativeValues_TargetUnit()`  
- `testAddition_NullTargetUnit()`  
- `testAddition_LargeScaleConversion()`  

---

## Conclusion

UC7 enhances the system by introducing **explicit control over the result unit**, making the API more flexible and user-friendly.

By allowing the caller to choose the output unit, the system becomes:
- More adaptable to real-world scenarios  
- More expressive and clear in intent  
- More powerful for complex unit operations  

This marks a significant step toward building a **complete and flexible measurement system**.

---
## 📅 Date: 13 March 2026
# Quantity Measurement App – UC8: Refactoring Unit Enum to Standalone with Conversion Responsibility
## Overview
UC8 refactors the design from UC1–UC7 to overcome the disadvantage of embedding the `LengthUnit` enum within the `QuantityLength` class.  
The `LengthUnit` enum is extracted into a **standalone, top-level class** and assigned full responsibility for managing conversions to and from the base unit.

---
## Objective
To:
- Extract `LengthUnit` into a standalone top-level enum class  
- Assign conversion responsibility to `LengthUnit`  
- Simplify `QuantityLength` by delegating all conversion logic  
- Eliminate circular dependency risk across measurement categories  
- Maintain full backward compatibility with UC1–UC7  

---
## Features
- `LengthUnit` as a standalone enum with `convertToBaseUnit()` and `convertFromBaseUnit()` methods  
- `QuantityLength` simplified to focus solely on comparison and arithmetic  
- All unit combinations supported: Feet, Inches, Yards, Centimeters  
- Backward compatible — no client code changes required  
- Scalable pattern for future measurement categories (Weight, Volume, Temperature)  

---
## Project Structure
- `LengthUnit` – Standalone enum with conversion factors and conversion methods  
- `QuantityLength` – Simplified class focused on comparison and arithmetic  
- `QuantityMeasurementApp` – Demo methods using refactored design  

---
## Working Flow
1. `LengthUnit` is extracted to a top-level standalone enum  
2. Conversion factors defined as constants in `LengthUnit`  
3. `convertToBaseUnit(value)` converts a value in this unit → feet  
4. `convertFromBaseUnit(baseValue)` converts feet → this unit  
5. `QuantityLength` delegates all conversion calls to `LengthUnit` methods  
6. All existing operations (equality, conversion, addition) work identically  

---
## Conversion Logic

| Unit         | Conversion Factor (to feet) |
|--------------|-----------------------------|
| FEET         | 1.0                         |
| INCHES       | 1/12 ≈ 0.0833               |
| YARDS        | 3.0                         |
| CENTIMETERS  | 1/30.48 ≈ 0.0328            |

---
## Example

**Input:**  
`LengthUnit.INCHES.convertToBaseUnit(12.0)`  
**Output:**  
`1.0` (feet)

**Input:**  
`LengthUnit.INCHES.convertFromBaseUnit(1.0)`  
**Output:**  
`12.0` (inches)

**Input:**  
`Quantity(1.0, FEET).convertTo(INCHES)`  
**Output:**  
`Quantity(12.0, INCHES)`

**Input:**  
`Quantity(1.0, FEET).add(Quantity(12.0, INCHES), FEET)`  
**Output:**  
`Quantity(2.0, FEET)`

**Input:**  
`Quantity(36.0, INCHES).equals(Quantity(1.0, YARDS))`  
**Output:**  
`true`

**Input:**  
`Quantity(2.54, CENTIMETERS).convertTo(INCHES)`  
**Output:**  
`Quantity(~1.0, INCHES)`

---
## Concepts Used
### Single Responsibility Principle (SRP)
- `LengthUnit` handles conversions  
- `QuantityLength` handles comparison and arithmetic  

### Separation of Concerns
- Unit-specific logic isolated in `LengthUnit`  
- Domain logic isolated in `QuantityLength`  

### Delegation Pattern
- `QuantityLength` delegates via `unit.convertToBaseUnit()` and `unit.convertFromBaseUnit()`  

### Circular Dependency Elimination
- Extracting `LengthUnit` prevents cross-category circular references  

### Encapsulation
- Conversion formulas hidden within `LengthUnit` — external classes use public API only  

### Scalability Pattern
- Template established for `WeightUnit`, `VolumeUnit`, `TemperatureUnit`  

### Java Enum Capabilities
- Enums encapsulate data (conversion factors) and behavior (conversion methods)  
- Inherently immutable and thread-safe  

### Refactoring Best Practices
- Functionality preserved while improving internal structure  
- Backward compatibility maintained throughout  

---
## Refactoring Steps

### Step 1 – Extract LengthUnit as Standalone Enum
- Move `LengthUnit` from inside `QuantityLength` to top-level class  
- Retain all constants: `FEET`, `INCHES`, `YARDS`, `CENTIMETERS`  
- Add `convertToBaseUnit(double value)` method  
- Add `convertFromBaseUnit(double baseValue)` method  

### Step 2 – Refactor QuantityLength
- Remove all internal conversion logic  
- Delegate all conversion operations to `LengthUnit` methods  

### Step 3 – Update All References
- Ensure all imports reference standalone `LengthUnit`  
- Remove any assumptions of `LengthUnit` being nested  

### Step 4 – Maintain Backward Compatibility
- Public API of `QuantityLength` remains unchanged  
- All existing method signatures and behaviors preserved  

### Step 5 – Verify All Test Cases
- Run all UC1–UC7 test cases without modification  
- Confirm no regressions in equality, conversion, or addition  

---
## Test Scenarios
### LengthUnit Enum Constants
- Verify `FEET`, `INCHES`, `YARDS`, `CENTIMETERS` accessible as standalone  

### convertToBaseUnit
- Feet → Feet (no change)  
- Inches → Feet  
- Yards → Feet  
- Centimeters → Feet  

### convertFromBaseUnit
- Feet → Feet (no change)  
- Feet → Inches  
- Feet → Yards  
- Feet → Centimeters  

### Refactored QuantityLength
- Equality using delegated conversion  
- `convertTo()` using unit methods  
- `add()` with and without target unit  

### Invalid Input
- Null unit → exception  
- `Double.NaN` value → exception  

### Backward Compatibility
- All UC1–UC7 test cases pass unchanged  

### Round-Trip Conversion
- `convert(convert(value, A→B), B→A) ≈ value` within epsilon  

---
## Sample Test Cases
- `testLengthUnitEnum_FeetConstant()`  
- `testLengthUnitEnum_InchesConstant()`  
- `testLengthUnitEnum_YardsConstant()`  
- `testLengthUnitEnum_CentimetersConstant()`  
- `testConvertToBaseUnit_FeetToFeet()`  
- `testConvertToBaseUnit_InchesToFeet()`  
- `testConvertToBaseUnit_YardsToFeet()`  
- `testConvertToBaseUnit_CentimetersToFeet()`  
- `testConvertFromBaseUnit_FeetToFeet()`  
- `testConvertFromBaseUnit_FeetToInches()`  
- `testConvertFromBaseUnit_FeetToYards()`  
- `testConvertFromBaseUnit_FeetToCentimeters()`  
- `testQuantityLengthRefactored_Equality()`  
- `testQuantityLengthRefactored_ConvertTo()`  
- `testQuantityLengthRefactored_Add()`  
- `testQuantityLengthRefactored_AddWithTargetUnit()`  
- `testQuantityLengthRefactored_NullUnit()`  
- `testQuantityLengthRefactored_InvalidValue()`  
- `testBackwardCompatibility_UC1EqualityTests()`  
- `testBackwardCompatibility_UC5ConversionTests()`  
- `testBackwardCompatibility_UC6AdditionTests()`  
- `testBackwardCompatibility_UC7AdditionWithTargetUnitTests()`  
- `testRoundTripConversion_RefactoredDesign()`  
- `testUnitImmutability()`  
- `testArchitecturalScalability_MultipleCategories()`  

---
## Conclusion
UC8 enhances the system by introducing a **clean architectural separation** between unit conversion logic and quantity domain logic.  
By extracting `LengthUnit` as a standalone enum with full conversion responsibility, the system becomes:
- More cohesive — each class has a single, well-defined role  
- More scalable — new measurement categories plug in without refactoring existing code  
- More maintainable — conversion logic changes are isolated to `LengthUnit`  
- Free of circular dependencies across measurement categories  

This marks a foundational step toward building a **complete, enterprise-grade measurement system** supporting multiple unit categories with clean, decoupled architecture.

---

## 📅 Date: 16 March 2026
# Quantity Measurement App – UC9: Weight Measurement Equality, Conversion, and Addition (Kilogram, Gram, Pound)
## Overview
UC9 extends the Quantity Measurement Application to support **weight measurements** alongside length measurements.  
It introduces a new measurement category — weight — that operates **independently from length**, supporting equality comparison, unit conversion, and addition across kilograms, grams, and pounds.

---
## Objective
To:
- Introduce `WeightUnit` enum as a standalone class with conversion responsibility  
- Implement `QuantityWeight` class mirroring the `QuantityLength` design  
- Support equality, conversion, and addition for weight measurements  
- Enforce category type safety (weight ≠ length)  
- Validate that the UC1–UC8 design pattern scales seamlessly to new measurement categories  

---
## Features
- Equality comparison between weight measurements across all unit combinations  
- Unit conversion between Kilogram, Gram, and Pound  
- Addition with implicit target unit (first operand's unit) and explicit target unit  
- Category type safety — weight and length measurements are non-interoperable  
- Full backward compatibility with UC1–UC8 length functionality  
- Immutable `QuantityWeight` objects (value and unit are final)  

---
## Project Structure
- `WeightUnit` – Standalone enum with conversion factors and conversion methods  
- `QuantityWeight` – Class focused on weight comparison, conversion, and arithmetic  
- `QuantityMeasurementApp` – Demo methods extended for weight operations  

---
## Working Flow
1. Two `QuantityWeight` objects with their respective units are provided  
2. Input validation is performed (non-null unit, finite value)  
3. Both values are converted to the **base unit (kilogram)** using `WeightUnit` conversion methods  
4. Equality comparison, conversion, or addition is performed  
5. Result is converted to the **target unit** (implicit or explicit)  
6. A new immutable `QuantityWeight` object is returned  

---
## Conversion Logic


| Unit       | Conversion Factor (to kg) |
|------------|---------------------------|
| KILOGRAM   | 1.0                       |
| GRAM       | 0.001                     |
| POUND      | 0.453592                  |

---
## Example

**Equality:**  
`Quantity(1.0, KILOGRAM).equals(Quantity(1000.0, GRAM))`  
→ `true`

`Quantity(1.0, KILOGRAM).equals(Quantity(~2.20462, POUND))`  
→ `true` (within epsilon)

`Quantity(500.0, GRAM).equals(Quantity(0.5, KILOGRAM))`  
→ `true`

**Conversion:**  
`Quantity(1.0, KILOGRAM).convertTo(GRAM)`  
→ `Quantity(1000.0, GRAM)`

`Quantity(2.0, POUND).convertTo(KILOGRAM)`  
→ `Quantity(~0.907184, KILOGRAM)`

`Quantity(500.0, GRAM).convertTo(POUND)`  
→ `Quantity(~1.10231, POUND)`

**Addition (Implicit Target Unit):**  
`Quantity(1.0, KILOGRAM).add(Quantity(1000.0, GRAM))`  
→ `Quantity(2.0, KILOGRAM)`

**Addition (Explicit Target Unit):**  
`Quantity(1.0, KILOGRAM).add(Quantity(1000.0, GRAM), GRAM)`  
→ `Quantity(2000.0, GRAM)`

`Quantity(2.0, KILOGRAM).add(Quantity(4.0, POUND), KILOGRAM)`  
→ `Quantity(~3.82, KILOGRAM)`

**Category Incompatibility:**  
`Quantity(1.0, KILOGRAM).equals(Quantity(1.0, FOOT))`  
→ `false`

---
## Concepts Used
### Multiple Measurement Categories
- Weight operates independently from length  
- Each category has its own unit enum and quantity class  
- Categories are type-safe and non-interoperable  

### Scalable Generic Design Pattern
- `WeightUnit` and `QuantityWeight` mirror `LengthUnit` and `QuantityLength`  
- Pattern is replicable for temperature, volume, time, and other categories  

### Category Type Safety
- `equals()` checks `getClass()` to reject cross-category comparisons  
- Compile-time and runtime safety prevent logical errors  

### Base Unit Normalization
- Kilogram is the base unit for weight (mirrors feet for length)  
- Centralized normalization through `WeightUnit` methods  

### Enum-Based Responsibility Assignment
- `WeightUnit` encapsulates conversion logic (following UC8 principles)  
- `QuantityWeight` focuses on comparison and arithmetic only  

### Immutability
- `QuantityWeight` objects are immutable — operations return new instances  
- Thread-safe across concurrent callers  

### Method Overloading
- `add(a, b)` → result in first operand's unit (UC6-equivalent)  
- `add(a, b, targetUnit)` → result in specified unit (UC7-equivalent)  

### Equals and HashCode Contract
- Both `equals()` and `hashCode()` are consistently overridden  
- Enables use in sets, maps, and hash-based collections  

### Floating-Point Precision
- Epsilon-based tolerance accommodates floating-point rounding  
- Consistent rounding (two decimal places) ensures predictability  

---
## Implementation Steps

### Step 1 – Create WeightUnit Standalone Enum
- Define constants: `KILOGRAM`, `GRAM`, `POUND`  
- Assign conversion factors relative to kilogram  
- Implement `getConversionFactor()`, `convertToBaseUnit()`, `convertFromBaseUnit()`  

### Step 2 – Implement QuantityWeight Class
- Mirror `QuantityLength` design with `WeightUnit` enum  
- Validate unit (not null) and value (finite number) in constructor  
- Implement `equals()`, `convertTo()`, overloaded `add()`, and `toString()`  

### Step 3 – Enforce Category Type Safety
- `equals()` returns `false` for cross-category comparisons  
- Document that weight and length are incompatible categories  

### Step 4 – Ensure Conversion Accuracy
- Verify: `1 kg = 1000 g`, `1 lb ≈ 0.453592 kg`, `1 kg ≈ 2.20462 lb`  
- Test round-trip conversions within epsilon (`1e-6`)  

### Step 5 – Verify Test Coverage
- Equality: same unit, cross-unit, incompatible category, null, edge cases  
- Conversion: all unit pairs, zero, negative, round-trip  
- Addition: same unit, cross-unit, explicit target unit, commutativity, edge cases  

---
## Test Scenarios
### Equality Tests
- Kilogram-to-kilogram same value → `true`  
- Kilogram-to-gram equivalent value → `true`  
- Kilogram-to-pound equivalent value → `true` (within epsilon)  
- Gram-to-pound equivalent value → `true`  
- Different values in same unit → `false`  
- Weight vs. length comparison → `false`  
- Null comparison → `false`  
- Same reference → `true`  
- Zero values across units → `true`  
- Negative values across units → `true`  

### Conversion Tests
- Kilogram → Gram, Gram → Kilogram  
- Pound → Kilogram, Kilogram → Pound  
- Gram → Pound, Pound → Gram  
- Same unit conversion (no change)  
- Zero and negative value conversions  
- Round-trip conversion within epsilon  

### Addition Tests
- Same unit addition (kg + kg)  
- Cross-unit addition (kg + g, lb + kg)  
- Explicit target unit (result in any unit)  
- Commutativity with target unit  
- Addition with zero  
- Addition with negative values  
- Addition with large magnitude values  

### Edge Cases
- Null unit → `IllegalArgumentException`  
- `Double.NaN` value → `IllegalArgumentException`  
- Infinite value → `IllegalArgumentException`  

---
## Sample Test Cases
- `testEquality_KilogramToKilogram_SameValue()`  
- `testEquality_KilogramToKilogram_DifferentValue()`  
- `testEquality_KilogramToGram_EquivalentValue()`  
- `testEquality_GramToKilogram_EquivalentValue()`  
- `testEquality_KilogramToPound_EquivalentValue()`  
- `testEquality_GramToPound_EquivalentValue()`  
- `testEquality_WeightVsLength_Incompatible()`  
- `testEquality_NullComparison()`  
- `testEquality_SameReference()`  
- `testEquality_NullUnit()`  
- `testEquality_TransitiveProperty()`  
- `testEquality_ZeroValue()`  
- `testEquality_NegativeWeight()`  
- `testEquality_LargeWeightValue()`  
- `testEquality_SmallWeightValue()`  
- `testConversion_KilogramToGram()`  
- `testConversion_GramToKilogram()`  
- `testConversion_PoundToKilogram()`  
- `testConversion_KilogramToPound()`  
- `testConversion_GramToPound()`  
- `testConversion_SameUnit()`  
- `testConversion_ZeroValue()`  
- `testConversion_NegativeValue()`  
- `testConversion_RoundTrip()`  
- `testAddition_SameUnit_KilogramPlusKilogram()`  
- `testAddition_CrossUnit_KilogramPlusGram()`  
- `testAddition_CrossUnit_PoundPlusKilogram()`  
- `testAddition_ExplicitTargetUnit_Kilogram()`  
- `testAddition_ExplicitTargetUnit_Gram()`  
- `testAddition_Commutativity()`  
- `testAddition_WithZero()`  
- `testAddition_NegativeValues()`  
- `testAddition_LargeValues()`  

---
## Conclusion
UC9 validates that the **generic design patterns established in UC1–UC8 scale seamlessly** to new measurement categories.  
By introducing weight measurements with no changes to existing length classes, the system demonstrates:
- Clean **category independence** — weight and length coexist without interference  
- True **architectural scalability** — adding a new category requires only a new enum and quantity class  
- Consistent **API design** — weight operations mirror length operations exactly  
- Robust **type safety** — cross-category comparisons are rejected at runtime  

This marks a significant step toward a **complete, enterprise-grade measurement system** supporting multiple unit categories with clean, decoupled, and maintainable architecture.

---
## 📅 Date: 18 March 2026
# Quantity Measurement App – UC10: Generic Quantity Class with Unit Interface for Multi-Category Support
## Overview
UC10 refactors the design from UC1–UC9 by introducing a **single generic `Quantity<U>` class** that works across all measurement categories through a common `IMeasurable` interface.  
This eliminates code duplication across parallel `QuantityLength` and `QuantityWeight` classes, restores the **Single Responsibility Principle**, and establishes a **linearly scalable architecture** for future measurement categories.

---
## Objective
To:
- Define an `IMeasurable` interface as a contract for all unit enums  
- Refactor `LengthUnit` and `WeightUnit` to implement `IMeasurable`  
- Replace `QuantityLength` and `QuantityWeight` with a single generic `Quantity<U extends IMeasurable>` class  
- Simplify `QuantityMeasurementApp` to use generic demonstration methods  
- Uphold DRY and SRP principles across the entire system  
- Maintain full backward compatibility with UC1–UC9  

---
## Features
- Single `Quantity<U>` class handles all measurement categories  
- `IMeasurable` interface standardizes unit behavior across all enums  
- Compiler-enforced type safety via bounded generics (`<U extends IMeasurable>`)  
- Cross-category comparison prevention at both compile-time and runtime  
- Generic demonstration methods in `QuantityMeasurementApp` — no category-specific duplication  
- New measurement categories require only a new enum implementing `IMeasurable`  
- All UC1–UC9 functionality preserved — no client code changes required  

---
## Project Structure
- `IMeasurable` – Interface defining the unit conversion contract  
- `LengthUnit` – Refactored to implement `IMeasurable`  
- `WeightUnit` – Refactored to implement `IMeasurable`  
- `Quantity<U>` – Single generic class replacing `QuantityLength` and `QuantityWeight`  
- `QuantityMeasurementApp` – Simplified with generic demonstration methods  

---
## Working Flow
1. `IMeasurable` interface defined with `getConversionFactor()`, `convertToBaseUnit()`, `convertFromBaseUnit()`, `getUnitName()`  
2. `LengthUnit` and `WeightUnit` implement `IMeasurable` — no external API changes  
3. `Quantity<U>` is instantiated with any `IMeasurable` unit  
4. Constructor validates unit (non-null) and value (finite)  
5. Operations (`equals`, `convertTo`, `add`) delegate to unit's `IMeasurable` methods  
6. `equals()` checks `unit.getClass()` to reject cross-category comparisons  
7. A new immutable `Quantity<U>` is returned for all operations  

---
## ⚙️ Conversion Logic

```
// Convert any unit to base unit
baseValue = value * unit.getConversionFactor()

// Convert base unit to target unit
result = baseValue / targetUnit.getConversionFactor()
```

| Category | Base Unit  | Units Supported                        |
|----------|------------|----------------------------------------|
| Length   | FEET       | FEET, INCHES, YARDS, CENTIMETERS       |
| Weight   | KILOGRAM   | KILOGRAM, GRAM, POUND                  |

---
## Example

**Length (UC1–UC8 preserved):**  
`new Quantity<>(1.0, LengthUnit.FEET).equals(new Quantity<>(12.0, LengthUnit.INCHES))`  
→ `true`

`new Quantity<>(1.0, LengthUnit.FEET).convertTo(LengthUnit.INCHES)`  
→ `Quantity(12.0, INCHES)`

`new Quantity<>(1.0, LengthUnit.FEET).add(new Quantity<>(12.0, LengthUnit.INCHES), LengthUnit.FEET)`  
→ `Quantity(2.0, FEET)`

**Weight (UC9 preserved):**  
`new Quantity<>(1.0, WeightUnit.KILOGRAM).equals(new Quantity<>(1000.0, WeightUnit.GRAM))`  
→ `true`

`new Quantity<>(1.0, WeightUnit.KILOGRAM).convertTo(WeightUnit.GRAM)`  
→ `Quantity(1000.0, GRAM)`

`new Quantity<>(1.0, WeightUnit.KILOGRAM).add(new Quantity<>(1000.0, WeightUnit.GRAM), WeightUnit.KILOGRAM)`  
→ `Quantity(2.0, KILOGRAM)`

**Cross-Category Prevention:**  
`new Quantity<>(1.0, LengthUnit.FEET).equals(new Quantity<>(1.0, WeightUnit.KILOGRAM))`  
→ `false`

`demonstrateEquality(Quantity<LengthUnit>, Quantity<WeightUnit>)`  
→ Compiler error (type mismatch)

---
## Disadvantages of UC9 Addressed

| UC9 Problem | UC10 Solution |
|-------------|---------------|
| Duplicate `QuantityLength` / `QuantityWeight` classes | Single `Quantity<U>` class |
| Duplicate unit enum structures | `IMeasurable` interface eliminates redundancy |
| `QuantityMeasurementApp` SRP violation | Generic methods replace category-specific ones |
| Exponential code growth per new category | Linear growth — new enum only |
| Inconsistency risk across categories | Single source of truth for all operations |
| Limited API flexibility | `Quantity<?>` wildcards enable polymorphic methods |

---
## Concepts Used
### Generic Programming
- Bounded type parameters (`<U extends IMeasurable>`) enforce constraints at compile-time  
- Generics eliminate code duplication while maintaining full type safety  

### Interface-Based Design
- `IMeasurable` defines a contract for all measurement units  
- Enums implementing interfaces encapsulate behavior within constants  
- Enables polymorphic treatment of different unit types  

### Single Responsibility Principle (SRP)
- `IMeasurable` — defines unit abstraction contract  
- `Quantity<U>` — handles value operations (equals, add, convert)  
- Unit enums — provide unit-specific constants and conversion factors  
- `QuantityMeasurementApp` — orchestration and demonstration only  

### DRY Principle
- Logic implemented once in `Quantity<U>`, reused across all categories  
- Bug fixes automatically benefit all measurement types  

### Open-Closed Principle (OCP)
- System is open for extension (new unit enums) but closed for modification  
- New categories added without changing `Quantity<U>` or `QuantityMeasurementApp`  

### Liskov Substitution Principle (LSP)
- Any `IMeasurable` implementation works interchangeably with `Quantity<U>`  
- No special handling required for different unit types  

### Composition Over Inheritance
- `Quantity<U>` holds a `U` (composition) rather than extending category-specific classes  
- More flexible than inheritance-based designs  

### Cross-Category Type Safety
- `equals()` checks `unit.getClass()` for runtime category matching  
- Compiler enforces category constraints through generics  

### Immutability
- `Quantity<U>` objects are immutable — all operations return new instances  
- Thread-safe across concurrent callers  

### Enum as Behavior Carrier
- Enums implement `IMeasurable`, carrying both data and behavior  
- Immutable and thread-safe by nature  

---
## Implementation Steps

### Step 1 – Define IMeasurable Interface
- Methods: `getConversionFactor()`, `convertToBaseUnit()`, `convertFromBaseUnit()`, `getUnitName()`  
- Minimal, focused contract — no unnecessary methods  

### Step 2 – Refactor LengthUnit
- Add `implements IMeasurable`  
- Implement all interface methods using existing conversion logic  
- No external API changes — fully backward compatible  

### Step 3 – Refactor WeightUnit
- Identical structure to refactored `LengthUnit`  
- Consistent implementation across enums supports polymorphism  

### Step 4 – Create Generic Quantity Class
- Replace `QuantityLength` and `QuantityWeight` with `Quantity<U extends IMeasurable>`  
- Implement `equals()`, `convertTo()`, overloaded `add()`, `hashCode()`, `toString()`  
- `equals()` includes `unit.getClass()` check for cross-category prevention  

### Step 5 – Simplify QuantityMeasurementApp
- Replace category-specific methods with single generic `demonstrateEquality()`, `demonstrateConversion()`, `demonstrateAddition()`  
- Reduce class to orchestration responsibilities only  

### Step 6 – Update Test Classes
- Rename to `QuantityTest` (replaces `QuantityLengthTest` and `QuantityWeightTest`)  
- Use parameterized tests or separate test classes per category  
- All test logic remains identical — only type parameters change  

### Step 7 – Verify Backward Compatibility
- Run all UC1–UC9 test cases unchanged  
- Confirm behavior is identical to previous implementation  

---
## Test Scenarios
### IMeasurable Interface Tests
- `LengthUnit` correctly implements all interface methods  
- `WeightUnit` correctly implements all interface methods  
- Consistent method behavior across both enums  

### Generic Quantity — Length Operations
- Equality, conversion, and addition via `Quantity<LengthUnit>`  
- Identical behavior to original `QuantityLength`  

### Generic Quantity — Weight Operations
- Equality, conversion, and addition via `Quantity<WeightUnit>`  
- Identical behavior to original `QuantityWeight`  

### Cross-Category Prevention
- `equals()` returns `false` when categories differ  
- Compiler rejects type mismatches at compile-time  

### Constructor Validation
- Null unit → `IllegalArgumentException`  
- `Double.NaN` value → `IllegalArgumentException`  
- Infinite value → `IllegalArgumentException`  

### Simplified QuantityMeasurementApp
- `demonstrateEquality()` handles both length and weight  
- `demonstrateConversion()` handles both length and weight  
- `demonstrateAddition()` handles both length and weight  

### Scalability
- New `VolumeUnit` enum integrates with `Quantity<VolumeUnit>` without any other changes  
- No modifications to `Quantity<U>` or `QuantityMeasurementApp` required  

### Backward Compatibility
- All UC1–UC9 test cases pass without modification  

---
## Sample Test Cases
- `testIMeasurableInterface_LengthUnitImplementation()`  
- `testIMeasurableInterface_WeightUnitImplementation()`  
- `testIMeasurableInterface_ConsistentBehavior()`  
- `testGenericQuantity_LengthOperations_Equality()`  
- `testGenericQuantity_WeightOperations_Equality()`  
- `testGenericQuantity_LengthOperations_Conversion()`  
- `testGenericQuantity_WeightOperations_Conversion()`  
- `testGenericQuantity_LengthOperations_Addition()`  
- `testGenericQuantity_WeightOperations_Addition()`  
- `testCrossCategoryPrevention_LengthVsWeight()`  
- `testCrossCategoryPrevention_CompilerTypeSafety()`  
- `testGenericQuantity_ConstructorValidation_NullUnit()`  
- `testGenericQuantity_ConstructorValidation_InvalidValue()`  
- `testGenericQuantity_Conversion_AllUnitCombinations()`  
- `testGenericQuantity_Addition_AllUnitCombinations()`  
- `testBackwardCompatibility_AllUC1Through9Tests()`  
- `testQuantityMeasurementApp_SimplifiedDemonstration_Equality()`  
- `testQuantityMeasurementApp_SimplifiedDemonstration_Conversion()`  
- `testQuantityMeasurementApp_SimplifiedDemonstration_Addition()`  
- `testTypeWildcard_FlexibleSignatures()`  
- `testScalability_NewUnitEnumIntegration()`  
- `testScalability_MultipleNewCategories()`  
- `testGenericBoundedTypeParameter_Enforcement()`  
- `testHashCode_GenericQuantity_Consistency()`  
- `testEquals_GenericQuantity_ContractPreservation()`  
- `testEnumAsUnitCarrier_BehaviorEncapsulation()`  
- `testTypeErasure_RuntimeSafety()`  
- `testCompositionOverInheritance_Flexibility()`  
- `testImmutability_GenericQuantity()`  
- `testArchitecturalReadiness_MultipleNewCategories()`  

---
## Conclusion
UC10 completes the architectural evolution of the Quantity Measurement Application by replacing category-specific duplication with a **single, type-safe generic design**.  
By introducing the `IMeasurable` interface and the `Quantity<U>` class, the system achieves:
- **Zero duplication** — one class handles all measurement categories  
- **Linear scalability** — adding a new category requires only a new enum  
- **Compile-time and runtime safety** — generics and class checks prevent invalid comparisons  
- **Simplified maintenance** — bug fixes and improvements apply to all categories at once  
- **Full backward compatibility** — all UC1–UC9 behavior is preserved identically  

This marks the culmination of a **complete, enterprise-grade measurement system** — extensible, maintainable, type-safe, and built on proven software design principles.

---
## 📅 Date: 19 March 2026
# Quantity Measurement App – UC11: Volume Measurement Equality, Conversion, and Addition (Litre, Millilitre, Gallon)
## Overview
UC11 extends the Quantity Measurement Application to support **volume measurements** alongside length and weight measurements.  
It introduces a new measurement category — volume — that operates **independently from length and weight** through the generic `Quantity<U>` class and `IMeasurable` interface established in UC10.

UC11 validates that the UC10 architecture **truly scales linearly** — adding a complete new measurement category requires only a single new enum, with **zero changes** to `Quantity<U>`, `IMeasurable`, or `QuantityMeasurementApp`.

---
## Objective
To:
- Create a `VolumeUnit` enum implementing `IMeasurable` with `LITRE` as the base unit  
- Support equality comparison, unit conversion, and addition for volume measurements  
- Enforce category type safety (volume ≠ length ≠ weight)  
- Prove that the UC10 generic architecture scales seamlessly to a third measurement category  
- Maintain full backward compatibility with UC1–UC10  

---
## Features
- Equality comparison between volume measurements across all unit combinations  
- Unit conversion between Litre, Millilitre, and Gallon  
- Addition with implicit target unit (first operand's unit) and explicit target unit  
- Category type safety — volume cannot be compared with length or weight  
- **Zero modifications** to `Quantity<U>`, `IMeasurable`, or `QuantityMeasurementApp`  
- Full backward compatibility with all UC1–UC10 functionality  

---
## Project Structure
- `VolumeUnit` – New standalone enum implementing `IMeasurable` (only new file required)  
- `Quantity<U>` – Unchanged; works with `VolumeUnit` automatically  
- `IMeasurable` – Unchanged; already supports any unit enum  
- `QuantityMeasurementApp` – Unchanged; generic methods handle volume automatically  

---
## Working Flow
1. `VolumeUnit` enum is created implementing `IMeasurable`  
2. Conversion factors defined relative to litre (base unit)  
3. `Quantity<VolumeUnit>` instances created using the existing generic class  
4. Input validation performed (non-null unit, finite value) by existing constructor  
5. Both values converted to **base unit (litre)** using `VolumeUnit` conversion methods  
6. Equality comparison, conversion, or addition performed by existing generic logic  
7. Result converted to **target unit** (implicit or explicit)  
8. New immutable `Quantity<VolumeUnit>` returned  

---
## ⚙️ Conversion Logic

```
// Convert any unit to base unit (litre)
baseValue = value * unit.getConversionFactor()

// Convert base unit (litre) to target unit
result = baseValue / targetUnit.getConversionFactor()
```

| Unit        | Conversion Factor (to litres) |
|-------------|-------------------------------|
| LITRE       | 1.0                           |
| MILLILITRE  | 0.001                         |
| GALLON      | 3.78541                       |

---
## Example

**Equality:**  
`new Quantity<>(1.0, LITRE).equals(new Quantity<>(1000.0, MILLILITRE))`  
→ `true`

`new Quantity<>(1.0, LITRE).equals(new Quantity<>(~0.264172, GALLON))`  
→ `true` (within epsilon)

`new Quantity<>(3.78541, LITRE).equals(new Quantity<>(1.0, GALLON))`  
→ `true` (within epsilon)

**Conversion:**  
`new Quantity<>(1.0, LITRE).convertTo(MILLILITRE)`  
→ `Quantity(1000.0, MILLILITRE)`

`new Quantity<>(2.0, GALLON).convertTo(LITRE)`  
→ `Quantity(~7.57082, LITRE)`

`new Quantity<>(500.0, MILLILITRE).convertTo(GALLON)`  
→ `Quantity(~0.132086, GALLON)`

**Addition (Implicit Target Unit):**  
`new Quantity<>(1.0, LITRE).add(new Quantity<>(1000.0, MILLILITRE))`  
→ `Quantity(2.0, LITRE)`

`new Quantity<>(2.0, GALLON).add(new Quantity<>(3.78541, LITRE))`  
→ `Quantity(3.0, GALLON)`

**Addition (Explicit Target Unit):**  
`new Quantity<>(1.0, LITRE).add(new Quantity<>(1000.0, MILLILITRE), MILLILITRE)`  
→ `Quantity(2000.0, MILLILITRE)`

`new Quantity<>(500.0, MILLILITRE).add(new Quantity<>(1.0, LITRE), GALLON)`  
→ `Quantity(~0.396258, GALLON)`

**Category Incompatibility:**  
`new Quantity<>(1.0, LITRE).equals(new Quantity<>(1.0, FOOT))`  
→ `false`

`new Quantity<>(1.0, LITRE).equals(new Quantity<>(1.0, KILOGRAM))`  
→ `false`

---
## Concepts Used
### Scalability of Generic Design
- Adding a third category requires **only a new enum** implementing `IMeasurable`  
- Zero changes to `Quantity<U>`, demonstration methods, or test infrastructure  
- Validates that UC10 architecture achieves true linear scalability  

### Pattern Replication Across Categories
- `VolumeUnit` mirrors the structure of `LengthUnit` and `WeightUnit`  
- Identical enum patterns reduce cognitive load for new developers  

### Base Unit Selection
- Litre is chosen as the base unit for volume (mirrors feet for length, kilogram for weight)  
- Base unit selection impacts conversion factor precision and formula simplicity  

### IMeasurable Interface Power
- Single interface enables polymorphic treatment of all measurement units  
- Volume integrates transparently — no branching or special-case code  

### Generic Type Constraints
- Bounded type parameter `<U extends IMeasurable>` ensures only valid units are used  
- Compiler prevents mixing `Quantity<VolumeUnit>` with `Quantity<LengthUnit>` or `Quantity<WeightUnit>`  

### DRY Principle at Scale
- Three categories now share one implementation — comparison, conversion, and addition logic written once  
- Confirms DRY principle holds across an expanding number of categories  

### Immutability Across All Categories
- `Quantity<VolumeUnit>` objects are immutable — all operations return new instances  
- Consistent with length and weight behavior  

### Floating-Point Precision
- Volume conversions require accuracy to multiple decimal places (e.g., 3.78541 for gallons)  
- Epsilon-based tolerance handles floating-point rounding consistently  

### Polymorphic Unit Behavior
- `LengthUnit`, `WeightUnit`, and `VolumeUnit` treated uniformly through `IMeasurable`  
- Generic demonstration methods in `QuantityMeasurementApp` work automatically  

---
## Implementation Steps

### Step 1 – Create VolumeUnit Enum
- Define constants: `LITRE`, `MILLILITRE`, `GALLON`  
- Assign conversion factors relative to litre  
- Implement `getConversionFactor()`, `convertToBaseUnit()`, `convertFromBaseUnit()`, `getUnitName()`  

### Step 2 – Verify Conversion Factor Accuracy
- `LITRE`: 1.0 (base unit)  
- `MILLILITRE`: 0.001 (1 mL = 0.001 L)  
- `GALLON`: 3.78541 (1 US gallon ≈ 3.78541 L)  

### Step 3 – Create Quantity Instances
- Use existing `Quantity<U>` class: `new Quantity<>(1.0, VolumeUnit.LITRE)`  
- No new class creation required  

### Step 4 – Test Equality Comparisons
- Verify `equals()` works for same-unit, cross-unit, and cross-category comparisons  

### Step 5 – Test Unit Conversions
- Verify `convertTo()` works for all volume unit pairs  

### Step 6 – Test Addition Operations
- Verify `add()` works with implicit and explicit target unit specification  

### Step 7 – Test Cross-Category Prevention
- Confirm volume cannot be compared with length or weight measurements  

### Step 8 – Comprehensive Test Coverage
- Cover all equality, conversion, addition, edge case, and precision scenarios  

### Step 9 – Integration Testing
- Verify existing generic `demonstrateEquality()`, `demonstrateConversion()`, `demonstrateAddition()` work with volume without modification  

### Step 10 – Backward Compatibility Validation
- Run all UC1–UC10 test cases unchanged to confirm no regressions  

---
## Test Scenarios
### Equality Tests
- Litre-to-litre same value → `true`  
- Litre-to-millilitre equivalent value → `true`  
- Litre-to-gallon equivalent value → `true` (within epsilon)  
- Gallon-to-litre equivalent value → `true` (symmetric)  
- Millilitre-to-gallon equivalent value → `true`  
- Different values in same unit → `false`  
- Volume vs. length → `false`  
- Volume vs. weight → `false`  
- Null comparison → `false`  
- Same reference → `true`  
- Zero values across units → `true`  
- Negative values across units → `true`  

### Conversion Tests
- Litre → Millilitre, Millilitre → Litre  
- Gallon → Litre, Litre → Gallon  
- Millilitre → Gallon, Gallon → Millilitre  
- Same unit conversion (no change)  
- Zero and negative value conversions  
- Round-trip conversion within epsilon  

### Addition Tests
- Same unit addition (L + L, mL + mL)  
- Cross-unit addition (L + mL, mL + L, gallon + L)  
- Explicit target unit (result in any volume unit)  
- Commutativity with target unit  
- Addition with zero (identity element)  
- Addition with negative values  
- Addition with large and small magnitude values  

### VolumeUnit Enum Tests
- `LITRE.getConversionFactor()` → `1.0`  
- `MILLILITRE.getConversionFactor()` → `0.001`  
- `GALLON.getConversionFactor()` → `3.78541`  
- `convertToBaseUnit()` and `convertFromBaseUnit()` for all constants  

### Edge Cases
- Null unit → `IllegalArgumentException`  
- `Double.NaN` value → `IllegalArgumentException`  
- Infinite value → `IllegalArgumentException`  

---
## Sample Test Cases
- `testEquality_LitreToLitre_SameValue()`  
- `testEquality_LitreToLitre_DifferentValue()`  
- `testEquality_LitreToMillilitre_EquivalentValue()`  
- `testEquality_MillilitreToLitre_EquivalentValue()`  
- `testEquality_LitreToGallon_EquivalentValue()`  
- `testEquality_GallonToLitre_EquivalentValue()`  
- `testEquality_VolumeVsLength_Incompatible()`  
- `testEquality_VolumeVsWeight_Incompatible()`  
- `testEquality_NullComparison()`  
- `testEquality_SameReference()`  
- `testEquality_NullUnit()`  
- `testEquality_TransitiveProperty()`  
- `testEquality_ZeroValue()`  
- `testEquality_NegativeVolume()`  
- `testEquality_LargeVolumeValue()`  
- `testEquality_SmallVolumeValue()`  
- `testConversion_LitreToMillilitre()`  
- `testConversion_MillilitreToLitre()`  
- `testConversion_GallonToLitre()`  
- `testConversion_LitreToGallon()`  
- `testConversion_MillilitreToGallon()`  
- `testConversion_SameUnit()`  
- `testConversion_ZeroValue()`  
- `testConversion_NegativeValue()`  
- `testConversion_RoundTrip()`  
- `testAddition_SameUnit_LitrePlusLitre()`  
- `testAddition_SameUnit_MillilitrePlusMillilitre()`  
- `testAddition_CrossUnit_LitrePlusMillilitre()`  
- `testAddition_CrossUnit_MillilitrePlusLitre()`  
- `testAddition_CrossUnit_GallonPlusLitre()`  
- `testAddition_ExplicitTargetUnit_Litre()`  
- `testAddition_ExplicitTargetUnit_Millilitre()`  
- `testAddition_ExplicitTargetUnit_Gallon()`  
- `testAddition_Commutativity()`  
- `testAddition_WithZero()`  
- `testAddition_NegativeValues()`  
- `testAddition_LargeValues()`  
- `testAddition_SmallValues()`  
- `testVolumeUnitEnum_LitreConstant()`  
- `testVolumeUnitEnum_MillilitreConstant()`  
- `testVolumeUnitEnum_GallonConstant()`  
- `testConvertToBaseUnit_LitreToLitre()`  
- `testConvertToBaseUnit_MillilitreToLitre()`  
- `testConvertToBaseUnit_GallonToLitre()`  
- `testConvertFromBaseUnit_LitreToLitre()`  
- `testConvertFromBaseUnit_LitreToMillilitre()`  
- `testConvertFromBaseUnit_LitreToGallon()`  
- `testBackwardCompatibility_AllUC1Through10Tests()`  
- `testGenericQuantity_VolumeOperations_Consistency()`  
- `testScalability_VolumeIntegration()`  

---
## Conclusion
UC11 delivers the ultimate proof of the generic architecture established in UC10 — a **complete new measurement category integrated with a single enum file** and zero changes to the existing codebase.  
By introducing volume measurements through only `VolumeUnit`, the system confirms:
- **True linear scalability** — complexity grows by one file per new category, not exponentially  
- **Architectural maturity** — the `IMeasurable` + `Quantity<U>` pattern handles any measurement type  
- **Developer experience** — new categories follow a clear, repeatable pattern with no guesswork  
- **Zero regression risk** — existing length and weight functionality is completely unaffected  

This marks the point where the Quantity Measurement Application becomes a **production-ready, infinitely extensible measurement framework** capable of supporting any measurement category — temperature, time, pressure, speed, and beyond — without ever touching the core classes again.

---
## 📅 Date: 20 March 2026
# Quantity Measurement App – UC12: Subtraction and Division Operations on Quantity Measurements
## Overview
UC12 extends the Quantity Measurement Application by introducing two new arithmetic operations — **subtraction** and **division** — to the generic `Quantity<U>` class.  
Building on equality comparison, unit conversion, and addition from UC1–UC11, this use case enables comprehensive arithmetic manipulation of measurements across all supported categories (length, weight, volume).

Subtraction finds the **difference** between two quantities of the same category. Division computes the **ratio** between two quantities, producing a dimensionless scalar result that represents how many times one measurement is larger than another.

---
## Objective
To:
- Add `subtract()` methods (implicit and explicit target unit) to `Quantity<U>`  
- Add a `divide()` method returning a dimensionless `double` scalar  
- Maintain all design patterns from UC1–UC11 (immutability, validation, cross-category safety)  
- Add corresponding demonstration methods to `QuantityMeasurementApp`  
- Preserve full backward compatibility with all UC1–UC11 functionality  

---
## Features
- Subtraction of two quantities with result in implicit or explicit target unit  
- Division of two quantities returning a dimensionless scalar ratio  
- Cross-unit arithmetic within the same measurement category  
- Division-by-zero prevention via `ArithmeticException`  
- Cross-category arithmetic prevention (`IllegalArgumentException`)  
- Immutability — original quantities unchanged by all operations  
- Works across all categories: length, weight, and volume  

---
## Project Structure
- `Quantity<U>` – Extended with `subtract()` and `divide()` methods  
- `IMeasurable` – Unchanged; conversion methods reused by new operations  
- `LengthUnit`, `WeightUnit`, `VolumeUnit` – Unchanged  
- `QuantityMeasurementApp` – Extended with subtraction and division demonstration methods  

---
## Working Flow

### Subtraction
1. Client calls `subtract(other)` or `subtract(other, targetUnit)`  
2. Validate: `other` is non-null, same category, finite value  
3. Convert both operands to base unit  
4. Compute: `baseResult = this.baseValue - other.baseValue`  
5. Convert result to target unit (implicit = first operand's unit, or explicit)  
6. Round to two decimal places  
7. Return new immutable `Quantity<U>`  

### Division
1. Client calls `divide(other)`  
2. Validate: `other` is non-null, same category, finite value, non-zero  
3. Convert both operands to base unit  
4. Compute: `result = this.baseValue / other.baseValue`  
5. Return dimensionless `double` scalar (no unit)  

---
## ⚙️ Arithmetic Logic

```
// Subtraction
baseResult = (this.value * this.unit.getConversionFactor())
           - (other.value * other.unit.getConversionFactor())
finalResult = baseResult / targetUnit.getConversionFactor()

// Division (dimensionless)
result = (this.value * this.unit.getConversionFactor())
       / (other.value * other.unit.getConversionFactor())
```

| Operation   | Returns          | Commutative | Target Unit Support |
|-------------|------------------|-------------|---------------------|
| `add()`     | `Quantity<U>`    | Yes         | Implicit + Explicit |
| `subtract()`| `Quantity<U>`    | No          | Implicit + Explicit |
| `divide()`  | `double` scalar  | No          | N/A (dimensionless) |

---
## Example

**Subtraction (Implicit Target Unit):**  
`new Quantity<>(10.0, FEET).subtract(new Quantity<>(6.0, INCHES))`  
→ `Quantity(9.5, FEET)`

`new Quantity<>(10.0, KILOGRAM).subtract(new Quantity<>(5000.0, GRAM))`  
→ `Quantity(5.0, KILOGRAM)`

`new Quantity<>(5.0, LITRE).subtract(new Quantity<>(500.0, MILLILITRE))`  
→ `Quantity(4.5, LITRE)`

**Subtraction (Explicit Target Unit):**  
`new Quantity<>(10.0, FEET).subtract(new Quantity<>(6.0, INCHES), INCHES)`  
→ `Quantity(114.0, INCHES)`

`new Quantity<>(5.0, LITRE).subtract(new Quantity<>(2.0, LITRE), MILLILITRE)`  
→ `Quantity(3000.0, MILLILITRE)`

**Subtraction (Negative Result):**  
`new Quantity<>(5.0, FEET).subtract(new Quantity<>(10.0, FEET))`  
→ `Quantity(-5.0, FEET)`

**Subtraction (Zero Result):**  
`new Quantity<>(10.0, FEET).subtract(new Quantity<>(120.0, INCHES))`  
→ `Quantity(0.0, FEET)`

**Division:**  
`new Quantity<>(10.0, FEET).divide(new Quantity<>(2.0, FEET))`  
→ `5.0`

`new Quantity<>(24.0, INCHES).divide(new Quantity<>(2.0, FEET))`  
→ `1.0`

`new Quantity<>(5.0, LITRE).divide(new Quantity<>(10.0, LITRE))`  
→ `0.5`

`new Quantity<>(2000.0, GRAM).divide(new Quantity<>(1.0, KILOGRAM))`  
→ `2.0`

**Error Cases:**  
`new Quantity<>(10.0, FEET).subtract(null)`  
→ throws `IllegalArgumentException`

`new Quantity<>(10.0, FEET).divide(new Quantity<>(0.0, FEET))`  
→ throws `ArithmeticException`

`new Quantity<>(10.0, FEET).subtract(new Quantity<>(5.0, KILOGRAM))`  
→ throws `IllegalArgumentException` (cross-category)

---
## Concepts Used
### Comprehensive Arithmetic Operations
- Quantity system evolves from comparison/conversion to full arithmetic support  
- Multiple operations share common validation and conversion patterns  
- Design accommodates operation diversity without restructuring  

### Non-Commutative Operations
- Subtraction and division are order-dependent — swapping operands changes the result  
- `A.subtract(B) ≠ B.subtract(A)` and `A.divide(B) ≠ B.divide(A)`  
- Testing must verify non-commutativity, unlike commutative addition  

### Division by Zero Handling
- Fail-fast principle: throw `ArithmeticException` rather than return `Infinity` or `NaN`  
- Validation prevents silent logic errors in downstream code  

### Immutability in Arithmetic
- All operations return new instances; original quantities remain unchanged  
- Thread-safe and supports functional composition  
- Consistent with all previous UC operations  

### Target Unit Specification Pattern
- Consistent overloading: implicit (first operand's unit) and explicit target unit  
- Applies to subtraction just as it does to addition  
- Division is dimensionless — no target unit concept applies  

### Cross-Category Type Safety
- `unit.getClass()` check prevents subtraction and division across categories  
- Compile-time and runtime safety layers consistent with UC10+  

### Private Helper Methods for Code Reuse
- Shared conversion and validation logic reduces duplication across operations  
- Adding future operations (modulo, power) follows the same helper structure  

### Validation Consistency
- All operations: null check, category check, finiteness check, zero check (division only)  
- Centralized validation patterns prevent missed edge cases  

### Precision Handling
- Subtraction rounds to two decimal places (consistent with `add()`)  
- Division returns raw `double` — no arbitrary rounding for dimensionless scalars  

---
## Implementation Steps

### Step 1 – Add Subtraction Methods to Quantity Class
- `subtract(Quantity<U> other)` — result in first operand's unit  
- `subtract(Quantity<U> other, U targetUnit)` — result in specified unit  
- Validate null, category, and finite value before operating  

### Step 2 – Add Division Method to Quantity Class
- `divide(Quantity<U> other)` — returns `double` scalar  
- Validate null, category, finiteness, and non-zero divisor  
- Throw `ArithmeticException` for division by zero  

### Step 3 – Add Demonstration Methods to QuantityMeasurementApp
- `demonstrateSubtraction()` — shows implicit and explicit target unit cases  
- `demonstrateDivision()` — shows ratio results and edge cases  

### Step 4 – Update Main Method
- Add demonstration calls for subtraction and division across all categories  

### Step 5 – Add Comprehensive Unit Tests
- Cover all subtraction and division scenarios listed in test cases below  

### Step 6 – Test Edge Cases and Error Handling
- Null arguments, null target unit, `NaN`, infinite values, division by zero, cross-category  

### Step 7 – Maintain Consistency with Addition
- Same implicit/explicit overloading pattern  
- Same immutability guarantees  
- Same rounding to two decimal places (subtraction)  

### Step 8 – Document with JavaDoc
- Method purpose, parameters, return values, exceptions, usage examples  
- Note non-commutativity and mathematical properties  

### Step 9 – Integration Testing
- Verify subtraction and division work across all three categories  
- Confirm coexistence with equality, conversion, and addition operations  
- Run all UC1–UC11 tests unchanged to confirm backward compatibility  

---
## Test Scenarios
### Subtraction — Same Unit
- `FEET - FEET`, `LITRE - LITRE`, `KILOGRAM - KILOGRAM`  
- Result in first operand's unit  

### Subtraction — Different Units (Same Category)
- `FEET - INCHES`, `KILOGRAM - GRAM`, `LITRE - MILLILITRE`  
- Conversion applied before subtraction  

### Subtraction — Explicit Target Unit
- Result expressed in any supported unit of the same category  

### Subtraction — Special Results
- Negative result (second operand larger than first)  
- Zero result (equivalent quantities)  
- Identity (subtracting zero)  
- Subtracting negative operand (equivalent to addition)  

### Division — Same Unit
- `FEET ÷ FEET`, `LITRE ÷ LITRE`, `KILOGRAM ÷ KILOGRAM`  
- Returns dimensionless scalar  

### Division — Different Units (Same Category)
- `INCHES ÷ FEET`, `GRAM ÷ KILOGRAM`, `MILLILITRE ÷ LITRE`  
- Units cancel out after base-unit conversion  

### Division — Ratio Cases
- Ratio > 1.0 (first operand larger)  
- Ratio < 1.0 (first operand smaller)  
- Ratio = 1.0 (equivalent quantities)  
- Very large ratios (e.g., `1e6 ÷ 1`)  
- Very small ratios (e.g., `1 ÷ 1e6`)  

### Error Cases
- Null operand → `IllegalArgumentException`  
- Null target unit → `IllegalArgumentException`  
- Cross-category operation → `IllegalArgumentException`  
- Division by zero → `ArithmeticException`  

### Mathematical Properties
- Non-commutativity of subtraction and division  
- Inverse relationship: `A.add(B).subtract(B) ≈ A`  
- Non-associativity of division: `(A ÷ B) ÷ C ≠ A ÷ (B ÷ C)`  

### Immutability
- Original quantities unchanged after subtraction  
- Original quantities unchanged after division  

---
## Sample Test Cases
- `testSubtraction_SameUnit_FeetMinusFeet()`  
- `testSubtraction_SameUnit_LitreMinusLitre()`  
- `testSubtraction_CrossUnit_FeetMinusInches()`  
- `testSubtraction_CrossUnit_InchesMinusFeet()`  
- `testSubtraction_ExplicitTargetUnit_Feet()`  
- `testSubtraction_ExplicitTargetUnit_Inches()`  
- `testSubtraction_ExplicitTargetUnit_Millilitre()`  
- `testSubtraction_ResultingInNegative()`  
- `testSubtraction_ResultingInZero()`  
- `testSubtraction_WithZeroOperand()`  
- `testSubtraction_WithNegativeValues()`  
- `testSubtraction_NonCommutative()`  
- `testSubtraction_WithLargeValues()`  
- `testSubtraction_WithSmallValues()`  
- `testSubtraction_NullOperand()`  
- `testSubtraction_NullTargetUnit()`  
- `testSubtraction_CrossCategory()`  
- `testSubtraction_AllMeasurementCategories()`  
- `testSubtraction_ChainedOperations()`  
- `testSubtraction_Immutability()`  
- `testSubtraction_PrecisionAndRounding()`  
- `testDivision_SameUnit_FeetDividedByFeet()`  
- `testDivision_SameUnit_LitreDividedByLitre()`  
- `testDivision_CrossUnit_FeetDividedByInches()`  
- `testDivision_CrossUnit_KilogramDividedByGram()`  
- `testDivision_RatioGreaterThanOne()`  
- `testDivision_RatioLessThanOne()`  
- `testDivision_RatioEqualToOne()`  
- `testDivision_NonCommutative()`  
- `testDivision_ByZero()`  
- `testDivision_WithLargeRatio()`  
- `testDivision_WithSmallRatio()`  
- `testDivision_NullOperand()`  
- `testDivision_CrossCategory()`  
- `testDivision_AllMeasurementCategories()`  
- `testDivision_Associativity()`  
- `testDivision_Immutability()`  
- `testDivision_PrecisionHandling()`  
- `testSubtractionAndDivision_Integration()`  
- `testSubtractionAddition_Inverse()`  

---
## Conclusion
UC12 completes the arithmetic foundation of the Quantity Measurement Application by adding **subtraction and division** alongside the existing addition operation.  
Both operations seamlessly integrate into the generic `Quantity<U>` design — following the same validation, conversion, immutability, and type-safety patterns established across UC1–UC11.

The system now supports:
- **Full arithmetic** — add, subtract, divide across any supported measurement category  
- **Non-commutative awareness** — design and tests account for order-dependent operations  
- **Robust error handling** — null safety, cross-category prevention, and division-by-zero protection  
- **Consistent API design** — implicit and explicit target unit overloading mirrors the `add()` pattern  

With UC12, the Quantity Measurement Application is a **fully featured, production-grade measurement framework** — extensible, type-safe, arithmetically complete, and built on proven software engineering principles.

---
## 📅 Date: 21 March 2026
# Quantity Measurement App – UC13: Centralized Arithmetic Logic to Enforce DRY in Quantity Operations
## Overview
UC13 refactors the arithmetic operations (addition, subtraction, division) implemented in UC12 to **eliminate code duplication** and enforce the **DRY (Don't Repeat Yourself) principle**.  
Instead of repeating unit conversion, base-unit normalization, and validation logic across each arithmetic method, a centralized private helper extracts all common logic into a single reusable implementation.

The public API remains completely unchanged — all UC12 behaviors are preserved while the internal structure is optimized for clarity, consistency, and scalability.

---
## Objective
To:
- Create a private `ArithmeticOperation` enum to dispatch operations cleanly  
- Extract a centralized `validateArithmeticOperands()` helper for shared validation  
- Extract a centralized `performBaseArithmetic()` helper for shared conversion and computation  
- Refactor `add()`, `subtract()`, and `divide()` to delegate to these helpers  
- Eliminate all duplicated validation, conversion, and error-handling code  
- Maintain full backward compatibility with all UC12 test cases  

---
## Objective
To:
- Create a private `ArithmeticOperation` enum to dispatch operations cleanly  
- Extract a centralized `validateArithmeticOperands()` helper for shared validation  
- Extract a centralized `performBaseArithmetic()` helper for shared conversion and computation  
- Refactor `add()`, `subtract()`, and `divide()` to delegate to these helpers  
- Eliminate all duplicated validation, conversion, and error-handling code  
- Maintain full backward compatibility with all UC12 test cases  

---
## Features
- `ArithmeticOperation` enum with `ADD`, `SUBTRACT`, `DIVIDE` constants (abstract method or lambda approach)  
- `validateArithmeticOperands()` — single source of truth for null, category, and finiteness checks  
- `performBaseArithmetic()` — single source of truth for base-unit conversion and computation  
- All public method signatures unchanged — zero impact on callers  
- Consistent error messages and exception types across all operations  
- Scalable pattern: new operations (multiply, modulo) require only a new enum constant  

---
## Project Structure
- `Quantity<U>` – Refactored internally; public API unchanged  
  - `ArithmeticOperation` (private enum) – dispatches `ADD`, `SUBTRACT`, `DIVIDE`  
  - `validateArithmeticOperands()` (private) – centralized validation  
  - `performBaseArithmetic()` (private) – centralized conversion and computation  
- `IMeasurable`, `LengthUnit`, `WeightUnit`, `VolumeUnit` – Unchanged  
- `QuantityMeasurementApp` – Unchanged; no public API changes  

---
## Working Flow

### Before UC13 (UC12 Pattern — Duplicated)
```
add()       → null check → category check → finite check → convert → compute → convert back
subtract()  → null check → category check → finite check → convert → compute → convert back
divide()    → null check → category check → finite check → convert → compute
```

### After UC13 (Centralized Pattern)
```
add()       → validateArithmeticOperands() → performBaseArithmetic(ADD)    → convert result
subtract()  → validateArithmeticOperands() → performBaseArithmetic(SUBTRACT) → convert result
divide()    → validateArithmeticOperands() → performBaseArithmetic(DIVIDE) → return scalar
```

### Internal Flow Example
```
q1.subtract(q2, FEET)
  ↓
validateArithmeticOperands(q2, FEET, true)
  ↓
performBaseArithmetic(q2, SUBTRACT)
  ↓
SUBTRACT.compute(q1.baseValue, q2.baseValue)
  ↓
Convert result to FEET
  ↓
Return new Quantity<>(..., FEET)
```

---
## ⚙️ ArithmeticOperation Enum

Two valid implementation approaches:

**Approach 1 — Abstract Interface Method (recommended for complex logic):**
```java
enum ArithmeticOperation {
    ADD {
        @Override
        public double compute(double a, double b) { return a + b; }
    },
    SUBTRACT {
        @Override
        public double compute(double a, double b) { return a - b; }
    },
    DIVIDE {
        @Override
        public double compute(double a, double b) {
            if (b == 0) throw new ArithmeticException("Division by zero");
            return a / b;
        }
    };
    public abstract double compute(double a, double b);
}
```

**Approach 2 — Lambda Expression (modern and concise):**
```java
enum ArithmeticOperation {
    ADD((a, b) -> a + b),
    SUBTRACT((a, b) -> a - b),
    DIVIDE((a, b) -> {
        if (b == 0) throw new ArithmeticException("Division by zero");
        return a / b;
    });

    private final DoubleBinaryOperator operator;
    ArithmeticOperation(DoubleBinaryOperator operator) { this.operator = operator; }
    public double compute(double a, double b) { return operator.applyAsDouble(a, b); }
}
```

---
## Disadvantages of UC12 Addressed

| UC12 Problem | UC13 Solution |
|--------------|---------------|
| Validation logic copied across 3+ methods | Single `validateArithmeticOperands()` helper |
| Conversion logic repeated in each method | Single `performBaseArithmetic()` helper |
| Inconsistent error messages possible | Centralized messages from one location |
| Bug fixes needed in multiple places | Change once → all operations updated |
| Future operations (multiply) would duplicate further | New enum constant only — zero other changes |
| Test duplication for validation scenarios | One validation test suite covers all operations |

---
## Example

**All outputs identical to UC12:**

`new Quantity<>(1.0, FEET).add(new Quantity<>(12.0, INCHES))`  
→ `Quantity(2.0, FEET)` *(internal: `performBaseArithmetic(other, ADD)`)*

`new Quantity<>(10.0, FEET).subtract(new Quantity<>(6.0, INCHES))`  
→ `Quantity(9.5, FEET)` *(internal: `performBaseArithmetic(other, SUBTRACT)`)*

`new Quantity<>(10.0, FEET).divide(new Quantity<>(2.0, FEET))`  
→ `5.0` *(internal: `performBaseArithmetic(other, DIVIDE)`)*

**Error cases (consistent across all operations):**  
`new Quantity<>(10.0, FEET).add(null)` → `IllegalArgumentException`  
`new Quantity<>(10.0, FEET).subtract(new Quantity<>(5.0, KILOGRAM))` → `IllegalArgumentException`  
`new Quantity<>(10.0, FEET).divide(new Quantity<>(0.0, FEET))` → `ArithmeticException`

---
## Concepts Used
### DRY Principle Enforcement
- Validation and conversion logic implemented once, reused by all operations  
- Future changes to validation rules require a single update  
- Eliminates inconsistency risk across arithmetic methods  

### Lambda Expressions
- `(a, b) -> a + b` is a concise anonymous function passed as data  
- `DoubleBinaryOperator` functional interface: takes two `double` values, returns one  
- Compiler bridges the lambda to the interface's `applyAsDouble()` method  

### Functional Interface
- A `@FunctionalInterface` has exactly one abstract method  
- `DoubleBinaryOperator` is the functional interface used in the lambda approach  
- Enables treating arithmetic operations as first-class values  

### Enum-Based Operation Dispatch
- Type-safe alternative to `if-else` or `switch` chains  
- Each enum constant carries its own logic — extensible without modifying callers  
- Adding `MULTIPLY` requires only a new constant and no changes elsewhere  

### Single Source of Truth
- Validation logic appears once in `validateArithmeticOperands()`  
- Conversion logic appears once in `performBaseArithmetic()`  
- Error messages are identical and centralized  

### Separation of Concerns
- Public methods: handle return type and API contracts  
- `validateArithmeticOperands()`: handles safety checks  
- `performBaseArithmetic()`: handles conversion and computation  

### Private Method Encapsulation
- Helper methods are `private` — invisible to callers  
- Reduces API surface area; implementation details protected  

### Scalability for Future Operations
- Adding multiplication: one new `MULTIPLY` enum constant  
- No changes to validation, conversion, or public methods  
- Codebase grows linearly, not by duplication  

### Refactoring Without Behavioral Change
- Public API and all outputs remain identical to UC12  
- Existing test cases pass without modification  
- Internal restructuring improves quality without introducing regression  

---
## Implementation Steps

### Step 1 – Create ArithmeticOperation Enum
- Define `ADD`, `SUBTRACT`, `DIVIDE` constants  
- Use abstract method approach or lambda + `DoubleBinaryOperator`  
- `DIVIDE` constant handles division-by-zero check  

### Step 2 – Create Centralized Validation Helper
```java
private void validateArithmeticOperands(Quantity<U> other, U targetUnit, boolean targetUnitRequired)
```
- Null check on `other`  
- Category type check via `unit.getClass()`  
- Finiteness validation for both values  
- Optional target unit null check  

### Step 3 – Create Core Arithmetic Helper
```java
private double performBaseArithmetic(Quantity<U> other, ArithmeticOperation operation)
```
- Convert `this` to base unit  
- Convert `other` to base unit  
- Call `operation.compute(thisBase, otherBase)`  
- Return base-unit result  

### Step 4 – Refactor Public Arithmetic Methods
- `add(other)` / `add(other, targetUnit)` → validate → `performBaseArithmetic(ADD)` → convert  
- `subtract(other)` / `subtract(other, targetUnit)` → validate → `performBaseArithmetic(SUBTRACT)` → convert  
- `divide(other)` → validate → `performBaseArithmetic(DIVIDE)` → return scalar  

### Step 5 – Verify Backward Compatibility
- Run all UC12 test cases without modification  
- Confirm all outputs, exception types, and messages are identical  

---
## Test Scenarios
### Validation Consistency
- `add(null)`, `subtract(null)`, `divide(null)` → same exception and message  
- Cross-category for all three operations → same exception  
- `NaN` / infinite value for all three operations → same exception  
- Null target unit for `add`/`subtract` → exception  

### Enum Operation Dispatch
- `ADD.compute(10, 5)` → `15.0`  
- `SUBTRACT.compute(10, 5)` → `5.0`  
- `DIVIDE.compute(10, 5)` → `2.0`  
- `DIVIDE.compute(10, 0)` → `ArithmeticException`  

### Helper Method Correctness
- `performBaseArithmetic` correctly converts both operands before operating  
- Result correctly converted from base unit to target unit for `add`/`subtract`  
- Division returns raw scalar without further conversion  

### Backward Compatibility
- All UC12 addition tests pass unchanged  
- All UC12 subtraction tests pass unchanged  
- All UC12 division tests pass unchanged  

### Rounding Consistency
- `add`/`subtract` results rounded to two decimal places  
- `divide` returns raw `double` without rounding  

### Immutability
- Original quantities unchanged after `add`, `subtract`, `divide`  

### Scalability
- All operations work across length, weight, and volume  
- Future `MULTIPLY` pattern demonstrable with same structure  

---
## Sample Test Cases
- `testRefactoring_Add_DelegatesViaHelper()`  
- `testRefactoring_Subtract_DelegatesViaHelper()`  
- `testRefactoring_Divide_DelegatesViaHelper()`  
- `testValidation_NullOperand_ConsistentAcrossOperations()`  
- `testValidation_CrossCategory_ConsistentAcrossOperations()`  
- `testValidation_FiniteValue_ConsistentAcrossOperations()`  
- `testValidation_NullTargetUnit_AddSubtractReject()`  
- `testArithmeticOperation_Add_EnumComputation()`  
- `testArithmeticOperation_Subtract_EnumComputation()`  
- `testArithmeticOperation_Divide_EnumComputation()`  
- `testArithmeticOperation_DivideByZero_EnumThrows()`  
- `testEnumConstant_ADD_CorrectlyAdds()`  
- `testEnumConstant_SUBTRACT_CorrectlySubtracts()`  
- `testEnumConstant_DIVIDE_CorrectlyDivides()`  
- `testPerformBaseArithmetic_ConversionAndOperation()`  
- `testHelper_BaseUnitConversion_Correct()`  
- `testHelper_ResultConversion_Correct()`  
- `testAdd_UC12_BehaviorPreserved()`  
- `testSubtract_UC12_BehaviorPreserved()`  
- `testDivide_UC12_BehaviorPreserved()`  
- `testRounding_AddSubtract_TwoDecimalPlaces()`  
- `testRounding_Divide_NoRounding()`  
- `testRounding_Helper_Accuracy()`  
- `testImplicitTargetUnit_AddSubtract()`  
- `testExplicitTargetUnit_AddSubtract_Overrides()`  
- `testImmutability_AfterAdd_ViaCentralizedHelper()`  
- `testImmutability_AfterSubtract_ViaCentralizedHelper()`  
- `testImmutability_AfterDivide_ViaCentralizedHelper()`  
- `testAllOperations_AcrossAllCategories()`  
- `testCodeDuplication_ValidationLogic_Eliminated()`  
- `testCodeDuplication_ConversionLogic_Eliminated()`  
- `testEnumDispatch_AllOperations_CorrectlyDispatched()`  
- `testFutureOperation_MultiplicationPattern()`  
- `testErrorMessage_Consistency_Across_Operations()`  
- `testHelper_PrivateVisibility()`  
- `testValidation_Helper_PrivateVisibility()`  
- `testArithmetic_Chain_Operations()`  
- `testRefactoring_Validation_UnifiedBehavior()`  

---
## Conclusion
UC13 applies the same architectural discipline to **internal implementation** that UC10 applied to the class hierarchy — eliminating duplication and establishing a single source of truth.  
By introducing the `ArithmeticOperation` enum and two private helper methods, the system achieves:
- **Zero duplication** — validation and conversion logic written once, shared by all operations  
- **Consistent behavior** — all operations fail identically for invalid inputs  
- **Effortless extensibility** — adding multiplication or modulo requires one enum constant  
- **Improved readability** — public methods are short and expressive; boilerplate is abstracted away  
- **Full backward compatibility** — all UC12 tests pass without a single modification  

UC13 demonstrates that **great architecture is not just about external design** — internal code quality matters equally, and the DRY principle is as important inside a class as it is across the system.

---
## 📅 Date: 23 March 2026
# Quantity Measurement App – UC14: Temperature Measurement with Selective Arithmetic Support and IMeasurable Refactoring
## Overview
UC14 extends the Quantity Measurement Application to support **temperature measurements** alongside length, weight, and volume — while simultaneously revealing and resolving a fundamental limitation in the current `IMeasurable` interface design.

Unlike linear measurement categories (length, weight, volume), temperature conversions are **non-linear** and arithmetic on absolute temperature values is **physically meaningless** (100°C + 50°C ≠ 150°C in any practical sense). This means temperature can only support equality comparison and unit conversion — not addition, subtraction, or division.

To accommodate this, UC14 refactors `IMeasurable` to introduce **optional operation support via default methods** and a `SupportsArithmetic` functional interface, allowing temperature to coexist cleanly with other categories while the existing system remains completely unchanged.

---
## Objective
To:
- Refactor `IMeasurable` to support optional arithmetic through default methods and a `SupportsArithmetic` functional interface  
- Create a `TemperatureUnit` enum implementing `IMeasurable` with non-linear conversion logic  
- Enhance `Quantity<U>` to check operation support before executing arithmetic  
- Ensure `TemperatureUnit` throws `UnsupportedOperationException` for unsupported operations  
- Maintain full backward compatibility with all UC1–UC13 functionality  

---
## Features
- Temperature equality comparison across Celsius and Fahrenheit  
- Non-linear temperature unit conversion (°C ↔ °F) using lambda expressions  
- `UnsupportedOperationException` thrown for add, subtract, and divide on temperature  
- `SupportsArithmetic` functional interface flags whether a unit supports arithmetic  
- `validateOperationSupport()` default method overridden in `TemperatureUnit`  
- All existing categories (length, weight, volume) inherit default `true` — zero changes required  
- Cross-category type safety maintained (temperature ≠ length ≠ weight ≠ volume)  

---
## Project Structure
- `IMeasurable` – Refactored with `SupportsArithmetic` functional interface and default methods  
- `TemperatureUnit` – New enum implementing `IMeasurable` with lambda-based non-linear conversions  
- `Quantity<U>` – Enhanced to call `validateOperationSupport()` before arithmetic  
- `LengthUnit`, `WeightUnit`, `VolumeUnit` – Unchanged; inherit default arithmetic support  
- `QuantityMeasurementApp` – Main method extended with temperature demonstrations  

---
## Working Flow

### Equality
1. Two `Quantity<TemperatureUnit>` objects provided  
2. Both values converted to **Celsius (base unit)** using non-linear formulas  
3. Compared using `Double.compare()` within epsilon tolerance  
4. Returns `true` if equivalent, `false` otherwise  

### Conversion
1. `convertTo(targetUnit)` called on a `Quantity<TemperatureUnit>`  
2. Special handling: if `TemperatureUnit`, invoke non-linear conversion formula directly  
3. New immutable `Quantity<TemperatureUnit>` returned  

### Arithmetic (Unsupported)
1. `add()`, `subtract()`, or `divide()` called on `Quantity<TemperatureUnit>`  
2. `this.unit.validateOperationSupport(operation.name())` called first  
3. `TemperatureUnit` overrides this method to throw `UnsupportedOperationException`  
4. Clear error message returned explaining why the operation is invalid  

---
## ⚙️ IMeasurable Refactoring

```java
@FunctionalInterface
public interface SupportsArithmetic {
    boolean isSupported();
}

// Default in IMeasurable — all existing units inherit this (no changes needed)
SupportsArithmetic supportsArithmetic = () -> true;

default boolean supportsArithmetic() {
    return supportsArithmetic.isSupported();
}

// Overridden by TemperatureUnit to throw UnsupportedOperationException
default void validateOperationSupport(String operation) {
    // No-op by default; TemperatureUnit overrides this
}
```

## ⚙️ Temperature Conversion Formulas

```
Celsius → Fahrenheit:   °F = (°C × 9/5) + 32
Fahrenheit → Celsius:   °C = (°F − 32) × 5/9
```

| Unit        | Base Unit | Conversion Formula (to Celsius)     |
|-------------|-----------|-------------------------------------|
| CELSIUS     | Celsius   | Identity — no conversion needed     |
| FAHRENHEIT  | Celsius   | `(°F − 32) × 5/9`                   |

Lambda expressions used per constant:
```java
// Identity (Celsius → Celsius)
final Function<Double, Double> CELSIUS_TO_CELSIUS = (celsius) -> celsius;

// Fahrenheit → Celsius
final Function<Double, Double> FAHRENHEIT_TO_CELSIUS = (f) -> (f - 32) * 5.0 / 9.0;

// Arithmetic support flag
SupportsArithmetic supportsArithmetic = () -> false;
```

---
## Disadvantages of UC13 Addressed

| UC13 Limitation | UC14 Solution |
|-----------------|---------------|
| `IMeasurable` assumes all categories support arithmetic | `SupportsArithmetic` functional interface flags support per unit |
| `Quantity` has no mechanism to block unsupported operations | `validateOperationSupport()` checked before any arithmetic |
| Interface forces temperature to implement dummy arithmetic | Default no-op with override in `TemperatureUnit` |
| No compile-time or early runtime warning for invalid ops | `UnsupportedOperationException` thrown with clear message |
| ISP violated — single interface mixes conversion and arithmetic | Default methods segregate optional operations cleanly |

---
## Example

**Equality:**  
`new Quantity<>(0.0, CELSIUS).equals(new Quantity<>(32.0, FAHRENHEIT))`  
→ `true`

`new Quantity<>(100.0, CELSIUS).equals(new Quantity<>(212.0, FAHRENHEIT))`  
→ `true`

`new Quantity<>(-40.0, CELSIUS).equals(new Quantity<>(-40.0, FAHRENHEIT))`  
→ `true` (the equal point)

**Conversion:**  
`new Quantity<>(100.0, CELSIUS).convertTo(FAHRENHEIT)`  
→ `Quantity(212.0, FAHRENHEIT)`

`new Quantity<>(32.0, FAHRENHEIT).convertTo(CELSIUS)`  
→ `Quantity(0.0, CELSIUS)`

`new Quantity<>(-40.0, CELSIUS).convertTo(FAHRENHEIT)`  
→ `Quantity(-40.0, FAHRENHEIT)`

**Unsupported Operations:**  
`new Quantity<>(100.0, CELSIUS).add(new Quantity<>(50.0, CELSIUS))`  
→ throws `UnsupportedOperationException: "Temperature does not support addition..."`

`new Quantity<>(100.0, CELSIUS).subtract(new Quantity<>(50.0, CELSIUS))`  
→ throws `UnsupportedOperationException`

`new Quantity<>(100.0, CELSIUS).divide(new Quantity<>(50.0, CELSIUS))`  
→ throws `UnsupportedOperationException`

**Cross-Category Prevention:**  
`new Quantity<>(100.0, CELSIUS).equals(new Quantity<>(100.0, FEET))`  
→ `false`

`new Quantity<>(50.0, CELSIUS).equals(new Quantity<>(50.0, KILOGRAM))`  
→ `false`

---
## Concepts Used
### Interface Segregation Principle (ISP)
- Refactored `IMeasurable` separates mandatory conversion from optional arithmetic  
- Categories implement only what they genuinely support  
- Forcing temperature to implement dummy arithmetic violates ISP  

### Functional Interface
- `SupportsArithmetic` has exactly one abstract method: `boolean isSupported()`  
- Used with lambda `() -> false` in `TemperatureUnit` to flag no arithmetic support  
- Enables concise, expressive capability declaration  

### Lambda Expressions
- Temperature conversion formulas expressed as `Function<Double, Double>` lambdas  
- Each `TemperatureUnit` constant carries its own conversion lambda  
- `CELSIUS_TO_CELSIUS = (celsius) -> celsius` — identity function  
- `FAHRENHEIT_TO_CELSIUS = (f) -> (f - 32) * 5.0 / 9.0` — formula-based  

### Default Methods in Interfaces
- Provide default implementations that existing units inherit without code changes  
- `TemperatureUnit` overrides `validateOperationSupport()` to block arithmetic  
- Enables non-breaking interface evolution  

### Non-Linear Conversions
- Temperature conversions use addition/subtraction formulas, not simple multiplication  
- Requires special handling in `Quantity.convertTo()` for `TemperatureUnit`  
- Fundamentally different from length, weight, and volume (which are linear)  

### Absolute vs. Relative Temperatures
- Absolute temperature: 100°C is a specific point on a scale  
- Arithmetic on absolute temperatures is physically meaningless  
- Subtraction of two temperatures gives a *difference* — which is a different concept  

### Capability-Based Design
- Query units about supported operations before attempting them  
- Graceful degradation with clear, informative error messages  
- More user-friendly than silent failures or cryptic exceptions  

### Exception Semantics
- `UnsupportedOperationException` — operation not available for this category  
- `IllegalArgumentException` — invalid argument provided  
- `ArithmeticException` — mathematical error (e.g., division by zero)  
- Each exception type communicates a distinct kind of failure  

### Backward Compatibility Through Defaults
- Existing units (`LengthUnit`, `WeightUnit`, `VolumeUnit`) require zero changes  
- Default `() -> true` lambda and no-op `validateOperationSupport()` preserve current behavior  
- Refactoring is purely additive and non-breaking  

---
## Implementation Steps

### Step 1 – Refactor IMeasurable Interface
- Add `SupportsArithmetic` `@FunctionalInterface` with `boolean isSupported()`  
- Add default `SupportsArithmetic supportsArithmetic = () -> true`  
- Add `default boolean supportsArithmetic()` returning `supportsArithmetic.isSupported()`  
- Add `default void validateOperationSupport(String operation)` as no-op  

### Step 2 – No Changes to LengthUnit, WeightUnit, VolumeUnit
- All three inherit default `supportsArithmetic = () -> true`  
- `validateOperationSupport()` default no-op applies — all operations allowed  

### Step 3 – Create TemperatureUnit Enum
- Define `CELSIUS`, `FAHRENHEIT` constants  
- Assign lambda conversion functions per constant  
- Set `SupportsArithmetic supportsArithmetic = () -> false`  
- Override `validateOperationSupport()` to throw `UnsupportedOperationException`  
- Implement `convertToBaseUnit()` and `convertFromBaseUnit()` using formula lambdas  

### Step 4 – Update Quantity Class
- Equality: works as-is via `convertToBaseUnit()`  
- Conversion: check if unit is `TemperatureUnit`; if so, invoke non-linear formula directly  
- Arithmetic: call `this.unit.validateOperationSupport(operation.name())` before processing  

### Step 5 – Update QuantityMeasurementApp
- No changes to existing demonstration methods  
- Add temperature equality, conversion, and unsupported operation demonstrations in `main()`  

### Step 6 – Comprehensive Test Coverage
- Equality across all temperature unit pairs  
- Conversion accuracy with epsilon tolerance  
- Unsupported operation exception handling  
- Cross-category prevention  
- Edge cases: absolute zero, -40° equal point, large values  

---
## Test Scenarios
### Temperature Equality
- Celsius-to-Celsius same value → `true`  
- Fahrenheit-to-Fahrenheit same value → `true`  
- 0°C = 32°F → `true`  
- 100°C = 212°F → `true`  
- −40°C = −40°F → `true` (equal point)  
- Different values in same unit → `false`  
- Null comparison → `false`  
- Same reference → `true` (reflexive)  
- Symmetric and transitive properties  

### Temperature Conversion
- Celsius → Fahrenheit (multiple values: 0, 50, 100, −40, −20)  
- Fahrenheit → Celsius (bidirectional)  
- Same unit conversion (no change)  
- Zero value conversion (0°C → 32°F)  
- Negative value conversion  
- Large value conversion  
- Round-trip conversion within epsilon  

### Unsupported Operations
- `add()` → `UnsupportedOperationException`  
- `subtract()` → `UnsupportedOperationException`  
- `divide()` → `UnsupportedOperationException`  
- Error message is clear and informative  

### Operation Support Methods
- `TemperatureUnit.CELSIUS.supportsArithmetic()` → `false`  
- `LengthUnit.FEET.supportsArithmetic()` → `true` (inherited default)  
- `WeightUnit.KILOGRAM.supportsArithmetic()` → `true`  
- `VolumeUnit.LITRE.supportsArithmetic()` → `true`  

### Cross-Category Prevention
- Temperature vs. length → `false`  
- Temperature vs. weight → `false`  
- Temperature vs. volume → `false`  

### IMeasurable Evolution
- Existing units work without any modification  
- New default methods do not break existing implementations  

---
## Sample Test Cases
- `testTemperatureEquality_CelsiusToCelsius_SameValue()`  
- `testTemperatureEquality_FahrenheitToFahrenheit_SameValue()`  
- `testTemperatureEquality_CelsiusToFahrenheit_0Celsius32Fahrenheit()`  
- `testTemperatureEquality_CelsiusToFahrenheit_100Celsius212Fahrenheit()`  
- `testTemperatureEquality_CelsiusToFahrenheit_Negative40Equal()`  
- `testTemperatureEquality_SymmetricProperty()`  
- `testTemperatureEquality_ReflexiveProperty()`  
- `testTemperatureConversion_CelsiusToFahrenheit_VariousValues()`  
- `testTemperatureConversion_FahrenheitToCelsius_VariousValues()`  
- `testTemperatureConversion_RoundTrip_PreservesValue()`  
- `testTemperatureConversion_SameUnit()`  
- `testTemperatureConversion_ZeroValue()`  
- `testTemperatureConversion_NegativeValues()`  
- `testTemperatureConversion_LargeValues()`  
- `testTemperatureUnsupportedOperation_Add()`  
- `testTemperatureUnsupportedOperation_Subtract()`  
- `testTemperatureUnsupportedOperation_Divide()`  
- `testTemperatureUnsupportedOperation_ErrorMessage()`  
- `testTemperatureVsLengthIncompatibility()`  
- `testTemperatureVsWeightIncompatibility()`  
- `testTemperatureVsVolumeIncompatibility()`  
- `testOperationSupportMethods_TemperatureUnitAddition()`  
- `testOperationSupportMethods_TemperatureUnitDivision()`  
- `testOperationSupportMethods_LengthUnitAddition()`  
- `testOperationSupportMethods_WeightUnitDivision()`  
- `testIMeasurableInterface_Evolution_BackwardCompatible()`  
- `testTemperatureUnit_NonLinearConversion()`  
- `testTemperatureUnit_AllConstants()`  
- `testTemperatureUnit_NameMethod()`  
- `testTemperatureNullUnitValidation()`  
- `testTemperatureNullOperandValidation_InComparison()`  
- `testTemperatureDifferentValuesInequality()`  
- `testTemperatureBackwardCompatibility_UC1_Through_UC13()`  
- `testTemperatureConversionPrecision_Epsilon()`  
- `testTemperatureEnumImplementsIMeasurable()`  
- `testTemperatureDefaultMethodInheritance()`  
- `testTemperatureValidateOperationSupport_MethodBehavior()`  
- `testTemperatureIntegrationWithGenericQuantity()`  

---
## Conclusion
UC14 is the most architecturally significant use case since UC10 — it reveals a real-world limitation of the existing design and resolves it through principled refactoring rather than workarounds.

By introducing the `SupportsArithmetic` functional interface and `validateOperationSupport()` default method, the system achieves:
- **Interface Segregation** — categories implement only what they genuinely support  
- **Fail-fast safety** — unsupported operations rejected immediately with clear messages  
- **Non-breaking evolution** — existing units require zero changes  
- **Lambda-powered conversions** — non-linear temperature formulas expressed cleanly  
- **Full backward compatibility** — all UC1–UC13 tests pass without modification  

UC14 demonstrates that **great systems evolve gracefully** — accommodating new, structurally different requirements without breaking existing contracts or duplicating defensive code throughout the codebase.

---
