using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace Ascension
{
    public partial class OptionalPlay : Form
    {
        private List<String> acts;
        MoveFromTo mv;
        CardCollection from;
        Game game;
        Card move;
        public OptionalPlay(MoveFromTo mvfrto, Game gme)
        {
            game = gme;
            this.mv = mvfrto;
            move = null;
            checkBox1.Text = mvfrto.printAction();
            switch (this.mv.fromCC)
            {
                case "void":
                    from = game.voidDeck;
                    break;
                case "discard":
                    from = game.getCurrPlayer().discardPile;
                    break;
                case "hand":
                    from = game.getCurrPlayer().hand;
                    break;
                case "deck":
                    from = game.getCurrPlayer().deck;
                    break;
            }
            if(this.mv.userChoice){

                

                comboBox1.Items.Clear();
                foreach (Card c in from.cards)
                {
                    comboBox1.Items.Add(c.cardName);
                }

            }
            
            
            InitializeComponent();
        }
        public OptionalPlay()
        {
            InitializeComponent();
        }

        private void OptionalPlay_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.mv.userChoice)
                move = from.getCard(comboBox1.SelectedIndex);
            if (checkBox1.Checked)
                mv.doTheAction(move);
            this.Close();
        }
    }
}
