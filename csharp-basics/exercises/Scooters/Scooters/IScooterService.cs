using System.Collections.Generic;
using System.Collections;

namespace Scooters
{
    public interface IScooterService
    {     
        public void AddScooter(string id, decimal pricePerMinute);       
        public void RemoveScooter(string id);
        public Dictionary<string, Scooter> GetScooters();     
        public Scooter GetScooterById(string scooterId);
    }
}
