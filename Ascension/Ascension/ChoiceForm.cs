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
    public partial class ChoiceForm : Form
    {
        CopyActions action;
        CardCollection col;

        public ChoiceForm(CopyActions action)
        {
            InitializeComponent();
            this.action = action;

            this.label1.Text = extraForms.WantToDo;
            this.label2.Text = extraForms.PickCard;
            this.button1.Text = extraForms.Yes;
            this.button2.Text = extraForms.No;
            this.button3.Text = extraForms.DoAction;


        }

        public void updateChoiceBox(CardCollection col)
        {
            this.col = col;
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(col.toStringArray());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ChoiceForm_Load(object sender, EventArgs e)
        {
            if ((this.action.game.hasAI) && (this.action.game.currTurn % this.action.game.numPlayers == 0))
            {
                try
                {
                    comboBox1.SelectedIndex = 0;
                    button3.PerformClick();
                    System.Windows.Forms.MessageBox.Show("Performed an action from a card.");
                }
                catch
                {
                    this.Close();
                    System.Windows.Forms.MessageBox.Show("Chose not to perform any card actions.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.action.userChoice)
                {
                    this.action.actuallyDoTheAction(this.col.getCard(comboBox1.SelectedIndex));
                }
                else
                {
                    this.action.actuallyDoTheAction(this.col.cards[0]);
                }

            this.Close();
        }

        public void hideCombo()
        {
            this.label2.Hide();
            this.comboBox1.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        public void hideOptions()
        {
            this.label1.Hide();
            this.button1.Hide();
            this.button2.Hide();
        }
    }
}
