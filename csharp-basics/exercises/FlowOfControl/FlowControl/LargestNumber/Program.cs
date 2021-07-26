using System;

namespace LargestNumber
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int input1, input2, input3;
            Console.WriteLine("Input the 1st number: ");
            var keyboard = Console.ReadLine();
            Int32.TryParse(keyboard, out input1);
            Console.WriteLine("Input the 2nd number: ");
            keyboard = Console.ReadLine();
            Int32.TryParse(keyboard, out input2);
            Console.WriteLine("Input the 3rd number: ");
            keyboard = Console.ReadLine();
            Int32.TryParse(keyboard, out input3);
            int largest = input1;
            if (input2 > largest)
            {
                largest = input2;
            }

            if (input3 > largest)
            {
                largest = input3;
            }

            Console.WriteLine($"The largest number is {largest}");
            Console.ReadKey();
        }
    }
}
