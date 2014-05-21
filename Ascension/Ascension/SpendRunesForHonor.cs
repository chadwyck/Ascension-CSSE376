using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    
    public class SpendRunesForHonor : CardAction
    {
        public Game game;
        public SpendRunesForHonor(Game game)
            : base()
        {
            this.game = game;
        }


        override public void doAction()
        {
            YggdrasilForm yf = new YggdrasilForm(this.game);
            yf.Show();
        }
        public override string printAction()
        {
            return "";
        }
    }
}
