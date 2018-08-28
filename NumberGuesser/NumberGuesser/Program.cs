using System;
using System.Collections.Generic;

namespace NumberGuesser
{
    class Program
    {
        int MAX = 100,MIN=1;
        Random rnd = new Random();

        Boolean MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome! Choose an option");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Play NumberGuesser");
            Console.WriteLine("2. Check Hall of Fame(who beat the game previously)");
            Console.WriteLine("3. Exit");
            Console.ForegroundColor = ConsoleColor.White;
            string op=Console.ReadLine();
            int k = Int32.Parse(op);
            switch (k)
            {
                case 1: { Play(); return false; }
                case 2: { HallOfFame(); MainMenu(); return false; }
                case 3: { return true; }
            }
            return true;
            
        }

        void HallOfFame()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" HALL OF FAME ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string text = System.IO.File.ReadAllText(@"C:\Users\luisg\Documents\csProjects\NumberGuesser\NumberGuesser\halloffame.txt");      
            Console.WriteLine("{0}", text);
        }

        static void Main(string[] args)
        {
            Program pg = new Program();
            pg.ShowAppInfo();
            if (pg.MainMenu()) return;
            
        }

        void Play()
        {
            string player=GreetPlayer();
            AskPlayer(player);

        }

        void ShowAppInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("VERSION 1.0.1 by iSW007");
            Console.WriteLine("LICENSE BY ISEL");
            Console.ForegroundColor = ConsoleColor.White;

        }

        string GreetPlayer()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Welcome Player! What is your name?\n");
            Console.ForegroundColor =ConsoleColor.White;
            string playerName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Hi {0}\n", playerName);
            Console.Write("Let's play a game! The Number Guesser game\n");
            Console.ForegroundColor = ConsoleColor.White;
            return playerName;
        }

        void AddToHallOfFame(string player)
        {
            using (System.IO.StreamWriter file =
             new System.IO.StreamWriter(@"C:\Users\luisg\Documents\csProjects\NumberGuesser\NumberGuesser\halloffame.txt", true))
            {
                file.WriteLine(player);
            }

        }

        void WonGame(string player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You guessed it! Want to play again?");
            AddToHallOfFame(player);
            Console.ForegroundColor = ConsoleColor.White;
            string c = Console.ReadLine().ToUpper();
            if (c == "Y") Play();
            else return;
        }

        void AskPlayer(string player)
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
            WonGame(player);
            return;
        }

        int GenerateAnswer()
        {
           return rnd.Next(MIN,MAX+1);
        }
    }
}
