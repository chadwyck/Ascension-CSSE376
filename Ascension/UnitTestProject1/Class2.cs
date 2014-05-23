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
    class runNormalGame
    {
        Game testgame;
        Game testgame1;
        [SetUp()]
        public void Setup()
        {
            testgame = new Game(2, false, true, "French");
            testgame1 = new Game(3, false, true, "English");
        }
        [Test()]
        public void runSomeFR()
        {
            Assert.AreEqual(testgame.getCurrPlayer().deck.getEndGameHonor(), 0);
            Assert.AreEqual(0, testgame.getCurrPlayer().constructs.numberOf("mechana"));
            Assert.IsNull(testgame.getCurrPlayer().deck.getAvatarOfFallen());
            
            Assert.IsNull(testgame.getCurrPlayer().constructs.getTabletOfTimesDawn(null));
            
            

            for (int i = 0; i < 15; i++)
            {
                testgame.playAll();
                testgame.advanceTurn();
                try
                {
                    testgame.buyMyst();
                    testgame.buyHI();
                    testgame.killCultist();
                }
                catch
                {
                }
            }
           
        }
        [Test()]
        public void runSomeEN()
        {
            Assert.AreEqual(testgame1.getCurrPlayer().deck.getEndGameHonor(), 0);
            Assert.IsNull(testgame1.getCurrPlayer().deck.getAvatarOfFallen());
            for (int i = 0; i < 30; i++)
            {
                testgame1.playAll();
                testgame1.advanceTurn();
                try
                {
                    testgame1.getCurrPlayer().purchase(testgame1.cenRow.getCard(0), false, testgame1.cenRow.getCard(0).runeCost);
                }
                catch
                {
                }
                try
                {
                    testgame1.getCurrPlayer().purchase(testgame1.cenRow.getCard(1), false, testgame1.cenRow.getCard(1).runeCost);
                }
                catch
                {
                }
                try
                {
                    testgame1.getCurrPlayer().purchase(testgame1.cenRow.getCard(2), false, testgame1.cenRow.getCard(2).runeCost);
                }
                catch
                {
                }
            }
           
        }
    }
}
