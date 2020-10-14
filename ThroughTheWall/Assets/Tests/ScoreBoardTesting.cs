using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ScoreBoardTesting
    {
        // A Test behaves as an ordinary method
        [Test]
        public void ScoreBoardTestingSimplePasses()
        {
            // Use the Assert class to test conditions            
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator ScoreBoardTestingWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            GameObject score = new Timer();
            float initialScore = score.getSecondsCount();
    
            // Use yield to skip a frame.
            yield return new WaitForSeconds(0.5f);

            Assert.More(score.getSecondsCount(), initialScore);
        }
    }
}
