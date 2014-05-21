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
        public bool optional { get; set; }
        public CardCollection cc { get; set; }
        public CopyActions(Game gme) : base()
        {
            this.game = gme;
            userChoice = true;
            optional = true;
        }
        public override string printAction()
        {
            return "";
        }


        public override void doAction()
        {
            this.game.boardView.updateCombos();
            this.setTheBox(this.game.getCurrPlayer().onBoard);
            queryUser();
        }

        public void setTheBox(CardCollection cc)
        {
            this.cc = cc;
        }

        protected void queryUser()
        {
            ChoiceForm cf = new ChoiceForm(this);
            cf.Show();
            cf.updateChoiceBox(this.cc);

            if (!this.userChoice)
            {
                cf.hideCombo();
            }
            if (!this.optional)
            {
                cf.hideOptions();
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
