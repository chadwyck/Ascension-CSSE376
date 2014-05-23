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
    class ConstructTest
    {
        private const int HONOR = 0, RUNES = 1, POWER = 2, MECHRUNES = 3; // metricIDs
        
        Card voidthirster;
        Card lifebound;
        private Game testGame = new Game(2, false, true);

        [SetUp()]
        public void Setup()
        {
            voidthirster = new Card(testGame, "Voidthirster", null, 5, 0, 3, "void", "construct",
                new List<CardAction> { new ChangeMetricCount(POWER, 1, testGame),
                                       new FirstTimeGet("fallen", "monster", HONOR, 39, testGame)});
            lifebound = new Card(testGame, "Lifebound Man", null, 7, 0, 3, "lifebound", "hero",
                new List<CardAction> { new ChangeMetricCount(HONOR, 1, testGame) });
            
            Player playplay = new Player();
        }

        [Test()]
        public void TestAddAndDestroyConstructs()
        {
            testGame.getCurrPlayer().constructs.add(voidthirster);
            Assert.AreEqual(1, testGame.getCurrPlayer().constructs.cards.Count);
            testGame.getCurrPlayer().constructs.add(lifebound);
            Assert.AreEqual(2, testGame.getCurrPlayer().constructs.cards.Count);
            testGame.getCurrPlayer().constructs.destroyAllButOneConstruct(voidthirster);
            Assert.AreEqual(1, testGame.getCurrPlayer().constructs.cards.Count);
            testGame.getCurrPlayer().constructs.destroyOneConstruct(voidthirster);
            Assert.AreEqual(0, testGame.getCurrPlayer().constructs.cards.Count);
        }
    }
}
