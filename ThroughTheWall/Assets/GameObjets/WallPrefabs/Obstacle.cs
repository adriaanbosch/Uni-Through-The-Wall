using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject newObstacle;

    void Start()
    {
        obstacleWave();
    }

    public void spawn()
    {
        GameObject obsacles = GameObject.Instantiate(newObstacle, spawnPos.position, spawnPos.rotation) as GameObject;
    }

    public void obstacleWave()
    {
        spawn();
    }
}
