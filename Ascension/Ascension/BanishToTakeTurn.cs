using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class BanishToTakeTurn : CardAction
    {
        public Game game;
        private Card card;
        public BanishToTakeTurn(Game gme)
            : base()
        {
            this.game = gme;
        }
        public override string printAction()
        {
            return "";
        }


        public override void doAction()
        {
            this.game.boardView.updateCombos();
            queryUser();
        }

        private void queryUser()
        {
            BanishConstruct bc = new BanishConstruct(this);
            bc.Show();
            
        }

        public void actuallyDoTheAction()
        {
            this.card = this.game.getCurrPlayer().constructs.getTabletOfTimesDawn(this);
            this.game.extraTurn = true;
            this.game.getCurrPlayer().constructs.remove(this.card);
            this.game.voidDeck.add(this.card);
            this.game.boardView.updateCombos();
        }
    }
}
