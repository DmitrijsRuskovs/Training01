namespace Scooters
{
    public class RentalCompany : IRentalCompany
    {
        private string _name;
        private double _money;
        private ScooterService _scooterService = new ScooterService();

        public RentalCompany(string CompanyName)
        {
            _name = CompanyName;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public void StartRent(string id)
        {
            _scooterService.GetScooterById(id).StartRent();
        }

        public decimal EndRent(string id)
        {
            _scooterService.GetScooterById(id).StopRent();
            return _scooterService.GetScooterById(id).GetTotalRentPriceOfLastRent();
        }

        public decimal CalculateIncome(int? year, bool includeNotCompletedRentals)
        {
            decimal result = 0;
            foreach (var eachScooter in _scooterService.GetScooters())
            {
                if (year.HasValue)
                {
                    result += eachScooter.GetRentalHistoryIncomeByYear(year.Value, includeNotCompletedRentals);
                }
                else
                {
                    result += eachScooter.GetRentalHistoryIncomeInTotal(includeNotCompletedRentals);
                }
            }

            return result;
        }
    }
}
