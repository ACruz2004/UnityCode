using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunButton : MonoBehaviour
{
    bool flip;
    public GameObject ground;
    public float turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flip) 
        {
            ground.transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            flip = true;
        }
    }
}
