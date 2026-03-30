using QuantityMeasurementApp.Console.Controller;
using QuantityMeasurementApp.Console.Interface;
using QuantityMeasurementAppBusinessLayer.Exception;
using QuantityMeasurementAppModelLayer.DTOs;
using QuantityMeasurementAppModelLayer.Enums;

namespace QuantityMeasurementApp.Console.Menu
{
    public class Menu : IMenu
    {
        private readonly QuantityMeasurementController _controller;

        public Menu(QuantityMeasurementController controller)
        {
            _controller = controller;
        }

        public void Show()
        {
            while (true)
            {
                try
                {
                    System.Console.WriteLine("\n===== Quantity Measurement Menu =====");
                    System.Console.WriteLine("1. Compare Quantities");
                    System.Console.WriteLine("2. Add Quantities");
                    System.Console.WriteLine("3. Subtract Quantities");
                    System.Console.WriteLine("4. Multiply Quantity");
                    System.Console.WriteLine("5. Divide Quantity");
                    System.Console.WriteLine("6. Convert Quantity");
                    System.Console.WriteLine("7. Show History");
                    System.Console.WriteLine("8. Exit");
                    System.Console.Write("Enter your choice: ");

                    string? choice = System.Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            CompareFlow();
                            break;
                        case "2":
                            AddFlow();
                            break;
                        case "3":
                            SubtractFlow();
                            break;
                        case "4":
                            MultiplyFlow();
                            break;
                        case "5":
                            DivideFlow();
                            break;
                        case "6":
                            ConvertFlow();
                            break;
                        case "7":
                            ShowHistory();
                            break;
                        case "8":
                            System.Console.WriteLine("Exiting application...");
                            return;
                        default:
                            System.Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (QuantityMeasurementException ex)
                {
                    System.Console.WriteLine($"Error: {ex.Message}");
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("Error: Please enter numeric values correctly.");
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine($"Unexpected error: {ex.Message}");
                }
            }
        }

        private void CompareFlow()
        {
            var first = ReadQuantity("First");
            var second = ReadQuantity("Second");

            bool result = _controller.CompareQuantities(first, second);
            System.Console.WriteLine($"Comparison Result: {result}");
        }

        private void AddFlow()
        {
            var first = ReadQuantity("First");
            var second = ReadQuantity("Second");

            var result = _controller.AddQuantities(first, second);
            PrintResult("Addition", result);
        }

        private void SubtractFlow()
        {
            var first = ReadQuantity("First");
            var second = ReadQuantity("Second");

            var result = _controller.SubtractQuantities(first, second);
            PrintResult("Subtraction", result);
        }

        private void MultiplyFlow()
        {
            var quantity = ReadQuantity("Input");
            System.Console.Write("Enter factor: ");
            double factor = Convert.ToDouble(System.Console.ReadLine());

            var result = _controller.MultiplyQuantity(quantity, factor);
            PrintResult("Multiplication", result);
        }

        private void DivideFlow()
        {
            var quantity = ReadQuantity("Input");
            System.Console.Write("Enter divisor: ");
            double divisor = Convert.ToDouble(System.Console.ReadLine());

            var result = _controller.DivideQuantity(quantity, divisor);
            PrintResult("Division", result);
        }

        private void ConvertFlow()
        {
            var quantity = ReadQuantity("Input");
            ShowUnitsForCategory(quantity.Category);
            System.Console.Write("Enter target unit: ");
            string targetUnit = System.Console.ReadLine() ?? string.Empty;

            var result = _controller.ConvertQuantity(quantity, targetUnit);
            PrintResult("Conversion", result);
        }

        private void ShowHistory()
        {
            var history = _controller.GetAllHistory();

            if (history.Count == 0)
            {
                System.Console.WriteLine("No history found.");
                return;
            }

            foreach (var item in history)
            {
                System.Console.WriteLine($"Id: {item.Id}, Value: {item.Value}, Unit: {item.Unit}, Category: {item.Category}");
            }
        }

        private QuantityDTO ReadQuantity(string label)
        {
            System.Console.WriteLine($"\nEnter {label} Quantity Details");
            System.Console.Write("Category (Length/Weight/Volume/Temperature): ");
            string category = System.Console.ReadLine() ?? string.Empty;

            ShowUnitsForCategory(category);
            System.Console.Write("Unit: ");
            string unit = System.Console.ReadLine() ?? string.Empty;

            System.Console.Write("Value: ");
            double value = Convert.ToDouble(System.Console.ReadLine());

            return new QuantityDTO
            {
                Category = category,
                Unit = unit,
                Value = value
            };
        }

        private void ShowUnitsForCategory(string category)
        {
            string normalized = category.Trim().ToLower();

            string units = normalized switch
            {
                "length" => string.Join(", ", Enum.GetNames(typeof(LengthUnit))),
                "weight" => string.Join(", ", Enum.GetNames(typeof(WeightUnit))),
                "volume" => string.Join(", ", Enum.GetNames(typeof(VolumeUnit))),
                "temperature" => string.Join(", ", Enum.GetNames(typeof(TemperatureUnit))),
                _ => ""
            };

            if (!string.IsNullOrWhiteSpace(units))
                System.Console.WriteLine($"Available Units: {units}");
        }

        private void PrintResult(string operationName, QuantityDTO result)
        {
            System.Console.WriteLine($"{operationName} Result: {result.Value} {result.Unit} ({result.Category})");
        }
    }
}