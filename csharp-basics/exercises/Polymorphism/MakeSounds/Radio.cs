using System;

namespace MakeSounds
{
    public class Radio : ISound
    {
        public void PlaySound()
        {
            Console.WriteLine("Meouw! Meouw!");
            Console.Beep(3000, 1000);
        }
    }
}