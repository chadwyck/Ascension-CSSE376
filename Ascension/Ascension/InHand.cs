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

        public Card takeOneAtRandom()
        {
            int n = this.cards.Count;
            if (n == 0)
            {
                return null;
            }
            Random rnd = new Random();
            while (n > 1)
            {
                int k = rnd.Next(0, n);
                n--;
                Card val = cards[k];
                cards[k] = cards[n];
                cards[n] = val;
            }
            Card ret = cards[0];
            this.remove(ret);
            return ret;
        }
        
        public void draw(int n)
        {
            for (int i = 0; i < n; i++)
            {
                
                if (this.deck.cards.Count == 0)
                {
                    this.discard.emptyDiscard();

                }
                System.Console.WriteLine(this.deck.cards.Count);
               this.add(this.deck.draw());
               System.Console.WriteLine(this.deck.cards.Count);
            }
        }
    }
}
