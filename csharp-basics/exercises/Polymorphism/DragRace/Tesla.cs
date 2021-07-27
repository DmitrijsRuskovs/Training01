using System;

namespace DragRace
{
    public class Tesla : Car, INitroCar
    {
       // private string _name = "";

        public Tesla(string name)
        {
            this._name = name;
        }

        public override void UseNitrousOxideEngine()
        {
            _currentSpeed += 12;
        }
    }
}