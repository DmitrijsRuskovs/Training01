using System;
using System.Collections.Generic;
using System.Collections;

namespace Scooters
{
    public class Scooter
    {
        private string _id;
        private decimal _pricePerMinute;
        private bool _isRented;
        DateTime _rentalStartTime;
        DateTime _rentalEndTime;
        List<RentalData> _rentalHistory = new List<RentalData>();
        private const int MINUTES_IN_DAY = 1440;
        private const int MAXIMUM_RENT_SUM_PER_DAY = 20;

        struct RentalData
        {
            public DateTime StartTime;
            public DateTime EndTime;
            public int Year;
            public decimal PriceForWholeRentalPeriod;

            public RentalData(DateTime startTime, DateTime endTime, decimal priceForWholeRentalPeriod)
            {
                StartTime = startTime;
                EndTime = endTime;
                PriceForWholeRentalPeriod = priceForWholeRentalPeriod;
                Year = endTime.Year;
            }
        }      
       
        public Scooter(string id, decimal pricePerMinute)
        {
            _id = id;
            _pricePerMinute = pricePerMinute;
            _isRented = false;
        }

        public decimal GetLastRentalEntryPrice()
        {
            return _rentalHistory[_rentalHistory.Count - 1].PriceForWholeRentalPeriod;
        }

        public void AddToRentalHistory(DateTime rentalStart, DateTime rentalEnd)
        {
            _rentalHistory.Add(new RentalData(rentalStart, rentalEnd, GetRentPrice(rentalStart, rentalEnd)));
        }

        public decimal GetRentalHistoryIncome(int? year, bool includeCurrent)
        {
            decimal result = 0;

            foreach (var entry in _rentalHistory)
            {
                if (year.HasValue)
                {
                    if (entry.Year == year.Value)
                    {
                        result += entry.PriceForWholeRentalPeriod;
                    }
                }
                else
                {
                    result += entry.PriceForWholeRentalPeriod;
                }
            }                     

            if (_isRented && includeCurrent && _rentalStartTime.Year == year.Value)
            {
                result += (DateTime.Now.Year == year.Value) ? 
                    GetRentPrice(_rentalStartTime, DateTime.Now) :
                    GetRentPrice(_rentalStartTime, new DateTime(year.Value, 12, 31, 23, 59, 59));
            }

            return result;
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

        public void StartRent()
        {
            if (!_isRented)
            {
                _rentalStartTime = DateTime.Now;
                _isRented = true;
            }
        }

        public void StopRent()
        {
            if (_isRented)
            {
                _rentalEndTime = DateTime.Now;
                _isRented = false;
                _rentalHistory.Add(new RentalData(_rentalStartTime, _rentalEndTime, GetRentPrice(_rentalStartTime, _rentalEndTime)));
            }
        }

        public long GetTimeOfRent(DateTime startRent, DateTime endRent)
        {
            TimeSpan time = endRent - startRent;
            return (long)Math.Floor(time.TotalMinutes);
        }
       
        public decimal GetRentPrice(DateTime startTime, DateTime endTime)
        {
            decimal result = 0;
            
                if (_pricePerMinute * MINUTES_IN_DAY < MAXIMUM_RENT_SUM_PER_DAY)
                {
                    result = GetTimeOfRent(startTime,endTime) * _pricePerMinute;
                }
                else
                {
                    result += GetTimeOfRent(startTime, endTime) / MINUTES_IN_DAY * MAXIMUM_RENT_SUM_PER_DAY;
                    long lastDayMinutes = GetTimeOfRent(startTime, endTime) % MINUTES_IN_DAY;
                    result += (lastDayMinutes * _pricePerMinute < MAXIMUM_RENT_SUM_PER_DAY) ? lastDayMinutes * _pricePerMinute : MAXIMUM_RENT_SUM_PER_DAY;
                }          

            return result;
        }

        public bool IsRented
        {
            get => _isRented;
            set => _isRented = value;
        }
    }
}
