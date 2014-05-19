using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class ConstructDeck : DiscardsToDeck
    {
        private Game game;
        public ConstructDeck (DiscardDeck discrd, Game game) : base(discrd) {
            this.game = game;
        }

        public void destroyOneConstruct (Card card)
        {
            discardCard(card);
        }

        public void destroyAllButOneConstruct (Card card)
        {
            for (int i = 0; i < cards.Count; i++ )
            {
                if (cards[i] != card)
                {
                    remove(cards[i]);   // needs to be fixed.  Index will mess it up.
                }
            }
        }

        public int numberOf(string faction)
        {
            if (faction.Equals("mechana") && this.game.allMechanaConstructs)
            {
                return this.cards.Count;
            }
            int count = 0;

            foreach (Card card in cards)
            {
                if ((card.faction == faction))
                {
                    count++;
                }
            }

            return count;
        }

        public void playAll()
        {
            foreach (var card in cards)
            {
                card.playCard();
            }
        }
    }
}
