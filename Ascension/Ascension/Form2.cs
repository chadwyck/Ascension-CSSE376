using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace Ascension
{
    public partial class BoardView : Form
    {
        private PortalDeck pDeck;
        private CardCollection voidDeck;
        private CenterRow cenRow;
        public CardView cardView;
        private InHand inHand;
        private ConstructDeck constDeck;
        private Game game;
        private AILogic aiLogic;

        public BoardView(Game gm)
        {
            this.initialize(gm, false);
        }

        public BoardView(Game gm, bool f)
        {
            this.initialize(gm, f);
        }

        private void initialize(Game gm, bool f)
        {
            InitializeComponent();
            this.voidDeck = new CardCollection();
            //Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-FR");
            //Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            this.KeyPreview = true;
            this.KeyPress +=
                new KeyPressEventHandler(BoardView_KeyPress);

            label9.Text = strings.Honor;
            currentPlayNum.Text = strings.Player;
            label7.Text = strings.Runes;
            label8.Text = strings.Power;
            button1.Text = strings.BuyMystic;
            button2.Text = strings.BuyHI;
            button3.Text = strings.KillCultist;
            button4.Text = strings.EndTurn;
            button6.Text = strings.PlayAll;
            label1.Text = strings.CenterRow;
            label2.Text = strings.CurrentHand;
            label3.Text = strings.OnTable;
            label4.Text = strings.DiscardPile;
            label5.Text = strings.Deck;
            label13.Text = strings.YourHonor;
            label6.Text = strings.Constructs;
            label15.Text = strings.TheVoid;
            label16.Text = strings.Portal;

            cardView = new CardView();
            if (!f)
                cardView.Show();
            game = gm;

            this.updatePlayer();
            this.currentPlayNum.Text = "Player " + this.game.getCurrPlayer().playerNumber;
        }

        private void BoardView_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                
                System.Console.WriteLine("key pressed: " + e.KeyChar.ToString());

                switch (e.KeyChar)
                {
                    case 'a':
                        this.button6.PerformClick();
                        SendKeys.Send("{BS}");
                        this.comboBox1.DroppedDown = false;
                        this.playHand.DroppedDown = false;
                        break;
                    case 'e':
                        this.button4.PerformClick();
                        SendKeys.Send("{BS}");
                        this.comboBox1.DroppedDown = false;
                        this.playHand.DroppedDown = false;
                        break;
                    case 'm':
                        this.button1.PerformClick();
                        SendKeys.Send("{BS}");
                        this.comboBox1.DroppedDown = false;
                        this.playHand.DroppedDown = false;
                        break;
                    case 'i':
                        this.button2.PerformClick();
                        SendKeys.Send("{BS}");
                        this.comboBox1.DroppedDown = false;
                        this.playHand.DroppedDown = false;
                        break;
                    case 'k':
                        this.button3.PerformClick();
                        SendKeys.Send("{BS}");
                        this.comboBox1.DroppedDown = false;
                        this.playHand.DroppedDown = false;
                        break;
                    case 'c':
                        SendKeys.Send("{BS}");
                        this.comboBox1.Select();
                        this.comboBox1.DroppedDown = true;
                        this.playHand.DroppedDown = false;
                        this.playHand.SelectedItem = "";
                        break;
                    case 'h':
                        SendKeys.Send("{BS}");
                        this.playHand.Select();
                        this.playHand.DroppedDown = true;
                        this.comboBox1.DroppedDown = false;
                        this.comboBox1.SelectedItem = "";
                        break;
                    case 'p':
                        this.cardView.Play.PerformClick();
                        SendKeys.Send("{BS}");
                        this.comboBox1.DroppedDown = false;
                        this.playHand.DroppedDown = false;
                        break;
                    case '4':
                        this.cardView.Purchase.PerformClick();
                        SendKeys.Send("{BS}");
                        this.comboBox1.DroppedDown = false;
                        this.playHand.DroppedDown = false;
                        break;
                    case '`':
                        this.cardView.Kill.PerformClick();
                        SendKeys.Send("{BS}");
                        this.comboBox1.DroppedDown = false;
                        this.playHand.DroppedDown = false;
                        break;
                    
                }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Card temp;
            if((temp = game.buyMyst()) != null)
            {
                game.getCurrPlayer().purchase(temp, false, temp.runeCost);
            }
            updatePlayer();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Card temp;
            if ((temp = game.buyHI()) != null)
            {
                game.getCurrPlayer().purchase(temp, false, temp.runeCost);
            }
            updatePlayer();
            this.game.canDoMore();
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
        public void updateVoidDeck(CardCollection vdDeck)
        {
            voidDeck = vdDeck;
            voidCombo.Items.Clear();
            voidCombo.Items.AddRange(voidDeck.toStringArray());

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
            cardView.changeVisibilityPlayButton(false);
            cardView.changeVisibilityAbilityButton(false);
            cardView.update(cenRow.getCard(comboBox1.SelectedIndex));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (game.endOfGame)
            {
                EndGameForm endGameForm = new EndGameForm(this.game);
                endGameForm.Show();
            }
            else
            {
                button4.BackColor = Color.Red;
                game.advanceTurn();
                this.currentPlayNum.Text = "Player " + game.getCurrPlayer().playerNumber;
                this.updatePlayer();
            }
        }

        public void updateCombos()
        {
            this.updatePlayer();
            this.updateVoidDeck(this.game.voidDeck);
            this.updateCenRow(this.game.cenRow,this.game.pDeck);
            this.updatePortal(this.game.pDeck);
        }
        public void updatePlayer()
        {

            playDeck.Items.Clear();
            playHand.Items.Clear();
            playPlay.Items.Clear();
            playDisc.Items.Clear();
            playConstructs.Items.Clear();
            playDeck.Items.AddRange(game.getCurrPlayer().deck.toStringArray());
            playHand.Items.AddRange(game.getCurrPlayer().hand.toStringArray());
            playPlay.Items.AddRange(game.getCurrPlayer().onBoard.toStringArray());
            playDisc.Items.AddRange(game.getCurrPlayer().discardPile.toStringArray());
            playConstructs.Items.AddRange(game.getCurrPlayer().constructs.toStringArray());
            lblHonorCount.Text = this.game.honorOnBoard.ToString();
            lblYourHonor.Text = this.game.getCurrPlayer().playerHonor.ToString();
            runeNum.Text = this.game.getCurrPlayer().playerRunes.ToString();
            mechRuneNum.Text = this.game.getCurrPlayer().playerMechRunes.ToString();
            constRuneNum.Text = this.game.getCurrPlayer().playerConstRunes.ToString();
            powNum.Text = this.game.getCurrPlayer().playerPower.ToString();
            if (!this.game.canDoMore())
            {
                button4.BackColor = Color.Green;
            }


        }

        public void clickPlayAll()
        {
            button6.PerformClick();
        }

        public void selectCard(int indexOfCard)
        {
            comboBox1.SelectedIndex = indexOfCard;
            cardView.Update();
            Thread.Sleep(1000);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            game.killCultist();
            
        }

        private void playHand_SelectedIndexChanged(object sender, EventArgs e)
        {

            cardView.changeVisibilityPlayButton(true);
            cardView.changeVisibilityAbilityButton(false);
            cardView.update(this.game.getCurrPlayer().hand.getCard(playHand.SelectedIndex));


            //cardView.update(cenRow.getCard(comboBox1.SelectedIndex));
        }

        private void playPlay_SelectedIndexChanged(object sender, EventArgs e)
        {
            cardView.changeVisibilityPlayButton(false);
            cardView.changeVisibilityPurchaseButton(false);
            cardView.changeVisibilityAbilityButton(true);
            cardView.update(this.game.getCurrPlayer().onBoard.getCard(playPlay.SelectedIndex));
            cardView.changeVisibilityPurchaseButton(false);
        }

        private void button5_Click(object sender, EventArgs e)  // Play All
        {
            //this.inHand = this.game.getCurrPlayer().hand;
            //for (int i = 0; i < inHand.cards.Count; i++)
            //{
            //    inHand.playCard(inHand.getCard(0));
            //}
            //this.updatePlayer();
        }

        public void setCanDoMoreButton()
        {
            button4.BackColor = Color.Red;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.game.playAll();
        }

        private void playDeck_SelectedIndexChanged(object sender, EventArgs e)
        {
            cardView.changeVisibilityPlayButton(false);
            cardView.changeVisibilityAbilityButton(false);
            cardView.changeVisibilityKillButton(false);

        }

        private void playDisc_SelectedIndexChanged(object sender, EventArgs e)
        {
            cardView.changeVisibilityPlayButton(false);
            cardView.changeVisibilityAbilityButton(false);
            cardView.changeVisibilityKillButton(false);
            cardView.update(this.game.getCurrPlayer().discardPile.getCard(playDisc.SelectedIndex));
        }

        private void playConstructs_SelectedIndexChanged(object sender, EventArgs e)
        {
            cardView.changeVisibilityPlayButton(false);
            cardView.changeVisibilityPurchaseButton(false);
            cardView.changeVisibilityAbilityButton(false);
            cardView.changeVisibilityKillButton(false);
            cardView.update(this.game.getCurrPlayer().constructs.getCard(playConstructs.SelectedIndex));
        }

        private void BoardView_Load(object sender, EventArgs e)
        {

        }

    }
}
