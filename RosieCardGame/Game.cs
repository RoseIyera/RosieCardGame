using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace RosieCardGame
{
    public class Game
    {
        private Deck deck;
        private Player player1;
        private Player player2;

        private int player1Wins = 0;
        private int player2Wins = 0;
        private int draws = 0;

        public Game()
        {
            deck = new Deck();
            player1 = new Player();
            player2 = new Player();
        }



        public void Start()
        {
            Console.WriteLine("Welcome to the card game!");

            string input;
            int numGames = 1;
            // Declare a variable for tracking ties
            int ties = 0;

            Console.Write("Enter the number of games to play (press enter for 1 game): ");
            input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                int.TryParse(input, out numGames);
            }

            for (int i = 0; i < numGames; i++)
            {
                PlaySingleGame();
                
            }

            if (numGames > 1)
            {
                Console.WriteLine("Games Played: {0}", numGames);
                Console.WriteLine("Player 1 Wins: {0}", player1Wins);
                Console.WriteLine("Player 2 Wins: {0}", player2Wins);
                Console.WriteLine("Ties: {0}", ties);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public void PlaySingleGame()
        {
            // Declare a variable for tracking ties
            int ties = 0;

            Console.WriteLine("Shuffling deck...");
            deck.Shuffle();

            Console.WriteLine("Dealing hands...");
            player1.ClearHand();
            player2.ClearHand();
            player1.AddCardToHand(deck.DrawCard());
            player2.AddCardToHand(deck.DrawCard());
            player1.AddCardToHand(deck.DrawCard());
            player2.AddCardToHand(deck.DrawCard());

            Console.WriteLine("Player 1's hand:");
            DisplayHand(player1);
            Console.WriteLine("Player 2's hand:");
            DisplayHand(player2);

            int player1Value = player1.GetHandValue();
            int player2Value = player2.GetHandValue();

            if (player1Value == 21 || player2Value > 21 || (player1Value > player2Value && player1Value <= 21))
            {
                Console.WriteLine("Player 1 wins!");
                player1Wins++;
            }
            else if (player2Value == 21 || player1Value > 21 || (player2Value > player1Value && player2Value <= 21))
            {
                Console.WriteLine("Player 2 wins!");
                player2Wins++;
            }
            else
            {
                Console.WriteLine("Tie!");
                ties++;
            }
            Console.ReadKey();
        }

        public void DeclareWinner(Player player1, Player player2)
        {
            int player1Total = player1.GetHandValue();
            int player2Total = player2.GetHandValue();

            // Declare a variable for tracking ties
            int ties = 0;

            if (player1Total > player2Total)
            {
                Console.WriteLine("Player 1 wins!");
                player1Wins++;
            }
            else if (player2Total > player1Total)
            {
                Console.WriteLine("Player 2 wins!");
                player2Wins++;
            }
            else
            {
                Console.WriteLine("It's a tie!");
                ties++;
            }
        }


        private void DisplayHand(Player player)
        {
            foreach (Card card in player.Hand)
            {
                Console.WriteLine("{0} of {1}", card.Rank, card.Suit);
            }
            Console.WriteLine("Total value: {0}\n", player.GetHandValue());
        }

        public void PlayMultipleRounds(int roundsToPlay)
        {
            for (int i = 0; i < roundsToPlay; i++)
            {
                Console.WriteLine($"Round {i + 1}");
                PlaySingleGame();
            }
        }

        public void DisplayWinStatistics()
        {
            // Declare a variable for tracking ties
            int ties = 0;

            Console.WriteLine($"Player 1 wins: {player1Wins}");
            Console.WriteLine($"Player 2 wins: {player2Wins}");
            Console.WriteLine($"Ties: {ties}");
        }



    }
}
