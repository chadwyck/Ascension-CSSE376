
using System;

namespace Ascension
{
    public class Game
    {
        private int numPlayers;
        public BoardView boardView;
        
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
        public CenterRow cenRow
        {
            get;
            private set;
        }
        private CardCollection myst;
        private CardCollection heavyIn;
        private Player[] plyrs;
        public Game (int numPlayers)
		{
            currTurn = 1;
            if ((numPlayers < 2)||(numPlayers > 4))
                throw new ArgumentOutOfRangeException("Must have between 2 and 4 players.");
            this.numPlayers = numPlayers;
            plyrs = new Player[numPlayers];
            for (int i = 0; i < numPlayers; i++)
                plyrs[i] = new Player(this, i + 1);
            myst = new CardCollection();
            heavyIn = new CardCollection();
            generateCards();
            foreach (var temp in plyrs){
                temp.endTurn();
                temp.deck.shuffle();
            }
            boardView = new BoardView(this);
            boardView.Show();
            boardView.updatePortal(pDeck);
            cenRow = new CenterRow(pDeck, new VoidDeck());
            boardView.updateCenRow(cenRow, pDeck);
            
            
            this.honorOnBoard = numPlayers * 30;
           
            honorOnBoard = 30 * numPlayers;
            boardView.lblHonorCount.Text = honorOnBoard.ToString();
            
             //Player 1 is always starting at the moment.
            
            
            
            boardView.updatePlayer();

        }

        public void generateCards(){
            Card apprentice = new Card(this, "Apprentice", null, 0, 0, 1, 0, 0, 0, 0, null, "basic");
            Card militia = new Card(this, "Militia", null, 0, 0, 0, 1, 0, 0, 0, null, "basic");
            Card heavyInfantry = new Card(this, "Heavy Infantry", null, 0, 0, 0, 2, 1, 0, 0, null, "basic");
            Card mystic = new Card(this, "Mystic", null, 0, 0, 2, 0, 1, 0, 0, null, "basic");
            Card voidthirster = new Card(this, "Voidthirster", null, 5, 0, 0, 1, 3, 1, 0, "void", "construct"); //One honor per turn, honorGain when first monster in center is defeated each turn
            Card theAllSeeingEye = new Card(this, "The All Seeing Eye", null, 6, 0, 0, 0, 2, 0, 1, "enlightened", "construct");
            Card theGrandDesign = new Card(this, "The Grand Design", null, 6, 0, 2, 0, 6, 0, 0, "mechana", "construct"); //Honor can only be used for Mechana Constructs and only once per turn.
            Card yggdrasilStaff = new Card(this, "Yggdrasil Staff", null, 4, 0, 0, 1, 2, 3, 0, "lifebound", "construct"); // Need to do the "once per turn" ability
            Card masterDhartha = new Card(this, "Master Dhartha", null, 7, 0, 0, 0, 3, 0, 3, "enlightened", "hero");
            Card demonSlayer = new Card(this, "Demon Slayer", null, 4, 0, 0, 3, 2, 0, 0, "void", "hero");
            Card lifeboundInitiate = new Card(this, "Lifebound Initiate", null, 1, 0, 1, 0, 1, 1, 0, "lifebound", "hero");
            Card avatarGolem = new Card(this, "Avatar Golem", null, 4, 0, 0, 2, 2, 1, 0, "mechana", "hero"); //1 for each faction among constructs you control
            Card samaelsTrickster = new Card(this, "Samael's Trickster", null, 0, 3, 1, 0, 0, 1, 0, "fallen", "monster");
            Card corrosiveWidow = new Card(this, "Corrosive Widow", null, 0, 4, 0, 0, 0, 3, 0, "fallen", "monster"); // Each opponent must destroy construct they control
            Card tormentedSoul = new Card(this, "Tormented Soul", null, 0, 3, 0, 0, 0, 1, 1, "fallen", "monster");
            Card mistakeOfCreation = new Card(this, "Mistake of Creation", null, 0, 4, 0, 0, 0, 4, 0, "fallen", "monster"); 
            // Needs to banish card from center row and/or card from discard pile  
            pDeck = new PortalDeck();
            
            pDeck.add(voidthirster);
            pDeck.add(theAllSeeingEye);
            pDeck.add(theGrandDesign);
            pDeck.add(masterDhartha);
            pDeck.add(demonSlayer);
            pDeck.add(lifeboundInitiate);
            pDeck.add(avatarGolem);
            pDeck.add(samaelsTrickster);
            pDeck.add(corrosiveWidow);
            pDeck.add(tormentedSoul);
            pDeck.add(mistakeOfCreation);
            
            pDeck.shuffle();
           
            
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
            if ((1 <= n)&& (n<= this.numPlayers))
                return this.plyrs[n];
            else return null;
        }
        public Player getCurrPlayer()
        {
            return this.plyrs[(this.currTurn - 1) % this.numPlayers];
        }

        public void advanceTurn()
        {
            this.getCurrPlayer().endTurn();
            this.currTurn++;
            
        }
        public Card buyMyst()
        {
            Card temp = null;
            if (myst.length != 0)
            {

                temp = myst.getCard(0);
                myst.remove(temp);
            }
            return temp;
        }
        public Card buyHI()
        {
            Card temp = null;
            if (heavyIn.length != 0)
            {

                temp = heavyIn.getCard(0);
                heavyIn.remove(temp);
            }
            return temp;
        }
        
    }
}