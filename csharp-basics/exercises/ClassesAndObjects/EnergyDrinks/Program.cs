using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyDrinks
{
    class Program
    {
        private const int NumberedSurveyed = 12467;
        private const double PurchasedEnergyDrinks = 0.14;
        private const double PreferCitrusDrinks = 0.64;

        private static void Main(string[] args)
        {         
             Console.WriteLine("Total number of people surveyed " + NumberedSurveyed);
             Console.WriteLine("Approximately " + CalculateEnergyDrinkers() + " bought at least one energy drink");
             Console.WriteLine(CalculatePreferCitrus() + " of those " + "prefer citrus flavored energy drinks.");
             Console.ReadKey();
        }

        public static int CalculateEnergyDrinkers()
        {
            return (int)Math.Round(PurchasedEnergyDrinks * NumberedSurveyed);
        }

        public static int CalculatePreferCitrus()
        {
            return (int)Math.Round(PreferCitrusDrinks * PurchasedEnergyDrinks * NumberedSurveyed);
        }
    }
}
