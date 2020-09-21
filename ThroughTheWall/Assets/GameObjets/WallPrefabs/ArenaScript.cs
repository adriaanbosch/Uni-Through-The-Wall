using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ArenaScript : MonoBehaviour
{
    //
    //
    // i recommend ignoring this script file, it does have some use not it doesnt work right yet
    //
    //


    // Start is called before the first frame update
    public GameObject ArenaGameObject;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    int wallNumber;
    int wallLimit; // number of spawned walls at any one point in time
    void Start()
    {
        wallNumber = 0;
        wallLimit = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Wall").Length < wallLimit)
        {
            SpawnWall();
        }
    }
    void SpawnWall()
    {
        GameObject wall = PrefabUtility.InstantiatePrefab(wall3) as GameObject;
        wall.transform.position = ArenaGameObject.transform.position;
        waitSeconds();


        //wall.transform.position = gridPositions[col, row];
        //wall.transform.localScale = new Vector3(cellSize, cellSize, cellSize);
        //wall.name = col.ToString() + "," + row.ToString();
        //wall.transform.parent = t.transform;

    }
    
    IEnumerable waitSeconds()
    {
        yield return new WaitForSeconds(5);

    }
}
