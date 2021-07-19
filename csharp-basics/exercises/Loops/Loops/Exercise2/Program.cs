using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input power to put number in: ");
            int power = Convert.ToInt32(Console.ReadLine());           
            Console.WriteLine(Pow(number,power));
            Console.ReadKey();
        }

        static int Pow(int number, int times)
        {
            int result = 1;
            for (int i = 1; i<= times; i++) result *= number;           
            return result;
        }
    }
}
