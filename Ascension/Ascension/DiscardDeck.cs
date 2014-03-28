using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class DiscardDeck : CardCollection
    {
        HandDeck handDeck;
        public DiscardDeck(HandDeck handDck) : base()
        {
            this.handDeck = handDck;
        }

        public void emptyDiscard()
        {
            while(this.length>0)
            {
                handDeck.add(this.getCard(0));
                remove(this.getCard(0));
            }
            handDeck.shuffle();
        }
    }
}
