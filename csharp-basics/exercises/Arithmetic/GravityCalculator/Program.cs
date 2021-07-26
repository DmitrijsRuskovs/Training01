
using System;

namespace GravityCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double gravity = -9.81;  // Earth's gravity in m/s^2
            double initialVelocity = 0.0;
            double fallingTime = 10.0;
            double initialPosition = 0.0;
            double finalPosition = initialPosition + initialVelocity * fallingTime + gravity * fallingTime * fallingTime / 2;
            Console.WriteLine("The object's position after " + fallingTime.ToString("0.0") + " seconds is " + finalPosition.ToString("0.0") + " m.");
            Console.ReadKey();
        }
    }
}
