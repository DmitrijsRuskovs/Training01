namespace Exercise5
{
    public class Hoarding : Advert
    {
        private int _numberOfDays;
        private double _pricePerDay;
        private double _surCharge;

        public Hoarding(string Name, string Type, int MaterialCost, int ProductionStaffCost, int MediaCost, int NumberOfDays, double PricePerDay, double SurchargeForPrimeLocations) : base(Name, Type, MaterialCost, ProductionStaffCost, MediaCost)
        {
            _numberOfDays = NumberOfDays;
            _pricePerDay = PricePerDay;
            _surCharge = SurchargeForPrimeLocations;
            _totalCost += (int)( (1 + _surCharge) * _numberOfDays * _pricePerDay);
        }
    }
}
