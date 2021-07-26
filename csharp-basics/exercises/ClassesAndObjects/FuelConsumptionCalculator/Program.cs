using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelConsumptionCalculator
{
    class Program
    {
        private static void Main(string[] args)
        {
            int startKilometers;
            int liters;
            
            Console.WriteLine();

            Car car = new Car(0);
            Car car1 = new Car(0);
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Car 1 Enter first reading: ");
                startKilometers = Convert.ToInt32(Console.ReadLine());    
                Console.Write("Car 1 Enter liters reading: ");
                liters = Convert.ToInt32(Console.ReadLine());
                car.FillUp(startKilometers, liters);
                
                Console.Write("Car 2 Enter first reading: ");
                startKilometers = Convert.ToInt32(Console.ReadLine());    
                Console.Write("Car 2 Enter liters reading: ");
                liters = Convert.ToInt32(Console.ReadLine());
                car1.FillUp(startKilometers, liters);
            }

            Console.WriteLine("Car1 consumption in L/100km is " + car.ConsumptionPer100Km() + " gasHog:" + car.GasHog());
            Console.WriteLine("Car2 consumption in L/100km is " + car1.ConsumptionPer100Km() + " economyCar:" + car1.EconomyCar());
            Console.ReadKey();
        }
    }
}
