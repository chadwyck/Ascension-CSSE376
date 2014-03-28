using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class DiscardDeck : CardCollection
    {

        public List<Card> emptyDiscard()
        {
            List<Card> ret = new List<Card>();
            foreach (var item in cards)
            {
                ret.Add(item);
                remove(item);
            }
            return ret;
        }
    }
}
