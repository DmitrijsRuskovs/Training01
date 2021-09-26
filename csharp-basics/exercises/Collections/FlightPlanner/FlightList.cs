using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace FlightPlanner
{
    public class FlightList
    {
        private static Dictionary<string, List<string>> _flights = new Dictionary<string, List<string>>();

        public FlightList()
        {
        }

        public string GetDepartureCityByIndex(int index)
        {
            return _flights.ElementAt(index).Key;
        }

        public string GetArrivalCityByIndex(int index, string DepartureCity)
        {
            return _flights[DepartureCity].ElementAt(index);
        }

        public void AddDestination(string s)
        {
            int arrow = s.IndexOf('>');
            string departure = s.Substring(0, arrow - 2).Trim();
            string arrival = s.Substring(arrow + 1, s.Length - arrow - 1).Trim();
            if (_flights.ContainsKey(departure))
            {
                if (!_flights[departure].Contains(arrival))
                {
                    _flights[departure].Add(arrival);
                }
            }
            else
            {
                var newcity = new List<string>();
                newcity.Add(arrival);
                _flights.Add(departure, newcity);
            }
        }

        public List<string> GetDepartureCities()
        {
            List<string> result = new List<string>();
            foreach (KeyValuePair<string, List<string>> i in _flights)
            {
                result.Add(i.Key);
            }

            return result;
        }

        public List<string> GetArrivalCities(string DepartureCity)
        {
            return _flights[DepartureCity];
        }
    }
}
