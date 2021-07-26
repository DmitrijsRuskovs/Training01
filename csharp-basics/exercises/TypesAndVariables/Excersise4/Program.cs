using System;

namespace Excersise4
{
    class Program
    {
        static void Main(string[] args)
        {          
            Console.Write("Enter the way Your Mother calls You for dinner: ");
            String name = Console.ReadLine();
            Console.Write("Enter Your birth year: ");
            int year = Convert.ToInt32(Console.ReadLine());           
            Console.WriteLine($"My name is {name} and I was born in {year}.");
            Console.ReadKey();
        }
    }
}
