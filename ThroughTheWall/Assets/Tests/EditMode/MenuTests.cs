using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MenuTests
    {
        // A Test behaves as an ordinary method
        public GameObject GoToTutorial()
        {
            GameObject button = GameObject.CreatePrimitive(PrimitiveType.Cube);
            button.AddComponent<Main_Menu>();

            return button;
        }
    
        [Test]
        public void GoToTutorialTest()
        {
            GameObject button = null;

            button = GoToTutorial();

            Assert.IsNotNull(button);
        }

    }
}
