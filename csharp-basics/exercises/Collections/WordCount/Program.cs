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
            System.IO.StreamReader file = new System.IO.StreamReader(@"..\..\lear.txt");
            
            int lines = 0;
            int words = 0;
            int wholeWords = 0;
            int characters = 0;
            int totalCharacters = 0;
            string text = "";
            while ((text = file.ReadLine()) != null)
            {
                lines++;
                words++;
                totalCharacters += text.Length;
                for (int i = 0; i < text.Length; i++)
                {                  
                    if (text[i] == ' ')
                    {
                        words++;
                        wholeWords++;
                    }                    
                    else if (text[i] == (char)39)
                    {
                        words++;
                    }
                    else if (Char.IsLetterOrDigit(text[i]))
                    {
                        characters++;
                    }
                }
            }

            Console.WriteLine($"Lines = {lines};\nWords: {words};\nWords without apostrophs: {wholeWords};\nWord Characters: {characters};\nTotal Characters: {totalCharacters}");
            Console.ReadKey();
        }
    }
}
