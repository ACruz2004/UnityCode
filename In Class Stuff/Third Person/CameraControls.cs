using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public bool test;
    public Transform target;
    // Start is called before the first frame update
    static public bool staticTest;
    void Start()
    {
        test = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);

        if(staticTest) {
            Debug.Log("Test is true");
            test = true;
        }
        if(!staticTest) {
            Debug.Log("Test is true");
            test = false;
        }
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y + 25, target.position.z - 25);
    }
}
