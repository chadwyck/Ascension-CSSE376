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
        public void setup()
        {
            testgame = new Game(2);
            CardImport im = new CardImport(testgame);
           deck = im.deck;
            
        }
        [Test()]
        public void testImport()
        {
           
            testgame.advanceTurn();
            deck.draw().playCard();
            Assert.AreEqual(testgame.getCurrPlayer().currentPower, 0);
            deck.draw().playCard();
            Assert.AreEqual(testgame.getCurrPlayer().currentRunes, 0);
        }

    }
}
