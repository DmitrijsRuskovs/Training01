using System;

namespace FizzBuzz
{
    class FizzBuzz
    {
        static void Main(string[] args)
        {
            const int numbersPerLine = 20;
            const int lowerBound = 1;
            
            Console.WriteLine("Enter number upto which to FizzBuzz?");
            int higherBound = Convert.ToInt16(Console.ReadLine());

            int currentIndex = lowerBound - 1;
            while (currentIndex < higherBound + 1)
            {
                String numberSetLine = "";
                for (int i = 1; i <= numbersPerLine; i++)
                {
                    currentIndex++;
                    String currentLine = "";
                    if (currentIndex > higherBound) break;
                    if (currentIndex % 3 == 0) currentLine += "Fizz";
                    if (currentIndex % 5 == 0) currentLine += "Buzz";                   
                    if (currentLine.Length == 0) currentLine += currentIndex.ToString();
                    numberSetLine += currentLine + " ";
                }
                Console.WriteLine(numberSetLine);
            }
            Console.ReadKey();
        }
    }
}
