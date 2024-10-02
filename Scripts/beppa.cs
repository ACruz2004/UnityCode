using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class beppa : MonoBehaviour
{
    [SerializeField]
    private Text beppaCount;
    private bool closeEnough;
    private int coinCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (closeEnough) {
            pickUp();
        }
        beppaCount.text = coinCount.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name.Equals("Doggo")) {
            closeEnough = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.name.Equals("Doggo")) {
            closeEnough = false;
        }
    }

    void pickUp() {
        Destroy(gameObject);
    }
}
