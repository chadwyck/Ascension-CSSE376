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
    public partial class StartView : Form
    {
        private Game game;
        private Boolean includeAI;
        public StartView()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyPress +=
                new KeyPressEventHandler(StartView_KeyPress);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void StartView_KeyPress(object sender, KeyPressEventArgs e)
        {


            System.Console.WriteLine("key pressed: " + e.KeyChar.ToString());

            switch (e.KeyChar)
            {
                case (char)Keys.Return:
                    this.button1.PerformClick();
                    break;
                
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!includeAI)
            {
                Game game = new Game(Convert.ToInt32(comboBox1.Text.ToString()), false, false, comboBox2.Text);
            }
            else
            {
                Game game = new Game(Convert.ToInt32(comboBox1.Text.ToString()), true, false, comboBox2.Text);
            }
            this.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            includeAI = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
