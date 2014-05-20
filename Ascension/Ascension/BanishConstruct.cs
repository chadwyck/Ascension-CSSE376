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
    }
}
