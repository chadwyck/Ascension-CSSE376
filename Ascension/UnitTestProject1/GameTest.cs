using System;
using Ascension;
using NUnit.Framework;

namespace AscensionTest
{
    [TestFixture()]
    public class GameTest
    {
        private readonly int TestGameInt = 3;
        
        [Test()]
        public void TestThatGameInitializes()
        {
            var target = new Game(TestGameInt);
            Assert.IsNotNull(target);
        }
        [Test()]
        public void TestNoInput()
        {
            Assert.Throws<ArgumentNullException>(() => new Game());
        }
        [Test()]
        public void TestInvalidInput()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Game(10));
        }

        [Test()]
        public void TestHonor2Players()
        {
            var target = new Game(2);
            Assert.AreEqual(target.honorOnBoard, 60);
        }

        [Test()]
        public void TestHonor3Players()
        {
            var target = new Game(3);
            Assert.AreEqual(target.honorOnBoard, 90);
        }

        [Test()]
        public void TestHonor4Players()
        {
            var target = new Game(4);
            Assert.AreEqual(target.honorOnBoard, 120);
        }

        [Test()]
        public void TestAdvTurn()
        {
            var target = new Game(3);
            target.advanceTurn();
            target.advanceTurn();
            Assert.AreEqual(3, target.currTurn);
        }

        [Test()]
        public void TestNotEnoughPowerToKillCultist()
        {
            var target = new Game(2);
            target.killCultist();
            Assert.True(target.getCurrPlayer().playerHonor == 0);
        }

        [Test()]
        public void TestKillCultist()
        {
            var target = new Game(2);
            target.getCurrPlayer().addPower(2);
            target.killCultist();
            Assert.True((target.getCurrPlayer().playerHonor == 1) && (target.getCurrPlayer().playerPower == 0));
        }

        [Test()]
        public void TestValidBuyMystic() //This needs to be fixed, it's not really a unit test.
        {
            var target = new Game(2);
            target.getCurrPlayer().addRunes(4);
            Card temp;
            if ((temp = target.buyMyst()) != null)
            {
                target.getCurrPlayer().purchase(temp, false, temp.runeCost);
            }
            Assert.True((target.getCurrPlayer().playerRunes == 1)); // && (target.getCurrPlayer().discardPile.cards.Count == 1)
        }

        [Test()]
        public void TestCanDoMoreRunes()
        {
            var target = new Game(3);
            target.cenRow.add(new Card(target, "Test", null, 3, 0, 1, "Void", "Hero", null));
            target.getCurrPlayer().addRunes(4);
            bool canDoMore = target.canDoMore();
            Assert.IsTrue(canDoMore);
        }

        [Test()]
        public void TestCannotDoMoreRunesButHasMoreCards()
        {
            var target = new Game(3);
            target.getCurrPlayer().addRunes((-1) * target.getCurrPlayer().currentRunes);
            bool canDoMore = target.canDoMore();
            Assert.IsTrue(canDoMore);
        }

        [Test()]
        public void TestCannotDoMoreRunesAndNoMoreCards()
        {
            var target = new Game(3);
            target.getCurrPlayer().addRunes((-1) * target.getCurrPlayer().currentRunes);
            target.getCurrPlayer().hand.discardAllCards();
            bool canDoMore = target.canDoMore();
            Assert.IsFalse(canDoMore);
        }

        [Test()]
        public void TestCanDoMorePower()
        {
            var target = new Game(3);
            target.cenRow.add(new Card(target, "Test", null, 0, 3, 1, "fallen", "monster", null));
            target.getCurrPlayer().addPower(4);
            bool canDoMore = target.canDoMore();
            Assert.IsTrue(canDoMore);
        }

        [Test()]
        public void TestCannotDoMorePowerButMoreCards()
        {
            var target = new Game(3);
            target.cenRow.add(new Card(target, "Test", null, 0, 3, 1, "fallen", "monster", null));
            bool canDoMore = target.canDoMore();
            Assert.IsTrue(canDoMore);
        }

        [Test()]
        public void TestCannotDoMorePowerAndNoMoreCards()
        {
            var target = new Game(3);
            target.cenRow.add(new Card(target, "Test", null, 0, 3, 1, "fallen", "monster", null));
            target.getCurrPlayer().hand.discardAllCards();
            bool canDoMore = target.canDoMore();
            Assert.IsFalse(canDoMore);
        }
    }
}
