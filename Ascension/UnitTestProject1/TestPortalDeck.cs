using System;
using Ascension;
using NUnit.Framework;

namespace AscensionTest
{
    [TestFixture()]
    public class TestPortalDeck : Shuffleable
    {

        [Test()]
        public void testPortalNotNull()
        {
            var target = new PortalDeck();
            Assert.NotNull(target);
         }


        [Test()]
        public void testDrawCard()
        {
            var target = new PortalDeck();
            Game game = new Game(2);
            Card card = new Card(game, "Apprentice", null, 0, 0, 1, 0, 0, 0, 0, null, "basic");
            target.add(card);
            //Assert.AreEqual(target.cards.Count, 1);
            Assert.AreEqual(target.draw().cardName, card.cardName);
        }
      





    }
}
