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
        public CardView()
        {
            InitializeComponent();
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

        }
    }
}
