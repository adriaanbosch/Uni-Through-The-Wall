using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanPoint : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {
        // Spwan obstacle into the game
        Instantiate(obstacle, spawnPos.position, spawnPos.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
