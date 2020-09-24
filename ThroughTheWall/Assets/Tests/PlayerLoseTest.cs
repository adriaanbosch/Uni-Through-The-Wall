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
            player = CreatePlayer(player);

            Assert.IsNull(player); //to is not null
            Object.Destroy(player);
        }
        [Test]
        public void PlayerLoses()
        {
            GameObject player = null;
            player = CreatePlayer(player);
            player.transform.position = new Vector3(1f, 1f, 1f);
            if (player.transform.position.y < -6)
            {

            }
            player.transform.position = new Vector3(1f, -10f, 1f);

        }

        public GameObject CreatePlayer(GameObject player)
        {
            GameObject Playerl = GameObject.CreatePrimitive(PrimitiveType.Cube);
            player.AddComponent<PlayerCollisionScriptToTest>();
            

            return player;
        }
    }
}
