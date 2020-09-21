using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public int wallNo;
    public int wallDifficulty;
    public bool breakablePart;
    public float wallSpeed;
    public float current_speed; // this was added to keep a record of speed as it will increase. This is needed because I need to set wallSpeed to 0 for pause, Dhanan
    // Start is called before the first frame update
    void Start()
    {
        wallSpeed = 0.1f;
        current_speed = wallSpeed;
    }

    // Update is called once per frame
    void Update()
    {// this should cause the wall to move only on the x axis
        transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z - wallSpeed);

        if(Time.timeScale == 0) // this was added to stop the wall when game is paused, Dhanan
        {
            wallSpeed = 0;
        }
        else
        {
            wallSpeed = current_speed;
        }
    }
}
