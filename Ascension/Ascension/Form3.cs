using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ascension;

namespace Ascension
{
    public partial class CardView : Form
    {   
        public Card currCard;
        private Card noneSelected;
        public CardView()
        {
            
            InitializeComponent();

            noneSelected = new Card(null, "Please Select a Card", null, 0, 0, 0, "", "basic", null);
        }
        public void update(Card card)
        {
            //currCard = (new CardImport()).cardImport(null).draw();
            currCard = card;
            upFrame();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void upFrame() 
        {
           
                
                cardName.Text = currCard.cardName;
                rCost.Text = currCard.runeCost.ToString();
                pCost.Text = currCard.powerCost.ToString();
                
                pictureBox1.Image = currCard.cardImage;
                pictureBox1.Show();
                killOrPurchase();
        }

        
       
        private void killOrPurchase()
        {
            if (currCard.cardType == "monster")
            {
                Purchase.Visible = false;
                Kill.Visible = true;
            }

            else
            {
                Purchase.Visible = true;
                Kill.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currCard.game.getCurrPlayer().purchase(currCard, false, currCard.runeCost);

            currCard.game.boardView.updatePlayer();
            currCard.game.boardView.updateCenRow(currCard.game.cenRow, currCard.game.pDeck);
            update(noneSelected);

        }

        private void CardView_Load(object sender, EventArgs e)
        {

        }

        private void Play_Click(object sender, EventArgs e)
        {
            if (!currCard.cardName.Equals("Please Select a Card"))
            {
                currCard.game.cardsPlayed.add(currCard);
                currCard.game.getCurrPlayer().play(currCard);
                currCard.game.boardView.updatePlayer();
                update(noneSelected);
            }
        }

        private void Kill_Click(object sender, EventArgs e)
        {
            currCard.game.getCurrPlayer().kill(currCard, currCard.powerCost);

            currCard.game.boardView.updateVoidDeck(currCard.game.voidDeck);
            currCard.game.boardView.updatePlayer();
            currCard.game.boardView.updateCenRow(currCard.game.cenRow, currCard.game.pDeck);
            update(noneSelected);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
