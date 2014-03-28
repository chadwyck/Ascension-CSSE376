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
        public BoardView()
        {
            InitializeComponent();
            cardView = new CardView();
            cardView.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

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
    }
}
