using Sample1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample1
{
    internal class Program
    {
        private static List<HighScore> highScoreList = new List<HighScore>();

        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                ExecuteChoice(Convert.ToInt32(args[0]));
            }

            int choice = 0;
            do
            {
                PrintMenu();
                choice = UserChoic();
                ExecuteChoice(choice);
            } while (choice != 3);
        }

        private static void PrintMenu()
        {
            Console.Clear();
            Console.SetCursorPosition(10, 10);
            Console.WriteLine("Welcome to game portal!");
            Console.SetCursorPosition(10, 12);
            Console.WriteLine("1. Start Game");
            Console.SetCursorPosition(10, 13);
            Console.WriteLine("2. High Score");
            Console.SetCursorPosition(10, 14);
            Console.WriteLine("3. Exit Game");
            Console.SetCursorPosition(10, 16);
            Console.Write("Your choice: ");
        }

        private static int UserChoic()
        {
            var userChoice = Console.ReadLine();
            int actualChoice;

            if (int.TryParse(userChoice, out actualChoice))
            {
                return actualChoice;
            }

            return 0;
        }

        private static void ExecuteChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    PlayGame();
                    break;
                case 2:
                    DisplayScores();
                    break;
                case 3: break;
                default: break;
            }
        }

        private static void PlayGame()
        {
            var result = RunGame();

            if ((result.Item2) && (highScoreList.Count() <= 5 || highScoreList.All(score => score.Score >= result.Item1)))
            {
                Console.WriteLine("You are a high scorer, please enter your name: ");

                if (highScoreList.Count() >= 5)
                {
                    highScoreList = highScoreList.OrderBy(s => s.Score).Take(highScoreList.Count() - 1).ToList();
                }

                string userName = Console.ReadLine();
                highScoreList.Add(new HighScore { Name = userName, Score = result.Item1 });
            }
        }

        private static void DisplayScores()
        {
            Console.Clear();
            Console.WriteLine("High Score List.");
            Console.WriteLine("----------------");

            var sno = 1;

            foreach(var score in highScoreList.OrderBy(s => s.Score))
            {
                Console.WriteLine($"{sno++} {score.Name} {score.Score}");
            }

            Console.ReadKey();
        }

        public static Tuple<int, bool> RunGame()
        {
            Console.Clear();
            Random rnd = new Random();
            var number = rnd.Next(1, 99);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Welcome to guessing game. Guess the number between 1 to 100 \n You will have 5 attempts to try : {number}");

            int attempts = 1;
            bool won = false;

            do
            {
                Console.Write($"Attempt {attempts} : ");
                var input = Convert.ToInt32(Console.ReadLine());
                if (input == number)
                {
                    won = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Congratulations!!!, You won.");
                    goto Endgame;
                }
                else
                {
                    Console.WriteLine(string.Format("You are just {0} the number", (input > number) ? "above" : "below"));
                }
                attempts++;
            } while (attempts != 6);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You have lost the game, try again");

            Endgame:
            Console.ResetColor();

            return new Tuple<int, bool>(attempts, won);
        }
    }
}
