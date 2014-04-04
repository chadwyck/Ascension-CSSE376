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
    public partial class BoardView : Form
    {
        private PortalDeck pDeck;
        private CenterRow cenRow;
        private CardView cardView;
        private InHand inHand;
        private Game game;

        public BoardView(Game gm)
        {
            InitializeComponent();
            cardView = new CardView();
            cardView.Show();
            game = gm;
            
            this.updatePlayer();
            this.currentPlayNum.Text = "Player " + this.game.getCurrPlayer().playerNumber;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Card temp;
            if((temp = game.buyMyst()) != null)
            {
                game.getCurrPlayer().purchase(temp, false, temp.runeCost);
            }
            updatePlayer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Card temp;
            if ((temp = game.buyHI()) != null)
            {
                game.getCurrPlayer().purchase(temp, false, temp.runeCost);
            }
            updatePlayer();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        public void updatePortal(PortalDeck pDek)
        {
            pDeck = pDek;
            portalCombo.Items.Clear();
            portalCombo.Items.AddRange(pDeck.toStringArray());

        }
        public void updateCenRow(CenterRow cRow,PortalDeck pDek)
        {
            cenRow = cRow;
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(cRow.toStringArray());
            updatePortal(pDek);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cardView.update(cenRow.getCard(comboBox1.SelectedIndex));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (game.endOfGame)
            {
                EndGameForm endGameForm = new EndGameForm(this.game);
                endGameForm.Show();
            }
            else
            {
                game.advanceTurn();
                this.currentPlayNum.Text = "Player " + game.getCurrPlayer().playerNumber;
                this.updatePlayer();
            }
        }
        public void updatePlayer()
        {

            playDeck.Items.Clear();
            playHand.Items.Clear();
            playPlay.Items.Clear();
            playDisc.Items.Clear();
            playDeck.Items.AddRange(game.getCurrPlayer().deck.toStringArray());

            playHand.Items.AddRange(game.getCurrPlayer().hand.toStringArray());
            playPlay.Items.AddRange(game.getCurrPlayer().onBoard.toStringArray());
            playDisc.Items.AddRange(game.getCurrPlayer().discardPile.toStringArray());
            lblHonorCount.Text = this.game.honorOnBoard.ToString();
            lblYourHonor.Text = this.game.getCurrPlayer().playerHonor.ToString();
            runeNum.Text = this.game.getCurrPlayer().playerRunes.ToString();
            powNum.Text = this.game.getCurrPlayer().playerPower.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            game.killCultist();
            
        }

        private void playHand_SelectedIndexChanged(object sender, EventArgs e)
        {
            cardView.update(this.game.getCurrPlayer().hand.getCard(playHand.SelectedIndex));


            //cardView.update(cenRow.getCard(comboBox1.SelectedIndex));
        }

        private void playPlay_SelectedIndexChanged(object sender, EventArgs e)
        {
            cardView.update(this.game.getCurrPlayer().onBoard.getCard(playHand.SelectedIndex));
        }

    }
}
