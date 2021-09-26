using System;
using System.Collections.Generic;
using System.Collections;

namespace Scooters
{
    public partial class RentalCompany : IRentalCompany
    {
        private static string _name;
        public IScooterService _scooterService = new ScooterService();
        List<RentalData> _rentalHistory = new List<RentalData>();        

        public RentalCompany(string CompanyName)
        {
            _name = CompanyName;
        }

        public RentalCompany(string CompanyName, ScooterService scooterService, List<RentalData> rentalHistory)
        {
            _name = CompanyName;
            _scooterService = scooterService;
            _rentalHistory = rentalHistory;
        }

        public static string Name
        {
            get => _name;
        }

        public void StartRent(string id)
        {
            Scooter scooter = _scooterService.GetScooterById(id);
            if (scooter.IsActive)
            {
                if (!scooter.IsRented)
                {
                    scooter.RentalStartTime = DateTime.Now;
                    scooter.IsRented = true;
                }
                else throw new ScooterRentedException("Scooter is already under rent!");
            }
            else throw new ScooterActivityException("Scooter is not active!");
        }

        public decimal EndRent(string id)
        {
            decimal rentPrice = 0m;
            Scooter scooter = _scooterService.GetScooterById(id);
            if (scooter.IsActive)
            {
                if (scooter.IsRented)
                {
                    scooter.RentalEndTime = DateTime.Now;
                    scooter.IsRented = false;
                    _rentalHistory.Add(new RentalData(id, scooter.RentalStartTime, scooter.RentalEndTime, scooter.PricePerMinute));
                    rentPrice = _rentalHistory[_rentalHistory.Count-1].PriceForWholeRentalPeriod;
                }
                else throw new ScooterRentedException("Scooter is not rented!");
            }
            else throw new ScooterActivityException("Scooter is not active!");
            return rentPrice;          
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

                foreach (Scooter scooter in _scooterService.GetScooters())
                {
                    if (scooter.IsActive && scooter.IsRented && includeNotCompletedRentals && scooter.RentalStartTime.Year == year.Value)
                    {
                        result += (DateTime.Now.Year == year.Value) ?
                           new RentalData(scooter.Id, scooter.RentalStartTime, DateTime.Now, scooter.PricePerMinute).PriceForWholeRentalPeriod :
                           new RentalData(scooter.Id, scooter.RentalStartTime, new DateTime(year.Value, 12, 31, 23, 59, 59), scooter.PricePerMinute).PriceForWholeRentalPeriod;                          
                    }
                }
            }

            return result;
        }      
    }
}
