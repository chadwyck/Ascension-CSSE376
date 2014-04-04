using System;
using Ascension;
using NUnit.Framework;

namespace AscensionTest
{
    [TestFixture()]
    class CardTest
    {
        private Game testGame;
        Card apprentice;
        Card militia;
        Card heavyInfantry;
        Card mystic;
        Card fakeHonor;
        int x;
        int y;
        int z;
        [SetUp()]
        public void setup()
        {
           testGame = new Game(2);
           apprentice = new Card(testGame, "Apprentice", null, 0, 0, 1, 0, 0, 0, 0, null, "basic");
           militia = new Card(testGame, "Militia", null, 0, 0, 0, 1, 0, 0, 0, null, "basic");
           heavyInfantry = new Card(testGame, "Heavy Infantry", null, 0, 0, 0, 2, 1, 0, 0, null, "basic");
           mystic = new Card(testGame, "Mystic", null, 0, 0, 2, 0, 1, 0, 0, null, "basic");
           fakeHonor = new Card(testGame, "freeHonor", null, 0, 0, 0, 0, 0, 3, 0, null, "basic");
           x = 0;
        }
        [Test()]
        public void testAddHonor()
        {
            x = testGame.getCurrPlayer().playerHonor;
            fakeHonor.playCard();
            Assert.AreEqual(x + 3, testGame.getCurrPlayer().playerHonor);
            x = testGame.getCurrPlayer().playerHonor;
            fakeHonor.playCard();
            fakeHonor.playCard();
            fakeHonor.playCard();
            Assert.AreEqual(x + 9, testGame.getCurrPlayer().playerHonor);
        }
        [Test()]
        public void testAddPower()
        {
            x = testGame.getCurrPlayer().playerPower;
            militia.playCard();
            Assert.AreEqual(x + 1, testGame.getCurrPlayer().playerPower);
            x = testGame.getCurrPlayer().playerPower;
            militia.playCard();
            heavyInfantry.playCard();
            Assert.AreEqual(x + 3, testGame.getCurrPlayer().playerPower);
        }
        [Test()]
        public void testAddRunes()
        {
            x = testGame.getCurrPlayer().playerRunes;
            apprentice.playCard();
            Assert.AreEqual(x + 1, testGame.getCurrPlayer().playerRunes);
            x = testGame.getCurrPlayer().playerRunes;
            apprentice.playCard();
            mystic.playCard();
            mystic.playCard();
            Assert.AreEqual(x + 5, testGame.getCurrPlayer().playerRunes);
        }
        [Test()]
        public void testBanish()
        {
            //
        }
        [Test()]
        public void testAddAll()
        {
            x = testGame.getCurrPlayer().playerRunes;
            y = testGame.getCurrPlayer().playerPower;
            z = testGame.getCurrPlayer().playerHonor;
            apprentice.playCard();
            mystic.playCard();
            mystic.playCard();
             militia.playCard();
             heavyInfantry.playCard();
             fakeHonor.playCard();
             fakeHonor.playCard();
             fakeHonor.playCard();
             Assert.AreEqual(x+ 5, testGame.getCurrPlayer().playerRunes);
             Assert.AreEqual(y + 3, testGame.getCurrPlayer().playerPower);
             Assert.AreEqual(z+ 9, testGame.getCurrPlayer().playerHonor);
        }
        
    }
}
