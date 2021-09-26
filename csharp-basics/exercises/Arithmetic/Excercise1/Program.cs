using System;

namespace Exercise1
{
    public class Program
    {
        public static bool ReturnFifteens(int number1, int number2)
        {
            return (number1 == 15 || number2 == 15 || (number1 - number2) == 15 || (number2 - number1) == 15 || number1 + number2 == 15);
        }

        static void Main()
        {
            Console.Write("Enter first number, Liva, please: ");
            int number1 = Int32.Parse(Console.ReadLine());
            Console.Write("Enter second number, Liva, please: ");
            int number2 = Int32.Parse(Console.ReadLine());                            
            Console.WriteLine(ReturnFifteens(number1,number2));
            Console.ReadKey();
        }
    }
}
