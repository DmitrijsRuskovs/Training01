using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public class Program
    {
        public static Dictionary<string, int> textAttributes(string text)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            int totalCharacters = text.Length;
            int words = 0;
            int wholeWords = 0;
            int characters = 0;
            int lines = 0;
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
                else if (text[i] == '\n') lines++;
            }

            if (words > 0)
            {
                words++;
                lines++;
            }

            result.Add("Total Characters", totalCharacters);
            result.Add("Lines", lines);
            result.Add("Words", words);
            result.Add("Whole Words", wholeWords);
            result.Add("Letter and Digit characters", characters);
            return result;
        }

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
                lines += textAttributes(text)["Lines"];
                wholeWords += textAttributes(text)["Whole Words"];
                words += textAttributes(text)["Words"];
                characters += textAttributes(text)["Letter and Digit characters"];
                totalCharacters += textAttributes(text)["Total Characters"];
            }

            Console.WriteLine($"Lines = {lines};\nWords: {words};\nWords without apostrophs: {wholeWords};\nWord Characters: {characters};\nTotal Characters: {totalCharacters}");
            Console.ReadKey();
        }
    }
}
