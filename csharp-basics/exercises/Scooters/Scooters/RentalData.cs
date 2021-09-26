using System;

namespace Scooters
{
    public struct RentalData
    {
        public DateTime StartTime;
        public DateTime EndTime;
        public int Year;
        public decimal PriceForWholeRentalPeriod;
        public string Id;
        private const int MINUTES_IN_DAY = 1440;
        private const int MAXIMUM_RENT_SUM_PER_DAY = 20;
        
        public RentalData(string scooterId, DateTime startTime, DateTime endTime, decimal pricePerMinute)
        {
            TimeSpan time = endTime - startTime;
            
            if (time.TotalMinutes < 0)
            {
                throw new InvalidDateTimeException("Date input for rental period not correct! Rental end should be after start");
            }
            else if (startTime.Year > 2010 && startTime.Year <= DateTime.Now.Year && endTime.Year > 2010 && endTime.Year <= DateTime.Now.Year)
            {
                StartTime = startTime;
                EndTime = endTime;
                PriceForWholeRentalPeriod = 0;               
                Year = endTime.Year;
                Id = scooterId;
                PriceForWholeRentalPeriod = GetRentPrice(pricePerMinute, startTime, endTime);
            }
            else throw new InvalidDateTimeException("Date input for rental period not correct!");           
        }
        private decimal GetRentPrice(decimal pricePerMinute, DateTime startTime, DateTime endTime)
        {
            decimal result = 0;
            long time = (long)Math.Floor(((TimeSpan)(endTime - startTime)).TotalMinutes);

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
    }   
}
