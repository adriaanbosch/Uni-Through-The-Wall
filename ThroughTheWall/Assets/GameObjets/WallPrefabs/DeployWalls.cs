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

    private void spawnWalls(int wave) {

        // Spawn wall and obstacle N times where N times is requried to be set;
        if((wave%2) == 0)
        {
            randWall = Random.Range(1, 4);

            // adds random walls to the scene
            if (randWall == 1)
            {
                GameObject a = Instantiate(wallBasic1) as GameObject;
                a.transform.position = new Vector3(-5.5f, 5f, 90f);
            }
            else if (randWall == 2)
            {
                GameObject a = Instantiate(wallBasic2) as GameObject;
                a.transform.position = new Vector3(-2.5f, 5f, 90f);
            }
            else if (randWall == 3)
            {
                GameObject a = Instantiate(wallBasic3) as GameObject;
                a.transform.position = new Vector3(0.0f, 7.5f, 90f);
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
            for (int i = 2; i < wave + 2; i++)
            {
                yield return new WaitForSeconds(respawnTime);
                spawnWalls(i);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
