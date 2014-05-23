using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class FirstTimeKillMonster : CardAction
    {
        public Game game;
        public FirstTimeKillMonster(Game game) : base()
        {
            this.game = game;
        }


        override public void doAction()
        {
            this.game.firstTimeMonster = true;
        }
        public override string printAction()
        {
            return "";
        }
    }
}
