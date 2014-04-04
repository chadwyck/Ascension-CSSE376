using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class Card
    {
        public Game game { get; private set; }

        public string cardName { get; private set; }

        public System.Drawing.Image cardImage { get; private set; }

        public int runeCost { get; private set; }

        public int powerCost { get; private set; }

        public int powerGain { get; private set; } // LEGACY CODE - NEEED TO REMOVE
        
        public int runeGain { get; private set; } // LEGACY CODE - NEEED TO REMOVE

        public int honorGain { get; private set; } // LEGACY CODE - NEEED TO REMOVE

        public int cardsToDraw { get; private set; }

        public int endGameHonorGain { get; private set; }

        public string faction { get; private set; }

        public string cardType { get; private set; }

        public List<CardAction> actions { get; private set; }

        public Card (Game game, string cardName, System.Drawing.Image cardImage, int runeCost,
                    int powerCost, int runeGain, int powerGain, int endGameHonorGain,
                    int immediateHonorGain, int cardsToDraw, string faction, string cardType) // LEGACY CODE - NEEED TO REMOVE
        {
            this.game = game;
            this.cardName = cardName;
            this.cardImage = cardImage;
            this.powerCost = powerCost;
            this.runeCost = runeCost;
            this.runeGain = runeGain;
            this.powerGain = powerGain;
            this.honorGain = honorGain;
            this.cardsToDraw = cardsToDraw;
            this.faction = faction;
            this.cardType = cardType;
        }

        public Card (Game game, string cardName, System.Drawing.Image cardImage, int runeCost,
                    int powerCost, int endGameHonorGain, string faction, string cardType, List<CardAction> actions)
        {
            this.game = game;
            this.cardName = cardName;
            this.cardImage = cardImage;
            this.runeCost = runeCost;
            this.powerCost = powerCost;
            this.endGameHonorGain = endGameHonorGain;
            this.faction = faction;
            this.cardType = cardType;
            this.actions = actions;
        }

        public void moveSelf(CardCollection to, CardCollection from) // LEGACY CODE - NEEED TO REMOVE
        {
            //To-Do: add and remove card
        }

        public void changeHonor(int n) // LEGACY CODE - NEEED TO REMOVE
        {
            game.getPlayer(game.currTurn).addHonor(n);
        }

        public void changeRunes(int n) // LEGACY CODE - NEEED TO REMOVE
        {
            game.getPlayer(game.currTurn).addRunes(n);
        }

        public void changePower(int n) // LEGACY CODE - NEEED TO REMOVE
        {
            game.getPlayer(game.currTurn).addPower(n);
        }

        public void playCard()
        {
            //if ((honorGain + runeGain + powerGain) != 0) // LEGACY CODE - NEEED TO REMOVE
            //{
            //    changeHonor(this.honorGain); 
            //    changeRunes(this.runeGain);
            //    changePower(this.powerGain);
            //}
            //else
            //{
                foreach (var action in this.actions)
                {
                    action.doAction();
                }
            //}
        }

        public void banishCard() // LEGACY CODE - NEEED TO REMOVE
        {
            //
        }
    }
}
