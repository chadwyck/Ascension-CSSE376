using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace Ascension
{
    public class Game
    {
        private const int HONOR = 0, RUNES = 1, POWER = 2, MECHRUNES = 3, CONSTRUNES = 4; // metricIDs
        public int numPlayers;
        public BoardView boardView;
        public bool endOfGame { get; private set; }

        public List<FirstTimeGet> firstTimeList { get; set; }
        public CardsPlayed cardsPlayed { get; set; }
        public Boolean hasAI;

        public bool allMechanaConstructs { get; set; }
        public bool mechanaDirectToPlay { get; set; }
        public bool mechanaDraw { get; set; }
        public bool extraTurn { get; set; }
        public bool firstTimeMonster { get; set; }

        public int currTurn
        {
            get;
            private set;
        }
       
        public int GameInt
        {
            get; private set;
        }
        
        public int honorOnBoard
        {
            get;
            set;
        }
        public PortalDeck pDeck
        {
            get;
            private set;
        }
        public CardCollection voidDeck
        {
            get;
            private set;
        }
        public CenterRow cenRow
        {
            get;
            private set;
        }
        public CardCollection myst; //made this public so AI could access it. Should really AI functions it so it can be private.
        private CardCollection heavyIn;
        public Player[] plyrs { get; set; }
        //public Game (int numPlayers)
        //{
        //    this.hasAI = false;
        //    gameInitialize(numPlayers, false, "English");
        //}

        //public Game(int numPlayers, Boolean hasAI)
        //{
        //    this.hasAI = hasAI;
        //    gameInitialize(numPlayers, false, "English");
        //}

        public Game(int numPlayers, Boolean hasAI, bool isTest)
        {
            this.hasAI = hasAI;
            gameInitialize(numPlayers, isTest, "English");
        }

        public Game(int numPlayers, Boolean hasAI, bool isTest, string language)
        {
            this.hasAI = hasAI;
            gameInitialize(numPlayers, isTest, language);
        }

        private void gameInitialize(int numPlayers, bool isTest, string language)
        {
            if (language.Equals("French"))
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-FR");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            }
            endOfGame = false;
            currTurn = 1;
            if (!this.hasAI)
            {
                Console.WriteLine("In the regular init.");
                if ((numPlayers < 2) || (numPlayers > 4))
                    throw new ArgumentOutOfRangeException("Must have between 2 and 4 players.");
                this.numPlayers = numPlayers;
                plyrs = new Player[numPlayers];
                for (int i = 0; i < numPlayers; i++)
                    plyrs[i] = new Player(this, i + 1);
                myst = new CardCollection();
                heavyIn = new CardCollection();
                generateCards();
                foreach (var temp in plyrs)
                {
                    temp.endTurn();
                    temp.deck.shuffle();
                }
                //if (isTest)
                //{
                //    boardView = new BoardView(this, isTest);
                //}
                //else
                //{
                boardView = new BoardView(this, isTest);
                //}
                if (!isTest)
                {
                    boardView.Show();
                }
                boardView.updatePortal(pDeck);
                voidDeck = new CardCollection();
                cenRow = new CenterRow(pDeck, voidDeck);
                boardView.updateCenRow(cenRow, pDeck);
                this.firstTimeList = new List<FirstTimeGet>();
                this.cardsPlayed = new CardsPlayed();


                this.honorOnBoard = numPlayers * 30;

                honorOnBoard = 30 * numPlayers;
                boardView.lblHonorCount.Text = honorOnBoard.ToString();

                //Player 1 is always starting at the moment.



                boardView.updatePlayer();
            }
            else
            {
                Console.WriteLine("In the AI init.");
                if ((numPlayers < 1) || (numPlayers > 3))
                    throw new ArgumentOutOfRangeException("Must have between 2 and 4 players, including AI.");
                this.numPlayers = numPlayers + 1;
                numPlayers = numPlayers + 1; //Not sure if this is needed; I just wanted to not modify below code as much as possible.
                plyrs = new Player[numPlayers];
                for (int i = 0; i < numPlayers; i++)
                {
                    if (i != (numPlayers - 1))
                        plyrs[i] = new Player(this, i + 1);
                    else
                    {
                        plyrs[i] = new AI(this, i + 1);
                        Console.WriteLine("Added an AI.");
                    }
                }
                myst = new CardCollection();
                heavyIn = new CardCollection();
                generateCards();
                foreach (var temp in plyrs)
                {
                    temp.endTurn();
                    temp.deck.shuffle();
                }
                
                boardView = new BoardView(this, isTest);

                if (!isTest)
                {
                    boardView.Show();
                }
                boardView.updatePortal(pDeck);
                voidDeck = new CardCollection();
                cenRow = new CenterRow(pDeck, voidDeck);
                boardView.updateCenRow(cenRow, pDeck);
                this.firstTimeList = new List<FirstTimeGet>();
                this.cardsPlayed = new CardsPlayed();


                this.honorOnBoard = numPlayers * 30;

                honorOnBoard = 30 * numPlayers;
                boardView.lblHonorCount.Text = honorOnBoard.ToString();

                //Player 1 is always starting at the moment.



                boardView.updatePlayer();
            }
            boardView.setCanDoMoreButton();
            this.allMechanaConstructs = false;
            this.mechanaDirectToPlay = false;
            this.mechanaDraw = false;
            this.extraTurn = false;
            this.firstTimeMonster = false;
        }
        public void generateCards(){
            //Card apprentice = new Card(this, "Apprentice", null, 0, 0, 0, "", "basic",
            //    new List<CardAction> { new ChangeMetricCount(RUNES, 1, this) });

            Card heavyInfantry = new Card(this, "Heavy Infantry", null, 2, 0, 1, "", "basic",
                new List<CardAction> { new ChangeMetricCount(POWER, 2, this) });

            Card mystic = new Card(this, "Mystic", null, 3, 0, 1, "", "basic",
                new List<CardAction> { new ChangeMetricCount(RUNES, 2, this) });

            //Card voidthirster = new Card(this, "Voidthirster", null, 5, 0, 3, "void", "construct",
            //    new List<CardAction> { new ChangeMetricCount(POWER, 1, this),
            //                           new FirstTimeGet("fallen", "monster", HONOR, 39, this)}); //One honor per turn, honorGain when first monster in center is defeated each turn

            //Card theAllSeeingEye = new Card(this, "The All Seeing Eye", null, 6, 0, 2, "enlightened", "construct",
            //    new List<CardAction> { });

            //Card theGrandDesign = new Card(this, "The Grand Design", null, 6, 0, 6, "mechana", "construct",
            //    new List<CardAction> { new ChangeMetricCount(RUNES, 2, this) }); //Honor can only be used for Mechana Constructs and only once per turn.

            //Card yggdrasilStaff = new Card(this, "Yggdrasil Staff", null, 4, 0, 2, "lifebound", "construct",
            //    new List<CardAction> { new ChangeMetricCount(POWER, 1, this) }); // Need to do the "once per turn" ability

            //Card masterDhartha = new Card(this, "Master Dhartha", null, 7, 0, 3, "enlightened", "hero",
            //    new List<CardAction> { new ChangeMetricCount(POWER, 100, this) });

            //Card demonSlayer = new Card(this, "Demon Slayer", null, 4, 0, 2, "void", "hero",
            //    new List<CardAction> { new ChangeMetricCount(POWER, 3, this) });

            //Card lifeboundInitiate = new Card(this, "Lifebound Initiate", null, 1, 0, 1, "lifebound", "hero",
            //    new List<CardAction> { new ChangeMetricCount(RUNES, 1, this),
            //                           new ChangeMetricCount(HONOR, 1, this)});

            //Card avatarGolem = new Card(this, "Avatar Golem", null, 4, 0, 2, "mechana", "hero",
            //    new List<CardAction> { new ChangeMetricCount(POWER, 2, this) }); //1 for each faction among constructs you control

            //Card samaelsTrickster = new Card(this, "Samael's Trickster", null, 0, 3, 0, "fallen", "monster",
            //    new List<CardAction> { new ChangeMetricCount(RUNES, 1, this),
            //                           new ChangeMetricCount(HONOR, 1, this)});

            //Card corrosiveWidow = new Card(this, "Corrosive Widow", null, 0, 4, 0, "fallen", "monster",
            //    new List<CardAction> { new ChangeMetricCount(HONOR, 3, this) }); // Each opponent must destroy construct they control

            //Card tormentedSoul = new Card(this, "Tormented Soul", null, 0, 3, 0, "fallen", "monster",
            //    new List<CardAction> { new ChangeMetricCount(HONOR, 1, this) });

            //Card mystic = new Card(this, "Runic Lycanthrope", null, 0, 0, 1, "lifebound", "hero",
             //   new List<CardAction> { new ChangeMetricCount(RUNES, 2, this),
             //                           new ForEachCardType("lifebound","hero",true,POWER,2,this) });

            //Card mistakeOfCreation = new Card(this, "Mistake of Creation", null, 0, 4, 0, "fallen", "monster",
            //    new List<CardAction> { new ChangeMetricCount(HONOR, 4, this) });
            //// Needs to banish card from center row and/or card from discard pile  
            pDeck = new PortalDeck();

            //pDeck.add(voidthirster);
            //pDeck.add(theAllSeeingEye);
            //pDeck.add(theGrandDesign);
            //pDeck.add(masterDhartha);
            //pDeck.add(demonSlayer);
            //pDeck.add(lifeboundInitiate);
            //pDeck.add(avatarGolem);
            //pDeck.add(samaelsTrickster);
            //pDeck.add(corrosiveWidow);
            //pDeck.add(tormentedSoul);
            //pDeck.add(runicLycanthrope);
            //pDeck.add(mistakeOfCreation);

           

            CardImport card = new CardImport(this, "\\Portal\\");
            card.cardImportP(this, "\\Portal\\", pDeck);
            pDeck.shuffle();                              // shuffleCode
           foreach(Player p in plyrs){
                
           }

           
           for (int i = 0; i < 30; i++)
           {
               myst.add(mystic);
               heavyIn.add(heavyInfantry);
           }
		}

        public Game()
        {
            throw new ArgumentNullException("Please select a number of players.");
        }

        //This part, could use refactoring (put players in an array, etc.)
        public Player getPlayer(int n)
        {
            if ((n >= this.numPlayers) || (n < 0))
                throw new ArgumentOutOfRangeException("Wrong player index");
            return this.plyrs[n];
        }
        public Player getCurrPlayer()
        {
            return this.plyrs[(this.currTurn - 1) % this.numPlayers];
        }

        public void advanceTurn()
        {
            this.firstTimeList.Clear();
            this.cardsPlayed.Clear();
            this.getCurrPlayer().endTurn();
            if (!this.extraTurn)
            {
                this.currTurn++;
            }
            else
            {
                this.extraTurn = false;
            }
            this.firstTimeMonster = false;
            this.allMechanaConstructs = false;
            this.mechanaDirectToPlay = false;
            this.mechanaDraw = false;
            this.getCurrPlayer().queryAllDestroyConstructs();
            this.getCurrPlayer().constructs.playAll();
                        

            checkForAI();

        }

        public void checkForAI()
        {
            if ((this.hasAI) && (this.currTurn % this.numPlayers == 0))
            {
                this.boardView.updatePlayer();
                this.boardView.clickPlayAll();
                if (this.getCurrPlayer().playerRunes >= 2)
                {
                    while (this.getCurrPlayer().playerRunes >= 2)
                    {
                        //add method to hide all buttons for AI
                        try
                        {
                            this.boardView.clickPlayAll();
                            int indexOfHighestRuneCostCardAffordable = this.getHighestCost();
                            this.boardView.selectCard(getHighestCost());
                            this.boardView.cardView.clickPurchaseButton();
                            System.Windows.Forms.MessageBox.Show("Bought something from the center row.");
                        }
                        catch
                        {
                            try
                            {
                                if (this.getCurrPlayer().playerRunes >= 3)
                                {
                                    this.boardView.clickBuyMystic();
                                    System.Windows.Forms.MessageBox.Show("Bought a mystic.");
                                }
                                else throw nullReferenceException;
                            }

                            catch
                            {
                                try
                                {
                                    this.boardView.clickBuyHI();
                                    System.Windows.Forms.MessageBox.Show("Bought a heavy infantry.");
                                }

                                catch
                                {
                                    System.Windows.Forms.MessageBox.Show("Did not buy anything.");
                                }
                            }
                        }
                    }
                }
                else System.Windows.Forms.MessageBox.Show("Did not buy anything.");

                if (this.getCurrPlayer().playerPower >= 2)
                {
                    while (this.getCurrPlayer().playerPower >= 2)
                    {
                        try
                        {
                            this.boardView.selectCard(getHighestPower());
                            this.boardView.cardView.clickKillButton(); //this... kind of isn't working? I'm scared of all of this.
                            System.Windows.Forms.MessageBox.Show("Killed a monster in the center row.");
                        }

                        catch
                        {
                            try
                            {
                                this.killCultist();
                                System.Windows.Forms.MessageBox.Show("Killed the Cultist.");
                            }

                            catch
                            {
                                System.Windows.Forms.MessageBox.Show("Did not kill anything.");
                            }
                        }
                    }
                }
                else System.Windows.Forms.MessageBox.Show("Did not kill anything.");
            }
        }
        


           
        private int getHighestCost()
        {
            int totalRunes = this.getCurrPlayer().playerRunes;
            Card currBest = this.cenRow.cards[0];
            foreach (Card card in this.cenRow.cards)
            {
                if ((currBest.runeCost < card.runeCost) && (totalRunes >= card.runeCost) && (card.runeCost > 0))
                {
                    currBest = card;
                }
            }
            if ((currBest.runeCost <= totalRunes) && (currBest.runeCost > 0))
            {
                return this.cenRow.cards.IndexOf(currBest);
            }
            else throw nullReferenceException;
        }
        public Card buyMyst()
        {
            Card temp = null;

            if ((myst.cards.Count != 0) && (getCurrPlayer().playerRunes >= 3))
            {
                temp = myst.getCard(0);
            }
            return temp;
        }
        public Card buyHI()
        {
            Card temp = null;
            if ((heavyIn.cards.Count != 0) && (getCurrPlayer().playerRunes >= 2))
            {
                temp = heavyIn.getCard(0);
            }
            return temp;
        }

        private int getHighestPower()
        {
            int totalPower = this.getCurrPlayer().playerPower;
            Card currBest = this.cenRow.cards[0];
            foreach (Card card in this.cenRow.cards)
            {
                if ((currBest.powerCost < card.powerCost) && (totalPower >= card.powerCost) && (card.powerCost > 0))
                {
                    currBest = card;
                }
            }
            if ((currBest.powerCost <= totalPower) && (currBest.powerCost > 0))
            {
                return this.cenRow.cards.IndexOf(currBest);
            }
            else throw new NullReferenceException();
        }
       

        public void killCultist()
        {
            if (getCurrPlayer().playerPower >= 2)
            {
                getCurrPlayer().addHonor(1);
                getCurrPlayer().addPower(-2);
                boardView.updatePlayer();
            }
            else throw new NullReferenceException();
        }

        public Boolean canDoMore()
        {
            int availableRunes = getCurrPlayer().playerRunes;
            int availablePower = getCurrPlayer().playerPower;

            if (availablePower >= 2 || availableRunes >= 2)
            {
                return true;
            }

            if (this.cenRow != null)
            {
                foreach (Card card in cenRow.cards)
                {
                    if (card.cardType == "monster")
                    {
                        if (card.powerCost <= availablePower)
                            return true;
                    }
                    else
                    {
                        if (card.cardType.Equals("construct"))
                        {
                            if (card.faction.Equals("mechana"))
                            {
                                if (card.runeCost <= (availableRunes + getCurrPlayer().playerMechRunes + getCurrPlayer().playerConstRunes))
                                    return true;
                            }
                            else
                            {
                                if (card.runeCost <= (availableRunes + getCurrPlayer().playerConstRunes))
                                    return true;
                            }
                        }
                        else
                        {
                            if (card.runeCost <= availableRunes)
                                return true;
                        }
                        
                    }
                }
                return this.getCurrPlayer().hand.cards.Count > 0;
            }
            return false;
               
        }

        public void playAll()
        {
               
                while (this.getCurrPlayer().hand.cards.Count > 0)
                {
                    this.getCurrPlayer().play(this.getCurrPlayer().hand.getCard(0));
                }

                this.boardView.updatePlayer();
       }

        public void endGame()
        {
            this.endOfGame = true;
        }


        public Exception nullReferenceException { get; set; }
    }
}