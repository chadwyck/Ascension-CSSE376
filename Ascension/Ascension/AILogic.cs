using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class AILogic
    {
        public AI aiPlayer;
        public Game game;

        public AILogic (AI aiPlayer)
        {
            this.aiPlayer = aiPlayer;
            this.game = aiPlayer.game;

        }

        public void buyMystic()
        {
            Card temp = null;

            if ((this.game.myst.length != 0) && (aiPlayer.playerRunes >= 3))
            {

                temp = this.game.myst.getCard(0);
                this.game.myst.remove(temp);
                aiPlayer.addRunes(-3); //these references to aiPlayer really ought to be abstracted
                this.aiPlayer.discardPile.add(temp);
            }
        }

        public void buyHI()
        {
            this.game.buyHI();
        }

    }
}
