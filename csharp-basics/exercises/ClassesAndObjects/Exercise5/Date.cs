using System;

namespace DateTest
{ 
    public class Date
    {
        private int _day;
        private int _month;
        private int _year;

        public Date(int day, int month, int year)
        {
            this._day = day;
            this._month = month;
            this._year = year;
        }

        public void SetDay(int day)
        {
            this._day = (Math.Abs(day) > 31) ? 31 : Math.Abs(day);
            if (day == 0) this._day = 1;
        }

        public void SetMonth(int month)
        {
            this._month = (Math.Abs(month) > 12) ? 12 : Math.Abs(month);
            if (month == 0) this._month = 1;
        }

        public void SetYear(int year)
        {
            this._year = (Math.Abs(year)<100)? Math.Abs(year)+2000 : Math.Abs(year);
        }

        public int GetYear()
        {
            return this._year;
        }

        public int GetMonth()
        {
            return this._month;
        }
        public int GetDay()
        {
            return this._day;
        }

        public string DisplayDate()
        {
            return $"{this._month} / {this._day} / {this._year}";
        }
    }
    
}
