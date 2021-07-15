using System;

namespace SumAverageRunningInt
{
    class Program
    {
        static void Main(string[] args)
        {
            long sum = 0;

            const int lowerBound = 1;
            const int upperBound = 100;

            for (int number = lowerBound; number <= upperBound; ++number)
            {
                sum += number;
            }
            float average = (float)(lowerBound + upperBound) / 2;
            Console.WriteLine($"The sum of {lowerBound} to {upperBound} is {sum}");
            Console.WriteLine($"The average is {average.ToString("0.0")}");

            Console.ReadKey();
        }
    }
}
