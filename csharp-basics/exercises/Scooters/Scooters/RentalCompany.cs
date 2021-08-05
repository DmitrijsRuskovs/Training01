using System;
using System.Collections.Generic;
using System.Collections;

namespace Scooters
{
    public class RentalCompany : IRentalCompany
    {
        private string _name;
        private ScooterService _scooterService = new ScooterService();
        List<RentalData> _rentalHistory = new List<RentalData>();
        private const int MINUTES_IN_DAY = 1440;
        private const int MAXIMUM_RENT_SUM_PER_DAY = 20;

        struct RentalData
        {
            public DateTime StartTime;
            public DateTime EndTime;
            public int Year;
            public decimal PriceForWholeRentalPeriod;
            public string Id;

            public RentalData(string scooterId, DateTime startTime, DateTime endTime, decimal priceForWholeRentalPeriod)
            {
                StartTime = startTime;
                EndTime = endTime;
                PriceForWholeRentalPeriod = priceForWholeRentalPeriod;
                Year = endTime.Year;
                Id = scooterId;
            }
        }

        public RentalCompany(string CompanyName)
        {
            _name = CompanyName;
        }

        public ScooterService GetScooterService()
        {
            return _scooterService;
        }

        public string Name
        {
            get => _name;          
        }

        public void StartRent(string id)
        {
            Scooter scooter = _scooterService.GetScooters()[id];
            if (scooter.IsActive)
            {
                if (!scooter.IsRented)
                {
                    scooter.RentalStartTime = DateTime.Now;
                    scooter.IsRented = true;
                }
            }
            else throw new ScooterActivityException("Scooter is not active!");
        }

        public decimal EndRent(string id)
        {
            decimal rentPrice = 0m;
            Scooter scooter = _scooterService.GetScooters()[id];
            if (scooter.IsActive)
            {
                if (scooter.IsRented)
                {
                    scooter.RentalEndTime = DateTime.Now;
                    scooter.IsRented = false;
                    rentPrice = GetRentPrice(scooter.PricePerMinute, scooter.RentalStartTime, scooter.RentalEndTime);
                    _rentalHistory.Add(new RentalData(id, scooter.RentalStartTime, scooter.RentalEndTime, rentPrice));
                }
            }
            else throw new ScooterActivityException("Scooter is not active!");
            return rentPrice;          
        }

        private decimal GetRentPrice(decimal pricePerMinute, DateTime startTime, DateTime endTime)
        {
            decimal result = 0;
            long time = (long)Math.Floor(((TimeSpan)(endTime- startTime)).TotalMinutes);

            if (pricePerMinute * MINUTES_IN_DAY < MAXIMUM_RENT_SUM_PER_DAY)
            {
                result = time * pricePerMinute;
            }
            else
            {
                result += time / MINUTES_IN_DAY * MAXIMUM_RENT_SUM_PER_DAY;
                long lastDayMinutes = time % MINUTES_IN_DAY;
                result += (lastDayMinutes * pricePerMinute < MAXIMUM_RENT_SUM_PER_DAY) ? lastDayMinutes * pricePerMinute : MAXIMUM_RENT_SUM_PER_DAY;
            }

            return result;
        }

        public decimal CalculateIncome(int? year, bool includeNotCompletedRentals)
        {
            decimal result = 0;
            bool yearValid = true;
            if (year.HasValue)
            {
                if (year.Value < 2010 || year.Value > DateTime.Now.Year)
                {
                    yearValid = false;
                    throw new InvalidDateTimeException();
                }
            }

            if (yearValid)
            {
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

                foreach (KeyValuePair<string, Scooter> scooter in _scooterService.GetScooters())
                {
                    if (scooter.Value.IsActive && scooter.Value.IsRented && includeNotCompletedRentals && scooter.Value.RentalStartTime.Year == year.Value)
                    {
                        result += (DateTime.Now.Year == year.Value) ?
                            GetRentPrice(scooter.Value.PricePerMinute, scooter.Value.RentalStartTime, DateTime.Now) :
                            GetRentPrice(scooter.Value.PricePerMinute, scooter.Value.RentalStartTime, new DateTime(year.Value, 12, 31, 23, 59, 59));
                    }
                }
            }

            return result;
        }

        public void AddToRentalHistory(string id, DateTime rentalStart, DateTime rentalEnd)
        {
            TimeSpan time = rentalEnd - rentalStart;
            if (time.TotalMinutes < 0)
            {
                throw new InvalidDateTimeException("Date input for rental period not correct! Rental end should be after start");
            }
            else if (rentalStart.Year > 2010 && rentalStart.Year <= DateTime.Now.Year && rentalEnd.Year > 2010 && rentalEnd.Year <= DateTime.Now.Year)
            {
                _rentalHistory.Add(new RentalData(id, rentalStart, rentalEnd, GetRentPrice(_scooterService.GetScooters()[id].PricePerMinute, rentalStart, rentalEnd)));
            }
            else throw new InvalidDateTimeException("Date input for rental period not correct!");
        }
    }
}
