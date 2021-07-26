using System;

namespace Test
{
    class Piglet
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int score = 0;
            int randomNumber = 0;

            Console.WriteLine("Welcome to Piglet!");
            Console.WriteLine("Do you want to start to play?");
            string answer = Console.ReadLine();
          
            while (true)
            {
                if (answer[0] == 'y')
                {
                    randomNumber = random.Next(1, 6);
                    if (randomNumber == 1)
                    {
                        Console.WriteLine("You rolled a 1! You got 0 points. The game is over, #%$&!");
                        score = 0;
                        break;
                    }

                    score += randomNumber;
                    Console.WriteLine($"You rolled a {randomNumber}! And You got {score} points! ");
                    Console.WriteLine("Do you want to continue to play?");
                    answer = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"Your score is {score}. The game is over. Take Your money tomorrow at 10:00 from Sandris. He lives beside the lake.");
                    break;
                }

            }
            Console.ReadKey();
        }
    }
}
