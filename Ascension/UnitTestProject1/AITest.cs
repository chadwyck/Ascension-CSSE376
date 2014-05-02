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
    class AITest
    {
        [Test]
        public void TestThatAIInitializes()
        {
            Game game = new Game(3);
            AI aiTest = new AI(game, 4);
            Assert.True(aiTest != null);
        }

        [Test]
        public void TestThatAIGetsACard()
        {
            Game game = new Game(3, true);
            game.getCurrPlayer().endTurn();
            game.getCurrPlayer().endTurn();
            game.getCurrPlayer().endTurn();
            Assert.True(game.getCurrPlayer().discardPile.cards.Count == 5 || game.voidDeck.cards.Count == 1);
            //This needs to be looked at again. -JRB
        }



    }
}
