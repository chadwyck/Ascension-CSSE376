using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class ConstructDeck : DiscardsToDeck
    {
        public void destroyOneConstruct (Card card)
        {
            discardCard(card);
        }

        public void destroyAllButOneConstruct (Card card)
        {
            foreach (var item in cards)
	        {
                if (item != card)
                {
                    remove(item);
                }
	        }
        }
    }
}
