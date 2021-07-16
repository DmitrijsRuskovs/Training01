using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class Program
    {
        //TODO: Write a C# program to find the index of an array element.
        private static void Main(string[] args)
        {
            int[] myArray = {25, 14, 56, 15, 36, 56, 77, 18, 29, 49};

            Console.WriteLine($"Index position of 36 is: {Array.IndexOf(myArray,36)}");
            Console.WriteLine($"Index position of 29 is: {Array.IndexOf(myArray, 29)}");

            Console.ReadKey();
        }
    }
}
