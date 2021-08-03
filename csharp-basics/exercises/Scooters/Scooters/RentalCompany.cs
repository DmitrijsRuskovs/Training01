namespace Scooters
{
    public class RentalCompany : IRentalCompany
    {
        private string _name;
        private ScooterService _scooterService = new ScooterService();

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
            set => _name = value;
        }
        public void StartRent(string id)
        {
            _scooterService.GetScooterById(id).StartRent();
        }

        public decimal EndRent(string id)
        {
            _scooterService.GetScooterById(id).StopRent();
            return _scooterService.GetScooterById(id).GetLastRentalEntryPrice();
        }

        public decimal CalculateIncome(int? year, bool includeNotCompletedRentals)
        {
            decimal result = 0;
            foreach (var eachScooter in _scooterService.GetScooters())
            {               
                 result += eachScooter.GetRentalHistoryIncome(year, includeNotCompletedRentals);               
            }

            return result;
        }
    }
}
