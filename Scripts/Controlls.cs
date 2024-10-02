using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Numerics;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Controlls : MonoBehaviour
{
    Animator spriteRenderer;
    Animator animator;
    public InputAction movement;
    public float moveSpeed;
    UnityEngine.Vector3 pos; 
    Rigidbody2D doggo;
    public Text beppaCount;
    public int coinCount = 0;



    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<Animator>();

        animator = GetComponent<Animator>();

        doggo = GetComponent<Rigidbody2D>();

        movement.Enable();

        moveSpeed += 100;
    }

    void Update() {
        beppaCount.text = coinCount.ToString();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        beppaCount.text = coinCount.ToString();

        var moveDirection = movement.ReadValue<UnityEngine.Vector2>();
        float x = moveDirection.x * moveSpeed * Time.deltaTime;
        float y = moveDirection.y * moveSpeed * Time.deltaTime;
        pos = new UnityEngine.Vector3(x, y, 0);   

        animator.SetFloat("Horizontal", x);
        animator.SetFloat("Vertical", y);
        
        // Blend tree 
        animator.SetFloat("X", x);
        animator.SetFloat("Y", y);

        doggo.velocity = pos;
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Beppa") {
            ++coinCount;
            other.gameObject.SetActive(false);
        }
    }
}
