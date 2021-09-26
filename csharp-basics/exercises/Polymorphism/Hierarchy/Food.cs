namespace Hierarchy
{
    public abstract class Food
    {
        protected double _quantity;

        protected Food()
        {
            _quantity = 0;
        }

        protected Food(double quantity)
        {
            _quantity = quantity;
        }

        public void Eaten(double foodEaten)
        {
            if (_quantity>= foodEaten) 
            {
                _quantity -= foodEaten;
            }
            else 
            {
                _quantity = 0;
            }
        }

        public double GetQuantity()
        {
            return this._quantity;
        }

        public abstract string FoodType();
    }

    public class Vegetable : Food
    {
        public Vegetable()
        {
            this._quantity = 0;
        }

        public Vegetable(double quantity)
        {
            this._quantity = quantity;
        }

        public override string FoodType()
        {
            return "Vegetable";
        }
}

    public class Meat : Food
    {
        public Meat()
        {
            this._quantity = 0;
        }

        public Meat(double quantity)
        {
            this._quantity = quantity;
        }

        public override string FoodType()
        {
            return "Meat";
        }
    } 
}