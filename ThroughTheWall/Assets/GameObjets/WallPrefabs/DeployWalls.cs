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
    public float respawnTime = 10.0f;
    public int waves;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(callSpawnWalls(waves));
    }

    private void spawnWalls(int wave, int currentTotalWaves) {

        // Spawn wall and obstacle N times where N times is requried to be set;
        if((wave%2) == 0)
        {
            // randWall = Random.Range(1, 4);
            randWall = 1;

            // adds random walls to the scene
            if (randWall == 1)
            {
                GameObject a = Instantiate(wallBasic1) as GameObject;
                a.transform.position = new Vector3(-1.193203f, 6.31f, 92f); 
                if (currentTotalWaves % 3 == 0) {
                    WallScript scriptForWalls = a.GetComponent<WallScript>();
                    scriptForWalls.wallSpeed = 1.5f;
                }               
            }
            else if (randWall == 2)
            {
                GameObject a = Instantiate(wallBasic2) as GameObject;
                a.transform.position = new Vector3(-5.893f, 6.31f, 92f);
            }
            else if (randWall == 3)
            {
                GameObject a = Instantiate(wallBasic3) as GameObject;
                a.transform.position = new Vector3(3.158229f, 6.31f, 92f);
            }
        }
        else
        {
            // adds ball obstacle to the scene in random x location.
            float randomX = Random.Range(-7f, 7f);
            GameObject obstacle = Instantiate(ballObject) as GameObject;
            obstacle.transform.position = new Vector3(randomX, 5f, 90f);
        } 
    }

    IEnumerator callSpawnWalls(int wave) {
        // Delay between object spawn
        while (true) {
            int currentTotalWaves = 1;
            for (int i = 2; i < wave + 2; i++)
            {
                yield return new WaitForSeconds(respawnTime);
                spawnWalls(i, currentTotalWaves);
                currentTotalWaves++;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
