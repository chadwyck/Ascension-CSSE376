using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class DiscardsToDeck : CardCollection
    {
        private DiscardDeck discard;
        public DiscardsToDeck(DiscardDeck discrd) : base()
        {
            discard = discrd;
        }
        public void discardCard(Card card)
        {
            remove(card);
            discard.add(card);
        }
        public void discardAllCards()
        {
            while(this.cards.Count>0)
                discardCard(this.getCard(0));
            
        }

    }
}
