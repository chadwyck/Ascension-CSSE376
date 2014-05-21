using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascension
{
    public class CardCollection
    {
        public List<Card> cards { get; set; }

        public CardCollection()
        {
            cards = new List<Card>();
        }

        public void add(Card card)
        {
            cards.Add(card);
        }

        public virtual void remove(Card card)
        {
            cards.Remove(card);
        }
        public void Clear()
        {
            cards.Clear();
        }

        public bool containsAvatarOfFallen()
        {
            bool ret = false;

            foreach (var card in cards)
            {
                if (card.cardName.Equals("Avatar of the Fallen"))
                {
                    ret = true;
                }
            }

            return ret;
        }

        public Card getAvatarOfFallen()
        {
            Card ret = null;

            foreach (var card in cards)
            {
                if (card.cardName.Equals("Avatar of the Fallen"))
                {
                    ret = card;
                }
            }

            return ret;
        }

        public String[] toStringArray()
        {
            List<String> names = new List<String>();
            foreach(Card card in cards){
                names.Add(card.cardName);
                
            }
            return names.ToArray();
        }
        public virtual Card getCard(int index)
        {
            return cards.ElementAt<Card>(index);
        }
    }
}
