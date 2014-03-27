using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class CenterRow : CardCollection
    {
        private PortalDeck pDeck;
        private VoidDeck vDeck;

        public CenterRow(PortalDeck PortalDeck, VoidDeck VoidDeck)
        {
            pDeck = PortalDeck;
            vDeck = VoidDeck;

            for (int i = 0; i < 6; i++)
            {
                cards.Add(pDeck.draw());
            }
        }

        public override void remove(Card card)
        {
            base.remove(card);
            vDeck.add(card);
            cards.Add(pDeck.draw());
        }
    }
}
