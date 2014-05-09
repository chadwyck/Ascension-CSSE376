using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class ConstructDeck : DiscardsToDeck
    {
        public ConstructDeck (DiscardDeck discrd) : base(discrd) { }

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

        public void playAll()
        {
            foreach (var card in cards)
            {
                card.playCard();
            }
        }
    }
}
