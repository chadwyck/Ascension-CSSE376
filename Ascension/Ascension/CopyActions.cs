using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class CopyActions : CardAction
    {
        private Game game;
        public bool userChoice { get; set; }
        public CopyActions(Game gme) : base()
        {
            this.game = gme;
            userChoice = true;
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
            ChoiceForm cf = new ChoiceForm(this);
            cf.Show();
            cf.updateChoiceBox(this.game.getCurrPlayer().onBoard);

            if (!this.userChoice)
            {
                cf.hideCombo();
            }

        }

        public virtual void actuallyDoTheAction(Card moving)
        {
            if (moving == null)
            {
                moving = this.game.getCurrPlayer().onBoard.getCard(0);
            }

            moving.playCard();
            
            this.game.boardView.updateCombos();

        }
    }
}
