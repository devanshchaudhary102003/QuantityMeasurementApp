## 📅 Date: 21 Febraury 2026

### 📘 Topic
## UC1: Feet Measurement Equality

### Description

The `QuantityMeasurementApp` class is responsible for checking the equality of two numerical values measured in feet within the Quantity Measurement Application.  
It ensures accurate comparisons while handling edge cases such as null values, type mismatches, and floating-point precision issues.

---

## Preconditions

- The `QuantityMeasurementApp` class is instantiated.
- Two numerical values in feet are provided for comparison.

---

## Main Flow

1. The user inputs two numerical values in feet.
2. The application validates that both inputs are numeric.
3. Two `Feet` objects are created.
4. The application compares the two objects using the overridden `equals()` method.
5. The result (true/false) is displayed to the user.

---

## Postconditions

- The equality result (`true` or `false`) is returned based on the comparison of the two values.

---

## Implementation Steps

### Step 1 – Import Necessary Classes
Import required Java classes such as:
- `java.util.Scanner`

---

### Step 2 – Class Design
- Define the main `QuantityMeasurementApp` class.
- Create an inner `Feet` class.
- Use proper access modifiers to maintain encapsulation.

---

### Step 3 – Inner Class Structure
- Create a `Feet` class to represent a feet measurement.
- Store the measurement value as a private final field.
- Ensure immutability by making the field `final`.

---

### Step 4 – Constructor
- Initialize the value field in the constructor.
- Optional: Add validation if required.

---

### Step 5 – Equals Method Implementation
Override the `equals()` method from the `Object` class:

- Check if references are the same → `this == obj`
- Check if object is null
- Check if object type matches using `getClass()`
- Safely cast to `Feet`
- Compare values using `Double.compare()` instead of `==`

---

### Step 6 – Main Method
- Instantiate two `Feet` objects.
- Compare them using the `equals()` method.
- Print the comparison result.

---

## Example Output

Input:
1.0 ft and 1.0 ft

Output:
Equal (true)

---

## Concepts Learned from UC1

### Object Equality
Understanding how to properly override the `equals()` method.

### Floating-Point Comparison
Using `Double.compare()` instead of `==` to avoid precision issues.

### Null Checking
Preventing `NullPointerException` by validating null objects before casting.

### Type Checking
Using `getClass()` to ensure type safety during comparison.

### Object-Oriented Design
Encapsulation of measurement value within a class.

### Unit Testing Best Practices
- One assertion per test (recommended)
- Descriptive test names (Given–When–Then pattern)
- Clear failure messages for debugging

---

## Key Concepts Tested

### Equality Contract (equals() Method)

- **Reflexive:** `a.equals(a)` must return true
- **Symmetric:** If `a.equals(b)` then `b.equals(a)`
- **Transitive:** If `a.equals(b)` and `b.equals(c)` then `a.equals(c)`
- **Consistent:** Multiple calls return the same result
- **Null Handling:** `a.equals(null)` must return false

---

### Type Safety
Objects should only be equal to objects of the same type.  
Prevents `ClassCastException` and logical errors.

---

### Value-Based Equality
Two objects with identical values should be considered equal.  
Different values should result in inequality.

---

### Null Safety
Proper null checks prevent runtime exceptions.  
Object comparison should handle null gracefully.

---

## Test Case Examples

### testEquality_SameValue()
Verifies that two values of `1.0 ft` are equal.  
Expected Result: `true`

---

### testEquality_DifferentValue()
Verifies that `1.0 ft` and `2.0 ft` are not equal.  
Expected Result: `false`

---

### testEquality_NullComparison()
Verifies that a value is not equal to `null`.  
Expected Result: `false`

---

### testEquality_NonNumericInput()
Verifies that non-numeric inputs are handled properly.  
Expected Result: Validation failure or `false`

---

### testEquality_SameReference()
Verifies reflexive property (`a.equals(a)`).  
Expected Result: `true`

---

## Code Snippet

- `QuantityMeasurementApp`
- `QuantityMeasurementAppTest`

## Project Structure

QuantityMeasurementApp  
├── Models  
│   └── Feet.cs  
├── Services  
│   └── FeetServices.cs  
├── Program.cs  
└── QuantityMeasurementApp.Tests  
    └── FeetTests.cs  
