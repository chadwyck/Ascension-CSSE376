using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    class Card
    {
        public string cardName
        {
            get;
            private set;
        }

        public System.Drawing.Image cardImage
        {
            get;
            private set;
        }
        public int runeCost
        {
            get;
            private set;
        }

        public int powerCost
        {
            get;
            private set;
        }

        public int powerGain
        {
            get;
            private set;
        }
        public int runeGain
        {
            get;
            private set;
        }

        public int honorGain
        {
            get;
            private set;
        }

        public int cardsToDraw
        {
            get;
            private set;
        }



        public Card (string cardName, System.Drawing.Image cardImage, int runeCost, int powerCost, int runeGain, int powerGain, int honorGain, int cardsToDraw)
        {
            this.cardName = cardName;
            this.cardImage = cardImage;
            this.powerCost = powerCost;
            this.runeGain = runeGain;
            this.powerGain = powerGain;
            this.honorGain = honorGain;
            this.cardsToDraw = cardsToDraw;
        }
    }
}
