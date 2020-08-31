using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
	float speed = 10;
	float rotSpeed = 120;
	float rot = 0f;
	float gravity = 8;

	Vector3 moveDir = Vector3.zero;


	CharacterController controller;
	Animator anim;




	// Start is called before the first frame update
	void Start()
	{
		controller = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
	}


	// Update is called once per frame
	void Update()
	{
		Movement();
	}

	void Movement()
	{
		if (controller.isGrounded)
		{


			if (Input.GetKey(KeyCode.W))
			{
				anim.SetInteger("condition", 1);
				moveDir = new Vector3(0, 0, 1);
				moveDir *= speed;
				moveDir = transform.TransformDirection(moveDir);
			}

			if (Input.GetKeyUp(KeyCode.W))
			{
				anim.SetInteger("condition", 0);
				moveDir = new Vector3(0, 0, 0);
			}

			if (Input.GetKey(KeyCode.Space))
            {
				anim.SetInteger("condition", 1);
				moveDir = new Vector3(0, 1, 1);
				moveDir *= speed;
				moveDir = transform.TransformDirection(moveDir);
			}

			if (Input.GetKeyUp(KeyCode.Space))
			{
				anim.SetInteger("condition", 0);
				moveDir = new Vector3(0, 0, 0);
			}
		}

		rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
		transform.eulerAngles = new Vector3(0, rot, 0);

		moveDir.y -= gravity * Time.deltaTime;
		controller.Move(moveDir * Time.deltaTime);
	}
}
