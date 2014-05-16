using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class ChangeMetricCount : CardAction
    {
        protected int metricID, incrementBy;
        protected Game game;
        public ChangeMetricCount (int metricID, int incrementBy, Game game)
        {
            this.metricID = metricID;
            this.incrementBy = incrementBy;
            this.game = game;
            this.required = false;
        }
        override public void doAction()
        {
            Player player = game.getCurrPlayer();
            player.changeMetricCount(metricID, incrementBy);
        }
        public override string printAction()
        {
            String type = "";
            String amount = "" + this.incrementBy;
            switch (this.metricID)
            {
            
                case 0:
                    type = strings.Honor;
                    break;
                case 1:
                    type = strings.Runes;
                    break;
                case 2:
                    type = strings.Power;
                    break;
                case 3:
                    type = strings.MechanaRunes;
                    break;
            }

            return strings.Increment + type + strings.ByAmount + amount;
        }
    }
}
