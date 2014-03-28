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
    public partial class CardView : Form
    {   
        public Card currCard;
        private Card noneSelected;
        public CardView()
        {
            InitializeComponent();
            noneSelected = new Card(null,"Please Select a Card", null, 0, 0, 0, 0, 0, 0, 0, null, "basic");
        }
        public void update(Card card)
        {
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
                currCard.game.getCurrPlayer().play(currCard);
                currCard.game.boardView.updatePlayer();
                update(noneSelected);
            }
        }
    }
}
