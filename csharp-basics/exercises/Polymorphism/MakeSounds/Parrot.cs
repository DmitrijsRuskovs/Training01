using System;

namespace MakeSounds
{
    public class Parrot : ISound
    {
        public void PlaySound()
        {
            Console.WriteLine("pirk-pirk-pirk");
            Console.Beep(300, 1000);
        }
    }
}