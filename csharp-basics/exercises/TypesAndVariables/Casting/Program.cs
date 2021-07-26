using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casting
{
    class Program
    {
        static void Main(string[] args)
        {
            first();
            second();
            Console.ReadKey();
        }

        static void first()
        {
            String a = "1";
            int b = 2;
            int c = 3;
            double d = 4;
            float e = 5;
            int sum = Int32.Parse(a) + b + c + (int)Math.Round(d + (double)e);
            Console.WriteLine(sum);
        }

        static void second()
        {
            String a = "1";
            int b = 2;
            int c = 3;
            double d = 4.2;
            float e = 5.3f; 
            float sum = Int32.Parse(a) + b + c + (float)d + e;
            Console.WriteLine(String.Format("{0:0.0}", sum));
        }
    }
}
