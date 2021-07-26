using System;
namespace ConsoleApp1
{
    public class FuelGauge
    {
        private int _fuelLevel;
        public int Level;
        public int Fuel;
        public int GetFuelLevel()
        {
            return _fuelLevel;
        }

        public void ReportFuelLevel()
        {
            Console.WriteLine($"Current fuel level is {_fuelLevel}");
        }

        public void Fill()
        {
            if(_fuelLevel < 70) _fuelLevel++;
        }

        public void DecreaseLevel()
        {
            if (_fuelLevel >0) _fuelLevel--;
        }
    }
}
