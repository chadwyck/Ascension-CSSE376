using System;
using Ascension;
using NUnit.Framework;

namespace AscensionTest
{
    [TestFixture()]
    public class PlayerTest
    {

        [Test()]
        public void TestThatPlayerInitializes()
        {
            var target = new Player(new Game(2, false, true), 1);
            Assert.IsNotNull(target);
        }


        [Test()]
        public void TestThatHonorAdds()
        {
            var target = new Player(new Game(2, false, true), 1);
            target.addHonor(5);
            Assert.AreEqual(5, target.playerHonor);
        }

        [Test()]
        public void TestThatRunesAdd()
        {
            var target = new Player(new Game(2, false, true), 1);
            target.addRunes(3);
            Assert.AreEqual(3, target.playerRunes);
        }

        [Test()]
        public void TestThatPowerAdds()
        {
            var target = new Player(new Game(2, false, true), 1);
            target.addPower(2);
            Assert.AreEqual(2, target.playerPower);
        }

        [Test()]
        public void TestThatRunesDrain()
        {
            Game game = new Game(2, false, true);
            var target = new Player(game, 1);
            target.endTurn();
            Assert.AreEqual(0, target.playerRunes);
        }

        [Test()]
        public void TestThatPowerDrain()
        {
            Game game = new Game(2, false, true);
            var target = new Player(game, 1);
            target.endTurn();
            Assert.AreEqual(0, target.playerPower);
        }
        [Test()]
        public void TestKill(){
            Game game = new Game(2, false, true);
            game.advanceTurn();
            game.getCurrPlayer().play(game.getCurrPlayer().hand.getCard(0));
            game.getCurrPlayer().kill(game.cenRow.cards[0], 0);
            Assert.AreEqual(game.voidDeck.cards.Count, 1);
        }
        [Test()]
        public void TestPurchase()
        {
            Game game = new Game(2, false, true);
            game.advanceTurn();
            game.getCurrPlayer().play(game.getCurrPlayer().hand.getCard(0));
            game.getCurrPlayer().purchase(game.cenRow.cards[0], true, 0);
            game.getCurrPlayer().purchase(game.cenRow.cards[0], false, 0);
            Assert.AreEqual(game.getCurrPlayer().discardPile.cards.Count, 1);
        }
        [Test()]
        public void TestEndGame()
        {
            Game game = new Game(2, false, true);
            game.honorOnBoard = -1;
            game.getCurrPlayer().play(game.getCurrPlayer().hand.getCard(0));
            game.getCurrPlayer().changeMetricCount(0, 5);
            Assert.Throws<ArgumentException>(() => game.getCurrPlayer().changeMetricCount(5, 5));
        }


    }
}