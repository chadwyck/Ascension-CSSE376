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
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNoInput()
        {
            var target = new Game();
            
        }
        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInvalidInput()
        {
            var target = new Game(10);
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


    }
}
