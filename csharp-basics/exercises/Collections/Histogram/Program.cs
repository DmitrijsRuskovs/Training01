using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histogram
{
    class Program
    {
        private const string Path = "../../midtermscores.txt";

        private static void Main(string[] args)
        {
            var readText = File.ReadAllText(Path).Split(' ').ToList();
            string[] histogram = new string[11];
            foreach (var s in readText)
            {
                if (s.Length == 1)
                {
                    histogram[0] += "*";
                }
                else if (s.Length == 3)
                {
                    histogram[10] += "*";
                }
                else
                {
                    histogram[int.Parse(s[0].ToString())] += "*";
                }
            }
            
            for (int i = 0; i < 10;i++)
            {
                Console.WriteLine(i.ToString()+"0-"+ i.ToString()+"9: "+histogram[i]);
            }
            
            Console.WriteLine("  100: " + histogram[10]);
            Console.ReadKey();
        }
    }
}
