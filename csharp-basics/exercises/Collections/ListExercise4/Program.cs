using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListExercise4
{
    class Program
    {
        private static void Main(string[] args)
        {
            // Create a list and add some colors to the list
            var colors = new List<string>
            {
                "Red",
                "Green",
                "Orange",
                "White",
                "Black"
            };

            colors.Add("Twice orange tham usual orange");
            string element = colors.ElementAt(0);
            Console.WriteLine("First element: " + element);
            element = colors.ElementAt(2);
            Console.WriteLine("Third element: " + element);
            Console.ReadKey();

            //fixme
            //string element = ...;
            //Console.WriteLine("First element: " + element);

            //fixme
            //element = ...;
            //Console.WriteLine("Third element: " + element);
        }
    }
}
