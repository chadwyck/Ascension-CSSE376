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
    class CardImportTest
    {
        
        
        PortalDeck deck;
        Game testgame;
        [SetUp()]
        public void Setup()
        {

            testgame = new Game(2, false, true);
            CardImport im = new CardImport(testgame, "\\Portal\\");

            im.cardImportP(testgame, "\\Portal\\", deck);

            
        }
        [Test()]
        public void TestImport()
        {
           
            testgame.advanceTurn();
            deck.draw().playCard();
            Assert.AreEqual(testgame.getCurrPlayer().currentPower, 0);
            deck.draw().playCard();
            Assert.AreEqual(testgame.getCurrPlayer().currentRunes, 0);
        }

    }
}
