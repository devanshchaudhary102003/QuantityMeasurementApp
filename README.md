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
