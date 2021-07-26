using System;

namespace Exercise4
{
    public class Movie
    {
        private string _name;
        private string _studio;
        private string _rating;

        public Movie(string name, string studio, string rating)
        {
            this._name = name;
            this._studio = studio;
            this._rating = rating;
        }
        public Movie(string name, string studio)
        {
            this._name = name;
            this._studio = studio;
            this._rating = "PG";
        }

        public string GetName()
        {
            return this._name;
        }

        public static Movie[] GetPG(Movie[] movies)
        {
            int index = 0;
            Movie[] result = new Movie[index];
            foreach (Movie i in movies)
            {              
                if (i._rating == "PG") {                 
                    Array.Resize(ref result, ++index);
                    result[index - 1] = i;                   
                }               
            }
            return result;
        }
    }   
}
