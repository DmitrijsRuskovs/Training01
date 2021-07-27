using System;

namespace MakeSounds
{
    public class Firework: ISound
    {
        public void PlaySound()
        {
            Console.WriteLine("whoosh-bang");
            Console.Beep(1000, 1000);
        }
    }
}