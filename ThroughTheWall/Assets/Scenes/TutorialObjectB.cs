using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObjectB : MonoBehaviour
{
    public float speed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -109)
        {
            speed = 50f;
        }

        if (transform.position.x >= -9)
        {
            speed = -50f;
        }

        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
