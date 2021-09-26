using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

namespace Scooters
{
    public class ScooterService : IScooterService
    {
        private static List<Scooter> _scooterList = new List<Scooter>();

        public ScooterService()
        {
        }

        public void AddScooter(string id, decimal pricePerMinute)
        {
            if (!ScooterIdExists(id))
            {
                _scooterList.Add(new Scooter(id, pricePerMinute));
            }
            else throw new DuplicateScooterIdException("Scooter id exists!");
        }

        public bool ScooterIdExists(string scooterId)
        {
            return _scooterList.Any(x => x.Id == scooterId);
        }

        public void RemoveScooter(string id)
        {
            Scooter scooter = GetScooterById(id);
            if (scooter.IsActive)
            {
                if (!scooter.IsRented)
                {
                    scooter.IsActive = false;
                }
                else throw new ScooterRentedException("Scooter is rented!");
            }
            else throw new ScooterActivityException("Scooter is not active!");
        }

        public void ReactivateScooter(string id)
        {
            Scooter scooter = GetScooterById(id);
            if (!scooter.IsActive)
            {
                scooter.IsActive = true;
            }
            else throw new ScooterActivityException("Scooter is still active!");
        }

        public void ChangeScooterId(string id, string newId)
        {
            if (!ScooterIdExists(newId))
            {
                GetScooterById(id).Id = newId;
            }
            else throw new DuplicateScooterIdException("New Scooter id already exists!");
        }

        public Scooter GetScooterById(string scooterId)
        {
            if (ScooterIdExists(scooterId))
            {
                return _scooterList.Find(x => x.Id == scooterId);
            }
            else throw new ScooterIdNotFoundException("Scooter id does not exist!");
        }

        public IList<Scooter> GetScooters()
        {
            return new List<Scooter>(_scooterList);           
        }           
    }
}
