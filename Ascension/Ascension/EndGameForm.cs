using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ascension
{
    public partial class EndGameForm : Form
    {
        private Game game;
        public EndGameForm(Game game)
        {
            this.game = game;
            InitializeComponent();

            int plr1 = int.Parse(game.getPlayer(0).playerHonor.ToString());
            int plr2 = int.Parse(game.getPlayer(1).playerHonor.ToString());

            plr1 += this.endGame(game.getPlayer(0));
            plr2 += this.endGame(game.getPlayer(1));

            lblPlayer1Honor.Text = plr1.ToString();
            lblPlayer2Honor.Text = plr2.ToString();
        }

        public int endGame(Player plyr)
        {
            int ret = 0;
            ret += plyr.deck.getEndGameHonor();
            ret += plyr.constructs.getEndGameHonor();
            ret += plyr.discardPile.getEndGameHonor();
            ret += plyr.hand.getEndGameHonor();
            ret += plyr.onBoard.getEndGameHonor();

            return ret;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
