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

        public ArrayList constructs
        {
            get;
            private set;
        }

        public ArrayList deck
        {
            get;
            private set;
        }

        public ArrayList hand
        {
            get;
            private set;
        }

        public ArrayList onBoard
        {
            get;
            private set;
        }

        public ArrayList discardPile
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
            this.constructs = new ArrayList();
            this.deck = new ArrayList();
            this.hand = new ArrayList();
            this.onBoard = new ArrayList();
            this.discardPile = new ArrayList();
            this.playerRunes = 0;
            this.playerPower = 0;
            this.game = game;
        }

        public void addHonor(int honor)
        {
            this.playerHonor = this.playerHonor + honor;
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
            this.game.advanceTurn();
        }
    }
}
