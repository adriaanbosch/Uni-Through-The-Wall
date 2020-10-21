using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    private float objectSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setObstacleSpeed(float newSpeed) {
        this.objectSpeed = newSpeed;
    }

    // FixedUpdate is called at time intervals
    void FixedUpdate()
    {
        // this should cause the ball to move only on the z axis
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - objectSpeed);

        // removes game object from scene once it goes out of bounds on x axis
        if (transform.position.z < -40.0f) {
            Destroy(this.gameObject);
        }
    }
}
