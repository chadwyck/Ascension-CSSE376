
using System;

namespace Ascension
{
    public class Game
    {
        private int numPlayers;
        private BoardView boardView = new BoardView();
        private CardView cardView = new CardView();
        public int currTurn
        {
            get;
            private set;
        }
        public Player player1
        {
            get;
            private set;
        }
        public Player player2
        {
            get;
            private set;
        }
        public Player player3
        {
            get;
            private set;
        }
        public Player player4
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
            private set;
        }

        public Game (int numPlayers)
		{
            boardView.Show();
            cardView.Show();
            this.numPlayers = numPlayers;
            this.honorOnBoard = numPlayers * 30;
            if ((numPlayers < 2)||(numPlayers > 4))
                throw new ArgumentOutOfRangeException("Must have between 2 and 4 players.");
            honorOnBoard = 30 * numPlayers;
            boardView.lblHonorCount.Text = honorOnBoard.ToString();
            currTurn = 1; //Player 1 is always starting at the moment.
            if (numPlayers >= 2)
            {
                player1 = new Player(this, 1);
                player2 = new Player(this, 2);
            }
            if (numPlayers >= 3)
            {
                player3 = new Player(this, 3);
            }
            if (numPlayers == 4)
            {
                player4 = new Player(this, 4);
            }
            generateCards();
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
            Card mistakeOfCreation = new Card(this, "Mistake of Creation", null, 0, 4, 0, 0, 0, 4, 0, "fallen", "monster"); // Needs to banish card from center row and/or card from discard pile  
		}

        public Game()
        {
            throw new ArgumentNullException("Please select a number of players.");
        }

        //This part, could use refactoring (put players in an array, etc.)
        public Player getPlayer(int n)
        {
            if (n == 1)
                return player1;
            if (n == 2)
                return player2;
            if (n == 3)
                return player3;
            if (n == 4)
                return player4;
            else return null;
        }

        public void advanceTurn()
        {
            if (this.currTurn == numPlayers)
                this.currTurn = 1;
            else this.currTurn = this.currTurn + 1;
        }

    }
}