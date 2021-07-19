using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    class Program
    {
        //TODO: Write a C# program to test if an array contains a specific value.
        private static void Main(string[] args)
        {
            int[] myArray =
            {
                1789, 2035, 1899, 1456, 2013,
                1458, 2458, 1254, 1472, 2365,
                1456, 2265, 1457, 2456
            };

            int valueToIdentify = 1456;
            int count = 0;
            for (int i = 0; i < myArray.Length; i++) 
            {
                if (myArray[i] == valueToIdentify) count++;
            }

            if (count>0) Console.WriteLine($"Value {valueToIdentify} appears {count} times!");
            else Console.WriteLine($"Value {valueToIdentify} is not here!");
            Console.ReadKey();
        }
    }
}
