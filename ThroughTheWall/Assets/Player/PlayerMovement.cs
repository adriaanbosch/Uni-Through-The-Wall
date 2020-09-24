using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
	float speed = 10f;
	float jumpForce = 8f;
	float gravity = 12f;
	float rotSpeed = 100f;
	float rot = 0f;
    float pickupRange = 2;
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
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = Vector3.ClampMagnitude(moveDir, 1);
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;

            if (Input.GetButtonDown("Vertical"))
            {
                anim.SetInteger("condition", 1);
            }

            if (Input.GetButtonDown("Jump"))
            {
                anim.SetInteger("condition", 2);
                moveDir.y = jumpForce;
            }

            if (Input.GetButtonUp("Vertical") || Input.GetButtonUp("Jump"))
            {
                anim.SetInteger("condition", 0);
            }
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }
    
    void ArmControl()
    {
        if (Input.GetAxis("Mouse Y") > 0)
        {
            print("Mouse moved up");
            //something something animation
        }
        if (Input.GetAxis("Mouse Y") < 0)
        {
            print("Mouse moved down");
            //something something animation	
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed primary button.");
            GrabObject();
        }


    }
    GameObject GetObjectMouseHover()// raycasts to find what opject is infront of the player
    {
        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + gameObject.transform.forward * pickupRange;
        if (Physics.Linecast(position, target, out raycastHit))
        {
            return raycastHit.collider.gameObject;
        }
        return null;
    }
    void GrabObject() // uses the fixed joint attached to the character to connect / grab objects // not fully working yet
    {
        GameObject objects = GetObjectMouseHover();
        gameObject.GetComponent<FixedJoint>().connectedBody = objects.GetComponent<Rigidbody>();
        Debug.Log("fixed joint should be connected");
    }
}
