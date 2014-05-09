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
            this.remove(card);
            card.playCard();
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
                System.Console.WriteLine(this.deck.length + " ala " + i + " " + n);
                if (this.deck.length == 0)
                {
                    this.discard.emptyDiscard();

                }
                System.Console.WriteLine(this.deck.length + " " +i+" " + n);
               this.add(this.deck.draw());
            }
        }
    }
}
