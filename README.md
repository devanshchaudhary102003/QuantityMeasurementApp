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
-  Same values should return true  
-  Different values should return false  
-  Null comparison should return false  
-  Same reference should return true  
-  Non-numeric input handling  

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


| Category | Base Unit  | Units Supported                        |
|----------|------------|----------------------------------------|
| Length   | FEET       | FEET, INCHES, YARDS, CENTIMETERS       |
| Weight   | KILOGRAM   | KILOGRAM, GRAM, POUND                  |

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

| Unit        | Conversion Factor (to litres) |
|-------------|-------------------------------|
| LITRE       | 1.0                           |
| MILLILITRE  | 0.001                         |
| GALLON      | 3.78541                       |

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

| Operation   | Returns          | Commutative | Target Unit Support |
|-------------|------------------|-------------|---------------------|
| `add()`     | `Quantity<U>`    | Yes         | Implicit + Explicit |
| `subtract()`| `Quantity<U>`    | No          | Implicit + Explicit |
| `divide()`  | `double` scalar  | No          | N/A (dimensionless) |

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

## ⚙️ Temperature Conversion Formulas

```
Celsius → Fahrenheit:   °F = (°C × 9/5) + 32
Fahrenheit → Celsius:   °C = (°F − 32) × 5/9
```

| Unit        | Base Unit | Conversion Formula (to Celsius)     |
|-------------|-----------|-------------------------------------|
| CELSIUS     | Celsius   | Identity — no conversion needed     |
| FAHRENHEIT  | Celsius   | `(°F − 32) × 5/9`                   |

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

## 📅 Date: 25 March 2026

# UC15: N-Tier Architecture Refactoring

## Overview

UC15 refactors the monolithic Quantity Measurement Application into a professional **N-Tier architecture** by separating concerns into distinct layers: Controller Layer, Service Layer, and Entity/Model Layer. This architectural shift transforms the standalone application from a single-responsibility class into a scalable, maintainable system that adheres to SOLID principles and industry best practices.

The refactoring redistributes responsibilities as follows:

- **Application Layer** (`QuantityMeasurementApp`): Entry point; initializes components and invokes the controller
- **Controller Layer**: Handles user interactions and delegates business logic to the Service Layer
- **Service Layer**: Contains the core business logic for comparisons, conversions, and arithmetic operations
- **Entity/Model Layer**: Defines data structures (DTOs and Entities) used across the application

---

## Objective

- Refactor the monolithic `QuantityMeasurementApp` into a clean N-Tier layered architecture
- Define POCO/DTO classes: `QuantityDTO`, `QuantityModel`, `QuantityMeasurementEntity`
- Implement Repository pattern with `IQuantityMeasurementRepository` and `QuantityMeasurementCacheRepository`
- Implement Service pattern with `IQuantityMeasurementService` and `QuantityMeasurementServiceImpl`
- Implement Controller layer with `QuantityMeasurementController`
- Apply Factory, Facade, Singleton, and Dependency Injection design patterns
- Maintain full backward compatibility with all UC1–UC14 functionality

---

## Features

- Clean 4-tier architecture: Application → Controller → Service → Repository
- Standardized data flow via `QuantityDTO` across all layer boundaries
- In-memory cache repository with disk serialization using C# Binary Serialization (`BinaryFormatter` / `System.Text.Json`)
- Singleton `QuantityMeasurementCacheRepository` for centralized data access
- Custom `QuantityMeasurementException` (unchecked — inherits from `Exception`) for centralized error handling
- Dependency injection via constructor — no tight coupling between layers
- Controller methods named `PerformXXX` — REST-ready design for future HTTP mapping
- All UC1–UC14 business logic preserved; only structure reorganized

---

## Project Structure

```
QuantityMeasurementApp.cs              ← Entry Point (Application Layer)
QuantityMeasurementController.cs       ← Controller Layer
IQuantityMeasurementService.cs         ← Service Interface
QuantityMeasurementServiceImpl.cs      ← Service Implementation
IQuantityMeasurementRepository.cs      ← Repository Interface
QuantityMeasurementCacheRepository.cs  ← Cache Repository (Singleton)
QuantityDTO.cs                         ← Data Transfer Object
QuantityModel.cs                       ← Internal Model (generic)
QuantityMeasurementEntity.cs           ← Persistence Entity (Serializable)
QuantityMeasurementException.cs        ← Custom Exception
```

---

## Architecture Overview

```
QuantityMeasurementApp.Console (Entry Point)
        │
        ▼
QuantityMeasurementAppBusinessLayer
        │
        ▼
QuantityMeasurementAppRepositoryLayer 
        │
        ▼
QuantityMeasurementAppModelLayer 
```

---

## Data Flow — Example: Addition

```
Controller.PerformAddition(QuantityDTO a, QuantityDTO b)
    │
    ▼
ServiceImpl.Add(QuantityDTO a, QuantityDTO b)
    │── Extract QuantityModel objects from DTOs
    │── Validate same measurement category
    │── Perform addition using base unit conversion
    │── Create QuantityMeasurementEntity (operand1, operand2, result)
    │── Save entity to IQuantityMeasurementRepository
    │
    ▼
Return QuantityDTO (result)
    │
    ▼
Controller formats and displays result
```

---

## Disadvantages of UC14 Addressed

