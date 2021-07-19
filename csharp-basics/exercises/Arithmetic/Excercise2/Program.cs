using System;

namespace CheckOddEven
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number, Liva, please: ");
            int number = Int32.Parse(Console.ReadLine());
            if (number % 2 == 1) Console.WriteLine("Odd!");
            else Console.WriteLine("Even!");
            Console.WriteLine("Bye!");
            Console.ReadKey();
        }
    }
}
