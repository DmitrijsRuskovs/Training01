using System;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie[] movies = { 
                new Movie("Casino Royale", "Eon Productions", "PG­13"), 
                new Movie("Glass", "Buena Vista International", "PG­13"), 
                new Movie("Spider - Man: Into the Spider - Verse", "Columbia Pictures", "PG")
            };

            movies = Movie.GetPG(movies);
            foreach (Movie i in movies)
            {
                Console.WriteLine(i.GetName()+ " has a rating of PG");
            }

            Console.ReadKey();
        }
    }   
}
