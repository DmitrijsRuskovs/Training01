using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products = { new Product("Logitech rat", 70.0, 14), new Product("aifouns 5s", 999.99, 3), new Product("Epson EB-U05", 440.46, 1)};
            foreach (Product i in products)
            {
                i.PrintProduct();
                i.SetPrice(5.0);
                i.SetQuantity(5);
                i.PrintProduct();
            }

            Console.ReadKey();         
        }
    }
}
