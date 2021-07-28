using System;

namespace ArrayX6
{

    public class ArrayReorganization
    {
        public const int arraySize = 10;
        public int[] myArray = new int[arraySize];
        public int[] Array2 = new int[arraySize];

        public ArrayReorganization()
        {
        }

        public void AssembleArrays()
        {
            Random rnd = new Random();

            for (int i = 0; i < arraySize; i++)
            {
                myArray[i] = rnd.Next(arraySize);
            }

            Array.Copy(myArray, Array2, arraySize);
            myArray[arraySize - 1] = -7;
        }

        public void DisplayArrays()
        {

            Console.WriteLine();
            Console.Write($"Array1 is: ");
            for (int i = 0; i < arraySize; i++)
            {
                Console.Write($"{myArray[i]} ");
            }

            Console.WriteLine();
            Console.Write($"Array2 is: ");
            for (int i = 0; i < arraySize; i++)
            {
                Console.Write($"{Array2[i]} ");
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArrayReorganization test = new ArrayReorganization();          
            test.AssembleArrays();
            test.DisplayArrays();
        }
    }
}
