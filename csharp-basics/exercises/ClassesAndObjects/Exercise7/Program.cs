using System;

namespace Exercise7
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog[] doggies = { new Dog("Max","male"), new Dog("Rocky","male"), new Dog("Sparky","male"), new Dog("Buster","male"), new Dog("Sam","male"),
                new Dog("Lady","female"), new Dog("Molly","female"), new Dog("Coco","female"), new Dog("Mylo","bisexual cactus-lover") };
            doggies[0].SetMother(doggies[5]);
            doggies[0].SetFather(doggies[1]);
            doggies[7].SetMother(doggies[6]);
            doggies[7].SetFather(doggies[3]);
            doggies[1].SetMother(doggies[6]);
            doggies[1].SetFather(doggies[4]);
            doggies[3].SetMother(doggies[5]);
            doggies[3].SetFather(doggies[2]);
            foreach (Dog i in doggies)
            {
                Console.Write($"{i.name} is {i.sex} doggy.");
                if (i.HasMother)
                {
                    Console.Write($" {i.name} has a mother {i.GetMother().name}.");
                }
                if (i.HasFather)
                {
                    Console.Write($" {i.name} has a father {i.GetFather().name}.");
                }

                Console.WriteLine();
            }

            if (doggies[7].HasSameMotherAs(doggies[1]))
            {
                Console.WriteLine($" {doggies[7].name} has the same mother as {doggies[1].name}. Its mother's called {doggies[1].GetMotherName()}. So technically they are brothers if they would care about this.");
            }

            Console.ReadKey();            
        }
    }
}
