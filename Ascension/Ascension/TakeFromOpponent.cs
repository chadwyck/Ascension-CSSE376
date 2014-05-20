using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
   
    public class TakeFromOpponent : CardAction
    {
        private Game game;
        public TakeFromOpponent(Game gme) : base()
        {
            this.game = gme;
        }
        public override string printAction()
        {
            return "";
        }


        public override void doAction()
        {
            List<Card> cards = new List<Card>();
            foreach (var player in this.game.plyrs)
            {
                if (player.Equals(this.game.getCurrPlayer()))
                {
                    continue;
                }
                cards.Add(player.hand.takeOneAtRandom());
            }
            this.game.getCurrPlayer().hand.cards.AddRange(cards);
            this.game.boardView.updateCombos();
        }
    }
}
