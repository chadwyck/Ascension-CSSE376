using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascension
{
    public class CardCollection
    {
        public int length { get; set; }
        public List<Card> cards { get; set; }

        public CardCollection()
        {
            length = 0;
            cards = new List<Card>();
        }

        public void add(Card card)
        {
            length++;
            cards.Add(card);
        }

        public virtual void remove(Card card)
        {
            length--;
            cards.Remove(card);
        }
    }
}
