using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {           
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\albin\source\repos\Training01\csharp-basics\exercises\Collections\WordCount\lear.txt");
            
            int lines = 0;
            int words = 0;
            int characters = 0;
            string text = "";
            while ((text = file.ReadLine()) != null)
            {
                lines++;
                words++;
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == ' '|| text[i] == (char)39)
                    {
                        words++;
                    }
                    
                    if (Char.IsLetterOrDigit(text[i]))
                    {
                        characters++;
                    }
                }
            }

            Console.WriteLine($"Lines = {lines}; Words: {words}; Chars: {characters}");
            Console.ReadKey();
        }
    }
}
