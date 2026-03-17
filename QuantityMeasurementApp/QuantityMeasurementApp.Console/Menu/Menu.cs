using QuantityMeasurementApp.Console.Controller;
using QuantityMeasurementAppBusinessLayer.Interface;
using QuantityMeasurementAppModelLayer.DTOs;

namespace QuantityMeasurementApp.Console.Menu
{
    public class Menu
    {
        public  IQuantityMeasurementService _controller;

        public Menu(IQuantityMeasurementService controller)
        {
            _controller = controller;
        }

        public void Show()
        {
            while (true)
            {
                System.Console.WriteLine("\n===== Quantity Measurement Menu =====");
                System.Console.WriteLine("1. Compare Quantities");
                System.Console.WriteLine("2. Add Quantities");
                System.Console.WriteLine("3. Show History");
                System.Console.WriteLine("4. Exit");
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
                        ShowHistory();
                        break;
                    case "4":
                        System.Console.WriteLine("Exiting application...");
                        return;
                    default:
                        System.Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void CompareFlow()
        {
            var first = ReadQuantity("First");
            var second = ReadQuantity("Second");

            bool result = _controller.Compare(first, second);
            System.Console.WriteLine($"Comparison Result: {result}");
        }

        private void AddFlow()
        {
            var first = ReadQuantity("First");
            var second = ReadQuantity("Second");

            var result = _controller.Add(first, second);
            System.Console.WriteLine($"Addition Result: {result.BaseValue} {result.Unit}");
        }

        private void ShowHistory()
        {
            var history = _controller.GetHistory();

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
            string category = System.Console.ReadLine() ?? "";

            System.Console.Write("Unit: ");
            string unit = System.Console.ReadLine() ?? "";

            System.Console.Write("Value: ");
            double value = Convert.ToDouble(System.Console.ReadLine());

            return new QuantityDTO
            {
                Category = category,
                Unit = unit,
                Value = value
            };
        }
    }
}