namespace Scooters
{
    public interface IRentalCompany
    {
        public void StartRent(string id);     
        public decimal EndRent(string id);      
        public decimal CalculateIncome(int? year, bool includeNotCompletedRentals);
    }
}
