using System.Collections.Generic;

namespace Scooters
{
    public class ScooterService : IScooterService
    {
        private static Dictionary<string, Scooter> _scooterList = new Dictionary<string, Scooter>();

        public ScooterService()
        {
        }

        public void AddScooter(string id, decimal pricePerMinute)
        {
            _scooterList.Add(id, new Scooter(id, pricePerMinute));
        }

        public void RemoveScooter(string id)
        {
            if (!_scooterList[id].IsRented)
            {
                _scooterList.Remove(id);
            }
        }

        public Scooter GetScooterById(string scooterId)
        {
            return _scooterList[scooterId];
        }

        public List<Scooter> GetScooters()
        {
            List<Scooter> result = new List<Scooter>();
            foreach (KeyValuePair<string, Scooter> entry in _scooterList)
            {
                result.Add(entry.Value);
            }
            return result;
        }
    }
}
