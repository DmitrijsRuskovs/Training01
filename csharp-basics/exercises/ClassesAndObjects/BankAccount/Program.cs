using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount[] accounts = {new BankAccount("Mister Jecabson",-17.567,0.5), new BankAccount("Sister Mary", 17, 0.5),
                new BankAccount("Bill Gates", 120000000, 5), new BankAccount("Valera",-1000.5,0.5)};
            foreach (BankAccount i in accounts)
            {
                Console.WriteLine(i.ShowUserNameAndBalance());
            }
            Console.ReadKey();
        }
    }
}
