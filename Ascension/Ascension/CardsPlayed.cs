using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class CardsPlayed : CardCollection
    {

        public CardsPlayed() : base()
        {
            
        }

        public int numberOf(string faction, string cardType)
        {
            int count = 0;

            foreach (Card card in cards)
            {
                if((card.faction == faction) && (card.cardType == cardType))
                {
                    count++;
                }
            }

            return count;
        }
        //public int numberOfFaction(string faction)
        //{
        //    int count = 0;

        //    foreach (Card card in cards)
        //    {
        //        if (card.faction == faction)
        //        {
        //            count++;
        //        }
        //    }

        //    return count;
        //}
        //public int numberOfCardType(string cardType)
        //{
        //    int count = 0;

        //    foreach (Card card in cards)
        //    {
        //        if (card.cardType == cardType)
        //        {
        //            count++;
        //        }
        //    }

        //    return count;
        //}
    }
}
