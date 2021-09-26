using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class PhoneDirectory
    {
        private SortedDictionary<string, string> _dataSD = new SortedDictionary<string, string>();

        public PhoneDirectory() 
        {
        }

        private bool Find(string name) 
        {
            return _dataSD.ContainsKey(name);
        }

        public string GetNumber(string name) 
        {
            return _dataSD[name];
        }

        public int GetEntryCount()
        {
            return _dataSD.Count;
        }

        public void PutNumber(string name, string number) 
        {
            if (name == null || number == null) 
            {
                throw new Exception("name and number cannot be null");
            }

            if (Find(name))
            {
                _dataSD[name] = number;
            }
            else 
            {
                _dataSD.Add(name, number);
            }
        }
    }
}