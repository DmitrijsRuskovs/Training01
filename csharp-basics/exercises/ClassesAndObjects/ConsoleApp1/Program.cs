using System;
using System.Collections;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("new odometer");
            var fuelGauge = new FuelGauge();
            for (int i = 0; i < 30; i++)
            {
                fuelGauge.Fill();
            }

            fuelGauge.ReportFuelLevel();
            var odometer = new Odometer(fuelGauge);
            Console.WriteLine("running...");
            for (int i = 0; i < 500; i++)
            {
                odometer.IncreaseMileage();
                odometer.ReportMileage();
                fuelGauge.ReportFuelLevel(); 
                if (fuelGauge.GetFuelLevel() == 0)
                {
                    Console.WriteLine("Ooops! Seems, we have run out of fuel...");
                    break;
                }
            }
            Console.ReadKey();
        }        
    }
}
