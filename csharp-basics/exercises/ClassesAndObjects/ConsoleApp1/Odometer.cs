using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Odometer
    {
        public Odometer(FuelGauge fuelGauge)
        {
            _fuelGauge = fuelGauge;
        }

        private readonly FuelGauge _fuelGauge;
        private int _currentMilage;

        public int GetMileage()
        {
            return _currentMilage;
        }
        public void ReportMileage()
        {
            Console.WriteLine($"Current mileage is {_currentMilage}");
        }

        public void IncreaseMileage()
        {
            if (_fuelGauge.GetFuelLevel() <= 0) return;
            
            if (_currentMilage == 999999)
            {
                _currentMilage = 0;
            }
            else _currentMilage++;

            if (_currentMilage % 10 == 0)
            {
                _fuelGauge.DecreaseLevel();
            }
        }
    }
}
