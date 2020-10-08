using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public float objectSpeed;
    // Start is called before the first frame update
    void Start()
    {
        objectSpeed = 0.1f;
    }

    // FixedUpdate is called at time intervals
    void FixedUpdate()
    {
        // this should cause the wall to move only on the x axis
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - objectSpeed);
    }
}
