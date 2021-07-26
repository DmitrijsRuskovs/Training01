using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner
{
    class Program
    {
        private static Dictionary<string, List<string>> flights = new Dictionary<string, List<string>>();
        private static List<string> trip = new List<string>();
        private const string Path = "../FlightPlanner/flights.txt";

        private static void DisplayFirst()
        {
            Console.WriteLine("\n\n..............................................."); 
            Console.WriteLine(". Choose Your action:                         .");
            Console.WriteLine(". 1 - View all list of departures -> arrivals .");
            Console.WriteLine(". 2 - Start Your trip: choose departure city  .");
            Console.WriteLine(". SPACE - Exit                                .");
            Console.WriteLine("...............................................");
        }

        private static void DisplayAllDestinations()
        {
            Console.WriteLine("-------------------------------------");
            foreach (KeyValuePair<string, List<string>> i in flights)
            {
                Console.WriteLine($"DEPARTURE from {i.Key}:");
                foreach (var j in i.Value)
                {
                    Console.WriteLine($"   {i.Value.IndexOf(j)} {j}");
                }
            }

            Console.WriteLine("-------------------------------------");
        }

        private static void DisplayCurrentTrip()
        {
            if (trip.Count > 0)
            {
                Console.Write("\n\nTRIP:    ");
                foreach (var i in trip)
                {
                    Console.Write(i + " -> ");
                }
            }
        }

        private static void DisplaytArrivalCities(List<string> cityList)
        {
            int index = 0;
            Console.WriteLine($"\n\nChoose Your arrival city:");
            Console.WriteLine("-----------------------------");
            foreach (var i in cityList)
            {
                index = cityList.ToList().IndexOf(i);
                Console.WriteLine($"{index} -  {i}");
            }

            Console.WriteLine("-----------------------------");
            Console.WriteLine("SPACE - Exit");
        }

        private static void DisplaytDepartureCities()
        {
            int index = 0;
            Console.Clear();
            Console.WriteLine($"\n\nChoose Your departure city:");
            Console.WriteLine("-----------------------------");
            foreach (KeyValuePair<string, List<string>> i in flights)
            {
                index = flights.Keys.ToList().IndexOf(i.Key);
                Console.WriteLine($"{index} -  {i.Key}");
            }

            Console.WriteLine("-----------------------------");
            Console.WriteLine("SPACE - Exit");
        }

        private static void StartPlanningFlight()
        {
            char key = 'a';
            bool arrivedHomeAfterTrip = false;
            string lastVisitedCity = "";
            while (key != ' '&&!arrivedHomeAfterTrip)
            {
                int chosenIndex = Convert.ToInt32(key) - 48; //Index 0 - 9 from pressed key
                Console.Clear();
                if (chosenIndex>=0 && chosenIndex<=9)
                {
                    if (trip.Count == 0)
                    {
                        lastVisitedCity = flights.ElementAt(chosenIndex).Key;                      
                    }
                    else
                    {
                        lastVisitedCity = flights[lastVisitedCity].ElementAt(chosenIndex);
                        if (trip.ElementAt(0) == lastVisitedCity)
                        {
                            arrivedHomeAfterTrip = true;
                            Console.WriteLine("\n\n HOME, SWEET HOME!!!!!");
                        }
                    }
                    
                    trip.Add(lastVisitedCity);
                }

                DisplayCurrentTrip();
                if (!arrivedHomeAfterTrip)
                {
                    if (trip.Count == 0)
                    {
                        DisplaytDepartureCities();
                    }
                    else
                    {
                        DisplaytArrivalCities(flights[lastVisitedCity]);
                    }

                    key = Console.ReadKey().KeyChar;
                }
            }
        }

        
        private static void Main(string[] args)
        {
            var readText = File.ReadAllLines(@"..\..\flights.txt");
            
            foreach (var s in readText)
            {
                int arrow = s.IndexOf('>');
                string departure = s.Substring(0, arrow - 2).Trim();
                string arrival = s.Substring(arrow + 1, s.Length - arrow - 1).Trim();
                if (flights.ContainsKey(departure))
                {
                    flights[departure].Add(arrival);
                }
                else
                {
                    var newcity = new List<string>();
                    newcity.Add(arrival);
                    flights.Add(departure, newcity);
                }
            }
            char key = '1';

            while (key != ' ')
            {
                DisplayFirst();
                key = Console.ReadKey().KeyChar;
                if (key == '1')
                {
                    DisplayAllDestinations();  
                }
                else if (key == '2')
                {
                    StartPlanningFlight();
                }
            }
        }        
    }
}
