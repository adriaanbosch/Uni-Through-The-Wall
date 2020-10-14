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
	//back to main menu
	void IsDead()
	{ 
        if (this.transform.position.y < -6)
        {
			
				SceneManager.LoadScene(0);
				Time.timeScale = 1;
		}
	}
}
