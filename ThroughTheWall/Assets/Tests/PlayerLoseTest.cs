using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerLoseTest : MonoBehaviour
    {

        [Test]
        public void PlayerCreation()
        {
            GameObject player = null;
            player = CreatePlayer();

            Assert.IsNotNull(player); //to is not null
            Object.Destroy(player);
        }
        [UnityTest]
        public IEnumerator PlayerLoses()
        {
            GameObject player = null;
            player = CreatePlayer();
            player.transform.position = new Vector3(1f, -1f, 1f);

            for(int i =0; i < 10; i++)
            {
                float yValue = -1.0f;
                player.transform.position = new Vector3(1f, yValue, 1f);
                yield return null;
                yValue -= -1.0f;
            }

            Assert.IsNull(player); //to is not null
        }

        public GameObject CreatePlayer()
        {
            GameObject Player1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Player1.AddComponent<PlayerCollisionScriptToTest>();
            
            return Player1;
        }
    }
}
