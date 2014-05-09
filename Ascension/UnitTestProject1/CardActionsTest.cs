using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ascension;
using NUnit.Framework;

namespace AscensionTest
{
    [TestFixture()]
    class CardActionsTest
    {
        private const int HONOR = 0, RUNES = 1, POWER = 2; // metricIDs

        private Game testGame = new Game(2);
        //Card voidthirster;
        //Card demonSlayer;
        //Card samaelsTrickster;
        Card runicLycanthrope;
        Card lifebound;
        Card nonRunic;
        Card moverToVoid;
        Card moverToDiscard;
        Card moverToHand;

        [SetUp()]
        public void Setup()
        {
            runicLycanthrope = new Card(testGame, "Runic Lycanthrope", null, 3, 0, 1, "lifebound", "hero",
                new List<CardAction> { new ChangeMetricCount(RUNES, 2, testGame),
                                       new ForEachCardType("lifebound","hero",true,POWER,2,testGame) });
            lifebound = new Card(testGame, "Lifebound Man", null, 7, 0, 3, "lifebound", "hero",
                new List<CardAction> { new ChangeMetricCount(HONOR, 1, testGame) });
            nonRunic = new Card(testGame, "Runic Lycanthrope", null, 3, 0, 1, "lifebound", "hero",
                new List<CardAction> { new ChangeMetricCount(RUNES, 2, testGame),
                                       new ForEachCardType("lifebound","hero",false,POWER,2,testGame) });
            moverToVoid = new Card(testGame, "Mover Man", null, 7, 0, 3, "void", "hero",
                new List<CardAction> { new MoveFromTo("hand","void",false,false,testGame) });
            moverToDiscard = new Card(testGame, "Mover Man 2", null, 7, 0, 3, "void", "hero",
                new List<CardAction> { new MoveFromTo("void", "discard", false, false, testGame) });
            moverToHand = new Card(testGame, "Mover Man 2", null, 7, 0, 3, "void", "hero",
                new List<CardAction> { new MoveFromTo("discard", "hand", false, false, testGame) });
            
        }

        [Test()]
        public void TestForEachCardType()
        {
            lifebound.playCard();
            lifebound.playCard();
            lifebound.playCard();
            Assert.AreEqual(3, testGame.getCurrPlayer().playerHonor);
            testGame.cardsPlayed.add(lifebound);
            testGame.cardsPlayed.add(lifebound);
            testGame.cardsPlayed.add(lifebound);
            runicLycanthrope.playCard();
            testGame.cardsPlayed.add(runicLycanthrope);
            Assert.AreEqual(4, testGame.cardsPlayed.numberOf("lifebound", "hero"));
            Assert.AreEqual(2, testGame.getCurrPlayer().playerPower);
            testGame.advanceTurn();
        }

        [Test()]
        public void TestForEachCardTypeFalse()
        {
            lifebound.playCard();
            lifebound.playCard();
            Assert.AreEqual(2, testGame.getCurrPlayer().playerHonor);
            testGame.cardsPlayed.add(lifebound);
            testGame.cardsPlayed.add(lifebound);
            nonRunic.playCard();
            testGame.cardsPlayed.add(nonRunic);
            Assert.AreEqual(3, testGame.cardsPlayed.numberOf("lifebound", "hero"));
            Assert.AreEqual(4, testGame.getCurrPlayer().playerPower);
            testGame.advanceTurn();
        }

        [Test()]
        public void TestMoveFromTo()
        {
            int discardNum = testGame.getCurrPlayer().discardPile.length;
            lifebound.playCard();
            moverToVoid.playCard();
            Assert.AreEqual(1, testGame.voidDeck.length);
                //.getCurrPlayer().discardPile.cards[testGame.getCurrPlayer().discardPile.length - 1].cardName);
            moverToDiscard.playCard();
            Assert.AreEqual(discardNum + 1, testGame.getCurrPlayer().discardPile.length);
            moverToHand.playCard();
            Assert.AreEqual(0, testGame.voidDeck.length);
            Assert.AreEqual(discardNum, testGame.getCurrPlayer().discardPile.length);
        }
    }
}
