using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class Player
    {
        public Game game
        {
            get;
            private set;
        }
        public int playerNumber
        {
            get;
            private set;
        }

        public int playerPower
        {
            get;
            private set;
        }

        public int playerRunes
        {
            get;
            private set;
        }

        public int playerHonor
        {
            get;
            private set;
        }

        public int currentRunes
        {
            get;
            private set;
        }

        public int currentPower
        {
            get;
            private set;
        }

        public ConstructDeck constructs
        {
            get;
            private set;
        }

        public HandDeck deck
        {
            get;
            private set;
        }

        public InHand hand
        {
            get;
            private set;
        }

        public InPlay onBoard
        {
            get;
            private set;
        }

        public DiscardDeck discardPile
        {
            get;
            private set;
        }
        public Player(Game game, int playerNumber)
        {
            this.playerNumber = playerNumber;
            this.playerHonor = 0;
            this.currentRunes = 0;
            this.currentPower = 0;
            this.deck = new HandDeck();
            this.discardPile = new DiscardDeck(this.deck);
            this.constructs = new ConstructDeck(this.discardPile);
            this.onBoard = new InPlay(this.discardPile);
            this.hand = new InHand(this.discardPile, this.onBoard, this.deck);
            
           
            this.playerRunes = 0;
            this.playerPower = 0;
            this.game = game;
        }

        public void addHonor(int honor)
        {
            this.playerHonor = this.playerHonor + honor;
            this.game.honorOnBoard = this.game.honorOnBoard - honor;
        }

        public void addRunes(int runes)
        {
            this.playerRunes = this.playerRunes + runes;
        }

        public void addPower(int power)
        {
            this.playerPower = this.playerPower + power;
        }

        public void endTurn()
        {
            this.playerPower = 0;
            this.playerRunes = 0;
            this.hand.newHand();
        }
        public void purchase(Card crd, Boolean play, int Cost)
        {
            if (!play)
            {
                discardPile.add(crd);
            }
            else
            {
                this.play(crd);
            }

        }
        public void play(Card crd)
        {
            onBoard.add(crd);
        }
        


    }
}
