using System;

namespace Excercise9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter distance in meters, Liva: ");
            long distance = Int64.Parse(Console.ReadLine());
            Console.Write("Enter hours, Liva: ");
            int hours = Int32.Parse(Console.ReadLine());
            Console.Write("Enter minutes, Liva: ");
            int minutes = Int32.Parse(Console.ReadLine());
            Console.Write("Enter seconds, Liva: ");
            int seconds = Int32.Parse(Console.ReadLine());
            
            
            double speedMS = (double)distance / ((double)hours *60*60+ (double)minutes *60+ (double)seconds);
            double speedKmH = (double)distance / 1000 / ((double)hours + (double)minutes /60 + (double)seconds /3600);
            double speedMH = (double)distance / 1609 / ((double)hours + (double)minutes / 60 + (double)seconds / 3600);


            Console.WriteLine("Your speed in meters / second is: " + String.Format("{0:0.00}", speedMS));
            Console.WriteLine("Your speed in km / h is: " + String.Format("{0:0.00}", speedKmH));
            Console.WriteLine("Your speed in miles / h is: " + String.Format("{0:0.00}", speedMH));
           
            Console.ReadKey();
        
        }
    }
}
