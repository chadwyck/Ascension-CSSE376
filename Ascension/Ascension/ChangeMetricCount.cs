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
        }
        override public void doAction()
        {
            Player player = game.getCurrPlayer();
            player.changeMetricCount(metricID, incrementBy);
        }
    }
}
