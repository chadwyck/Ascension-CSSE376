﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ascension;

namespace Ascension
{
    public partial class CardView : Form
    {   
        public Card currCard;
        private Card noneSelected;
        public CardView()
        {
            
            InitializeComponent();

            button1.Visible = false;
            label4.Visible = false;
            comboBox1.Visible = false;
            Banish.Visible = false;

            cardName.Text = strings_form3.PleaseSelectCard;
            label2.Text = strings_form3.RuneCost;
            label3.Text = strings_form3.PowerCost;
            label4.Text = strings_form3.Abilities;
            button1.Text = strings_form3.UseSelectedAbility;
            Purchase.Text = strings_form3.Purchase;
            Kill.Text = strings_form3.Kill;
            Play.Text = strings_form3.Play;
            Banish.Text = strings_form3.Banish;
            label5.Text = strings_form3.EndGameHonor;

            noneSelected = new Card(null, strings_form3.PleaseSelectCard, null, 0, 0, 0, "", "basic", null);
        }

        public void changeVisibilityPlayButton(Boolean visible)
        {
            Play.Visible = visible;
        }

        public void changeVisibilityAbilityButton(Boolean visible)
        {
            button1.Visible = visible;
        }

        public void changeVisibilityKillButton(Boolean visible)
        {
            Kill.Visible = visible;
        }

        public void changeVisibilityPurchaseButton(Boolean visible)
        {
            Purchase.Visible = visible;
        }

        public void update(Card card)
        {
            //currCard = (new CardImport()).cardImport(null).draw();
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
                
                pictureBox1.Image = currCard.cardImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Show();
                
                killOrPurchase();
                comboBox1.Items.Clear();
            if(!currCard.cardName.Equals(strings_form3.PleaseSelectCard))
                foreach (CardAction c in currCard.actions)
                {
                    comboBox1.Items.Add(c.printAction());
                }
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

        private void CardView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                MessageBox.Show("Form.KeyPress: '" +
                    e.KeyChar.ToString() + "' pressed.");

                switch (e.KeyChar)
                {
                    case (char)49:
                    case (char)52:
                    case (char)55:
                        MessageBox.Show("Form.KeyPress: '" +
                            e.KeyChar.ToString() + "' consumed.");
                        e.Handled = true;
                        break;
                }
            }
        }

        public void clickPurchaseButton()
        {
            Purchase.PerformClick();
        }

        public void clickKillButton()
        {
            Kill.PerformClick();
        }

        private void Play_Click(object sender, EventArgs e)
        {
            if (!currCard.cardName.Equals("Please Select a Card"))
            {
                currCard.game.cardsPlayed.add(currCard);
                currCard.game.getCurrPlayer().play(currCard);
                currCard.game.boardView.updatePlayer();
                update(noneSelected);
            }
        }

        private void Kill_Click(object sender, EventArgs e)
        {
            currCard.game.getCurrPlayer().kill(currCard, currCard.powerCost);

            currCard.game.boardView.updateVoidDeck(currCard.game.voidDeck);
            currCard.game.boardView.updatePlayer();
            currCard.game.boardView.updateCenRow(currCard.game.cenRow, currCard.game.pDeck);
            update(noneSelected);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Banish_Click(object sender, EventArgs e)
        {
            currCard.game.getCurrPlayer().banish(currCard);
            currCard.game.boardView.updateVoidDeck(currCard.game.voidDeck);
            currCard.game.boardView.updatePlayer();
            update(noneSelected);
        }
    }
}
