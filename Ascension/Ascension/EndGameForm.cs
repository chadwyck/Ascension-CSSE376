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

            label1.Text = extraForms.GameOver;

            List<Label> labels = new List<Label>();
            List<Label> nums = new List<Label>();

            label2.Text = extraForms.Player1;
            label3.Text = extraForms.Player2;
            label7.Text = extraForms.Player3;
            label6.Text = extraForms.Player4;

            labels.Add(label2);
            labels.Add(label3);
            labels.Add(label7);
            labels.Add(label6);

            nums.Add(lblPlayer1Honor);
            nums.Add(lblPlayer2Honor);
            nums.Add(lblPlayer3Honor);
            nums.Add(lblPlayer4Honor);

            foreach (var lbl in labels)
            {
                lbl.Hide();
            }

            foreach (var num in nums)
            {
                num.Hide();
            }

            for (int i = 0; i < game.numPlayers; i++)
            {
                int plr = int.Parse(game.getPlayer(i).playerHonor.ToString());
                plr += this.endGame(game.getPlayer(i));
                nums[i].Text = plr.ToString();
                nums[i].Show();
                labels[i].Show();
            }
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
