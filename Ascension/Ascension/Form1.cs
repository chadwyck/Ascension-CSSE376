﻿using System;
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
        public StartView()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Game game = new Game(Convert.ToInt32(comboBox1.Text.ToString()));
            this.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
