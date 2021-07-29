using System;

namespace Persons
{
    public class Person
    {
        static protected int _maximumId = 0;
        protected int _id;
        protected string _address = "";
        protected string _firstName = "";
        protected string _lastName = "";

        public Person()
        {
            this._id = ++_maximumId;
        }

        public Person(string firstName, string lastName, string address)
        {
            this._id = ++_maximumId;
            this._firstName = firstName;
            this._lastName = lastName;
            this._address = address;
        }

        public string FirstName   
        {
            get { return _firstName; } 
            set { _firstName = value; }
        }

        public string LastName 
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Address 
        {
            get { return _address; }
            set { _address = value; }
        }

        public int GetId()
        {
             return _id;           
        }

        public virtual void Display()
        {
            Console.WriteLine("Meouw! Meouw!");
            Console.Beep(3000, 1000);
        }
    }
}