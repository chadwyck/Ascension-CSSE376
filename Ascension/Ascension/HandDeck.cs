using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{   
    public class HandDeck : Shuffleable
    {
        DiscardDeck discard;
        public override Card getCard(int index)
        {
            if (this.length == 0)
            {
                this.discard.emptyDiscard();
            }
            return cards.ElementAt<Card>(index);
        }
        public void addToTop(Card card)
        {
            cards.Insert(0, card);
        }

        internal void setDiscard(DiscardDeck discardDeck)
        {
            this.discard = discardDeck;
        }
    }
}
