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
            if (!_scooterList.ContainsKey(id))
            {
                _scooterList.Add(id, new Scooter(id, pricePerMinute));
            }
            else throw new ScooterIdException("Scooter id exists!");
        }

        public bool ScooterIdExists(string id)
        {
            return _scooterList.ContainsKey(id);
        }

        public void RemoveScooter(string id)
        {
            if (!_scooterList[id].IsRented)
            {
                _scooterList.Remove(id);
            }
            else throw new ScooterIsRentedException("Scooter is rented!");
        }

        public void ChangeScooterId(string id, string newId)
        {
            if (!_scooterList.ContainsKey(newId))
            {
                Scooter currentScooter = GetScooterById(id);
                currentScooter.Id = newId;
                _scooterList.Add(newId, currentScooter);
                _scooterList.Remove(id);
            }
            else throw new ScooterIdException("New Scooter id already exists!");
        }

        public Scooter GetScooterById(string scooterId)
        {
            if (_scooterList.ContainsKey(scooterId))
            {
                return _scooterList[scooterId];
            }
            else throw new ScooterIdException("Scooter id does not exist!");
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
