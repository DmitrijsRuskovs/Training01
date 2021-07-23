using System;

namespace DateTest
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Date[] dates = { 
                new Date(10,10,2021), 
                new Date(9, 8, 2018), 
                new Date(10, 10, 2014), 
                new Date(10, 10, 2012), 
                new Date(10, 10, 2011), 
                new Date(10, 10, 2008)
            };

            foreach (Date i in dates)
            {
                i.DisplayDate();
            }

            Console.ReadKey();
        }
    }
}
