using System;
namespace Exercise1
{
    public class Product
    {
        private double _price=0;
        private int _amount = 0;
        private string _name = "";

        public Product(string name, double priceAtStart, int amountAtStart)
        {
            this._price = priceAtStart;
            this._name = name;
            this._amount = amountAtStart;
        }

        public void SetQuantity(int quantity)
        {
            this._amount = quantity;
        }

        public int GetQuantity()
        {
            return this._amount;
        }

        public string GetName()
        {
            return this._name;
        }

        public void SetPrice(double price)
        {
            this._price = price;
        }

        public double GetPrice()
        {
            return this._price;
        }

        public double GetWholeStockPrice()
        {
            return this._price* this._amount;
        }


        public string PrintProduct()
        {
            return $"{this._name}, price: {this._price} EUR, amount: {this._amount} units";
        }
    }
}
