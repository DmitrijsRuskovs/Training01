using System;

namespace DragRace
{
    public class Lexus : Car
    {
        public Lexus(string name)
        {
            this._name = name;
        }

        public override void UseNitrousOxideEngine() 
        {
            _currentSpeed+=10;
        }
    }
}