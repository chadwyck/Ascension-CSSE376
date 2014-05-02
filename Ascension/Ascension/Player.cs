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

        private const int HONOR = 0, RUNES = 1, POWER = 2; // metricIDs
        
        public Game game { get; protected set; }

        public int playerNumber { get; private set; }
        
        public int playerPower { get; private set; }

        public int playerRunes { get; private set; }
        
        public int playerHonor { get; private set; }
        
        public int currentRunes { get; private set; }
        
        public int currentPower { get; private set; }

        public ConstructDeck constructs { get; private set; }
        
        public HandDeck deck { get; private set; }
        
        public InHand hand { get; private set; }

        public InPlay onBoard { get; private set; }

        public DiscardDeck discardPile { get; private set; }

        public Player()
        {
            //should something go here?
        }
        public Player(Game game, int playerNumber)
        {

            this.playerNumber = playerNumber;
            this.playerHonor = 0;
            this.currentRunes = 0;
            this.currentPower = 0;
            this.deck = new HandDeck();
            this.discardPile = new DiscardDeck(this.deck);
            this.deck.setDiscard(this.discardPile);
            this.constructs = new ConstructDeck(this.discardPile);
            this.onBoard = new InPlay(this.discardPile);
            this.hand = new InHand(this.discardPile, this.onBoard, this.deck);
            
           
            this.playerRunes = 0;
            this.playerPower = 0;
            this.game = game;

            Card apprentice = new Card(this.game, "Apprentice", null, 0, 0, 0, "lifebound", "hero",
                new List<CardAction> { new ChangeMetricCount(RUNES, 5, game),
                                       new FirstTimeGet("fallen", "monster", HONOR, 5, game) });

            Card militia = new Card(this.game, "Militia", null, 0, 0, 0, null, "basic",
                new List<CardAction> { new ChangeMetricCount(POWER, 3, this.game),
                                       //new MoveFromTo(deck", hand, false, false),
                                      /* new ForEachCardType("lifebound","hero",false,HONOR,2,this.game)*/});
            for (int j = 0; j < 8; j++)
            deck.add(apprentice);
            deck.add(militia);
            deck.add(militia);
        }


        public void addHonor(int honor)  // LEGACY CODE - NEEED TO REMOVE
        {
            this.changeMetricCount(HONOR, honor);
        }


        public void addRunes(int runes) // LEGACY CODE - NEEED TO REMOVE
        {
            this.changeMetricCount(RUNES, runes);
        }


        public void addPower(int power) // LEGACY CODE - NEEED TO REMOVE
        {
            this.changeMetricCount(POWER, power);
        }

        public void changeMetricCount(int metricID, int incrementBy)
        {
            switch (metricID)
            {
                case HONOR:
                    this.playerHonor = this.playerHonor + incrementBy;
                    this.game.honorOnBoard = this.game.honorOnBoard - incrementBy;
                    if (this.game.honorOnBoard < 1)
                    {
                        this.game.honorOnBoard = 0;
                        this.game.endGame();
                    }
                    break;
                case RUNES:
                    this.playerRunes = this.playerRunes + incrementBy;
                    break;
                case POWER:
                    this.playerPower = this.playerPower + incrementBy;
                    break;
                default:
                    throw new System.ArgumentException("MetricID must be between 0 and 2", "metricID");
            }
        }

        public void endTurn()
        {
            this.playerPower = 0;
            this.playerRunes = 0;
            this.hand.newHand();
        }
        public void purchase(Card crd, Boolean play, int Cost)
        {
            if (Cost <= this.playerRunes)
            {
                this.playerRunes = this.playerRunes - Cost;

                if (!play)
                {
                    this.game.cenRow.remove(crd);
                    discardPile.add(crd);
                }
                else
                {
                    this.play(crd);
                }
            }
        }

        public int getEndGameHonor()
        {
            return this.playerHonor;
        }

        public void play(Card crd)
        {
            hand.remove(crd);
            onBoard.add(crd);
            crd.playCard();
        }

        public void kill(Card crd, int Cost)
        {
            if (Cost <= this.playerPower)
            {
                crd.playCard();
                this.playerPower = this.playerPower - Cost;
                this.game.cenRow.remove(crd);
                this.game.voidDeck.add(crd);
            }
        }
                

    }
}
