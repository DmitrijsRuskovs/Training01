using System;

namespace MoreVariablesAndPrinting
{
    class Program
    {
        static void Main(string[] args)
        {
            String name = "Zed A. Shaw";
            int age = 35;
            double height = 74 * 2.54;
            double weight = 180 * 0.453592;
            String eyes = "Blue";
            String teeth = "White";
            String hair = "Brown";
            Console.WriteLine("Let's talk about " + name + ".");
            Console.WriteLine("He's " + String.Format("{0:0.00}", height) + " cm tall.");
            Console.WriteLine("He's " + String.Format("{0:0.00}", weight) + " kg heavy.");
            Console.WriteLine("Actually, that's not too heavy.");
            Console.WriteLine("He's got " + eyes + " eyes and " + hair + " hair.");
            Console.WriteLine("His teeth are usually " + teeth + " depending on the coffee.");
            Console.WriteLine("If I add " + age + ", " + String.Format("{0:0.00}", height) + ", and " + String.Format("{0:0.00}", weight) + " I get " + String.Format("{0:0.00}", age + height + weight) + ".");
            Console.ReadKey();
        }
    }
}