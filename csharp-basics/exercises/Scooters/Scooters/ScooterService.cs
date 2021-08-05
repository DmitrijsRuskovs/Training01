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
            if (!ScooterIdExists(id))
            {
                _scooterList.Add(id, new Scooter(id, pricePerMinute));
            }
            else throw new DuplicateScooterIdException("Scooter id exists!");
        }

        public bool ScooterIdExists(string id)
        {
            return _scooterList.ContainsKey(id);
        }

        public void RemoveScooter(string id)
        {
            if (_scooterList[id].IsActive)
            {
                if (!_scooterList[id].IsRented)
                {
                    _scooterList[id].DesActivate();
                }
                else throw new ScooterRentedException("Scooter is rented!");
            }
            else throw new ScooterActivityException("Scooter is not active!");
        }

        public void ReactivateScooter(string id)
        {
            if (!_scooterList[id].IsActive)
            {
                _scooterList[id].Activate();
            }
            else throw new ScooterActivityException("Scooter is still active!");
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
            else throw new DuplicateScooterIdException("New Scooter id already exists!");
        }

        public Scooter GetScooterById(string scooterId)
        {
            if (ScooterIdExists(scooterId))
            {
                return _scooterList[scooterId];
            }
            else throw new ScooterIdNotFoundException("Scooter id does not exist!");
        }

        public Dictionary<string, Scooter> GetScooters()
        {
            return _scooterList;
        }           
    }
}
