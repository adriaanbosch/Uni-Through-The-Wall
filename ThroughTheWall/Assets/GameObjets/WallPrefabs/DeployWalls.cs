using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployWalls : MonoBehaviour
{
    public GameObject wallBasic1;
    public GameObject wallBasic2;
    public GameObject wallBasic3;
    private int i;
    public float respawnTime = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(callSpawnWalls());
    }

    private void spawnWalls() {
        i = Random.Range(1, 4);
    
        // adds prefab to scene
        if (i == 1) {
            GameObject a = Instantiate(wallBasic1) as GameObject;
            a.transform.position = new Vector3(-5.5f, 5f, 115.4f);
        } else if (i == 2) {
            GameObject a = Instantiate(wallBasic2) as GameObject;
            a.transform.position = new Vector3(-2.5f, 5f, 115.4f);
        } else if (i == 3) {
            GameObject a = Instantiate(wallBasic3) as GameObject;
            a.transform.position = new Vector3(0.0f, 7.5f, 115.4f);
        }
        
    }

    IEnumerator callSpawnWalls() {
        while(true) {
            yield return new WaitForSeconds(respawnTime);
            spawnWalls();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
