using System;

namespace Excercise8
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] companyFoo = new Employee[3];
            companyFoo[0] = new Employee("Mister Jecabson", 7.50, 35);
            companyFoo[1] = new Employee("Mister Jochanson", 8.20, 47);
            companyFoo[2] = new Employee("Mister Jason", 10, 73);
            Console.WriteLine("| Employee | Base Pay | Hours Worked | Salary | Instructions |");
            for (int i = 0; i < companyFoo.Length; i++)
            {
                companyFoo[i].Report();
            }

            Console.ReadKey();            
        }
    }
}
