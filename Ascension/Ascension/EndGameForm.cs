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
            lblPlayer1Honor.Text = game.getPlayer(0).playerHonor.ToString();
            lblPlayer2Honor.Text = game.getPlayer(1).playerHonor.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
