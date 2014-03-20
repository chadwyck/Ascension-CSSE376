using System;
using Ascension;
using NUnit.Framework;

namespace AscensionTest
{
    [TestFixture()]
    public class GameTest
    {
        private readonly int TestGameInt = 5;
        [Test()]
        public void TestThatGameInitializes()
        {
            var target = new Game(TestGameInt);
            Assert.IsNotNull(target);
        }
    }
}
