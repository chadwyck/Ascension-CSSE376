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
    public partial class BanishConstruct : Form
    {
        public BanishToTakeTurn act;
        public BanishConstruct(BanishToTakeTurn act)
        {
            InitializeComponent();
            this.act = act;

            this.label1.Text = extraForms.BanishConstruct;
            this.button1.Text = extraForms.Yes;
            this.button2.Text = extraForms.No;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.act.actuallyDoTheAction();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BanishConstruct_Load(object sender, EventArgs e)
        {
            if ((this.act.game.hasAI) && (this.act.game.currTurn % this.act.game.numPlayers == 0))
                button2.PerformClick();
        }
    }
}
