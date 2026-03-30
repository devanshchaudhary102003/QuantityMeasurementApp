using System;
using QuantityMeasurementApp.Implementation;

namespace QuantityMeasurementApp.Menu
{
    public class Menu
    {
        QuantityMeasurementImpl service = new QuantityMeasurementImpl();

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\n==== Quantity Measurement ====");
                Console.WriteLine("1. Compare");
                Console.WriteLine("2. Convert");
                Console.WriteLine("3. Add");
                Console.WriteLine("4. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        service.HandleCompare();
                        break;

                    case 2:
                        service.HandleConvert();
                        break;

                    case 3:
                        service.HandleAdd();
                        break;

                    case 4:
                        Console.WriteLine("THANK YOU");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}