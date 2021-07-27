using System;

namespace Persons
{
    

    class Program
    {
        static void Main(string[] args)
        {
            Student Valera = new Student(6.7, "Valera", "Samokatov", "Strelnieku laukums 1");
            Employee SanSanych = new Employee("Rain-stopper", "Aleksandrs", "Holodilnikov", "Strelnieku laukums 2");
            Valera.Display();
            SanSanych.Display();
            Console.ReadKey();
        }
    }
}