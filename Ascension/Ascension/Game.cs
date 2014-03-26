
using System;

namespace Ascension
{
    public class Game
    {
        private int numPlayers;
        private BoardView boardView = new BoardView();
        private CardView cardView = new CardView();

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
            //if ((numPlayers == null))
            //    throw new ArgumentNullException("Please select a number of players.");
            if ((numPlayers < 2)||(numPlayers > 4))
                throw new ArgumentOutOfRangeException("Must have between 2 and 4 players.");

            //CardCollection portal = new CardCollection();
            
            honorOnBoard = 30 * numPlayers;
            boardView.lblHonorCount.Text = honorOnBoard.ToString();
            
            
		}

        public Game ()
        {
            throw new ArgumentNullException("Please select a number of players.");
        }


    }
}