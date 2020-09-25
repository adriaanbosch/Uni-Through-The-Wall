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
        [Test]
        public void PlayerLoses()
        {
            GameObject player = null;
            player = CreatePlayer();
            player.transform.position = new Vector3(1f, -10f, 1f);

            if (player.transform.position.y < -6f)
            {
                player = null;
            }

            Assert.IsNull(player);
        }

        public GameObject CreatePlayer()
        {
            GameObject Player1 = GameObject.CreatePrimitive(PrimitiveType.Cube);

            return Player1;
        }
    }
}
