using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class WallTesting : MonoBehaviour
    {
        public GameObject wallBasic1;
        public GameObject wallBasic2;
        public GameObject wallBasic3;

        // A Test behaves as an ordinary method
        [Test]
        public void CreateWallTesting()
        {
            GameObject wall = null;

            wall = CreateWall();

            Assert.IsNotNull(wall);

            Object.Destroy(wall);
        }

        [UnityTest]
        public IEnumerator WallsMoveForwards()
        {
            // Create an instance of the game
            GameObject wall = CreateWall();
            float initialZPos = wall.transform.position.z;

            // need a yield return value because it is a coroutine and wait for 0.5 seconds to simulate passage of time
            yield return new WaitForSeconds(0.5f);

            // assert new position is less than original position
            Assert.Less(wall.transform.position.z, initialZPos);

            // destroy game object
            Object.Destroy(wall);
        }

        [UnityTest]
        public IEnumerator WallIsDestroyed() 
        {
            GameObject wall = CreateWall();

            //update the position
            yield return new WaitForSeconds(60.0f);

            // asset the game object has been deleted
            Assert.IsTrue(wall == null);

            // destroy game object
            Object.Destroy(wall);
        }

        public GameObject CreateWall() 
        {
            GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wall.AddComponent<WallScriptToTest>();
            wall.transform.position = new Vector3(-5.5f, 5f, 115.4f);

            return wall;
        }
    }
}
