using System;

namespace DragRace
{
    public class Lexus : Car, INitroCar
    {
        //private string _name = "";

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