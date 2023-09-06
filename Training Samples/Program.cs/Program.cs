using Program.cs.Models;
using System;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace Program.cs
{
    class Program
    {
        private static List<Score> scoreList = new ();
        static void Main(string[] args)
        {

            int choice;
            do
            { 
                Menus();
                choice = UserChoice();
                MenuOptions(choice);
            } while (choice != 3);
        }
        private static void Menus()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(10, 10);
            Console.WriteLine(" Welcome to Guessing game!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(10, 11);
            Console.WriteLine(" Please Select an option:");
            Console.SetCursorPosition(10, 12);
            Console.WriteLine(" `1` to start a new game");
            Console.SetCursorPosition(10, 13);
            Console.WriteLine(" '2' for Score history");
            Console.SetCursorPosition(10, 14);
            Console.WriteLine(" '3' To exit the menus ");
            Console.SetCursorPosition(10, 16);
            Console.Write("Your Option: ");
        }
        private static int UserChoice()
        {
            var userChoice = Console.ReadLine();
            int actualChoice;

            if (int.TryParse(userChoice, out actualChoice))
            {
                return actualChoice;
            }
            return 0;
        }
        private static void MenuOptions(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Play();
                    break;

                case 2:
                    Console.Clear();
                    DisplayScores();
                    break;

                case 3:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Goodbye");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Default");
                    break;
            }
        }
        public static void Play()
        {
            var result = StartGame();
            string path = @"C:\Users\JunathanA\Documents\Training Samples\Program.cs";
            string fileName = "highScoreFile.txt";
                

            if ((result.Item2) && (scoreList.Count() <= 5 || scoreList.All(score => score.ScoreNum >= result.Item1)))
            {
                 Console.WriteLine("You are a high scorer, please enter your name: ");

                if (scoreList.Count() >= 5)
                {
                    scoreList = scoreList.OrderBy(s => s.ScoreNum).Take(scoreList.Count() - 1).ToList();
                }

                string userName = Console.ReadLine();
               
                
                path = System.IO.Path.Combine(path, fileName);
                if (!File.Exists(path))
                {
                    File.Create(path);
                    using (StreamWriter sw = File.CreateText(path))
                    { 
                            scoreList.Add(new Score{ Name = userName, ScoreNum = result.Item1 });
                           
                            sw.Write(" " + userName);
                            sw.WriteLine(" " + result.Item1.ToString());                    
                    }
                           
                   
                    
            
                } 

                else if (File.Exists(path))
                {
                      using (StreamWriter sw = File.AppendText(path))
                      { 
                       
                       sw.Write(" " + userName);
                       sw.WriteLine(" - " +  result.Item1.ToString());

                      }


                }
                   
               
                
            }

        }

        private static Tuple<int, bool> StartGame()
        {
            Random random = new();
            int returnValue = random.Next(1, 100);
   
            
            Console.Write("I am thinking of a number between ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" 1-100");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Can you guess what it is?");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(returnValue);

           int attempts = 1;
            bool won = false;

            do
            {
                Console.Write($"Attempt {attempts} : ");
                var input = Convert.ToInt32(Console.ReadLine());
                if (input == returnValue)
                {
                    won = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Congratulations!!!, You won.");
                    goto Endgame;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(string.Format("You are just {0} the number", (input > returnValue) ? "above" : "below"));
                }
                attempts++;
            } while (attempts != 6);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You have lost the game, the number was{returnValue} try again");
            Console.ReadKey();

            Endgame:
            Console.ResetColor();
            return new Tuple<int, bool>(attempts, won);
           
        }

        private static void DisplayScores()
        {
            Console.Clear();
           string TxtFile = (@"C:\Users\JunathanA\Documents\Training Samples\Program.cs\highScoreFile.txt");
            Console.WriteLine("High Score List");
            Console.WriteLine("================");
            foreach (string line in File.ReadLines(TxtFile))
            {
                 int sno = 1;
                 Console.WriteLine($"{sno++})" + line);
            }
            Console.WriteLine("");
            Console.WriteLine("Press enter or escape to go back to the main menus...");
            Console.ReadKey();
        }

        
    }
}