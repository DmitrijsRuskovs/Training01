using System;
using System.Collections.Generic;
using System.Linq;

namespace MakeSounds
{
    class Program
    {
        private static void Main(string[] args)
        {
            List<ISound> listOfSounds = new List<ISound>() { new Parrot(), new Radio(), new Firework() };
            foreach (var sound in listOfSounds) 
            {
                sound.PlaySound();
            }

            Console.ReadKey();
        }
    }
}