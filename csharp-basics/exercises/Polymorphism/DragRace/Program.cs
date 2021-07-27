using System;
using System.Collections.Generic;
using System.Linq;

namespace DragRace
{
    class Program
    {
        private static void Main(string[] args)
        {

            List<Car> cars = new List<Car>() { new Audi("Papa's Audi"), new Bmw("Mama's Bembis"), new Lexus("Sissy's Lexy"), new Tesla("Bro's Tessy") };
            for (int i = 1; i <= 10; i++) 
            {
                foreach (var car in cars)
                {
                    car.StartEngine();
                    car.SpeedUp();
                    if (i % 3 == 2)
                    {
                        car.UseNitrousOxideEngine();
                    }
                }

            }

            int maxSpeed = 0;
            string maxSpeedCarName = "";
            foreach (var car in cars) 
            {
                Console.WriteLine(car.GetName() + " speed is:" + car.ShowCurrentSpeed());
                if (car.GetSpeed()>maxSpeed)
                {
                    maxSpeed = car.GetSpeed();
                    maxSpeedCarName = car.GetName();
                }
            }
          
            Console.WriteLine($"The fastest is {maxSpeedCarName} with speed of {maxSpeed} km/h");
            Console.ReadKey();
        }
    }
}