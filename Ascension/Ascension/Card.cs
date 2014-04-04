using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class Card
    {
        public Game game
        {
            get;
            private set;
        }

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

        public int endGameHonorGain
        {
            get;
            private set;
        }

        public string faction
        {
            get;
            private set;
        }

        public string cardType
        {
            get;
            private set;
        }



        public Card (Game game, string cardName, System.Drawing.Image cardImage, int runeCost, int powerCost, int runeGains, int powerGains, int endGameHonorGain, int immediateHonorGain, int cardsToDraw, string faction, string cardType)        {
            this.game = game;
            this.cardName = cardName;
            this.cardImage = cardImage;
            this.powerCost = powerCost;
            this.runeCost = runeCost;
            this.runeGain = runeGains;
            this.powerGain = powerGains;
            this.honorGain = immediateHonorGain;
            this.cardsToDraw = cardsToDraw;
            this.faction = faction;
            this.cardType = cardType;
        }


      

        private void changeHonor(int n)
        {
            game.getCurrPlayer().addHonor(n);
        }

        private void changeRunes(int n)
        {
            game.getCurrPlayer().addRunes(n);
        }

        private void changePower(int n)
        {
            game.getCurrPlayer().addPower(n);
        }

        public void playCard()
        {
            changeHonor(this.honorGain);
            changeRunes(this.runeGain);
            changePower(this.powerGain);
        }

        public void banishCard()
        {
          //
        }

    }
}
