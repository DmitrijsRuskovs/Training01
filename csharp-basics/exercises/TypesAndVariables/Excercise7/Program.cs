using System;

namespace Excercise7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please, enter a word, Liva: ");
            String word = Console.ReadLine();
            String lowerWord = word.ToLower();
            int sum = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i]!=lowerWord[i]) sum ++;
            }
            Console.WriteLine("There are " + sum.ToString()+" capitals in Your word, Liva");

            Console.ReadKey();
        }
    }
}
