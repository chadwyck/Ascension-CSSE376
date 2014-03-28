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
        public InHand(DiscardDeck discrd, InPlay inPly) : base(discrd)
        {
            inPlay = inPly;
        }
        public void playCard(Card card)
        {
            inPlay.add(card);
        }
    }
}
