using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListExercise11
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Create an List with string elements
            var elements = new List<string>() {"first","second" };

            //TODO: Add 10 values to list
            elements.Add("third");
            elements.Add("4th");
            elements.Add("5th");
            elements.Add("6th");
            elements.Add("7th");
            elements.Add("8th");
            elements.Add("9th");
            elements.Add("10th");
            elements.Add("11th");
            elements.Add("12th");
            elements[4] = "another value at 5th position";
            elements[elements.Count-1] = "another value at last position";
            elements.Sort();

            if (elements.Contains("Foobar"))
            {
                Console.WriteLine("Foobar is here!");
            }
            else
            {
                Console.WriteLine("No time for Foobars!");
            }

            foreach (var i in elements)
            {
                Console.Write(i+", ");
            }

            Console.ReadKey();
        }
    }
}
