using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class AI : Player
    {
        int playerNum;
        public AI(Game game, int playerNum): base()
        {
            base.game = game;
            this.playerNum = playerNum;
        }
    }
}
