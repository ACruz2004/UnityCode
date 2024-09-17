using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(1, 300)]
    public float speed = 5.0f;

    [Range(10, 30)]
    public float turnSpeed = 20.0f;
  

    public Rigidbody bulletPrefab;
    public Transform firePosition;

    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shoot();
        

    }

    void Movement() {
        float forwardMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        float turnMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(Vector3.forward * forwardMovement);
        transform.Rotate(Vector3.up * turnMovement);
    }

    void Shoot() {
        if(Input.GetButtonDown("Fire1")) {
            Rigidbody bulletInstance = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation) as Rigidbody;
            bulletInstance.AddForce(firePosition.forward * bulletSpeed);
        }

        if(Input.GetButton("Fire2")) {
            
        }
    }
}
