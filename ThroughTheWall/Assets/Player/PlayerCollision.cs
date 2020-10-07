using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
	Animator anim;
	public PlayerMovement movement;

	void Start()
	{
		anim = GetComponent<Animator>();
		
	}
	void Update()
	{
		IsDead();
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
	IEnumerator OnCollisionEnter(Collider other)
	{
		// other object is close
		if (other.GetComponent<MeshCollider>().tag == "KillZone")
		{
			this.tag = "dead";
			Debug.Log("character tag set to dead.");
			yield return 0;
		}
		else
		{
			Debug.Log("character tag is left alone.");
			yield return 1;
		}

	}
	void IsDead()
	{ //commented out as its not working
      //if (this.tag == "dead")
      //{
      //	Debug.Log("you dead.");
      //	//Destroy();
      //	//restart or menu
      //}
      //------------------tempt fix here terrible i know
        if (this.transform.position.y < -6)
        {
			Debug.Log("you dead.");

			//back to main menu
				SceneManager.LoadScene(0);
				Time.timeScale = 1;
		}
	}
}
