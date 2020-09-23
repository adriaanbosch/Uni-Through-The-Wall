using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	Animator anim;
	public PlayerMovement movement;

	void Start()
	{
		anim = GetComponent<Animator>();
		
	}

	IEnumerator OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "Obstacle")
		{
			Debug.Log("test");
			anim.SetInteger("condition", 3);
			movement.enabled = false;
			yield return new WaitForSeconds(2);
			movement.enabled = true;
		}
	}

}
