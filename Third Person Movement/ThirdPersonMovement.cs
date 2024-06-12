using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 8f;
    //Making the turn smoother
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;



    // For checking contact with the ground
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    //Gravity
    Vector3 velocity;
    bool isGrounded;

    //For Sprinting
    bool isSprinting = true;
    public float gravity = -9.81f;

    public float jumpHeight = 3f;

    // Locking the cursor
    void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

 // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        speed = 8f;
        isSprinting = false;

        if (isGrounded && velocity.y < 0) 
        {
            velocity.y = -2f;
            // Sprint Function
            // If The player is already in the air but not sprinting, they can't sprint
            if (Input.GetKey("left shift")) 
            {
                speed = speed * 2f;
                isSprinting = true;
            } 
        
        } else {
            // Sprint Function
            // If The player is already in the air but not sprinting, they can't sprint
            if (Input.GetKey("left shift") && isSprinting == true) 
            {
                speed = speed * 1.5f;
                isSprinting = true;

            } else if (Input.GetKey("left shift") && isSprinting == false) {
                speed = speed * 1.25f;
                isSprinting = false;
            }
        
        }
        
        
       

        // Horizontal
        float horizontal = Input.GetAxisRaw("Horizontal");
        // Vertical
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f) 
        {
            //Atan2 is a mathematical sequence that returns the angle between the x axis and a vector starting at zero and starting at x,y
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection * speed * Time.deltaTime);

            
        }

        //Jumping

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            if (isSprinting = true) 
            {
                speed = speed * 1.5f;
            }

        }

        //For Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        
    }
}
