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
    public partial class YggdrasilForm : Form
    {
        public Game game;
        public YggdrasilForm(Game game)
        {
            InitializeComponent();
            this.game = game;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (game.getCurrPlayer().playerRunes >= 4)
            {
                this.game.getCurrPlayer().playerRunes = this.game.getCurrPlayer().playerRunes - 4;
                this.game.getCurrPlayer().changeMetricCount(0, 3);
                this.game.boardView.updatePlayer();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
