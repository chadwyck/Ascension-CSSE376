using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class MoveBlahOrLess : MoveFromTo 
    {
        public int metric, atMost;
        public string type;
        public MoveBlahOrLess(String fromCC, string type, int metric, int atMost, Game gme)
            : base(fromCC, fromCC, true, false, false, gme)
        {
            this.metric = metric;
            this.atMost = atMost;
            this.type = type;
        }

        new private void queryUser()
        {
            this.doTheAction();
            ChoiceForm cf = new ChoiceForm(this);
            cf.Show();
            cf.updateChoiceBox(this.from);

            cf.hideOptions();
            
        }

        public override void doAction()
        {
                this.game.boardView.updateCombos();
                queryUser();
        }

        public override void actuallyDoTheAction(Card moving)
        {
            if (moving == null)
            {
                if (this.type.Equals("monster"))
                {
                    this.game.getCurrPlayer().addHonor(1); // kill cultist
                    this.game.boardView.updatePlayer();
                } else {
                    Card temp;
                    if ((temp = game.buyMyst()) != null)
                    {
                        this.game.getCurrPlayer().deck.addToTop(temp);
                    }
                    this.game.boardView.updatePlayer();
                }
            }

            if (moving.cardType.Equals(this.type))
            {
                if (this.type.Equals("monster"))
                {
                    if (moving.powerCost <= this.atMost)
                    {
                        this.game.getCurrPlayer().kill(moving, 0);
                    }
                    else
                    {
                        this.game.getCurrPlayer().addHonor(1); // kill cultist
                        this.game.boardView.updatePlayer();
                    }
                }
                else
                {
                    if (moving.runeCost <= this.atMost)
                    {
                        from.remove(moving);
                        this.game.getCurrPlayer().deck.addToTop(moving);
                    }
                    else
                    {
                        Card temp;
                        if ((temp = game.buyMyst()) != null)
                        {
                            this.game.getCurrPlayer().deck.addToTop(temp);
                        }
                        this.game.boardView.updatePlayer();
                    }
                }
                
            }

            

            this.game.boardView.updateCombos();
        }
    }
}
