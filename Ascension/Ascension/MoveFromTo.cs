using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class MoveFromTo : CardAction
    {
        private CardCollection fromCC, toCC;
        private bool userChoice, optional, willPerformAction;
        //private Card cardToMove;
        public MoveFromTo (CardCollection fromCC, CardCollection toCC, bool userChoice, bool optional)
        {
            this.fromCC = fromCC;
            this.toCC = toCC;
            this.userChoice = userChoice;
            this.optional = optional;
            
            this.willPerformAction = true;
        }

        override public void doAction()
        {
            Card cardToMove = this.fromCC.getCard(0);
            queryUser();
            if (willPerformAction)
            {
                this.fromCC.remove(cardToMove);
                this.toCC.add(cardToMove);
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
