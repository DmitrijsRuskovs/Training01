using System;

namespace CheckOddEven
{
    public class Program
    {
        public static bool IsIntegerOdd(int number)
        {
            return (Math.Abs(number) % 2 == 1);
        }

        static void Main(string[] args)
        {
            Console.Write("Enter number, Liva, please: ");
            int number = Int32.Parse(Console.ReadLine());
            Console.WriteLine(IsIntegerOdd(number) ? "Odd!" : "Even!");          
            Console.WriteLine("Bye!");
            Console.ReadKey();
        }
    }
}
