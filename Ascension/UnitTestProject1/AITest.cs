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




    }
}
