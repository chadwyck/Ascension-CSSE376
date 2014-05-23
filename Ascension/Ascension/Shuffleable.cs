using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public abstract class Shuffleable : CardCollection
    {
        public void shuffle()
        {
            int n = this.cards.Count;
            Random rnd = new Random();
            while (n > 1)
            {
                int k = rnd.Next(0, n);
                n--;
                Card val = cards[k];
                cards[k] = cards[n];
                cards[n] = val;
            }
        }
        public virtual Card draw()
        {

            Card card = this.getCard(0);
            remove(card);
            return card;
            
        }
    }
}
