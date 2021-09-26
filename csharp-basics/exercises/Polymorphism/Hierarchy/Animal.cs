using System;

namespace Hierarchy
{

    public abstract class Animal
    {
        protected string _animalName;
        protected string _animalType;
        protected double _animalWeight;
        protected double _foodEaten;

        protected Animal(string Name, string Type, double Weight)
        {
            _animalName = Name;
            _animalType = Type;
            _animalWeight = Weight;
        }

        public abstract void MakeSound();

        public abstract void Eat(Food food, double foodEaten);

        public abstract void DisplayInfo();

        public string GetName()
        {
            return _animalName;
        }

        public string GetType()
        {
            return _animalType;
        }

        public double GetWeight()
        {
            return _animalWeight;
        }

        public abstract string GetLivingRegion();

    }

    public abstract class Mammal : Animal
    {
        protected string _livingRegion;

        protected Mammal(string Name, string Type, double Weight, string LivingRegion) : base(Name, Type, Weight)
        {
            _livingRegion = LivingRegion;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"{_animalName} [{_animalType}, {_animalWeight}, {_livingRegion}, {_foodEaten}]");
        }

        public override string GetLivingRegion()
        {
            return _livingRegion;
        }
    }
    
    public abstract class Felime : Mammal
    {
        protected Felime(string Name, string Type, double Weight, string LivingRegion) : base(Name, Type, Weight, LivingRegion)
        {          
        }
    }

    public class Cat : Felime
    {
        private string _breed;

        public Cat(string Name, string Type, double Weight,string LivingRegion, string Breed) : base(Name, Type, Weight, LivingRegion)
        {
            _breed = Breed;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"{_animalName} [{_animalType}, {_breed}, {_animalWeight}, {_livingRegion}, {_foodEaten}]");
        }

        public override void MakeSound()
        {
            Console.WriteLine("Meowwww");
            Console.Beep(1000, 1000);
        }

        public override void Eat(Food food, double foodEaten)
        {
            if (food.FoodType() == "Vegetable" || food.FoodType() == "Meat") 
            {
                foodEaten = (food.GetQuantity() >= foodEaten) ? foodEaten : food.GetQuantity();
                this._foodEaten += foodEaten;
                _animalWeight += foodEaten;
                food.Eaten(foodEaten);
            }
            else 
            {
                Console.WriteLine(this._animalName + "s are not eating that type of food");
            }
        }

        public string GetBreed()
        {
            return _breed;
        }
    }

    public class Tiger : Felime
    {
        private string _breed;

        public Tiger(string Name, string Type, double Weight, string LivingRegion) : base(Name, Type, Weight, LivingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("ROAAR!!!");
            Console.Beep(200, 1000);
        }

        public override void Eat(Food food, double foodEaten)
        {
            if (food.FoodType() == "Meat") 
            {
                foodEaten = (food.GetQuantity() >= foodEaten) ? foodEaten : food.GetQuantity();
                this._foodEaten += foodEaten;
                _animalWeight += foodEaten;
                food.Eaten(foodEaten);
            }
            else 
            {
                Console.WriteLine(this._animalName + "s are not eating that type of food");
            }
        }
    }

    public class Mouse : Mammal
    {
        public Mouse(string Name, string Type, double Weight, string LivingRegion) : base(Name, Type, Weight, LivingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("piiiiiiiii...piii");
            Console.Beep(6000, 1000);
        }
        
        public override void Eat(Food food, double foodEaten)
        {
            if (food.FoodType() == "Vegetable") 
            {
                foodEaten = (food.GetQuantity() >= foodEaten) ? foodEaten : food.GetQuantity();
                this._foodEaten += foodEaten;
                _animalWeight += foodEaten;
                food.Eaten(foodEaten);
            }
            else 
            {
                Console.WriteLine(this._animalName + "s are not eating that type of food");
            }
        }
    }

    public class Zebra : Mammal
    {
        public Zebra(string Name, string Type, double Weight, string LivingRegion) : base(Name, Type, Weight, LivingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Prrr...Frrrr.....");
            Console.Beep(300, 1000);
        }

        public override void Eat(Food food, double foodEaten)
        {
            if (food.FoodType() == "Vegetable") 
            {
                foodEaten = (food.GetQuantity() >= foodEaten) ? foodEaten : food.GetQuantity();
                this._foodEaten += foodEaten;
                _animalWeight += foodEaten;
                food.Eaten(foodEaten);
            }
            else 
            {
                Console.WriteLine(this._animalName + "s are not eating that type of food");
            }
        }
    }
}