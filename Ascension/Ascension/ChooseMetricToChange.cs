using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class ChooseMetricToChange : CardAction
    {
        public int metricID;
        public Game game;
        public ChooseMetricToChange(Game game)
        {
            this.game = game;
        }
        override public void doAction()
        {
            queryUser();
        }

        public void actuallyDoTheAction()
        {
            Player player = game.getCurrPlayer();
            player.changeMetricCount(metricID, 1);
            this.game.boardView.updatePlayer();
        }
        public override string printAction()
        {
            return "";
        }

        private void queryUser()
        {
            MechanaInitiateChoose cf = new MechanaInitiateChoose(this);
            cf.Show();
        }
    }
}
