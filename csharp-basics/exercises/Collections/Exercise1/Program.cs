using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    class Program
    {
        /**
           * Origination:
           * Audi -> Germany
           * BMW -> Germany
           * Honda -> Japan
           * Mercedes -> Germany
           * VolksWagen -> Germany
           * Tesla -> USA
           */

        private static void Main(string[] args)
        {
            string[] array = { "Audi", "BMW", "Honda", "Mercedes", "VolksWagen", "Mercedes", "Tesla" };

            List<string> myList = new List<string>() { "Audi", "BMW", "Honda", "Mercedes", "VolksWagen", "Mercedes", "Tesla" };
            foreach (var i in myList)
            {
                Console.WriteLine(i);
            }

            Hashtable myHashTable = new Hashtable()
            {
                {"Audi","Germany"}, {"BMW","Germany"}, {"Honda","Japan"}, {"Mercedes","Germany"},{"VolksWagen","Germany"}, {"Tesla","USA"}
            };

            foreach (DictionaryEntry i in myHashTable)
            {
                Console.WriteLine(i.Key+" "+i.Value);
            }

            Dictionary<string,string> myDictionary= new Dictionary<string, string>()
            {
                {"Audi","Germany"}, {"BMW","Germany"}, {"Honda","Japan"}, {"Mercedes","Germany"},{"VolksWagen","Germany"}, {"Tesla","USA"}
            };

            foreach (KeyValuePair<string, string> i in myDictionary)
            {
                Console.WriteLine(i.Key + " " + i.Value);
            }

            Console.ReadKey();

            //todo - replace array with an List and print out the results

            //todo - replace array with a HashSet and print out the results

            //todo - replace array with a Dictionary (use brand as key and origination as value) and print out the results
        }
    }
}
