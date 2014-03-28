using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{   
    public class HandDeck : Shuffleable
    {   
        
        public void addToTop(Card card)
        {
            cards.Insert(0, card);
        }
    }
}