| UC14 Limitation | UC15 Solution |
|-----------------|---------------|
| Mixed responsibilities in a single class | Clear 4-tier architecture with single-responsibility layers |
| Business logic tightly coupled to presentation | Service layer has zero presentation concerns |
| No defined data contract between operations | `QuantityDTO` as standardized input/output contract |
| Testing business logic requires UI mocking | Service layer testable independently with no UI dependency |
| No reusability across different interfaces | Service layer reusable from CLI, REST API, GUI |
| Exception handling scattered throughout | Centralized in `QuantityMeasurementException` |
| No extension points for frameworks | DI-ready; can integrate with ASP.NET Core DI or Autofac without changes |

---

## Concepts Used

### N-Tier Architecture
- Application, Controller, Service, Repository, and Entity layers with clear boundaries
- Each layer communicates only with the layer directly below it
- Enables independent development, testing, and deployment of layers

### POCO and DTO Classes
- **POCO**: Plain Old C# Object — only properties, constructors, getters/setters; no framework annotations
- **DTO**: Data Transfer Object — carries only data needed for a specific operation between layers
- `QuantityDTO` is used at the boundary between Controller and Service
- `QuantityModel` is used internally within the Service layer
- `QuantityMeasurementEntity` is used for persistence/history in the Repository

### Repository Pattern
- `IQuantityMeasurementRepository` abstracts persistence implementation
- `QuantityMeasurementCacheRepository` provides in-memory storage with disk serialization
- Interface Segregation Principle applied: easy to swap cache for database implementation

### Singleton Design Pattern
- `QuantityMeasurementCacheRepository` is a Singleton
- Ensures one centralized cache instance throughout the application lifecycle
- Thread-safe global access point using `lock` or `Lazy<T>` for all stored measurements

### Factory Design Pattern
- `QuantityMeasurementApp` uses Factory pattern to create Controller and Service instances
- Clients do not depend on concrete implementations
- Easy to substitute mock or alternate implementations

### Facade Design Pattern
- `QuantityMeasurementController` acts as a Facade over the Service layer
- Simplifies complex service interactions into focused API methods
- Hides complexity of business logic from the entry point

### Dependency Injection
- Controller receives Service via constructor — not created internally
- Service receives Repository via constructor — not created internally
- Enables easy unit testing with mock implementations
- Framework-ready for ASP.NET Core built-in DI or Autofac integration

### Immutability
- `QuantityMeasurementEntity` designed to be effectively immutable
- Multiple constructors for different operation scenarios (single operand, binary operand, error)
- Fields use `readonly` where applicable; initialized only through constructors

### C# Serialization
- `QuantityMeasurementEntity` marked with `[Serializable]` attribute
- Uses `BinaryFormatter` or `System.Text.Json` for file-based persistence
- Custom append logic handles writing to existing serialized files
- Enables persistence across application restarts without a database

