﻿using System;
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
            var target = new Player(new Game(2), 1);
            Assert.IsNotNull(target);
        }


        [Test()]
        public void TestThatHonorAdds()
        {
            var target = new Player(new Game(2), 1);
            target.addHonor(5);
            Assert.AreEqual(5, target.playerHonor);
        }

        [Test()]
        public void TestThatRunesAdd()
        {
            var target = new Player(new Game(2), 1);
            target.addRunes(3);
            Assert.AreEqual(3, target.playerRunes);
        }

        [Test()]
        public void TestThatPowerAdds()
        {
            var target = new Player(new Game(2), 1);
            target.addPower(2);
            Assert.AreEqual(2, target.playerPower);
        }

        [Test()]
        public void TestThatRunesDrain()
        {
            Game game = new Game(2);
            var target = new Player(game, 1);
            target.endTurn();
            Assert.AreEqual(0, target.playerRunes);
        }

        [Test()]
        public void TestThatPowerDrain()
        {
            Game game = new Game(2);
            var target = new Player(game, 1);
            target.endTurn();
            Assert.AreEqual(0, target.playerPower);
        }





    }
}