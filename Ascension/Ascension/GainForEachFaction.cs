using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{ 
    public class GainForEachFaction : CardAction
    {
        public Game game;
        public GainForEachFaction(Game game) : base()
        {
            this.game = game;
        }


        override public void doAction()
        {
            List<string> facts = new List<string>();
            foreach (var card in this.game.getCurrPlayer().constructs.cards)
            {
                if (!facts.Contains(card.faction))
                {
                    facts.Add(card.faction);
                }
            }
            this.game.getCurrPlayer().changeMetricCount(0, facts.Count);
        }
        public override string printAction()
        {
            return "";
        }
    }
}
