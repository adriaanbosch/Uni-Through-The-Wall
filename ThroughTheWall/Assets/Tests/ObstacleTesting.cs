using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ObstacleTesting
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CreateObstacleTesting()
        {
            GameObject obstacle = CreateObstacle(1);

            Assert.IsNotNull(GameObject.Find("Sphere"));
        }

        [Test]
        public void ResizeObstacle()
        {
            var randomSize = Random.Range(1, 6);
            GameObject obstacle = CreateObstacle(randomSize);

            Vector3 check = new Vector3(randomSize, randomSize, randomSize);

            Assert.AreEqual(check, obstacle.transform.localScale);
        }

        [Test]
        public void ObstacleMovement()
        {
            var randomSize = Random.Range(1, 6);
            GameObject obstacle = CreateObstacle(randomSize);

            
        }

        public GameObject CreateObstacle(int size)
        {
            GameObject obstacle = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            obstacle.AddComponent<Rigidbody>();

            obstacle.transform.localScale = new Vector3(size, size, size);

            return obstacle;
        }
    }
}
