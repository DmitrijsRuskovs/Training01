using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListExercise1
{
    class Program
    {
        private static void Main(string[] args)
        {
            //TODO: Write a C# program to create a new list, add some elements (string) and print out the collection.
            List<string> colors = new List<string>();

            //TODO: Add 5 colors to list
            colors.Add("Red");
            colors.Add("Color of the Sky");
            colors.Add("Color of Grass");
            colors.Add("Color of Lemon");
            colors.Add("Color of Orange, but not orange");

            foreach (var i in colors)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
