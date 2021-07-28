using System;
using System.Collections.Generic;

namespace Hierarchy
{

    class Program
    {
        static void Main(string[] args)
        {
            List < Animal > animals = new List<Animal>();
            while (true) 
            {
                Console.WriteLine('\n'+"Enter animal's parameters: ");
                string[] parameters = Console.ReadLine().Split(' ');
                if (parameters[0] == "End") 
                {
                    break;
                }
                else if (parameters[0] == "Cat") 
                {
                    animals.Add(new Cat(parameters[0], parameters[1], double.Parse(parameters[2]), parameters[3], parameters[4]));
                }
                else if (parameters[0] == "Zebra")
                {
                    animals.Add(new Zebra(parameters[0], parameters[1], double.Parse(parameters[2]), parameters[3]));
                }
                else if (parameters[0] == "Tiger") 
                {
                    animals.Add(new Tiger(parameters[0], parameters[1], double.Parse(parameters[2]), parameters[3]));
                }
                else if (parameters[0] == "Mouse") 
                {
                    animals.Add(new Mouse(parameters[0], parameters[1], double.Parse(parameters[2]), parameters[3]));
                }

                animals[animals.Count-1].MakeSound();
                Console.WriteLine("Enter food parameters: ");
                string[] foodParameters = Console.ReadLine().Split(' ');
                if (foodParameters[0] == "Meat") 
                {
                    Meat food = new Meat(int.Parse(foodParameters[1]));
                    animals[animals.Count - 1].Eat(food,food.GetQuantity());
                }
                else if (foodParameters[0] == "Vegetable") 
                {
                    Vegetable food = new Vegetable(int.Parse(foodParameters[1]));
                    animals[animals.Count - 1].Eat(food, food.GetQuantity());
                }

                animals[animals.Count - 1].DisplayInfo();
            }

            foreach (Animal animal in animals) 
            {
                animal.DisplayInfo();
            }
        }
    }
}