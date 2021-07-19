using System;

namespace Excercise8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of minutes, Liva: ");
            long totalMinutes = Int64.Parse(Console.ReadLine());
            long residualMinutes = totalMinutes % 60;
            long hours = (long)Math.Floor((decimal)totalMinutes / 60) % 24;
            long days = (long)Math.Floor((decimal)totalMinutes / 60 / 24);         
            Console.WriteLine(totalMinutes.ToString() + " minutes comprises:");
            Console.WriteLine(days.ToString() + " full days;");
            Console.WriteLine(hours.ToString() + " full hours;");
            Console.WriteLine(residualMinutes.ToString() + " residual minutes");
            Console.ReadKey();
        }
    }
}
