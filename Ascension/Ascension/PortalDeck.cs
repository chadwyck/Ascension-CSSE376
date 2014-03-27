using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascension
{
    public class PortalDeck : Shuffleable
    {

        public PortalDeck()
        {

        }

        public Card draw()
        {
            Card card = cards[0];
            remove(card);
            return card;
        }

    }
}
