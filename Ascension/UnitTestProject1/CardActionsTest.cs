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

        [SetUp()]
        public void Setup()
        {
            runicLycanthrope = new Card(testGame, "Runic Lycanthrope", null, 3, 0, 1, "lifebound", "hero",
                new List<CardAction> { new ChangeMetricCount(RUNES, 2, testGame),
                                       new ForEachCardType("lifebound","hero",true,POWER,2,testGame) });
            lifebound = new Card(testGame, "Lifebound Man", null, 7, 0, 3, "lifebound", "hero",
                new List<CardAction> { new ChangeMetricCount(HONOR, 1, testGame) });
        }

        [Test()]
        public void TestForEachCardType()
        {
            lifebound.playCard();
            Assert.AreEqual(1, testGame.getCurrPlayer().playerHonor);
            testGame.cardsPlayed.add(lifebound);
            testGame.cardsPlayed.add(runicLycanthrope);
            runicLycanthrope.playCard();
            Assert.AreEqual(2, testGame.cardsPlayed.numberOf("lifebound", "hero"));
            Assert.AreEqual(2, testGame.getCurrPlayer().playerPower);

        }

    }
}
