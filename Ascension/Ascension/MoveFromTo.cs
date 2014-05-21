using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class MoveFromTo : CopyActions
    {
        public String fromCC, toCC;
        public CardCollection to;
        public CardCollection from;
        public bool isABanish;
        //private Card cardToMove;
        public Game game;

        public bool willPerformAction { get; set; }

        public MoveFromTo (String fromCC, String toCC, bool userChoice, bool optional, bool isABanish, Game gme) : base(gme)
        {
            this.fromCC = fromCC;
            this.toCC = toCC;
            this.userChoice = userChoice;
            this.optional = optional;
            this.isABanish = isABanish;
            this.game = gme;
            this.willPerformAction = true;
            
        }
        public override void doAction()
        {
            if (userChoice || optional)
            {
                this.game.boardView.updateCombos();
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
                case "center":
                    from = game.cenRow;
                    break;
                case "deck":
                    from = game.getCurrPlayer().deck;
                    break;
            }
        }

        public override void actuallyDoTheAction(Card moving)
        {
            if (moving == null)
            {
                moving = from.getCard(0);
            }


            from.remove(moving);
            to.add(moving);

            this.game.boardView.updateCombos();

        }

        new private void queryUser()
        {
            this.doTheAction();
            ChoiceForm cf = new ChoiceForm(this);
            cf.Show();

            CardCollection cc = new CardCollection();
            cc.cards.AddRange(this.from.cards);

            if (cc.containsAvatarOfFallen() && this.isABanish)
            {
                cc.remove(cc.getAvatarOfFallen());
            }


            cf.updateChoiceBox(cc);

            if(!this.userChoice)
            {
                cf.hideCombo();
            }

            if (!this.optional)
            {
                cf.hideOptions();
            }
            
        }
        public override string printAction()
        {
            return "";
        }

    }
}
