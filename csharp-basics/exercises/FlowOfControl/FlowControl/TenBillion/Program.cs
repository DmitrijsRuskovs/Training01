using System;

namespace TenBillion
{
    class Program
    {
        //TODO Write a C# program that reads an positive integer and count the number of digits the number (less than ten billion) has.
        static void Main(string[] args)
        {
            Console.WriteLine("Input an integer number less than ten billion: ");
            long input;
            var keyboard = Console.ReadLine();
            Int64.TryParse(keyboard, out input);
            if (input < 0||input>10000000000) Console.WriteLine("Please eneter a positive number less or equal to 10 000 000 000");
            else Console.WriteLine($"Your number is {input.ToString().Length} digits long");
            Console.ReadKey();                     
        }
    }
}
