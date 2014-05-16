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

        public System.Drawing.Bitmap cardImage { get; set; }

        public int runeCost { get;  set; }

        public int powerCost { get; set; }


        public int cardsToDraw { get; set; }

        public int endGameHonorGain { get; set; }

        public string faction { get;  set; }

        public string cardType { get; set; }

        public List<CardAction> actions { get; set; }



        public Card(Game game, string cardName, System.Drawing.Bitmap cardImage, int runeCost,
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
            if (!this.cardType.Equals("construct"))
            {
                for (int i = 0; i < game.firstTimeList.Count; i++)
                {
                    if (game.firstTimeList[i].checkCase(this.faction, this.cardType))
                    {
                        game.firstTimeList[i].gain();
                    }
                }
            }
            new OptionalPlay(this.game, this);
            foreach (var action in this.actions)
            {
                action.doAction();
            }
        }
    }
}
