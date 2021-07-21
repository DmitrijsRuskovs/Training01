using System;

namespace VariablesAndNames
{
    class Program
    {
        private static void Main(string[] args)
        {
            int cars = 10;
            int seatsInCar = 4;
            int drivers = 35;
            int passengers = 38;
            int carsDriven = (drivers>cars) ? cars : drivers;            
            int carpoolCapacity = carsDriven * seatsInCar;
            int carsNotDriven = cars - carsDriven;
            int passengersDriven =  (passengers > carpoolCapacity) ? carpoolCapacity : passengers;          
            carsDriven = (int)Math.Ceiling((double)passengersDriven / (double)seatsInCar);
            double averagePassengersPerCar =  (double)passengersDriven / (double)carsDriven;
            Console.WriteLine("There are " + cars + " cars available.");
            Console.WriteLine("There are only " + drivers + " drivers available.");
            Console.WriteLine("There will be " + carsNotDriven + " empty cars today.");
            Console.WriteLine("We can transport " + carpoolCapacity + " people today.");
            Console.WriteLine("We have " + passengers + " to carpool today.");
            Console.WriteLine(carsDriven + " cars will be used.");
            Console.WriteLine(passengersDriven + " passengers will be able to go.");
            Console.WriteLine("We need to put about " + String.Format("{0:0.00}", averagePassengersPerCar) + " in each car.");
            Console.ReadKey();
        }
    }
}