using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class FirstTimeGet : ChangeMetricCount
    {
        string faction, cardType;
        public FirstTimeGet (string faction, string cardType, int metricID, int incrementBy, Game game) : base(metricID,incrementBy,game)
        {
            this.faction = faction;
            this.cardType = cardType;
        }

        public bool checkCase(string faction, string cardType)
        {
            return (this.faction == faction && this.cardType == cardType);
        }

        override public void doAction()
        {
            this.game.firstTimeList.Add(this);
        }

        public void gain()
        {
            base.doAction();
        }
        public override string printAction()
        {
            return "";
        }

    }
}
