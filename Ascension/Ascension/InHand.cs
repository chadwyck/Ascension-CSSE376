using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class InHand : DiscardsToDeck
    {
        InPlay inPlay;
        HandDeck deck;
        DiscardDeck discard;
        public InHand(DiscardDeck discrd, InPlay inPly, HandDeck dck) : base(discrd)
        {
            discard = discrd;
            deck = dck;
            inPlay = inPly;
        }
        public void playCard(Card card)
        {
            inPlay.add(card);
        }
        public void newHand()
        {
            this.inPlay.discardAllCards();
            this.discardAllCards();
            this.draw(5);
        }
        public void draw(int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (this.deck.length == 0)
                {
                    this.discard.emptyDiscard();
                }

                this.add(this.deck.draw());
            }
        }
    }
}
