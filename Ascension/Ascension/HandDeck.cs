using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{   
    public class HandDeck : Shuffleable
    {
        public DiscardDeck discard;
        public override Card getCard(int index)
        {
            if (this.cards.Count == 0)
            {
                this.discard.emptyDiscard();
                return this.getCard(0);
            } else
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

        public override Card draw()
        {

            Card card = this.getCard(0);
            remove(card);
            return card;

        }

    }
}
