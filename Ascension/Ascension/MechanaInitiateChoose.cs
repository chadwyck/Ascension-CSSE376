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
    public partial class MechanaInitiateChoose : Form
    {
        ChooseMetricToChange act;
        public MechanaInitiateChoose(ChooseMetricToChange act)
        {
            this.act = act;
            InitializeComponent();

            this.button1.Text = extraForms.OneRune;
            this.button2.Text = extraForms.OnePower;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.act.metricID = 1;
            this.act.actuallyDoTheAction();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.act.metricID = 2;
            this.act.actuallyDoTheAction();
            this.Close();
        }

        private void MechanaInitiateChoose_Load(object sender, EventArgs e)
        {
            if ((this.act.game.hasAI) && (this.act.game.currTurn % this.act.game.numPlayers == 0))
            {
                button1.PerformClick(); //For now, the AI will always choose runes.
            }
        }
    }
}
