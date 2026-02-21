## 📅 Date: 21 Febraury 2026

### 📘 Topic
## UC2: Feet and Inches Measurement Equality

### Description
This use case extends **UC1** by adding an equality check for **Inches** along with **Feet**.  
**Important:** UC2 does **not** compare Feet with Inches. Both units are still compared separately (Feet vs Feet, Inches vs Inches).  
Test cases must ensure complete coverage and handle edge cases correctly.

---

## Preconditions
- The `QuantityMeasurementApp` application is instantiated.
- Two numerical values in **feet** and two numerical values in **inches** are provided (hard-coded or input-based) for comparison.

---

## Main Flow
1. The main method calls a dedicated method to validate and compare two **Feet** values.
2. The main method calls a dedicated method to validate and compare two **Inches** values.
3. Each method internally:
   - Creates objects of `Feet` or `Inches`.
   - Validates inputs to ensure they are numeric.
   - Compares the two values using the equality method (`Equals` / `equals()`).
4. The comparison result is returned and displayed to the user.

---

## Postconditions
- The equality result (`true` / `false`) is returned based on the comparison.
- Both comparisons are supported:
  - **Feet-to-Feet**
  - **Inches-to-Inches**

---

## Implementation Notes (High-Level)
### Step 1
Create an `Inches` class similar to the `Feet` class (value object design).

### Step 2
Create test scenarios for Inches:
- Same value → should be equal
- Different value → should not be equal

### Step 3
Reduce dependency on `Main()` by creating separate methods:
- `CheckFeetEquality()`
- `CheckInchesEquality()`

---

## Example Output
Input: `1.0 inch` and `1.0 inch`  
Output: `Equal (true)`

Input: `1.0 ft` and `1.0 ft`  
Output: `Equal (true)`

---

## Concepts Learned (UC2)
Concepts are similar to UC1:
- Object Equality
- Floating-point Comparison
- Null Checking
- Type Checking
- Encapsulation using value objects

---

## Key Concepts Tested
Similar to UC1:
- Equality Contract (reflexive, symmetric, transitive, consistent, null-safe)
- Type Safety
- Value-Based Equality
- Null Safety

---

## Test Case Examples
- `testEquality_SameValue()`
- `testEquality_DifferentValue()`
- `testEquality_NullComparison()`
- `testEquality_NonNumericInput()`
- `testEquality_SameReference()`

---

## Design Note: Disadvantage of Separate Feet & Inches Classes
Using separate `Feet` and `Inches` classes can violate the **DRY (Don't Repeat Yourself)** principle because both classes often contain duplicated logic:
- Same constructor pattern
- Identical equality method
- Same value field and validation logic

This duplication increases maintenance effort and bug risk, because updates must be applied to both classes.

### Better Approach (Recommended)
Create a reusable abstraction to remove duplication, for example:
- A generic `Quantity<TUnit>` class, or
- A single `Measurement` class with a unit type (Feet/Inches), or
- A shared base class / interface for common comparison behavior

- ## Project Structure (UC2 – Feet & Inches Equality)

QuantityMeasurementApp  
│  
├── Models  
│   ├── Feet.cs  
│   └── Inches.cs  
│  
├── Services  
│   ├── FeetServices.cs  
│   └── InchesServices.cs  
│  
├── Program.cs  
│  
└── QuantityMeasurementApp.Tests  
    ├── FeetTests.cs  
    └── InchesTests.cs  

