using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployWalls : MonoBehaviour
{
    public GameObject wallBasic1;
    public GameObject wallBasic2;
    public GameObject wallBasic3;
    public GameObject ballObject;
    private int randWall;
    private float respawnTime;
    public int waves;
    public float currentWallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(callSpawnWalls(waves));
    }

    private int spawnWalls(int i, int currentTotalWalls) {
        // control the speed variable
        if (currentTotalWalls == 1) {
            currentWallSpeed = 0.1f;
        } else if (currentTotalWalls % 5 == 0) {
            currentWallSpeed = currentWallSpeed + 0.07f;
        }

        setRespawnTime(Random.Range(1.5f, 4.0f));

        // Spawn wall and obstacle N times where N times is requried to be set;
        if((i%2) == 0)
        {
            // increment walls only when wall is spawned
            currentTotalWalls++;

            randWall = Random.Range(1, 4);

            // adds random walls to the scene and assign speed as each object is instantiated
            if (randWall == 1)
            {
                GameObject a = Instantiate(wallBasic1) as GameObject;
                a.transform.position = new Vector3(-1.193203f, 6.31f, 92f);
                WallScript ws = a.GetComponent<WallScript>();
                ws.setWallSpeed(currentWallSpeed);                          
            }
            else if (randWall == 2)
            {
                GameObject a = Instantiate(wallBasic2) as GameObject;
                a.transform.position = new Vector3(-5.893f, 6.31f, 92f);
                WallScript ws = a.GetComponent<WallScript>();
                ws.setWallSpeed(currentWallSpeed);
            }
            else if (randWall == 3)
            {
                GameObject a = Instantiate(wallBasic3) as GameObject;
                a.transform.position = new Vector3(3.158229f, 6.31f, 92f);
                WallScript ws = a.GetComponent<WallScript>();
                ws.setWallSpeed(currentWallSpeed);
            }
        }
        else
        {
            // adds ball obstacle to the scene in random x location.
            float randomX = Random.Range(-7f, 7f);
            GameObject obstacle = Instantiate(ballObject) as GameObject;
            obstacle.transform.position = new Vector3(randomX, 5f, 90f);
            ObstacleScript os = obstacle.GetComponent<ObstacleScript>();
            os.setObstacleSpeed(currentWallSpeed);
        } 

        return currentTotalWalls;
    }

    private void setRespawnTime(float newTime) {
        this.respawnTime = newTime;
    }

    IEnumerator callSpawnWalls(int wave) {
        // keep track of how many walls
        int currentTotalWalls = 1;
        setRespawnTime(3.0f);

        while (true) {
            for (int i = 2; i < wave + 2; i++)
            {
                yield return new WaitForSeconds(respawnTime);
                Debug.Log(currentTotalWalls);
                currentTotalWalls = spawnWalls(i, currentTotalWalls);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
