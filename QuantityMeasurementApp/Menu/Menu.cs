using System;
using QuantityMeasurementApp.Implementation;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Menu
{
    public class Menu
    {
        QuantityMeasurementImpl quantityMeasurementImpl = new QuantityMeasurementImpl();
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("==================== Quantity Measurement Application ====================");

                Console.WriteLine("\n----- Length Operations -----");
                Console.WriteLine("1. Feet Measurement Equality Check");
                Console.WriteLine("2. Inch Measurement Equality Check");
                Console.WriteLine("3. Compare Lengths (Feet , Inch, Yard, Centimeter)");
                Console.WriteLine("4. Convert Length (Unit to Unit)");
                Console.WriteLine("5. Add Length (Unit to Unit)");
                Console.WriteLine("6. Add Length with Target Unit");

                Console.WriteLine("\n----- Weight Operations -----");
                Console.WriteLine("7. Compare Weight (Kilogram,Gram,Pound)");
                Console.WriteLine("8. Convert Weight (Unit to Unit)");
                Console.WriteLine("9. Add Weight (Unit to Unit)");
                Console.WriteLine("10. Add Weight with Target Unit");

                Console.WriteLine("\n11. Exit");

                Console.WriteLine("Enter Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        quantityMeasurementImpl.Feet();
                        break;

                    case 2:
                        quantityMeasurementImpl.Inches();
                        break;

                    case 3:
                        quantityMeasurementImpl.CompareLength();
                        break;

                    case 4:
                        quantityMeasurementImpl.ConvertLength();
                        break;

                    case 5:
                        quantityMeasurementImpl.AddLength();
                        break;

                    case 6:
                        quantityMeasurementImpl.AddLengthWithTargetUnit();
                        break;

                    case 7:
                        quantityMeasurementImpl.CompareWeight();
                        break;

                    case 8:
                        quantityMeasurementImpl.ConvertWeight();
                        break;

                    case 9:
                        quantityMeasurementImpl.AddWeight();
                        break;

                    case 10:
                        quantityMeasurementImpl.AddWeightWithTargetUnit();
                        break;

                    case 11:
                        Console.WriteLine("THANK YOU FOR VISITING");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}