### Custom Exception
- `QuantityMeasurementException` extends `Exception` (can be used as unchecked — no forced `try-catch` in C#)
- Encapsulates all quantity measurement domain errors in one class
- Cleaner service code without excessive boilerplate

### Interface Segregation Principle (ISP)
- `IQuantityMeasurementService` defines contract for business operations only
- `IQuantityMeasurementRepository` defines contract for data access only
- Clients depend only on the interfaces they use

### REST-Readiness
- Controller methods named `PerformCompare`, `PerformConvert`, `PerformAdd`, etc.
- Designed to map easily to HTTP endpoints: `POST /compare`, `POST /convert`, `POST /add`
- `QuantityDTO` already serializable — compatible with JSON representation via `System.Text.Json`

---

## Implementation Steps

1. **Add Helper Methods to IMeasurable Interface** — Add method to get measurement type from a unit; update `LengthUnit`, `WeightUnit`, `VolumeUnit`, `TemperatureUnit` enums
2. **Define POCO and DTO Objects** — Create `QuantityDTO` with `IMeasurableUnit` interface and nested enums; create `QuantityModel<U>` and `QuantityMeasurementEntity`
3. **Create Repository Layer** — Define `IQuantityMeasurementRepository`; implement `QuantityMeasurementCacheRepository` as Singleton with in-memory `List<T>` and disk persistence
4. **Create Custom Exception** — Create `QuantityMeasurementException` extending `Exception`
5. **Create Service Layer** — Define `IQuantityMeasurementService`; implement `QuantityMeasurementServiceImpl` with full business logic
6. **Create Controller Layer** — Implement `QuantityMeasurementController` with `PerformXXX` methods; inject `IQuantityMeasurementService` via constructor
7. **Refactor Application Entry Point** — Simplify `QuantityMeasurementApp` to initialization only; delegate demonstrations to controller

---

## Preconditions

- All functionality from UC1–UC14 is fully operational
- `IMeasurable` interface with optional arithmetic support is defined
- `LengthUnit`, `WeightUnit`, `VolumeUnit`, `TemperatureUnit` enums are fully implemented
- Clear understanding of N-Tier architecture and SOLID principles

## Postconditions

- Application organized into four distinct layers with clear responsibilities
- All UC1–UC14 test cases pass with refactored code (behavior unchanged)
- Business logic testable without any UI dependencies
- Services reusable in multiple contexts (CLI, REST API, GUI)
- Dependency injection ready for framework integration (ASP.NET Core DI, Autofac)
- Error handling centralized and consistent
- Data flow between layers standardized and traceable

---

## Project Structure

```
QuantityMeasurementApp
│
├── QuantityMeasurementApp.Console
│   ├── Controller
│   │   └── QuantityMeasurementController.cs
│   ├── Interface
│   │   └── IMenu.cs
│   ├── Menu
│   │   └── Menu.cs
│   ├── Program.cs
│   ├── QuantityMeasurementApp.Console.csproj
│   ├── bin/
│   └── obj/
│
├── QuantityMeasurementAppBusinessLayer
│   ├── Exception
│   │   └── QuantityMeasurementException.cs
│   ├── Interface
│   │   └── IQuantityMeasurementService.cs
│   ├── Service
│   │   └── QuantityMeasurementService.cs
│   ├── QuantityMeasurementAppBusinessLayer.csproj
│   ├── bin/
│   └── obj/
│
├── QuantityMeasurementAppModelLayer
│   ├── DTOs
│   │   └── QuantityDTO.cs
│   ├── Enums
│   │   ├── LengthUnit.cs
│   │   ├── TemperatureUnit.cs
│   │   ├── VolumeUnit.cs
│   │   └── WeightUnit.cs
│   ├── Models
│   │   └── QuantityMeasurementEntity.cs
│   ├── QuantityMeasurementAppModelLayer.csproj
│   ├── bin/
│   └── obj/
│
├── QuantityMeasurementAppRepositoryLayer
│   ├── Cache
│   │   └── QuantityMeasurementCacheRepository.cs
│   ├── Interface
│   │   └── IQuantityMeasurementRepository.cs
│   ├── QuantityMeasurementAppRepositoryLayer.csproj
│   ├── bin/
│   └── obj/
│
├── QuantityMeasurementApp.sln
└── README.md

```
---

## 📅 Date: 30 March 2026

# UC16: Database Integration with ADO.NET for Quantity Measurement Persistence

## Overview

UC16 extends the Quantity Measurement Application by introducing **persistent database storage through ADO.NET** (C# Data Access). Building upon the N-Tier architecture established in UC15, this use case implements a `QuantityMeasurementDatabaseRepository` class that replaces the in-memory `QuantityMeasurementCacheRepository` for long-term data persistence.

This use case also introduces a **professional MSBuild/NuGet project structure** with proper namespace organization, comprehensive test coverage, and automated database schema creation. The refactoring maintains full backward compatibility while providing the ability to switch between in-memory cache and database storage through dependency injection and factory patterns.

---

## Objective

- Restructure the project to follow .NET standard directory layout with `.csproj`
- Organize classes into namespaces by layer: `Controller`, `Service`, `Repository`, `Entity`, `Exception`, `Unit`, `Util`
- Configure `.csproj` / `NuGet.config` with all required dependencies and build plugins
- Implement `QuantityMeasurementDatabaseRepository` using ADO.NET for full CRUD operations
- Implement `ApplicationConfig` for loading `appsettings.json` / `app.config`
- Implement `ConnectionPool` for efficient database connection management
- Create `DatabaseException` for database-specific error handling
- Create SQLite / H2Sharp database schema for development and testing
- Replace `Console.WriteLine` with NLog structured logging
- Write unit tests for Repository, Service, and Controller layers using MSTest / NUnit
- Write integration tests for end-to-end database persistence verification

---

## Features

- Full .NET project structure with MSBuild and NuGet package management
- ADO.NET-based `QuantityMeasurementDatabaseRepository` with `Save`, `FindAll`, `FindByOperation`, `FindByType`, `Count`, `DeleteAll`
- Custom `ConnectionPool` for reusable, thread-safe database connections
- `ApplicationConfig` class for environment-aware properties loading from `appsettings.json`
- SQLite for development and testing; SQL Server / PostgreSQL for production
- Parameterized SQL queries preventing SQL injection
- Transaction management ensuring data consistency
- NLog structured logging throughout all layers
- `DatabaseException` extending `QuantityMeasurementException`
- Enhanced `IQuantityMeasurementRepository` with query methods, count, deleteAll, pool statistics, and resource release
- Unit tests: `QuantityMeasurementDatabaseRepositoryTest`, `QuantityMeasurementServiceTest`, `QuantityMeasurementControllerTest`
- Integration tests: `QuantityMeasurementIntegrationTest`

---

## Project Structure

```
QuantityMeasurementApp
│
├── QuantityMeasurementApp.Console
│   ├── Controller
│   │   └── QuantityMeasurementController.cs
│   ├── Menu
│   │   └── Menu.cs
│   ├── Program.cs
│   ├── QuantityMeasurementApp.Console.csproj
│   ├── bin/
│   └── obj/
│
├── QuantityMeasurementAppBusinessLayer
│   ├── Exception
│   │   └── QuantityMeasurementException.cs
│   ├── Interface
│   │   └── IQuantityMeasurementService.cs
│   ├── Service
│   │   └── QuantityMeasurementService.cs
│   ├── QuantityMeasurementAppBusinessLayer.csproj
│   ├── bin/
│   └── obj/
│
├── QuantityMeasurementAppModelLayer
│   ├── DTOs
│   │   └── QuantityDTO.cs
│   ├── Enums
│   │   ├── LengthUnit.cs
│   │   ├── TemperatureUnit.cs
│   │   ├── VolumeUnit.cs
│   │   └── WeightUnit.cs
│   ├── Models
│   │   ├── QuantityMeasurementEntity.cs
│   │   └── QuantityModel.cs
│   ├── QuantityMeasurementAppModelLayer.csproj
│   ├── bin/
│   └── obj/
│
├── QuantityMeasurementAppRepositoryLayer
│   ├── Database
│   │   └── QuantityMeasurementDatabase.cs
│   ├── Interface
│   │   └── IQuantityMeasurementRepository.cs
│   ├── Utils
│   │   └── DbConnection.cs
│   ├── QuantityMeasurementAppRepositoryLayer.csproj
│   ├── bin/
│   └── obj/
│
├── QuantityMeasurementApp.sln
└── README.md
```

---

## Disadvantages of UC15 Addressed

| UC15 Limitation | UC16 Solution |
|-----------------|---------------|
| In-memory cache lost on application crash | ADO.NET database provides durable, crash-safe persistence |
| Serialized file not scalable or human-readable | Relational database with SQL queryable by any tool |
| No concurrent access support | Connection pool handles multiple threads safely |
| No filtering or aggregation capabilities | SQL queries support filtering by operation type, measurement type, count, etc. |
| No schema enforcement on stored data | Database schema with typed columns and constraints |
| Difficult to inspect stored data externally | Any SQL client can query the database directly |
| No integration with enterprise tools | ADO.NET standard connects to BI tools, reporting engines, monitoring systems |
| Testing tied to file system state | SQLite in-memory database creates clean isolated test state per test run |

---

## Concepts Used

### .NET Project Structure
- Standard directory hierarchy with `.csproj`
- Namespace organization by architectural layer
- NuGet package management for dependencies

### ADO.NET (C# Data Access)
- Low-level, vendor-neutral database access API
- Explicit management of `SqlConnection`, `SqlCommand` (`DbCommand`), and `SqlDataReader` (`DbDataReader`)
- `using` statements ensure all resources are automatically disposed

### Connection Pooling
- `ConnectionPool` maintains a pool of pre-created, reusable database connections
- Reduces overhead of opening and closing connections per operation
- Thread-safe with `lock` statements for acquiring and releasing connections
- Configurable pool size, timeout, and idle connection management

### Parameterized SQL Queries
- All SQL uses `@param` placeholders via `SqlCommand.Parameters`
- Separates SQL structure from user-supplied data
- Eliminates SQL injection vulnerabilities entirely

### Transaction Management
- Multiple related operations wrapped in a single atomic transaction
- `connection.BeginTransaction()` with explicit `Commit()` or `Rollback()`
- Ensures all-or-nothing semantics for data consistency

### Configuration Management
- `ApplicationConfig` reads from `appsettings.json` using `Microsoft.Extensions.Configuration`
- Supports environment-specific overrides via environment variables
- Centralizes all configuration — no hardcoded connection strings in code

### Custom Exception Hierarchy
- `DatabaseException` extends `QuantityMeasurementException`
- Wraps low-level `SqlException` with meaningful domain-level messages
- Propagates to service layer without exposing ADO.NET internals

### Database Schema Design
- `quantity_measurement_entity` table stores all operation records
- `quantity_measurement_history` table provides audit trail
- Indexes on frequently queried columns for performance
- Timestamps track when operations occurred

### NLog Structured Logging
- Replaces all `Console.WriteLine` calls with `Logger.Info()`, `Logger.Error()`, etc.
- NLog configuration in `nlog.config` controls log levels and output targets
- Structured logs improve debugging, monitoring, and production observability

### SQLite In-Memory Database for Testing
- Lightweight, zero-configuration database for unit and integration tests
- Schema auto-created from `schema.sql` before each test run
- Completely isolated from production database — no test data pollution

### Repository Interface Enhancement
- `IQuantityMeasurementRepository` extended with:
  - `GetMeasurementsByOperation(string operationType)`
  - `GetMeasurementsByType(string measurementType)`
  - `GetTotalCount()`
  - `DeleteAll()`
  - `GetPoolStatistics()` (default interface method)
  - `ReleaseResources()` (default interface method)

---

## Build Commands

```bash
dotnet restore                                              # Restore NuGet packages
dotnet build                                               # Compile the project
dotnet run                                                 # Run the application
dotnet test                                                # Run all tests
dotnet publish -c Release                                  # Build release output
dotnet test --filter "FullyQualifiedName~IntegrationTest"  # Run integration tests only
```

---

## Preconditions

- All functionality from UC1–UC15 is fully operational
- N-Tier architecture with `IQuantityMeasurementRepository` is established
- .NET SDK 8.0+ installed and configured
- Understanding of ADO.NET, SQL, and relational database concepts

## Postconditions

- Professional .NET project structure fully established
- All measurements persisted to SQLite/SQL Server database automatically during operations
- Historical data accessible through repository query methods
- Connection pool statistics available for monitoring
- All UC1–UC15 tests pass without modification
- `dotnet test` runs all tests successfully
- Release output created by `dotnet publish`

---

## 📅 Date: 02 April 2026

# UC17: ASP.NET Core REST API with Full Enterprise Architecture

## Overview

UC17 marks the **full web-tier introduction** — rebuilding the Quantity Measurement Application as a fully featured **ASP.NET Core REST API**. This use case introduces RESTful service design, the Model-View-Controller (MVC) pattern, Entity Framework Core ORM, CQRS design pattern, and a full suite of professional tooling including Swagger, Postman, MSTest, and NLog.

The business logic, architecture patterns, and domain knowledge from UC1–UC16 are extended and exposed over HTTP — reinforcing that good architectural principles translate directly into modern API development.

---

## Objective

- Build a fully functional ASP.NET Core WebAPI implementing RESTful services
- Apply the MVC pattern with Controllers, Routing, and HTTP verb mapping
- Integrate Entity Framework Core with LINQ to Entities for ORM-based persistence
- Implement the CQRS (Command Query Responsibility Segregation) design pattern
- Apply LINQ for data querying across the application
- Implement the Pub-Sub (Publish-Subscribe) pattern for event-driven operations
- Add ASP.NET Core Identity for user management and session handling
- Configure WebAPI Filters for cross-cutting concerns (validation, logging, exception handling)
- Enforce code quality with StyleCop / Roslyn Analyzers
- Write unit tests with MSTest
- Implement structured logging with NLog
- Test APIs with Postman
- Document APIs with Swagger / OpenAPI

---

## Features

- RESTful endpoints: `GET /api/quantity/compare`, `POST /api/quantity/convert`, `POST /api/quantity/add`, `POST /api/quantity/subtract`, `POST /api/quantity/divide`
- Entity Framework Core with `DbContext`, `DbSet<T>`, code-first Migrations
- LINQ to Entities queries replacing raw SQL
- CQRS pattern separating read (Query) and write (Command) operations
- Pub-Sub pattern for publishing measurement operation events
- ASP.NET Core Identity for authentication and session management
- WebAPI Filters: `ActionFilter`, `ExceptionFilter`, `AuthorizationFilter`
- Swagger UI for interactive API documentation and testing
- NLog structured logging with file and console targets
- MSTest unit tests for Controller, Service, and Repository layers
- Postman collection for manual API testing and automation

---

## Project Structure

```
QuantityMeasurementApp
│
├── QuantityMeasurementApp.Api
│   ├── Controller
│   │   └── QuantityMeasurementAPIController.cs
│   ├── Properties
│   ├── appsettings.json
│   ├── appsettings.Development.json
│   ├── Program.cs
│   ├── QuantityMeasurementApp.Api.csproj
│   ├── QuantityMeasurementApp.Api.http
│   ├── bin/
│   └── obj/
│
├── QuantityMeasurementAppBusinessLayer
│   ├── Exception
│   │   └── QuantityMeasurementException.cs
│   ├── Interface
│   │   └── IQuantityMeasurementService.cs
│   ├── Service
│   │   └── QuantityMeasurementService.cs
│   ├── QuantityMeasurementAppBusinessLayer.csproj
│   ├── bin/
│   └── obj/
│
├── QuantityMeasurementAppModelLayer
│   ├── DTOs
│   │   ├── LoginDTO.cs
│   │   ├── QuantityDTO.cs
│   │   └── QuantityInputDTO.cs
│   ├── Enums
│   │   ├── LengthUnit.cs
│   │   ├── TemperatureUnit.cs
│   │   ├── VolumeUnit.cs
│   │   └── WeightUnit.cs
│   ├── Entity
|   |    └── QuantityMeasurementEntity.cs
│   ├── QuantityMeasurementAppModelLayer.csproj
│   ├── bin/
│   └── obj/
│
├── QuantityMeasurementAppRepositoryLayer
│   ├── Data
│   │   └── UserDbContext.cs
│   ├── Database
│   │   └── QuantityMeasurementRepository.cs
│   ├── Interface
│   │   └── IQuantityMeasurementRepository.cs
│   ├── Migrations
│   │   ├── 20260325051649_InitialCreate.cs
│   │   ├── 20260325051649_InitialCreate.Designer.cs
│   │   ├── 20260325094008_QuantityTable.cs
│   │   ├── 20260325094008_QuantityTable.Designer.cs
│   │   └── UserDbContextModelSnapshot.cs
│   ├── Utils
│   │   └── DbConnection.cs
│   ├── QuantityMeasurementAppRepositoryLayer.csproj
│   ├── bin/
│   └── obj/
│
├── QuantityMeasurementApp.sln
└── README.md
```

---

## Disadvantages of UC16 Addressed

| UC16 Limitation | UC17 Solution |
|-----------------|---------------|
| No HTTP API exposure | ASP.NET Core WebAPI exposes all operations as REST endpoints |
| Raw ADO.NET requires verbose boilerplate SQL | Entity Framework Core with LINQ eliminates raw SQL |
| No standard API contract documentation | Swagger / OpenAPI auto-generates interactive API docs |
| No event-driven decoupling | Pub-Sub pattern decouples operation publishers from consumers |
| Read and write logic mixed in service layer | CQRS cleanly separates Query (read) and Command (write) paths |
| No user identity or session management | ASP.NET Core Identity provides full user management and sessions |
| Console logging only | NLog provides structured, configurable, multi-target logging |

---

## Concepts Used

### ASP.NET Core WebAPI
- Lightweight, high-performance framework for building HTTP services
- Built-in dependency injection container (`IServiceCollection`)
- Middleware pipeline for request/response processing
- Attribute-based routing: `[HttpGet]`, `[HttpPost]`, `[Route]`

### RESTful Service Design
- Resource-based URL design: `/api/quantity`
- HTTP verbs map to operations: `GET` for queries, `POST` for commands
- Stateless communication — no server-side session state for API calls
- Standardized JSON request/response bodies via `System.Text.Json`

### MVC Pattern
- **Model**: `QuantityDTO`, `QuantityModel`, `QuantityMeasurementEntity`
- **View**: JSON responses (API — no HTML views)
- **Controller**: `QuantityMeasurementController` routes requests to service layer

### Minimal APIs (ASP.NET Core)
- Lightweight endpoint definition without full controller classes
- `app.MapGet()`, `app.MapPost()` for route registration
- Suitable for microservice-style endpoints

### Entity Framework Core
- ORM mapping C# classes to database tables
- `DbContext` manages database connection and change tracking
- `DbSet<T>` represents a database table
- LINQ to Entities: type-safe queries compiled to SQL
- Code-first Migrations: schema changes tracked and applied via `dotnet ef migrations add`

### CQRS (Command Query Responsibility Segregation)
- **Commands**: Write operations — `AddQuantityCommand`, `ConvertQuantityCommand`
- **Queries**: Read operations — `GetAllMeasurementsQuery`, `GetMeasurementsByTypeQuery`
- Separates read and write models for scalability and clarity
- Handlers process commands and queries independently

### LINQ
- Language-Integrated Query syntax for collections and databases
- `Where`, `Select`, `OrderBy`, `GroupBy` used throughout service and repository layers
- Strongly typed — compile-time query validation

### Pub-Sub Pattern
- `MeasurementPerformedEvent` published after every operation
- Subscribers can independently react (logging, notifications, analytics)
- Decouples event producers from consumers

### ASP.NET Core Identity
- Built-in user management: registration, login, roles
- Session management for authenticated users
- Integration with WebAPI for protected endpoints

### WebAPI Filters
- `ActionFilter`: runs before/after controller actions (validation, logging)
- `ExceptionFilter`: centralized exception handling and error response formatting
- `AuthorizationFilter`: enforces access control rules

### StyleCop / Roslyn Analyzers
- Static code analysis enforcing C# coding style conventions
- Ensures consistent naming, spacing, and documentation across the codebase
- Integrated into the build pipeline — style violations treated as build warnings or errors

### MSTest
- Microsoft's unit testing framework for .NET
- `[TestClass]`, `[TestMethod]`, `[TestInitialize]`, `[TestCleanup]` attributes
- Assertions via `Assert.AreEqual`, `Assert.IsNotNull`, `Assert.ThrowsException`

### NLog
- Structured logging framework for .NET
- Configurable targets: file, console, database
- Log levels: Trace, Debug, Info, Warn, Error, Fatal
- Replaces `Console.WriteLine` throughout all layers

### Swagger / OpenAPI
- Auto-generates interactive API documentation from controller annotations
- Accessible at `/swagger` — test endpoints directly from the browser
- `[ProducesResponseType]` attributes document response types and status codes

### Postman
- GUI tool for manually testing REST API endpoints
- Collections for organizing and running multiple API tests
- Environment variables for switching between dev/test/prod configurations
- Automated test scripts with `pm.test()` assertions

---

## REST Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| `POST` | `/api/quantity/compare` | Compare two quantities for equality |
| `POST` | `/api/quantity/convert` | Convert a quantity to a different unit |
| `POST` | `/api/quantity/add` | Add two quantities |
| `POST` | `/api/quantity/subtract` | Subtract one quantity from another |
| `POST` | `/api/quantity/divide` | Divide two quantities |
| `GET` | `/api/quantity/measurements` | Retrieve all stored measurement records |
| `GET` | `/api/quantity/measurements/{type}` | Retrieve measurements filtered by type |

---

## Build Commands

```bash
dotnet new webapi -n QuantityMeasurementAPI    # Create project
dotnet restore                                  # Restore packages
dotnet build                                    # Build project
dotnet run                                      # Run API
dotnet test                                     # Run all tests
dotnet ef migrations add InitialCreate          # Create EF migration
dotnet ef database update                       # Apply migration to database
```

---

## Preconditions

- All UC1–UC16 functionality understood and implemented
- .NET SDK 8.0+ installed
- Understanding of C#, HTTP protocol, REST principles
- Entity Framework Core concepts understood

## Postconditions

- Fully functional ASP.NET Core REST API serving all quantity measurement operations
- EF Core migrations managing database schema
- Swagger UI documenting all endpoints
- All MSTest unit tests passing
- Postman collection verifying all endpoints manually and automatically
- NLog writing structured logs to file and console

---


## 📅 Date: 04 April 2026

# UC18: .NET Security — JWT, OAuth 2.0, Encryption and Hashing

## Overview

UC18 secures the ASP.NET Core REST API built in UC17 by implementing industry-standard authentication and authorization mechanisms. This use case introduces **JWT (JSON Web Tokens)** for stateless API authentication, **OAuth 2.0** for delegated authorization flows, **encryption and decryption** for protecting sensitive data at rest and in transit, and **hashing algorithms** for secure password storage.

Security is not an afterthought — UC18 integrates these mechanisms as foundational middleware layers that protect every endpoint in the Quantity Measurement API.

---

## Objective

- Implement JWT-based authentication for stateless API security
- Implement OAuth 2.0 authorization flows for delegated access
- Secure all REST API endpoints with `[Authorize]` attribute and JWT bearer tokens
- Implement encryption and decryption for sensitive data
- Implement hashing algorithms for secure password storage
- Add token refresh, expiry, and revocation mechanisms
- Apply security best practices: HTTPS enforcement, CORS policy, rate limiting
- Extend MSTest suite with security-focused test cases

---

## Features

- JWT generation with claims (user ID, roles, expiry)
- JWT validation middleware in ASP.NET Core pipeline
- OAuth 2.0 authorization code flow and client credentials flow
- `[Authorize]` and `[AllowAnonymous]` attributes on controller endpoints
- Role-based access control (RBAC) using JWT claims
- Symmetric encryption (AES-256) for sensitive data at rest
- Asymmetric encryption (RSA) for secure key exchange
- BCrypt password hashing with salt
- SHA-256 and SHA-512 hashing for data integrity verification
- Token refresh endpoint with refresh token rotation
- HTTPS enforcement middleware
- CORS policy configuration
- Rate limiting middleware to prevent brute-force attacks
- Security headers: `X-Content-Type-Options`, `X-Frame-Options`, `Strict-Transport-Security`

---

## Project Structure Additions

```
QuantityMeasurementApp
│
├── QuantityMeasurementApp.Api
│   ├── Controller
│   │   ├── AuthController.cs
│   │   └── QuantityMeasurementAPIController.cs
│   ├── Properties
│   ├── appsettings.json
│   ├── appsettings.Development.json
│   ├── Program.cs
│   ├── QuantityMeasurementApp.Api.csproj
│   ├── QuantityMeasurementApp.Api.http
│   ├── bin/
│   └── obj/
│
├── QuantityMeasurementAppBusinessLayer
│   ├── Exception
│   │   └── QuantityMeasurementException.cs
│   ├── Interface
│   │   ├── IAuthService.cs
│   │   └── IQuantityMeasurementService.cs
│   ├── Service
│   │   ├── QuantityMeasurementAuthService.cs
│   │   └── QuantityMeasurementService.cs
│   ├── QuantityMeasurementAppBusinessLayer.csproj
│   ├── bin/
│   └── obj/
│
├── QuantityMeasurementAppModelLayer
│   ├── DTOs
│   │   ├── ConvertDTO.cs
│   │   ├── GoogleLoginDTO.cs
│   │   ├── LoginDTO.cs
│   │   ├── QuantityDTO.cs
│   │   ├── QuantityInputDTO.cs
│   │   └── RegisterDTO.cs
│   ├── Entity
│   │   ├── QuantityMeasurementEntity.cs
│   │   └── UserEntity.cs
│   ├── Enums
│   │   ├── LengthUnit.cs
│   │   ├── TemperatureUnit.cs
│   │   ├── VolumeUnit.cs
│   │   └── WeightUnit.cs
│   ├── QuantityMeasurementAppModelLayer.csproj
│   ├── bin/
│   └── obj/
│
├── QuantityMeasurementAppRepositoryLayer
│   ├── Data
│   │   └── UserDbContext.cs
│   ├── Database
│   │   └── QuantityMeasurementRepository.cs
│   ├── Interface
│   │   └── IQuantityMeasurementRepository.cs
│   ├── Migrations
│   │   ├── 20260401104357_InitialCreate.cs
│   │   ├── 20260401104357_InitialCreate.Designer.cs
│   │   └── UserDbContextModelSnapshot.cs
│   ├── Utils
│   │   └── DbConnection.cs
│   ├── QuantityMeasurementAppRepositoryLayer.csproj
│   ├── bin/
│   └── obj/
│
├── QuantityMeasurementApp.sln
└── README.md
```

---

## Disadvantages of UC17 Addressed

| UC17 Limitation | UC18 Solution |
|-----------------|---------------|
| All endpoints publicly accessible — no authentication | JWT bearer token required for all protected endpoints |
| Passwords stored without hashing | BCrypt adaptive hashing with salt applied to all passwords |
| Sensitive data stored in plain text | AES-256 encryption applied to sensitive fields at rest |
| No authorization — any authenticated user can do anything | Role-based and policy-based access control via JWT claims |
| No protection against brute-force login attacks | Rate limiting middleware blocks excessive authentication attempts |
| Tokens never expire or get revoked | Short-lived JWT + refresh token rotation with revocation support |
| No transport security enforcement | HTTPS redirection and HSTS headers enforced |

---

## Concepts Used

### JWT (JSON Web Tokens)
- Three-part structure: `Header.Payload.Signature`
- **Header**: algorithm and token type (`HS256`, `RS256`)
- **Payload**: claims — `sub` (user ID), `role`, `exp` (expiry), `iat` (issued at), custom claims
- **Signature**: HMAC-SHA256 or RSA signature ensuring token integrity
- Stateless: server validates token without a database lookup on every request
- `JwtSecurityTokenHandler` from `System.IdentityModel.Tokens.Jwt` for generation and validation

### OAuth 2.0
- Authorization framework for delegated access
- **Authorization Code Flow**: user authenticates with identity provider; app receives authorization code exchanged for access token
- **Client Credentials Flow**: machine-to-machine authentication without user interaction
- **Scopes**: define what resources the token grants access to (`read:measurements`, `write:measurements`)
- Integration with ASP.NET Core Identity and external providers

### REST API Security
- `[Authorize]` attribute on controllers/actions requires valid JWT bearer token
- `[AllowAnonymous]` on login and registration endpoints
- Role-based: `[Authorize(Roles = "Admin")]`
- Policy-based: `[Authorize(Policy = "MeasurementWriter")]`
- JWT bearer token passed in `Authorization: Bearer <token>` HTTP header

### Encryption and Decryption
- **AES (Advanced Encryption Standard)**: symmetric encryption for sensitive stored data
  - 256-bit key, CBC mode with random IV
  - `Aes.Create()` in `System.Security.Cryptography`
- **RSA**: asymmetric encryption for secure key exchange and digital signatures
  - Public key encrypts; private key decrypts
  - `RSA.Create()` in `System.Security.Cryptography`

### Hashing Algorithms
- **BCrypt**: adaptive password hashing with built-in salt
  - `BCrypt.Net.BCrypt.HashPassword(password)` — stores hash + salt together
  - `BCrypt.Net.BCrypt.Verify(password, hash)` — validates without knowing salt separately
  - Work factor configurable — increases cost as hardware improves
- **SHA-256 / SHA-512**: cryptographic hash functions for data integrity
  - One-way: cannot reverse hash to original input
  - Deterministic: same input always produces same hash
  - Used for API request signing, file integrity, audit logs
  - `SHA256.Create()` / `SHA512.Create()` in `System.Security.Cryptography`

### Token Refresh and Rotation
- Short-lived access tokens (15 minutes) + long-lived refresh tokens (7 days)
- Refresh token stored securely (hashed) in database
- Token rotation: each refresh issues a new refresh token and invalidates the old one
- Prevents refresh token theft from granting indefinite access

### Security Middleware
- **HTTPS Enforcement**: `app.UseHttpsRedirection()` — redirects all HTTP to HTTPS
- **HSTS**: `app.UseHsts()` — instructs browsers to only use HTTPS
- **CORS Policy**: `app.UseCors()` — restricts which origins can call the API
- **Rate Limiting**: `app.UseRateLimiter()` (built-in .NET 7+) or custom middleware limiting requests per IP per time window
- **Security Headers**: `X-Content-Type-Options: nosniff`, `X-Frame-Options: DENY`, `Content-Security-Policy`

### Security Best Practices Applied
- Never store plain-text passwords — always BCrypt hash
- Never log JWT tokens or sensitive claims
- Validate all input before processing (prevent injection)
- Use environment variables or Azure Key Vault for secrets — never hardcode in `appsettings.json`
- Rotate secrets regularly
- Principle of least privilege: tokens carry only necessary claims

---

## Security Endpoints

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `POST` | `/api/auth/register` | Register new user | No |
| `POST` | `/api/auth/login` | Authenticate; receive JWT + refresh token | No |
| `POST` | `/api/auth/refresh` | Exchange refresh token for new access token | No |
| `POST` | `/api/auth/revoke` | Revoke refresh token | Yes |
| `GET` | `/api/quantity/measurements` | Get all measurements | Yes (JWT) |
| `POST` | `/api/quantity/add` | Add quantities | Yes (JWT) |

---

## Implementation Steps

1. **Configure JWT Settings** — Add `JwtSettings` to `appsettings.json`: `SecretKey`, `Issuer`, `Audience`, `ExpiryMinutes`; register with Options pattern in DI
2. **Implement JwtTokenService** — `GenerateAccessToken(user)`, `ValidateToken(token)`, `GenerateRefreshToken()`
3. **Register JWT Bearer Authentication** — `builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(...)`; add `app.UseAuthentication()` and `app.UseAuthorization()`
4. **Create AuthController** — `POST /register`, `POST /login`, `POST /refresh`, `POST /revoke`
5. **Secure Existing Endpoints** — Add `[Authorize]` to `QuantityMeasurementController`; add role-based policies
6. **Implement Encryption and Hashing Services** — `EncryptionService` (AES-256); `HashingService` (SHA-256, BCrypt wrapper)
7. **Add Security Middleware** — `SecurityHeadersMiddleware`, `RateLimitingMiddleware`; register in `Program.cs`
8. **Configure OAuth 2.0** — Register OAuth 2.0 provider; implement client credentials flow
9. **Write Security Tests** — JWT generation/validation, BCrypt hashing, 401/403 responses, rate limiting, token refresh

---

## Build Commands

```bash
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package BCrypt.Net-Next
dotnet add package System.IdentityModel.Tokens.Jwt
dotnet run                    # Run secured API
dotnet test                   # Run all tests including security tests
```

---

## Preconditions

- All UC1–UC17 functionality is fully operational
- ASP.NET Core WebAPI with all endpoints functional
- ASP.NET Core Identity configured (from UC17)
- Understanding of HTTP authentication headers, JWT structure, OAuth 2.0 flows

## Postconditions

- All API endpoints protected by JWT bearer authentication
- Passwords stored as BCrypt hashes — never plain text
- Sensitive data encrypted at rest with AES-256
- OAuth 2.0 flows implemented for external authorization scenarios
- Token refresh with rotation implemented and tested
- Security headers applied to all HTTP responses
- Rate limiting active on authentication endpoints
- All security-focused MSTest tests passing

---

## License

This project is developed for educational purposes as part of a progressive learning curriculum covering C#, .NET, ASP.NET Core REST APIs, database integration, and enterprise security patterns.
