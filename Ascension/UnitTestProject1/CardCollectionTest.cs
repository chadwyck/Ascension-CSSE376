﻿using System;
using Ascension;
using NUnit.Framework;

namespace AscensionTest
{
    [TestFixture()]
    public class CardCollectionTest
    {
        private Game testGame = new Game(2);
        Card voidthirster;
        Card demonSlayer;
        Card samaelsTrickster;

        [SetUp()]
        public void setup()
        {
             voidthirster = new Card(testGame, "Voidthirster", null, 5, 0, 0, 1, 3, 1, 0, "void", "construct");
             demonSlayer = new Card(testGame, "Demon Slayer", null, 4, 0, 0, 3, 2, 0, 0, "void", "hero");
             samaelsTrickster = new Card(testGame, "Samael's Trickster", null, 0, 3, 1, 0, 0, 1, 0, "fallen", "monster");
        }
        [Test()]
        public void testEmptyCC()
        {
            var target = new CardCollection();
            Assert.AreEqual(target.length, 0);
        }
        [Test()]
        public void testAddRemoveCardCC()
        {
            var cc = new CardCollection();
            cc.add(voidthirster);
            Assert.AreEqual(cc.length, 1);
            cc.add(demonSlayer);
            Assert.AreEqual(cc.getCard(0), voidthirster);
            Assert.AreEqual(cc.length, 2);
            cc.remove(voidthirster);
            Assert.AreEqual(cc.getCard(0), demonSlayer);
            cc.remove(demonSlayer);
            Assert.AreEqual(cc.length, 0);
        }
        [Test()]
        public void testShuffleable()
        {
            var pd = new PortalDeck(); // subclass of Shuffleable
            pd.add(voidthirster);
            pd.add(demonSlayer);
            Assert.AreEqual(pd.length, 2);
            Assert.AreEqual(pd.getCard(0), voidthirster);
            Card drawn = pd.draw();
            Assert.AreEqual(drawn, voidthirster);
            Assert.AreEqual(pd.length, 1);
            Card drawn2 = pd.draw();
            Assert.AreEqual(drawn2, demonSlayer);
            Assert.AreEqual(pd.length, 0);
        }
    }
}