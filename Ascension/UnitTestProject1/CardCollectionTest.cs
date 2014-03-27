using System;
using Ascension;
using NUnit.Framework;

namespace AscensionTest
{
    [TestFixture()]
    public class CardCollectionTest
    {
        [Test()]
        public void testEmptyCC()
        {
            var target = new CardCollection();
            Assert.AreEqual(target.length, 0);
        }

        
    }
}