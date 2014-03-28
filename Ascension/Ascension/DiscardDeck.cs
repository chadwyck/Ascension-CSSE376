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
            while(this.length>0)
            {
                ret.Add(this.getCard(0));
                remove(this.getCard(0));
            }
            return ret;
        }
    }
}
