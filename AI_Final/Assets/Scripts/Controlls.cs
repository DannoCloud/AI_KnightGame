using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlls : MonoBehaviour
{

    public Transform Player;
  
 

    //anim = GetComponent<Animator>(); 

    public float speed = 3f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
       
    }

    void Update()
    {
        
        if (controller.isGrounded)
        {
   

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;


            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }

            if (Input.GetButton("Run"))
            {
                moveDirection = moveDirection * (speed/1.5f);
            }
        }



        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }





}
