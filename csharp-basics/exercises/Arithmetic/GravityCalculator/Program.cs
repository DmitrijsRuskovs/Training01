
using System;

namespace GravityCalculator
{
    public class Program
    {
        public static double FreeFallPosition(double InitialPosition, double InitialVelocity, double FallingTime)
        {
            double gravity = 9.81;
            double result = InitialPosition - InitialVelocity * FallingTime - gravity * FallingTime * FallingTime / 2;
            return (result >= 0) ? result : 0; 
        }

        static void Main(string[] args)
        {            
            double initialVelocity = -5.0;
            double fallingTime = 10.0;
            double initialPosition = 1000.0;          
            Console.WriteLine("The object's position after " + fallingTime.ToString("0.0") + 
                " seconds is " + FreeFallPosition(initialPosition, initialVelocity, fallingTime).ToString("0.0") + " m.");
            Console.ReadKey();
        }
    }
}
