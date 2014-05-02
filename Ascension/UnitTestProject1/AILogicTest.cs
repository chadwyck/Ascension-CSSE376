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
    class AILogicTest
    {
        [Test]
        public void TestThatAILogicInitializes()
        {
            Game game = new Game(3);
            AI aiPlayer = new AI(game, 3);
            AILogic aiLogic = new AILogic(aiPlayer);
            Assert.NotNull(aiLogic);
        }

        [Test]
        public void TestThatAILogicHasPlayer()
        {
            Game game = new Game(3);
            AI aiPlayer = new AI(game, 3);
            AILogic aiLogic = new AILogic(aiPlayer);
            Assert.NotNull(aiLogic.aiPlayer);
        }

        [Test]
        public void TestThatAILogicHasGame()
        {
            Game game = new Game(3);
            AI aiPlayer = new AI(game, 3);
            AILogic aiLogic = new AILogic(aiPlayer);
            Assert.NotNull(aiLogic.game);
        }

        [Test]
        public void TestThatAILogicCanAddRunes()
        {
            Game game = new Game(3);
            AI aiPlayer = new AI(game, 3);
            AILogic aiLogic = new AILogic(aiPlayer);
            aiLogic.aiPlayer.addRunes(5);
            Assert.AreEqual(5, aiLogic.aiPlayer.playerRunes);
        }

        [Test]
        public void TestThatAILogicCanAddPower()
        {
            Game game = new Game(3);
            AI aiPlayer = new AI(game, 3);
            AILogic aiLogic = new AILogic(aiPlayer);
            aiLogic.aiPlayer.addPower(5);
            Assert.AreEqual(5, aiLogic.aiPlayer.playerPower);
        }

        [Test]
        public void TestBuyMystic()
        {
            Game game = new Game(3);
            AI aiPlayer = new AI(game, 3);
            AILogic aiLogic = new AILogic(aiPlayer);

            aiLogic.aiPlayer.addRunes(5);
            aiLogic.buyMystic();
            Assert.AreEqual("Mystic", aiLogic.aiPlayer.discardPile.cards[0].cardName);

        }


    }
}
