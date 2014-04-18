using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class Card
    {
        public Game game { get; set; }

        public string cardName { get; set; }

        public System.Drawing.Image cardImage { get; set; }

        public int runeCost { get;  set; }

        public int powerCost { get; set; }

        public int powerGain { get; private set; } // LEGACY CODE - NEEED TO REMOVE
        
        public int runeGain { get; private set; } // LEGACY CODE - NEEED TO REMOVE

       public int honorGain { get; private set; } // LEGACY CODE - NEEED TO REMOVE

        public int cardsToDraw { get; set; }

        public int endGameHonorGain { get; set; }

        public string faction { get;  set; }

        public string cardType { get; set; }

        public List<CardAction> actions { get; set; }

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
        
        

        public void playCard()
        {
            for (int i = 0; i < game.firstTimeList.Count; i++)
            {
                if (game.firstTimeList[i].checkCase(this.faction, this.cardType))
                {
                    game.firstTimeList[i].gain();
                }
            }
            foreach (var action in this.actions)
            {
                action.doAction();
            }
        }
    }
}
