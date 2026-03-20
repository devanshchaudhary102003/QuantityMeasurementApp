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
                Console.WriteLine("1. Feet Measurement Equality Check");
                Console.WriteLine("2. Exit");

                Console.WriteLine("Enter Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        quantityMeasurementImpl.Feet();
                        break;

                    case 2:
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