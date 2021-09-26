using System;

namespace CozaLozaWoza
{
    public class Program
    {
        public static string CozaLozaWoza(int number)
        {
            string result = "";
            if (number % 3 == 0)
            {
                result += "Coza";
            }

            if (number % 5 == 0)
            {
                result += "Loza";
            }

            if (number % 7 == 0)
            {
                result += "Woza";
            }

            if (result == "")
            {
                result += number.ToString();
            }

            return result;
        }

        static void Main(string[] args)
        {
            const int numbersPerLine = 11;
            const int lowerBound = 1;
            const int higherBound = 111;
            int currentIndex = lowerBound-1;
            while (currentIndex<higherBound+1)
            {
                string numberSetLine = "";
                for (int i = 1; i <= numbersPerLine; i++)
                {
                    currentIndex++;                   
                    if (currentIndex > higherBound)
                    {
                        break;
                    }
                                      
                    numberSetLine += CozaLozaWoza(currentIndex) + " ";
                }

                Console.WriteLine(numberSetLine);
            }

            Console.ReadKey();
        }
    }
}
