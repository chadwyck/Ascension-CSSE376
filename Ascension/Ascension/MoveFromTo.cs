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
        public bool userChoice, optional, willPerformAction;
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
        public override void doAction()
        {
            if (userChoice || optional)
                queryUser();
            else
                doTheAction(null);
        }
        
        public void doTheAction(Card moving)
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
            if(moving==null)
            moving = from.getCard(0);
            
            
                from.remove(moving);
                to.add(moving);
            
        }

        private void queryUser()
        {
            //new OptionalPlay(this);
        }
        public override string printAction()
        {
            return "";
        }

    }
}
