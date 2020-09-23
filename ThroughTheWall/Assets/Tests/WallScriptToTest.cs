using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScriptToTest : MonoBehaviour
{
    public int wallNo;
    public int wallDifficulty;
    public bool breakablePart;
    public float wallSpeed;
    private Rigidbody rb;
    private float screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        wallSpeed = 0.1f;
        rb = this.GetComponent<Rigidbody>();
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        screenBounds = -30.0f;
    }

    // Update is called once per frame
    void Update()
    {// this should cause the wall to move only on the x axis
        transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z - wallSpeed);

        // removes game object from scene once it goes out of bounds on z axis
        if (transform.position.z < screenBounds) {
            Destroy(this.gameObject);
        }
    }
}
