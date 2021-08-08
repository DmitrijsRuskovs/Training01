using System;
using System.Collections.Generic;
using System.Collections;

namespace Scooters
{
    public class Scooter
    {
        protected string _id;
        public bool IsActive;
        private decimal _pricePerMinute;
        private bool _isRented;
        public DateTime RentalStartTime;
        public DateTime RentalEndTime;   
       
        public Scooter(string id, decimal pricePerMinute)
        {
            _id = id;
            _pricePerMinute = pricePerMinute;
            _isRented = false;
            IsActive = true;
        }  

        public string Id
        {
            get => _id;
            set => _id = value;
        }

        public decimal PricePerMinute
        {
            get => _pricePerMinute;
            set => _pricePerMinute = value;
        }      

        public bool IsRented
        {
            get => _isRented;
            set => _isRented = value;
        }
    }
}
