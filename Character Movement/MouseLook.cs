using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// OLD CODE, WILL BE REVISED IN FUTURE
public class MouseLook : MonoBehaviour
{
    //Code for changing the sensitivity
    //This will be coded to be changed in game as well

    public float sensitivity = 100f;

    //This will be for actually rotating the characters
    public Transform playerBody;
    
    // xRotation has errors on rotate, does not work with unity build.
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Hiding and locking cursor to screen 
        //IMPORTANT
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
    //This is code for making the camera move depending on mouse location
    //Use float and the .GetAxis operator 

        //For X
        //Make sure you rotate dependednt on the frame rate
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        //For Y
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        //For moving Y
        xRotation -= mouseY;

        //Clamping so head doesn't just continue turning on Y axis into body
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        //Quaternions are used for rotation in Unity
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //Player Body Movement Code
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
