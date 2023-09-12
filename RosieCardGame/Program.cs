using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosieCardGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            string[] menuOptions = new string[] { "Play", "How to Play", "Exit" };
            int selectedOption = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"
 ____   __   ____  __  ____     ___   __   ____  ____  ____ 
(  _ \ /  \ / ___)(  )(  __)   / __) / _\ (  _ \(    \/ ___)
 )   /(  O )\___ \ )(  ) _)   ( (__ /    \ )   / ) D (\___ \
(__\_) \__/ (____/(__)(____)   \___)\_/\_/(__\_)(____/(____/)
");
                Console.WriteLine("Welcome to Rosie Cards! What would you like to do?");

                for (int i = 0; i < menuOptions.Length; i++)
                {
                    if (i == selectedOption)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }

                    Console.WriteLine($" {(i + 1)}. {menuOptions[i]} ");

                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selectedOption > 0)
                        {
                            selectedOption--;
                        }
                        else
                        {
                            selectedOption = menuOptions.Length - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectedOption < menuOptions.Length - 1)
                        {
                            selectedOption++;
                        }
                        else
                        {
                            selectedOption = 0;
                        }
                        break;
                    case ConsoleKey.Enter:
                        switch (selectedOption)
                        {
                            case 0:
                                Console.Clear();
                                Console.WriteLine("How many rounds would you like to play? (Enter a number, or press Enter for a single game)");
                                string input = Console.ReadLine();
                                if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int rounds))
                                {
                                    game.PlayMultipleRounds(rounds);
                                }
                                else
                                {
                                    game.PlaySingleGame();
                                }
                                game.DisplayWinStatistics();
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;
                            case 1:
                                Console.Clear();
                                Console.WriteLine("How to Play:");
                                Console.WriteLine("1. The game uses a standard deck of 52 playing cards.");
                                Console.WriteLine("2. The deck is shuffled before each game.");
                                Console.WriteLine("3. The game is played by two players. Each player is dealt a hand of cards.");
                                Console.WriteLine("4. The value of a card is determined by its rank (Ace has a value of 1, face cards have a value of 10, and all other cards have a value equal to their rank).");
                                Console.WriteLine("5. The goal of the game is to win more rounds than your opponent by having the higher card in each round.");
                                Console.WriteLine("6. If there is a tie, the round is considered a draw and no one wins.");
                                Console.WriteLine("7. A new round begins after each player plays a card.");
                                Console.WriteLine("8. The game ends when all cards have been played.");
                                Console.WriteLine("\nPress any key to go back to the main menu...");
                                Console.ReadKey();
                                    break;
                                case 2:
                                    Environment.Exit(0);
                                    break;
                        }
                            break;
                }
            }
        }
    }

    
}




        
