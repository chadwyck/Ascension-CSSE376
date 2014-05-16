﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class Player
    {

        private const int HONOR = 0, RUNES = 1, POWER = 2, MECHRUNES = 3; // metricIDs
        
        public Game game { get; protected set; }

        public int playerNumber { get; protected set; }
        
        public int playerPower { get; protected set; }

        public int playerRunes { get; protected set; }

        public int playerMechRunes { get; protected set; }
        
        public int playerHonor { get; protected set; }
        
        public int currentRunes { get; protected set; }
        
        public int currentPower { get; protected set; }

        public ConstructDeck constructs { get; protected set; }
        
        public HandDeck deck { get; protected set; }
        
        public InHand hand { get; protected set; }

        public InPlay onBoard { get; protected set; }

        public DiscardDeck discardPile { get; protected set; }

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
            this.game = game;
            CardImport card = new CardImport(this.game, "\\PlayerHand\\");
            card.cardImportH(this.game, "\\PlayerHand\\", deck);

            this.discardPile = new DiscardDeck(this.deck);
            this.deck.setDiscard(this.discardPile);
            this.constructs = new ConstructDeck(this.discardPile);
            this.onBoard = new InPlay(this.discardPile);
            this.hand = new InHand(this.discardPile, this.onBoard, this.deck);
            
            
           
            this.playerRunes = 0;
            this.playerPower = 0;



            //Card apprentice = new Card(this.game, "Apprentice", null, 0, 0, 0, "lifebound", "hero",
            //    new List<CardAction> { new ChangeMetricCount(RUNES, 1, game),
            //                           new FirstTimeGet("fallen", "monster", HONOR, 5, game) });

            //Card militia = new Card(this.game, "Militia", null, 0, 0, 0, null, "basic",
            //    new List<CardAction> { new ChangeMetricCount(POWER, 3, this.game),
            //                           //new MoveFromTo(deck", hand, false, false),
            //                          /* new ForEachCardType("lifebound","hero",false,HONOR,2,this.game)*/});
            //for (int j = 0; j < 8; j++)
            //    deck.add(apprentice);
            //deck.add(militia);
            //deck.add(militia);
            


        }


        public void addHonor(int honor)  
        {
            this.changeMetricCount(HONOR, honor);
        }


        public void addRunes(int runes) 
        {
            this.changeMetricCount(RUNES, runes);
        }


        public void addPower(int power) 
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
                case MECHRUNES:
                    this.playerMechRunes = this.playerMechRunes + incrementBy;
                    break;
                default:
                    throw new System.ArgumentException("MetricID must be between 0 and 2", "metricID");
            }
        }

        public void endTurn()
        {

            this.playerPower = 0;
            this.playerRunes = 0;
            this.playerMechRunes = 0;
            
            this.hand.newHand();
        }
        public void purchase(Card crd, Boolean play, int Cost)
        {
            if (crd.faction != null && crd.cardType != null && crd.faction.Equals("mechana") && crd.cardType.Equals("construct"))
            {
                if (Cost <= (this.playerRunes + this.playerMechRunes))
                {
                    this.playerMechRunes = this.playerMechRunes - Cost;
                    if (this.playerMechRunes < 0)
                    {
                        this.playerRunes = this.playerRunes + this.playerMechRunes;
                        this.playerMechRunes = 0;
                    }

                    if (!play)
                    {
                        if (this.game.cenRow.cards.Contains(crd))
                            this.game.cenRow.remove(crd);
                        discardPile.add(crd);
                    }
                    else
                    {
                        this.play(crd);
                    }
                }
            }
            else
            {
                if (Cost <= this.playerRunes)
                {
                    this.playerRunes = this.playerRunes - Cost;

                    if (!play)
                    {
                        if(this.game.cenRow.cards.Contains(crd))
                            this.game.cenRow.remove(crd);
                        discardPile.add(crd);
                    }
                    else
                    {
                        this.play(crd);
                    }
                }
            }
        }

        public int getEndGameHonor()
        {
            return this.playerHonor;
        }

        public void play(Card crd)
        {
            if (crd.cardType.Equals("construct"))
            {
                hand.remove(crd);
                constructs.add(crd);
            }
            else
            {
                hand.remove(crd);
                onBoard.add(crd);
            }

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
