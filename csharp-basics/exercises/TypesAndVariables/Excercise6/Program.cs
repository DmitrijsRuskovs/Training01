using System;

namespace Excercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many variables are You going to sum, Liva: ");
            int count = Int32.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < count; i++)
            {
                Console.Write("Liva, enter number #"+(i+1).ToString()+":  ");
                int number=Int32.Parse(Console.ReadLine());
                sum += number;
            }

            Console.WriteLine("Sum of all Your numbers seems to be "+sum.ToString());
            Console.ReadKey();
        }
    }
}
