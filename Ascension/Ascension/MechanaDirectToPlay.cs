using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class MechanaDirectToPlay : CardAction
    {
         private Game game;
         public MechanaDirectToPlay(Game gme) : base()
        {
            this.game = gme;
        }
         public override string printAction()
         {
             return "";
         }

        public override void doAction()
        {
            this.game.mechanaDirectToPlay = true;
        }
    }
}
