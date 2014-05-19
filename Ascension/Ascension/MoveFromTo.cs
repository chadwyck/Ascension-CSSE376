using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class MoveFromTo : CardAction
    {
        public String fromCC, toCC;
        public bool userChoice, optional;
        CardCollection to;
        CardCollection from;
        //private Card cardToMove;
        private Game game;

        public bool willPerformAction { get; set; }

        public MoveFromTo (String fromCC, String toCC, bool userChoice, bool optional, Game gme)
        {
            this.fromCC = fromCC;
            this.toCC = toCC;
            this.userChoice = userChoice;
            this.optional = optional;
            this.game = gme;
            this.willPerformAction = true;
            
        }
        public override void doAction()
        {
            if (userChoice || optional)
            {
                queryUser();
            }
            else
            {
                doTheAction();
                actuallyDoTheAction(null);
            }
                
        }
        
        public void doTheAction()
        {
            to = null;
            from = null;

            switch (this.toCC)
            {
                case "void":
                    to = game.voidDeck;
                    break;
                case "discard":
                    to = game.getCurrPlayer().discardPile;
                    break;
                case "hand":
                    to = game.getCurrPlayer().hand;
                    break;
            }
            switch (this.fromCC)
            {
                case "void":
                    from = game.voidDeck;
                    break;
                case "discard":
                    from = game.getCurrPlayer().discardPile;
                    break;
                case "hand":
                    from = game.getCurrPlayer().hand;
                    break;
                case "deck":
                    from = game.getCurrPlayer().deck;
                    break;
            }
        }

        public void actuallyDoTheAction(Card moving)
        {
            if (moving == null)
            {
                moving = from.getCard(0);
            }


            from.remove(moving);
            to.add(moving);

            this.game.boardView.updatePlayer();

        }

        private void queryUser()
        {
            this.doTheAction();
            ChoiceForm cf = new ChoiceForm(this);
            cf.Show();
            cf.updateChoiceBox(this.from);

            if(!this.userChoice)
            {
                cf.hideCombo();
            }
            
        }
        public override string printAction()
        {
            return "";
        }

    }
}
