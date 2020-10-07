using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Destroyer : MonoBehaviour
{
    public float lifeTime = 10f;
    public AudioSource collisionSource;

    private void Start()
    {
        collisionSource = GetComponent<AudioSource>();        
    }

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
            collisionSource.Play();

            Destruction();
        }
    }

    // Desturction methed
    void Destruction()
    {
        Destroy(this.gameObject);
    }
}
