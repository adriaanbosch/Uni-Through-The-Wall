using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour

{
	float speed = 10f;
	float jumpForce = 8f;
	float gravity = 12f;
	float rotSpeed = 100f;
	float rot = 0f;
    float pickupRange = 2;
    GameObject[] grabbableObjects;
    Vector3 moveDir = Vector3.zero;

	CharacterController controller;
	Animator anim;
    GameObject rightHand;
    GameObject itemGrabbed;

    // Start is called before the first frame update
    void Start()
	{
		controller = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
        rightHand = GameObject.FindGameObjectWithTag("PickupBone");
    }

	// Update is called once per frame
	void Update()
	{
        Movement();
        ArmControl();
        HeldItem();

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
            //something something animation
        }
        if (Input.GetAxis("Mouse Y") < 0)
        {
            //something something animation	
        }
        if (Input.GetMouseButtonDown(0))
        {
            GrabObject();
        }
    }
    void HeldItem()
    {
        if (itemGrabbed != null)
        {
            itemGrabbed.transform.position = rightHand.transform.position;
        }
    }
    // this method checks if an item is already being held, if so drop it, it not find all pickup'able objects and try pick them up
    void GrabObject()
    {
        if (itemGrabbed != null)
        {
            itemGrabbed.transform.parent = null;
            itemGrabbed = null;
        }
        else
        {
            grabbableObjects = GameObject.FindGameObjectsWithTag("Item");
            if (grabbableObjects.Length != 0)
            {
                foreach (GameObject grabbableObject in grabbableObjects)
                {
                    IsItemInPickupRange(grabbableObject);
                }
            }
        } 
    }
    //this method will check if the item is close enough to the player to be picked up, if so pick it up
    void IsItemInPickupRange(GameObject grabbableObject)
    {
        float dist = Vector3.Distance(grabbableObject.transform.position, rightHand.transform.position);
        if (dist <= 2 && dist >= 0)
        {
            itemGrabbed = grabbableObject;
            itemGrabbed.transform.parent = rightHand.transform;
        }
    }
}
