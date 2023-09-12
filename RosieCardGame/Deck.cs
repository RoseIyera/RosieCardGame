using System.Collections.Generic;
using System;
using System.Linq;

namespace RosieCardGame
{
    public class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();

            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    Card card = new Card(suit, rank);
                    cards.Add(card);
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();

            for (int i = 0; i < cards.Count; i++)
            {
                int j = random.Next(i, cards.Count);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        public List<Card> Deal(int numCards)
        {
            List<Card> hand = new List<Card>();

            for (int i = 0; i < numCards; i++)
            {
                Card card = cards[0];
                cards.RemoveAt(0);
                hand.Add(card);
            }

            return hand;
        }

        public Card DrawCard()
        {
            Card drawnCard = null;

            if (cards.Count > 0)
            {
                drawnCard = cards[cards.Count - 1];
                cards.RemoveAt(cards.Count - 1);
            }

            return drawnCard;
        }

    }





}