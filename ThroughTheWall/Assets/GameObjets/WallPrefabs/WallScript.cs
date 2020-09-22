using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public int wallNo;
    public int wallDifficulty;
    public bool breakablePart;
    public float wallSpeed;
    // Start is called before the first frame update
    void Start()
    {
        wallSpeed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {// this should cause the wall to move only on the x axis
        transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z - wallSpeed);
    }
}
