using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class Game
    {
        private const int HONOR = 0, RUNES = 1, POWER = 2; // metricIDs
        public int numPlayers;
        public BoardView boardView;
        public bool endOfGame { get; private set; }

        public List<FirstTimeGet> firstTimeList { get; set; }
        public CardsPlayed cardsPlayed { get; set; }
        public Boolean hasAI;

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
        private Player[] plyrs;
        public Game (int numPlayers)
		{
            gameInitialize(numPlayers, false);
            this.hasAI = false;
        }

        public Game(int numPlayers, Boolean hasAI)
        {
            this.hasAI = true;
            gameInitialize(numPlayers, false);
        }

        //public Game(int numPlayers, bool isTest)
        //{
        //    gameInitialize(numPlayers, true);
        //}

        private void gameInitialize(int numPlayers, bool isTest)
        {
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
                boardView = new BoardView(this);
                //}
                boardView.Show();
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
                //if (isTest)
                //{
                //    boardView = new BoardView(this, isTest);
                //}
                //else
                //{
                boardView = new BoardView(this);
                //}
                boardView.Show();
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
        }
        public void generateCards(){
            Card apprentice = new Card(this, "Apprentice", null, 0, 0, 0, null, "basic",
                new List<CardAction> { new ChangeMetricCount(RUNES, 1, this) });

            Card heavyInfantry = new Card(this, "Heavy Infantry", null, 2, 0, 1, null, "basic",
                new List<CardAction> { new ChangeMetricCount(POWER, 2, this) });

            Card mystic = new Card(this, "Mystic", null, 3, 0, 1, null, "basic",
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
            //    new List<CardAction> { new ChangeMetricCount(HONOR, 3, this)}); // Each opponent must destroy construct they control
            
            //Card tormentedSoul = new Card(this, "Tormented Soul", null, 0, 3, 0, "fallen", "monster",
            //    new List<CardAction> { new ChangeMetricCount(HONOR, 1, this)});
            
            //Card runicLycanthrope = new Card(this, "Runic Lycanthrope", null, 3, 0, 1, "lifebound", "hero",
            //    new List<CardAction> { new ChangeMetricCount(RUNES, 2, this),
            //                            new ForEachCardType("lifebound","hero",true,POWER,2,this) });
            
            //Card mistakeOfCreation = new Card(this, "Mistake of Creation", null, 0, 4, 0, "fallen", "monster",
            //    new List<CardAction> { new ChangeMetricCount(HONOR, 4, this)}); 
            //// Needs to banish card from center row and/or card from discard pile  
            //pDeck = new PortalDeck();
            
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
            
            //pDeck.shuffle();

            CardImport card = new CardImport(this);
            pDeck = card.cardImport(this);
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
            this.currTurn++;
            
        }
        public Card buyMyst()
        {
            Card temp = null;

            if ((myst.length != 0) && (getCurrPlayer().playerRunes >= 3))
            {

                temp = myst.getCard(0);
                myst.remove(temp);
                getCurrPlayer().addRunes(-3);
            }
            return temp;
        }
        public Card buyHI()
        {
            Card temp = null;
            if ((heavyIn.length != 0) && (getCurrPlayer().playerRunes >= 2))
            {

                temp = heavyIn.getCard(0);
                heavyIn.remove(temp);
                getCurrPlayer().addRunes(-2);
            }
            return temp;
        }

        public void killCultist()
        {
            if (getCurrPlayer().playerPower >= 2)
            {
                getCurrPlayer().addHonor(1);
                getCurrPlayer().addPower(-2);
                boardView.updatePlayer();
            }
        }

        public Boolean canDoMore()
        {
            int availableRunes = getCurrPlayer().playerRunes;
            int availablePower = getCurrPlayer().playerPower;


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
                        if (card.runeCost <= availableRunes)
                            return true;
                    }
                }
                return this.getCurrPlayer().hand.cards.Count > 0;
            }
            return false;
               
        }

        public void endGame()
        {
            this.endOfGame = true;
        }
        
    }
}