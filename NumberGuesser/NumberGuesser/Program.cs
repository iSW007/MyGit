using System;

namespace NumberGuesser
{
    class Program
    {
        static int MAX = 100,MIN=1;
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Play();
            
        }

        static void Play()
        {
            ShowAppInfo();
            GreetPlayer();
            AskPlayer();

        }

        static void ShowAppInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("VERSION 1.0.0 by iSW007");
            Console.WriteLine("LICENSE BY ISEL");
            Console.ForegroundColor = ConsoleColor.White;

        }

        static void GreetPlayer()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Welcome Player! What is your name?\n");
            Console.ForegroundColor =ConsoleColor.White;
            string playerName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Hi {0}\n", playerName);
            Console.Write("Let's play a game! The Number Guesser game\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void wonGame()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You guessed it! Want to play again?");
            Console.ForegroundColor = ConsoleColor.White;
            string c = Console.ReadLine().ToUpper();
            if (c == "Y") Play();
            else return;
        }

        static void AskPlayer()
        {
            int x = GenerateAnswer();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Try to guess the number I'm thinking of! It's between {0} and {1}",MIN,MAX);
            Console.ForegroundColor = ConsoleColor.White;
            string guess = Console.ReadLine();
            int answer = Int32.Parse(guess);
            string c;
           
            while (answer != x)
            {
                Console.ForegroundColor = ConsoleColor.Green;   
                if (x > answer) Console.WriteLine("The number you inserted is lower than the Correct Number");
                else if(x<answer)Console.WriteLine("The number you inserted is higher than the Correct Number");
                Console.WriteLine("Try again!");
                Console.ForegroundColor = ConsoleColor.White;
                guess = Console.ReadLine();
                answer = Int32.Parse(guess);
                
            }
            wonGame();
            return;
        }

        static int GenerateAnswer()
        {
           return rnd.Next(MIN,MAX+1);
        }
    }
}
