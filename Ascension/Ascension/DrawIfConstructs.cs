using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class DrawIfConstructs : CardAction
    {
        public Game game;
        public DrawIfConstructs(Game game)
        {
            this.game = game;
        }
        override public void doAction()
        {
            if (this.game.getCurrPlayer().constructs.cards.Count >= 2)
            {
                this.game.getCurrPlayer().hand.add(this.game.getCurrPlayer().deck.draw());
            }
        }

        public override string printAction()
        {
            return "";
        }
    }
}
