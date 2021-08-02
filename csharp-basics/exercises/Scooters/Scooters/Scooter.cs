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

        struct RentalData
        {
            public DateTime StartTime;
            public DateTime EndTime;
            public int Year;
            public decimal PriceForWholeRentalPeriod;

            public RentalData(DateTime startTime,DateTime endTime, decimal priceForWholeRentalPeriod)
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
        
        public decimal GetRentalHistoryIncomeByYear(int year, bool includeCurrent)
        {
            decimal result = 0;
            foreach (var entry in _rentalHistory)
            {
                if (entry.Year == year) result += entry.PriceForWholeRentalPeriod;
            }

            if (includeCurrent && _rentalStartTime.Year == year)
            {
                if (_pricePerMinute * 1440 < 20)
                {
                    result += GetTotalTimeOfLastRent() * _pricePerMinute;
                }
                else
                {
                    result += GetTotalTimeOfLastRent() / 1440 * 20;
                    long lastDayMinutes = GetTotalTimeOfLastRent() % 1440;
                    result += (lastDayMinutes * _pricePerMinute < 20) ? lastDayMinutes * _pricePerMinute : 20;
                }
            }

            return result;
        }
        public decimal GetRentalHistoryIncomeInTotal(bool includeCurrent)
        {
            decimal result = 0;
            foreach (var entry in _rentalHistory)
            {
               result += entry.PriceForWholeRentalPeriod;
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
            _rentalStartTime = DateTime.Now;
            _isRented = true;
        }

        public void StopRent()
        {
            _rentalEndTime = DateTime.Now;
            _isRented = false;
            _rentalHistory.Add(new RentalData(_rentalStartTime, _rentalEndTime, GetTotalRentPriceOfLastRent()));
        }

        public long GetTotalTimeOfLastRent()
        {
            TimeSpan time = _rentalEndTime - _rentalStartTime;
            return (_isRented) ? 0 : (long)Math.Floor(time.TotalMinutes);
        }

        public long GetTotalTimeOfCurrentRentInStartYear()
        {           
            DateTime finishTime = (DateTime.Now.Year > _rentalStartTime.Year) ? new DateTime(_rentalStartTime.Year, 12, 31, 23, 59, 59) : DateTime.Now;
            TimeSpan time = finishTime - _rentalStartTime;
            return (_isRented) ? 0 : (long)Math.Floor(time.TotalMinutes);
        }

        public int GetFullDaysOfLastRent()
        {
            long totalMinutes = GetTotalTimeOfLastRent();
            return (_isRented) ? 0 : (int)Math.Floor((decimal)totalMinutes / 1440);
        }

        public decimal GetTotalRentPriceOfUnfinishedRentCurrentYear()
        {
            decimal result = 0;
            if (!_isRented)
            {
                if (_pricePerMinute * 1440 < 20)
                {
                    result = GetTotalTimeOfCurrentRentInStartYear() * _pricePerMinute;
                }
                else
                {
                    result += GetTotalTimeOfCurrentRentInStartYear() / 1440 * 20;
                    long lastDayMinutes = GetTotalTimeOfCurrentRentInStartYear() % 1440;
                    result += (lastDayMinutes * _pricePerMinute < 20) ? lastDayMinutes * _pricePerMinute : 20;
                }
            }

            return result;
        }

        public decimal GetTotalRentPriceOfLastRent()
        {
            decimal result = 0;
            if (!_isRented)
            {
                if (_pricePerMinute * 1440 < 20)
                {
                    result = GetTotalTimeOfLastRent() * _pricePerMinute;
                }
                else
                {
                    result += GetTotalTimeOfLastRent() / 1440 * 20;
                    long lastDayMinutes = GetTotalTimeOfLastRent() % 1440;
                    result += (lastDayMinutes * _pricePerMinute < 20) ? lastDayMinutes * _pricePerMinute : 20;
                }
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
