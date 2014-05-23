using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{    
    public class DestroyConstructs : CopyActions
    {
        public Game game;
        public bool destroyAll;
        public DestroyConstructs(Game game, bool destroyAll) : base(game)
        {
            this.game = game;
            this.destroyAll = destroyAll;
          
        }

        override public void doAction()
        {
            foreach (var player in this.game.plyrs)
            {
                if (!player.Equals(this.game.getCurrPlayer()))
                {
                    player.destroyConstructs.Add(this);
                }
            }
        }

        public void queryTheUser()
        {
            if (this.game.getCurrPlayer().constructs.cards.Count > 0)
            {
                base.userChoice = true;
                base.optional = false;
                base.setTheBox(this.game.getCurrPlayer().constructs);
                base.queryUser();
            }
        }

        public override void actuallyDoTheAction(Card moving)
        {
            if (this.destroyAll)
            {
                this.game.getCurrPlayer().constructs.destroyAllButOneConstruct(moving);
            }
            else
            {
                this.game.getCurrPlayer().constructs.destroyOneConstruct(moving);
            }
            
            this.game.boardView.updateCombos();
        }

        public override string printAction()
        {
            return "";
        }
    }
}
