namespace Hierarchy
{
    public abstract class Food
    {
        protected int _quantity;

        protected Food()
        {
            _quantity = 0;
        }

        protected Food(int quantity)
        {
            _quantity = quantity;
        }

        public int GetQuantity()
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

        public Vegetable(int quantity)
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

        public Meat(int quantity)
        {
            this._quantity = quantity;
        }

        public override string FoodType()
        {
            return "Meat";
        }
    } 
}