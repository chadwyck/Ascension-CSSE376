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



        public Card (Game game, string cardName, System.Drawing.Image cardImage, int runeCost, int powerCost, int runeGain, int powerGain, int endGameHonorGain, int immediateHonorGain, int cardsToDraw, string faction, string cardType)        {
            this.game = game;
            this.cardName = cardName;
            this.cardImage = cardImage;
            this.powerCost = powerCost;
            this.runeGain = runeGain;
            this.powerGain = powerGain;
            this.honorGain = honorGain;
            this.cardsToDraw = cardsToDraw;
        }


        public void generateCards()
        {
            //
            
        }

        public void moveSelf(CardCollection to, CardCollection from)
        {
            //To-Do: add and remove card
        }

        public void changeHonor(int n)
        {
            game.getPlayer(game.currTurn).addHonor(n);
        }

        public void changeRunes(int n)
        {
            game.getPlayer(game.currTurn).addRunes(n);
        }

        public void changePower(int n)
        {
            game.getPlayer(game.currTurn).addPower(n);
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
