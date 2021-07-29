using System;

namespace Persons
{
    public class Student : Person
    {
        private double _gpa;

        public Student()
        {
            this._id = ++_maximumId;
        }

        public Student(double gpa, string firstName, string lastName, string address)
        {
            this._id = ++_maximumId;
            this._gpa = gpa;
            this._firstName = firstName;
            this._lastName = lastName;
            this._address = address;
        }

        public double GPA {
            get { return _gpa; }
            set { _gpa = value; }
        }

        public override void Display()
        {
            Console.WriteLine($"Student {_firstName} {_lastName} (address: {_address}) has GPA of {_gpa}");          
        }
    }
}