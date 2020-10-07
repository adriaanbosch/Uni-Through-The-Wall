using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float lifeTime = 10f;

    // Update is called once per frame
    void Update()
    {
        if(lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
            if(lifeTime <= 0)
            {
                Destruction();
            }
        }
    }

    // Collision will destroy object
    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.name == "Destroyer")
        {
            Destruction();
        }
    }

    // Desturction methed
    void Destruction()
    {
        Destroy(this.gameObject);
    }
}
