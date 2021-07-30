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
        private static List<string> _trip = new List<string>();
        private static FlightList _flightList = new FlightList();

        private static void DisplayFirstMenu()
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
            foreach (var departureCity in _flightList.GetDepartureCities())
            {
                Console.WriteLine($"DEPARTURE from {departureCity}:");
                int index = 0;
                foreach (var arrivalCity in _flightList.GetArrivalCities(departureCity))
                {
                    Console.WriteLine($"   {index++} {arrivalCity}");
                }
            }

            Console.WriteLine("-------------------------------------");
        }

        public static string CurrentTrip()
        {
            string result = "";
            foreach (var i in _trip)
            {
                result += i + " -> ";
            }
            return result;
        }

        private static void DisplayCurrentTrip()
        {
            if (_trip.Count > 0)
            {
                Console.Write("\n\nTRIP:    ");
                Console.Write(CurrentTrip());
            }
        }

        private static void DisplaytArrivalCities(string DepartureCity)
        {
            int index = 0;
            Console.WriteLine($"\n\nChoose Your arrival city:");
            Console.WriteLine("-----------------------------");
            foreach (var arrivalCity in _flightList.GetArrivalCities(DepartureCity))
            {
                Console.WriteLine($"{index++} -  {arrivalCity}");              
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
            foreach (var departureCity in _flightList.GetDepartureCities())
            {
                Console.WriteLine($"{index++} -  {departureCity}");
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
                    if (_trip.Count == 0)
                    {
                        lastVisitedCity = _flightList.GetDepartureCityByIndex(chosenIndex);                   
                    }
                    else
                    {
                        lastVisitedCity = _flightList.GetArrivalCityByIndex(chosenIndex, lastVisitedCity);
                        if (_trip.ElementAt(0) == lastVisitedCity)
                        {
                            arrivedHomeAfterTrip = true;
                            Console.WriteLine("\n\n HOME, SWEET HOME!!!!!");
                        }
                    }
                    
                    _trip.Add(lastVisitedCity);
                }

                DisplayCurrentTrip();
                if (!arrivedHomeAfterTrip)
                {
                    if (_trip.Count == 0)
                    {
                        DisplaytDepartureCities();
                    }
                    else
                    {
                        DisplaytArrivalCities(lastVisitedCity);
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
                _flightList.AddDestination(s);              
            }

            char key = '1';
            while (key != ' ')
            {
                DisplayFirstMenu();
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
