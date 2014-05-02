using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class MoveFromTo : CardAction
    {
        private String fromCC, toCC;
        private bool userChoice, optional, willPerformAction;
        //private Card cardToMove;
        private Game game;
        public MoveFromTo (String fromCC, String toCC, bool userChoice, bool optional, Game gme)
        {
            this.fromCC = fromCC;
            this.toCC = toCC;
            this.userChoice = userChoice;
            this.optional = optional;
            this.game = gme;
            this.willPerformAction = true;
        }

        override public void doAction()
        {
            CardCollection to =null;
            CardCollection from = null;
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
            }
            Card cardToMove = from.getCard(0);
            queryUser();
            if (willPerformAction)
            {
                from.remove(cardToMove);
                to.add(cardToMove);
            }
        }

        private void queryUser()
        {
            if (userChoice || optional)
            {
                // generate form
            }
        }

    }
}
