using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosieCardGame
{
    public class Player
    {
        public List<Card> Hand { get; private set; }

        public Player()
        {
            Hand = new List<Card>();
        }

        public int GetHandValue()
        {
            int handValue = 0;
            int numAces = 0;

            foreach (Card card in Hand)
            {
                if (card.Rank == "Ace")
                {
                    numAces++;
                    handValue += 1;
                }
                else if (card.Rank == "Jack" || card.Rank == "Queen" || card.Rank == "King")
                {
                    handValue += 10;
                }
                else
                {
                    handValue += int.Parse(card.Rank);
                }
            }

            while (numAces > 0 && handValue + 10 <= 21)
            {
                handValue += 10;
                numAces--;
            }

            return handValue;
        }

        public void AddCardToHand(Card card)
        {
            Hand.Add(card);
        }

        public void ClearHand()
        {
            Hand.Clear();
        }
    }

}
